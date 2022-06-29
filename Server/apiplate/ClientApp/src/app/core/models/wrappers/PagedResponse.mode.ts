import { ApiResponse } from "./apiResponse.model";

export class PagedResponse<T> extends ApiResponse<T>{
    pageIndex:number;
    totalPages:number;
    totalRecords:number;
    firstPage:string;
    lastPage:string;
    nextPage:string;
    previousPage:string;
    
}