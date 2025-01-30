import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateTasksDialogComponent } from './create-tasks-dialog.component';

describe('CreateTasksDialogComponent', () => {
  let component: CreateTasksDialogComponent;
  let fixture: ComponentFixture<CreateTasksDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateTasksDialogComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateTasksDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
