import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { Sector } from '../models/sector.model';
import { PagedResponse } from '../models/wrappers/PagedResponse.mode';

@Injectable({
  providedIn: 'root'
})
export class SectorsService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }
  get(pageIndex = 1, pageSize = 10,title="",orderBy="lastUpdate",ascending = false): Observable<PagedResponse<Sector[]>> {
    console.log(`${this.baseUrl}api/sectors?pageSize=${pageSize}&pageIndex=${pageIndex}`);
    return this.http.get(`${this.baseUrl}api/sectors?pageIndex=${pageIndex}&pageSize=${pageSize}&title=${title}&orderBy=${orderBy}&ascending=${ascending}`) as Observable<PagedResponse<Sector[]>>;
  }
  post(item: Sector) {
    return this.http.post(`${this.baseUrl}api/sectors`, item);
  }
  put(item: Sector) {
    return this.http.put(`${this.baseUrl}api/sectors/${item.id}`, item);
  }
  delete(id: number) {
    return this.http.delete(`${this.baseUrl}api/sectors/${id}`);
  }
  downloadCSV() {
    this.http.get(`${this.baseUrl}api/sectors/export/csv`, { responseType: 'blob' }).subscribe(res => {
      let blob = new Blob([res], { type: 'text/plain' });
      var downloadURL = window.URL.createObjectURL(res);
      var link = document.createElement('a');
      link.href = downloadURL;
      link.download = "sectors.csv";
      link.click();
    })
  }
}
