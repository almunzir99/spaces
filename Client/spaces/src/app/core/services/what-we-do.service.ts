import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Project } from '../models/project.model';
import { Sector } from '../models/sector.model';
import { PagedResponse } from '../models/wrappers/PagedResponse.mode';

@Injectable({
  providedIn: 'root'
})
export class WhatWeDoService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
  }
  getProjects(pageIndex = 1, pageSize = 9, title = "", orderBy = "lastUpdate", ascending = false, sectorId: number | null = null, regionId: number | null = null): Observable<PagedResponse<Project[]>> {
    var params: any = {
      PageIndex: pageIndex,
      PageSize: pageSize,
      orderBy: orderBy,
      ascending: ascending,
      title: title,
    }
    if(sectorId != null)
    params['sectorId'] = sectorId;
    if(regionId != null)
    params['regionId'] = regionId;
    return this.http.get(`${this.baseUrl}api/projects/all`,{params:params}) as Observable<PagedResponse<Project[]>>;
  }
}
