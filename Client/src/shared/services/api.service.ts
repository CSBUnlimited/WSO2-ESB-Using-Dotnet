import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class ApiService {

    constructor(
        private httpClient: HttpClient
    ) { }

    private get headers(): HttpHeaders {
        let headers = new HttpHeaders();
        headers.append('Accept', 'application/json');
        return headers;
    }

    public get<T>(url: string, params: HttpParams = new HttpParams()): Observable<T> {
        return this.httpClient.get<T>(url, { headers: this.headers, params: params });
    }

    public post<T>(url: string, body: Object): Observable<T> {
        return this.httpClient.post<T>(url, body, { headers: this.headers });
    }
}