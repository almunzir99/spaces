import { Component, OnInit } from '@angular/core';
import { FuiModalService } from 'ngx-fomantic-ui';
import { Subscription } from 'rxjs';
import { EducationLevels, genders } from 'src/app/core/constants/constants';
import { Volunteer } from 'src/app/core/models/volunteer.model';
import { VolunteersService } from 'src/app/core/services/volunteers.service';
import { Column } from 'src/app/shared/data-table/models/column.model';

@Component({
  selector: 'app-volunteers',
  templateUrl: './volunteers.component.html',
  styleUrls: ['./volunteers.component.scss']
})
export class VolunteersComponent implements OnInit {

  cols: Column[];
  data:Volunteer[];
  pageIndex = 1;
  pageSize = 10;
  totalRecords = 0;
  totalPages = 1;
  DimLoading = false;
  orderBy = "lastUpdate";
  ascending = false;
  searchValue = "";
  isDataLoading: boolean = false;
  subscription = new Subscription();
  genders = genders;
  levels = EducationLevels;
  constructor(private _service:VolunteersService,private modalService:FuiModalService) {
    this.initCols();
    this.initData();
  }

  ngOnInit(): void {
    
  }
  
  onSearchChange(value){
    this.searchValue = value;
    this.initData();
  }
  onSortChange(event){
    this.orderBy = event.orderBy;
    this.ascending = event.ascending;
    this.initData();

  }
  pageIndexChanged(index: number) {
    this.pageIndex = index;
    this.initData();

  }
  pageSizeChanged(size: number) {
    this.pageSize = size;
    this.initData();

  }
  initData() {
    this.isDataLoading = true;
   var sub = this._service.get(this.pageIndex, this.pageSize,this.searchValue,this.orderBy,this.ascending).subscribe(res => {
      this.data = res.data;
      this.totalRecords = res.totalRecords;
      this.totalPages = res.totalPages;
      this.isDataLoading = false;

    }, err => {
      this.isDataLoading = false;

    });
    this.subscription.add(sub);
  }
  initCols() {
    this.cols = [
      {
        title: "Id",
        prop: "id",
        show: true,
        sortable: true
      },
      {
        title: "full Name",
        prop: "firstName",
        show: true,
        sortable: true
      },
      {
        title: "Email",
        prop: "email",
        show: true,
        sortable: true
      },
      {
        title: "Phone",
        prop: "phone",
        show: true,
        sortable: true
      },
      {
        title: "Gender",
        prop: "gender",
        show: true,
        sortable: true
      },
      {
        title: "Education Level",
        prop: "educationLevel",
        show: true,
        sortable: true
      },
      {
        title: "Sector",
        prop: "sector",
        show: true,
        sortable: true
      },
    
      {
        title: "Sent At",
        prop: "createdAt",
        show: true,
        sortable: true
      },
      {
        title: "Actions",
        prop: "actions",
        show: true,
      }
    ]
  }
   


  range(total: number, beginIndex: number = 0, step: number = 1): number[] {
    let list: number[] = [];
    for (let index = beginIndex; index < total; index += step) {
      list.push(index);
    }
    return list;
  }
  ngOnDestroy (){
    this.subscription.unsubscribe();
  }
}
