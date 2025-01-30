import { Component, Injector } from '@angular/core';
import { BsModalRef, BsModalService } from '@node_modules/ngx-bootstrap/modal';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { PagedListingComponentBase, PagedRequestDto } from '@shared/paged-listing-component-base';
import { TaskItemDto, TaskItemDtoPagedResultDto, TaskItemServiceProxy } from '@shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';
import { CreateTasksDialogComponent } from './create-tasks/create-tasks-dialog.component';
import { EditTasksDialogComponent } from './edit-tasks/edit-tasks-dialog.component';


class PagedTasksRequestDto extends PagedRequestDto {
  keyword: string;
}


@Component({
  selector: 'app-tasks',

  templateUrl: './tasks.component.html',
    animations: [appModuleAnimation()],
  styleUrls: ['./tasks.component.css']
})
export class TasksComponent extends PagedListingComponentBase<TaskItemDto> {
  tasks: TaskItemDto[] = [];
  keyword = '';
  isActive: boolean | null;
  advancedFiltersVisible = false;

  constructor(
    injector: Injector,
    private _taskService: TaskItemServiceProxy,
    private _modalService: BsModalService
  ) {
    super(injector);
  }

  createTask(): void {
    this.showCreateOrEditTaskDialog();
  }

  editTask(task: TaskItemDto): void {
    this.showCreateOrEditTaskDialog(task.id);
  }



  clearFilters(): void {
    this.keyword = '';
    this.isActive = undefined;
    this.getDataPage(1);
  }

  protected list(
    request: PagedTasksRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;

    this._taskService
      .getAll(
        request.keyword,
        request.skipCount,
        request.maxResultCount
      )
      .pipe(
        finalize(() => {
          finishedCallback();
        })
      )
      .subscribe((result: TaskItemDtoPagedResultDto) => {
        this.tasks = result.items;
        this.showPaging(result, pageNumber);
      });
  }

  protected delete(task: TaskItemDto): void {
    abp.message.confirm(
      this.l('TaskDeleteWarningMessage', task.title),
      undefined,
      (result: boolean) => {
        if (result) {
          this._taskService.delete(task.id).subscribe(() => {
            abp.notify.success(this.l('SuccessfullyDeleted'));
            this.refresh();
          });
        }
      }
    );
  }

 

  private showCreateOrEditTaskDialog(id?: string): void {
    let createOrEditTaskDialog: BsModalRef;
    if (!id) {
      createOrEditTaskDialog = this._modalService.show(
        CreateTasksDialogComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditTaskDialog = this._modalService.show(
        EditTasksDialogComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditTaskDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }
}

