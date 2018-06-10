import { AuthService } from './../../shared/services/authentication/auth.service';
import { FastFoodOnlineService } from './../../shared/services/fast.food.online.service';
import { Component, OnInit } from '@angular/core';
import { UserVM } from '../../shared/models';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

    public users: UserVM[] = [];

    constructor(
        private apiService: FastFoodOnlineService,
        private authService: AuthService
    ) { }

    ngOnInit() {
        // this.getAllUsers();
    }

    //Api calls
    public getAllUsers(): void {
        this.apiService.getAllUsers().subscribe(
            data => {
                if (data.isSuccess) {
                    this.users = data.users;
                }
                else {

                }
            },
            err => {

            }
        )
    }

    public login() {
        this.authService.login();
    }
}
