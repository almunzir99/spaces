import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Article } from '../models/article.model';
import { Comment } from '../models/comment.model';
import { Project } from '../models/project.model';
import { ApiResponse } from '../models/wrappers/apiResponse.model';
import { PagedResponse } from '../models/wrappers/PagedResponse.mode';

@Injectable({
  providedIn: 'root'
})
export class DetailService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string){
  }
  get(base:string,pageIndex = 1, pageSize = 5,title="",orderBy="lastUpdate",ascending = false): Observable<PagedResponse<Article[] | Project[]>> {
    return this.http.get(`${this.baseUrl}api/${base}?pageIndex=${pageIndex}&pageSize=${pageSize}&title=${title}&orderBy=${orderBy}&ascending=${ascending}`) as Observable<PagedResponse<Article[] | Project[]>>;
  }
  single(base:string,id:number) : Observable<PagedResponse<Article | Project>>
  {
    return this.http.get(`${this.baseUrl}api/${base}/${id}`) as Observable<PagedResponse<Article | Project>>;
  }
  postComment(base:string,id:number,comment:Comment) :Observable<ApiResponse<Comment>>
  {
    return this.http.post(`${this.baseUrl}api/${base}/${id}/comments`,comment) as Observable<ApiResponse<Comment>>;
  }
  getComments(base:string,id:number,pageIndex = 1, pageSize = 5,title="",orderBy="lastUpdate",ascending = false): Observable<PagedResponse<Comment[]>> {
    return this.http.get(`${this.baseUrl}api/${base}/${id}/comments?pageIndex=${pageIndex}&pageSize=${pageSize}&title=${title}&orderBy=${orderBy}&ascending=${ascending}`) as Observable<PagedResponse<Comment[]>>;
  }
}
