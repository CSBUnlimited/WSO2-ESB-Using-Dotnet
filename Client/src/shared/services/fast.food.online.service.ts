import { Observable } from 'rxjs/Observable';
import { ApiService } from './api.service';
import { Injectable } from '@angular/core';
import { UserResponse } from '../models';

@Injectable()
export class FastFoodOnlineService {

    private url = "http://localhost:5556/api/";

    constructor(
        private apiService: ApiService
    ) { }

    //User Api Calls
    public getAllUsers(): Observable<UserResponse> {
        return this.apiService.get(`${ this.url }user/GetUsersAsync`);
    }

    public getUserById(userId: number): Observable<UserResponse> {
        return this.apiService.get(`${ this.url }user/GetUsersAsync/${ userId }`);
    }
}