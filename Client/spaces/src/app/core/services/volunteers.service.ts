import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { Volunteer } from '../models/volunteer.model';
import { ApiResponse } from '../models/wrappers/apiResponse.model';

@Injectable({
  providedIn: 'root'
})
export class VolunteersService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
  }
  post(volunteer: Volunteer):Observable<ApiResponse< Volunteer>> {
    return this.http.post(`${this.baseUrl}api/volunteers`,volunteer) as Observable<ApiResponse< Volunteer>>;
  }
}
