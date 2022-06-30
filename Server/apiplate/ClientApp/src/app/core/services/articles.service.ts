import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Article } from '../models/article.model';
import { PagedResponse } from '../models/wrappers/PagedResponse.mode';

@Injectable({
  providedIn: 'root'
})
export class ArticlesService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }
  get(pageIndex = 1, pageSize = 10,title="",orderBy="lastUpdate",ascending = false): Observable<PagedResponse<Article[]>> {
    console.log(`${this.baseUrl}api/articles?pageSize=${pageSize}&pageIndex=${pageIndex}`);
    return this.http.get(`${this.baseUrl}api/articles?pageIndex=${pageIndex}&pageSize=${pageSize}&title=${title}&orderBy=${orderBy}&ascending=${ascending}`) as Observable<PagedResponse<Article[]>>;
  }
  post(article: Article) {
    return this.http.post(`${this.baseUrl}api/articles`, article);
  }
  put(article: Article) {
    return this.http.put(`${this.baseUrl}api/articles/${article.id}`, article);
  }
  delete(id: number) {
    return this.http.delete(`${this.baseUrl}api/articles/${id}`);
  }
  downloadCSV() {
    this.http.get(`${this.baseUrl}api/articles/export/csv`, { responseType: 'blob' }).subscribe(res => {
      let blob = new Blob([res], { type: 'text/plain' });
      var downloadURL = window.URL.createObjectURL(res);
      var link = document.createElement('a');
      link.href = downloadURL;
      link.download = "articles.csv";
      link.click();
    })
  }
}
