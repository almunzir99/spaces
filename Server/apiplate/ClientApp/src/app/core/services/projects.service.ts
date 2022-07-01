import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Project } from '../models/project.model';
import { PagedResponse } from '../models/wrappers/PagedResponse.mode';

@Injectable({
  providedIn: 'root'
})
export class ProjectsService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }
  get(pageIndex = 1, pageSize = 10, title = "", orderBy = "lastUpdate", ascending = false, sectorId: number = null, regionId: number = null): Observable<PagedResponse<Project[]>> {
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
  post(item: Project) {
    return this.http.post(`${this.baseUrl}api/projects`, item);
  }
  put(item: Project) {
    return this.http.put(`${this.baseUrl}api/projects/${item.id}`, item);
  }
  delete(id: number) {
    return this.http.delete(`${this.baseUrl}api/projects/${id}`);
  }
  downloadCSV() {
    this.http.get(`${this.baseUrl}api/projects/export/csv`, { responseType: 'blob' }).subscribe(res => {
      let blob = new Blob([res], { type: 'text/plain' });
      var downloadURL = window.URL.createObjectURL(res);
      var link = document.createElement('a');
      link.href = downloadURL;
      link.download = "projects.csv";
      link.click();
    })
  }
}
