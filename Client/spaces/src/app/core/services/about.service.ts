import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Team } from '../models/team.model';
import { PagedResponse } from '../models/wrappers/PagedResponse.mode';

@Injectable({
  providedIn: 'root'
})
export class AboutService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string){
  }
  getTeam(pageIndex = 1, pageSize = 50,title="",orderBy="priority",ascending = true): Observable<PagedResponse<Team[]>> {
    return this.http.get(`${this.baseUrl}api/team?pageIndex=${pageIndex}&pageSize=${pageSize}&title=${title}&orderBy=${orderBy}&ascending=${ascending}`) as Observable<PagedResponse<Team[]>>;
  }
}
