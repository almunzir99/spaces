import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Image } from '../models/image.model';
import { Media } from '../models/media.model';
import { PagedResponse } from '../models/wrappers/PagedResponse.mode';
@Injectable({
  providedIn: 'root'
})
export class MediaService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }
  get(pageIndex = 1, pageSize = 10,title="",orderBy="lastUpdate",ascending = false): Observable<PagedResponse<Media[]>> {
    console.log(`${this.baseUrl}api/media?pageSize=${pageSize}&pageIndex=${pageIndex}`);
    return this.http.get(`${this.baseUrl}api/media?pageIndex=${pageIndex}&pageSize=${pageSize}&title=${title}&orderBy=${orderBy}&ascending=${ascending}`) as Observable<PagedResponse<Media[]>>;
  }
  post(item: Media) {
    return this.http.post(`${this.baseUrl}api/media`, item);
  }
  postMulitImage(item: Image[]) {
    return this.http.post(`${this.baseUrl}api/media/multi-images`, item);
  }
  put(item: Media) {
    return this.http.put(`${this.baseUrl}api/media/${item.id}`, item);
  }
  delete(id: number) {
    return this.http.delete(`${this.baseUrl}api/media/${id}`);
  }
}
