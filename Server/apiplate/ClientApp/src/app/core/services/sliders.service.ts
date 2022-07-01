import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Slider } from '../models/slider.model';
import { PagedResponse } from '../models/wrappers/PagedResponse.mode';

@Injectable({
  providedIn: 'root'
})
export class SlidersService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }
  get(pageIndex = 1, pageSize = 10,title="",orderBy="lastUpdate",ascending = false): Observable<PagedResponse<Slider[]>> {
    console.log(`${this.baseUrl}api/sliders?pageSize=${pageSize}&pageIndex=${pageIndex}`);
    return this.http.get(`${this.baseUrl}api/sliders?pageIndex=${pageIndex}&pageSize=${pageSize}&title=${title}&orderBy=${orderBy}&ascending=${ascending}`) as Observable<PagedResponse<Slider[]>>;
  }
  post(item: Slider) {
    return this.http.post(`${this.baseUrl}api/sliders`, item);
  }
  put(item: Slider) {
    return this.http.put(`${this.baseUrl}api/sliders/${item.id}`, item);
  }
  delete(id: number) {
    return this.http.delete(`${this.baseUrl}api/sliders/${id}`);
  }
  downloadCSV() {
    this.http.get(`${this.baseUrl}api/sliders/export/csv`, { responseType: 'blob' }).subscribe(res => {
      let blob = new Blob([res], { type: 'text/plain' });
      var downloadURL = window.URL.createObjectURL(res);
      var link = document.createElement('a');
      link.href = downloadURL;
      link.download = "sliders.csv";
      link.click();
    })
  }
}
