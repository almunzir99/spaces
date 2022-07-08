import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Article } from '../models/article.model';
import { Media } from '../models/media.model';
import { Partners } from '../models/partners.model';
import { Sector } from '../models/sector.model';
import { Slider } from '../models/slider.model';
import { Testimonial } from '../models/testimonial.model';
import { ApiResponse } from '../models/wrappers/apiResponse.model';
import { PagedResponse } from '../models/wrappers/PagedResponse.mode';

@Injectable({
  providedIn: 'root'
})
export class HomeService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string){
  }
  getSliders(pageIndex = 1, pageSize = 10,title="",orderBy="lastUpdate",ascending = false): Observable<PagedResponse<Slider[]>> {
    return this.http.get(`${this.baseUrl}api/sliders?pageIndex=${pageIndex}&pageSize=${pageSize}&title=${title}&orderBy=${orderBy}&ascending=${ascending}`) as Observable<PagedResponse<Slider[]>>;
  }
  getSectors(pageIndex = 1, pageSize = 10,title="",orderBy="lastUpdate",ascending = false): Observable<PagedResponse<Sector[]>> {
    return this.http.get(`${this.baseUrl}api/sectors?pageIndex=${pageIndex}&pageSize=${pageSize}&title=${title}&orderBy=${orderBy}&ascending=${ascending}`) as Observable<PagedResponse<Sector[]>>;
  }
  getPartners(pageIndex = 1, pageSize = 10,title="",orderBy="lastUpdate",ascending = false): Observable<PagedResponse<Partners[]>> {
    return this.http.get(`${this.baseUrl}api/Partners?pageIndex=${pageIndex}&pageSize=${pageSize}&title=${title}&orderBy=${orderBy}&ascending=${ascending}`) as Observable<PagedResponse<Partners[]>>;
  }
  getArticles(pageIndex = 1, pageSize = 10,title="",orderBy="lastUpdate",ascending = false): Observable<PagedResponse<Article[]>> {
    return this.http.get(`${this.baseUrl}api/articles?pageIndex=${pageIndex}&pageSize=${pageSize}&title=${title}&orderBy=${orderBy}&ascending=${ascending}`) as Observable<PagedResponse<Article[]>>;
  }
  getTestimonials(pageIndex = 1, pageSize = 10,title="",orderBy="lastUpdate",ascending = false): Observable<PagedResponse<Testimonial[]>> {
    return this.http.get(`${this.baseUrl}api/testimonials?pageIndex=${pageIndex}&pageSize=${pageSize}&title=${title}&orderBy=${orderBy}&ascending=${ascending}`) as Observable<PagedResponse<Testimonial[]>>;
  }
  getMedia(pageIndex = 1, pageSize = 10,title="",orderBy="lastUpdate",ascending = false): Observable<PagedResponse<Media[]>> {
    return this.http.get(`${this.baseUrl}api/media?pageIndex=${pageIndex}&pageSize=${pageSize}&title=${title}&orderBy=${orderBy}&ascending=${ascending}`) as Observable<PagedResponse<Media[]>>;
  }
  getMainVideo(): Observable<ApiResponse<Media>> {
    return this.http.get(`${this.baseUrl}api/media/main-video`) as Observable<PagedResponse<Media>>;
  }
}
