import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Partners } from '../models/partners.model';
import { PagedResponse } from '../models/wrappers/PagedResponse.mode';

@Injectable({
  providedIn: 'root'
})
export class PartnersService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }
  get(pageIndex = 1, pageSize = 10,title="",orderBy="lastUpdate",ascending = false): Observable<PagedResponse<Partners[]>> {
    console.log(`${this.baseUrl}api/partners?pageSize=${pageSize}&pageIndex=${pageIndex}`);
    return this.http.get(`${this.baseUrl}api/partners?pageIndex=${pageIndex}&pageSize=${pageSize}&title=${title}&orderBy=${orderBy}&ascending=${ascending}`) as Observable<PagedResponse<Partners[]>>;
  }
  post(item: Partners) {
    return this.http.post(`${this.baseUrl}api/partners`, item);
  }
  put(item: Partners) {
    return this.http.put(`${this.baseUrl}api/partners/${item.id}`, item);
  }
  delete(id: number) {
    return this.http.delete(`${this.baseUrl}api/partners/${id}`);
  }
  downloadCSV() {
    this.http.get(`${this.baseUrl}api/partners/export/csv`, { responseType: 'blob' }).subscribe(res => {
      let blob = new Blob([res], { type: 'text/plain' });
      var downloadURL = window.URL.createObjectURL(res);
      var link = document.createElement('a');
      link.href = downloadURL;
      link.download = "partners.csv";
      link.click();
    })
  }
}
