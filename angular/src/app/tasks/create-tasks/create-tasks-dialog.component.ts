import { Component, EventEmitter, Injector, OnInit, Output } from '@angular/core';
import { BsModalRef } from '@node_modules/ngx-bootstrap/modal';
import { AppComponentBase } from '@shared/app-component-base';
import { CreateTaskItemDto, TaskItemDto, TaskItemServiceProxy, UserDto } from '@shared/service-proxies/service-proxies';

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
  usersList: TaskItemDto[]=[];
  statusesList: any[]=[];

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _taskService: TaskItemServiceProxy,
    // private _directorateService: DirectorateServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }
  ngOnInit(): void {
   // this.getAllDirectorates();
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


  // getAllDirectorates() {

  //   this._directorateService.getAllWithoutPagination().subscribe((result: DirectorateDto[]) => {
  //     this.directorates = result;
     
  //   });
   

  // }
}


