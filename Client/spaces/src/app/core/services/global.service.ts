import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Sector } from '../models/sector.model';
import { PagedResponse } from '../models/wrappers/PagedResponse.mode';

@Injectable({
  providedIn: 'root'
})
export class GlobalService {
  $sectors = new BehaviorSubject<Sector[]>([]);
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }
  getSectors(pageIndex = 1, pageSize = 20, title = "", orderBy = "lastUpdate", ascending = false): Observable<PagedResponse<Sector[]>> {
    return this.http.get(`${this.baseUrl}api/sectors?pageIndex=${pageIndex}&pageSize=${pageSize}&title=${title}&orderBy=${orderBy}&ascending=${ascending}`) as Observable<PagedResponse<Sector[]>>;
  }
}
