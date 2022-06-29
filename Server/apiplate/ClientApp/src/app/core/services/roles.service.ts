import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Role } from '../models/role.model';
import { PagedResponse } from '../models/wrappers/PagedResponse.mode';

@Injectable({
  providedIn: 'root'
})
export class RolesService {

  constructor(private http:HttpClient,@Inject('BASE_URL') private baseUrl: string) { }
  get(pageIndex = 1, pageSize = 10,title="",orderBy="lastUpdate",ascending = false) : Observable<PagedResponse<Role[]>>{
    return this.http.get(`${this.baseUrl}api/roles?pageIndex=${pageIndex}&pageSize=${pageSize}`) as Observable<PagedResponse<Role[]>>;
}
post(role:Role){
  return this.http.post(`${this.baseUrl}api/roles`,role);
}
put(role:Role){
  return this.http.put(`${this.baseUrl}api/roles/${role.id}`,role);
}
patchTitle(id,title)
{
  console.log({op:"add",path:"/title",value:title});
  return this.http.patch(`${this.baseUrl}api/roles/${id}`,[{op:"add",path:"/title",value:title}]);

}
delete(id:number){
  return this.http.delete(`${this.baseUrl}api/roles/${id}`);
}
}

