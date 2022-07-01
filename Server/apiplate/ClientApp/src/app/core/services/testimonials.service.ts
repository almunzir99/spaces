import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Testimonial } from '../models/testimonial.model';
import { PagedResponse } from '../models/wrappers/PagedResponse.mode';

@Injectable({
  providedIn: 'root'
})
export class TestimonialsService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }
  get(pageIndex = 1, pageSize = 10,title="",orderBy="lastUpdate",ascending = false): Observable<PagedResponse<Testimonial[]>> {
    console.log(`${this.baseUrl}api/testimonials?pageSize=${pageSize}&pageIndex=${pageIndex}`);
    return this.http.get(`${this.baseUrl}api/testimonials?pageIndex=${pageIndex}&pageSize=${pageSize}&title=${title}&orderBy=${orderBy}&ascending=${ascending}`) as Observable<PagedResponse<Testimonial[]>>;
  }
  post(item: Testimonial) {
    return this.http.post(`${this.baseUrl}api/testimonials`, item);
  }
  put(item: Testimonial) {
    return this.http.put(`${this.baseUrl}api/testimonials/${item.id}`, item);
  }
  delete(id: number) {
    return this.http.delete(`${this.baseUrl}api/testimonials/${id}`);
  }
  downloadCSV() {
    this.http.get(`${this.baseUrl}api/testimonials/export/csv`, { responseType: 'blob' }).subscribe(res => {
      let blob = new Blob([res], { type: 'text/plain' });
      var downloadURL = window.URL.createObjectURL(res);
      var link = document.createElement('a');
      link.href = downloadURL;
      link.download = "testimonials.csv";
      link.click();
    })
  }
}
