import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from '../../shared/models/user'

const AUTH_API = 'http://164.77.114.239:5100/Auth/';

const httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};


@Injectable({
    providedIn: 'root'
})
export class AuthService {

    constructor(private http: HttpClient) { }

    login(userInfo: User): Observable<any> {
        console.log('service login');
        return this.http.post(AUTH_API + 'authenticate',
        userInfo
        , httpOptions);
    }
}
