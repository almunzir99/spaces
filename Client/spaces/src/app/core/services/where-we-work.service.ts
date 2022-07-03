import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Region } from '../models/region.model';
import { PagedResponse } from '../models/wrappers/PagedResponse.mode';

@Injectable({
  providedIn: 'root'
})
export class WhereWeWorkService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
  }
  getRegions(pageIndex = 1, pageSize = 50, title = "", orderBy = "lastUpdate", ascending = true): Observable<PagedResponse<Region[]>> {
    return this.http.get(`${this.baseUrl}api/regions?pageIndex=${pageIndex}&pageSize=${pageSize}&title=${title}&orderBy=${orderBy}&ascending=${ascending}`) as Observable<PagedResponse<Region[]>>;
  }
}
