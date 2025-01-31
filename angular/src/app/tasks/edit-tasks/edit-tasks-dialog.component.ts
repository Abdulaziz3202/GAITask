import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { BsModalRef } from '@node_modules/ngx-bootstrap/modal';
import { AppComponentBase } from '@shared/app-component-base';
import { TaskItemDto, TaskItemServiceProxy, TaskStatusDto, UserDto, UserServiceProxy } from '@shared/service-proxies/service-proxies';

@Component({
  selector: 'app-edit-tasks-dialog',
  templateUrl: './edit-tasks-dialog.component.html',
  styleUrls: ['./edit-tasks-dialog.component.css']
})
export class EditTasksDialogComponent extends AppComponentBase
  implements OnInit {
    saving = false;
      taskItem = new TaskItemDto();
    usersList: UserDto[]=[];
    statusesList: TaskStatusDto[]=[];
    allowedToUpdateAllFields:boolean=false;
      checkedRolesMap: { [key: string]: boolean } = {};
      id: string;
    
      @Output() onSave = new EventEmitter<any>();
    
      constructor(
        injector: Injector,
        public _taskService: TaskItemServiceProxy,
            private _usersService: UserServiceProxy,
        public bsModalRef: BsModalRef
      ) {
        super(injector);
      }
    
      ngOnInit(): void {
        this._taskService.get(this.id).subscribe((result) => {
          this.taskItem = result;
        });
        if(this.allowedToUpdateAllFields){
          this.getAllUsers();
        }
        
    
        this.getAllTaskStatuses();

      }
    
     
    
    
      save(): void {
        this.saving = true;
    
    
        this._taskService.update(this.taskItem).subscribe(
          () => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.bsModalRef.hide();
            this.onSave.emit();
          },
          () => {
            this.saving = false;
          }
        );
      }
      getAllUsers() {

        this._usersService.getAllUsers().subscribe((result: UserDto[]) => {
          this.usersList = result;
         
        });
       
    
      }
    
    
      getAllTaskStatuses() {
    
        this._taskService.getAllTaskStatuses().subscribe((result: TaskStatusDto[]) => {
          this.statusesList = result;
         
        });
       
    
      }
}
