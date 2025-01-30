import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { AppRouteGuard } from '@shared/auth/auth-route-guard';

import { UsersComponent } from './users/users.component';

import { RolesComponent } from 'app/roles/roles.component';
import { ChangePasswordComponent } from './users/change-password/change-password.component';
import { TasksComponent } from './tasks/tasks.component';
import { RouterModule } from '@angular/router';

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                component: AppComponent,
                children: [
                  
                    { path: 'users', component: UsersComponent, data: { permission: 'Pages.Users' }, canActivate: [AppRouteGuard] },
                    { path: 'roles', component: RolesComponent, data: { permission: 'Pages.Roles' }, canActivate: [AppRouteGuard] },
                    { path: 'tasks', component: TasksComponent, data: { permission: 'Pages.Tasks' }, canActivate: [AppRouteGuard] },


               
                    { path: 'update-password', component: ChangePasswordComponent, canActivate: [AppRouteGuard] }
                ]
            }
        ])
    ],
    exports: [RouterModule]
})
export class AppRoutingModule { }
