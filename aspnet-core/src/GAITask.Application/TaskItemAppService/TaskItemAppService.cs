using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Linq.Extensions;
using Abp.ObjectMapping;
using Abp.Runtime.Session;
using AutoMapper.Internal.Mappers;
using GAITask.Authorization.Roles;
using GAITask.ProjectEntities;
using GAITask.TaskItemAppService.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAITask.TaskItemAppService
{
    [AbpAuthorize]
    public class TaskItemAppService : AsyncCrudAppService<TaskItem, TaskItemDto, Guid, PagedTaskItemResultRequestDto, CreateTaskItemDto, TaskItemDto>
    {



        IRepository<ProjectEntities.TaskStatus, long> _taskStatusRepository;
        private readonly IAbpSession _abpSession;
        IRepository<TaskItem, Guid> _repository;
        public TaskItemAppService(IRepository<TaskItem, Guid> repository,IAbpSession abpSession, IRepository<ProjectEntities.TaskStatus, long> taskStatusRepository) : base(repository)
        {

            _abpSession = abpSession;
            _taskStatusRepository = taskStatusRepository;
            _repository = repository;

        }

        public override async Task<PagedResultDto<TaskItemDto>> GetAllAsync(PagedTaskItemResultRequestDto input)
        {
            try
            {

               

                var isItAdmin = await PermissionChecker.IsGrantedAsync("AdminOnly");

                var query = _repository.GetAllIncluding(x => x.AssignedTo, x => x.TaskStatus)
                    .Where(x=> (!isItAdmin && (x.AssignedToId == _abpSession.UserId)) || isItAdmin)
                    .WhereIf(
                    
                    !string.IsNullOrWhiteSpace(input.Keyword),
                        x => x.Title.Contains(input.Keyword) || x.Description.Contains(input.Keyword)  ) // Apply search filter
                    .Select(x => new TaskItem
                    {
                        Id = x.Id,
                        Title = x.Title,
                        Description = x.Description,
                        TaskStatus = x.TaskStatus,
                        TaskStatusId = x.TaskStatusId,
                        AssignedTo = x.AssignedTo,
                        Comment = x.Comment,
                        CreationTime = x.CreationTime,
                        CreatorUserId = x.CreatorUserId,
                    });

                var totalCount = await query.CountAsync();

                // Apply pagination
                var paginatedResult = await query.PageBy(input).ToListAsync();

                return new PagedResultDto<TaskItemDto>(totalCount, ObjectMapper.Map<List<TaskItemDto>>(paginatedResult));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [AbpAuthorize("AdminOnly")]

        public override Task<TaskItemDto> CreateAsync(CreateTaskItemDto input)
        {
            return base.CreateAsync(input);
        }

        [AbpAuthorize("AdminOnly")]
        public override Task DeleteAsync(EntityDto<Guid> input)
        {
            return base.DeleteAsync(input);
        }


        public async Task<List<TaskStatusDto>> GetAllTaskStatusesAsync()
        {

            try
            {
                var result = await _taskStatusRepository.GetAllListAsync();
                return ObjectMapper.Map<List<TaskStatusDto>>(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override async Task<TaskItemDto> UpdateAsync(TaskItemDto input)
        {
            var userId = AbpSession.UserId ?? throw new AbpAuthorizationException("User not logged in.");
            var hasAdminPermission = await PermissionChecker.IsGrantedAsync("AdminOnly");

            // Get the existing task from the database
            var task = await Repository.GetAsync(input.Id);

            if (!hasAdminPermission)
            {
                // Regular users can only update TaskStatusId
                task.TaskStatusId = input.TaskStatusId;
                await Repository.UpdateAsync(task);
                return MapToEntityDto(task);
            }

            // Admins can update everything
            return await base.UpdateAsync(input);
        }
    }
}
