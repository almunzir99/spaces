import { ApiResponse } from "./apiResponse.model";

export class PagedResponse<T> extends ApiResponse<T>{
    pageIndex:number = 1;
    totalPages:number = 0;
    totalRecords:number = 0;
    firstPage?:string;
    lastPage?:string;
    nextPage?:string;
    previousPage?:string;
    
}