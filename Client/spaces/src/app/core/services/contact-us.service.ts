import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Message } from '../models/message.model';
import { ApiResponse } from '../models/wrappers/apiResponse.model';

@Injectable({
  providedIn: 'root'
})
export class ContactUsService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
  }
  postMessage(message: Message):Observable<ApiResponse< Message>> {
    return this.http.post(`${this.baseUrl}api/messages`,message) as Observable<ApiResponse< Message>>;
  }
}
