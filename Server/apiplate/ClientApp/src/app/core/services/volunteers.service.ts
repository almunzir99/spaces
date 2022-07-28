import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Volunteer } from '../models/volunteer.model';
import { PagedResponse } from '../models/wrappers/PagedResponse.mode';

@Injectable({
  providedIn: 'root'
})
export class VolunteersService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
  }
  get(pageIndex = 1, pageSize = 10, title = "", orderBy = "lastUpdate", ascending = false): Observable<PagedResponse<Volunteer[]>> {
    return this.http.get(`${this.baseUrl}api/volunteers?pageIndex=${pageIndex}&pageSize=${pageSize}&title=${title}&orderBy=${orderBy}&ascending=${ascending}`) as Observable<PagedResponse<Volunteer[]>>;
  }
}
