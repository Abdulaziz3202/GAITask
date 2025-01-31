import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { BsModalRef } from '@node_modules/ngx-bootstrap/modal';
import { AppComponentBase } from '@shared/app-component-base';
import { CreateTaskItemDto, TaskItemDto, TaskItemServiceProxy, TaskStatusDto, UserDto, UserServiceProxy } from '@shared/service-proxies/service-proxies';

@Component({
  selector: 'app-create-tasks-dialog',
  standalone: false,
  templateUrl: './create-tasks-dialog.component.html',
  styleUrls: ['./create-tasks-dialog.component.css'],


})
export class CreateTasksDialogComponent extends AppComponentBase
implements OnInit {
  saving = false;
  taskItem: CreateTaskItemDto = new CreateTaskItemDto();
  usersList: UserDto[]=[];
  statusesList: TaskStatusDto[]=[];
  allowedToUpdateAllFields:boolean=false;
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
    this.allowedToUpdateAllFields=!this.permission.isGranted('Pages.Tasks.Update.StatusOnly')
    if(this.allowedToUpdateAllFields){
      this.getAllUsers();
    }
    

    this.getAllTaskStatuses();




  }

  save(): void {
    this.saving = true;

  

    this._taskService.create(this.taskItem).subscribe(
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


