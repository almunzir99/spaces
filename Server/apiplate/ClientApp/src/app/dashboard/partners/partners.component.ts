import { Component, OnInit } from '@angular/core';
import { FuiModalService } from 'ngx-fomantic-ui';
import { Subscription } from 'rxjs';
import { Partners } from 'src/app/core/models/partners.model';
import { PartnersService } from 'src/app/core/services/partners.service';
import { Column } from 'src/app/shared/data-table/models/column.model';
import { ControlTypes } from 'src/app/shared/form-builder/models/control-type.enum';
import { FormBuilderGroup } from 'src/app/shared/form-builder/models/form-builder-group.model';
import { FormBuilderModal } from 'src/app/shared/modals/form-builder-modal/form-builder-modal.component';
import { MessageModal, MessageTypes } from 'src/app/shared/modals/message-modal/message-modal.component';

@Component({
  selector: 'app-partners',
  templateUrl: './partners.component.html',
  styleUrls: ['./partners.component.scss']
})
export class PartnersComponent implements OnInit {

  cols: Column[];
  data: Partners[] = [];
  isDataLoading = false;
  pageIndex = 1;
  pageSize = 10;
  totalRecords = 0;
  totalPages = 1;
  DimLoading = false;
  orderBy = "lastUpdate";
  ascending = false;
  searchValue = "";
  selectedLang = "en";
  subscription = new Subscription();
  selectedContent = null;
  constructor(private _service: PartnersService, private modalService: FuiModalService) {

  }
  onSearchChange(value) {
    this.searchValue = value;
    this.initData();
  }
  onSortChange(event) {
    this.orderBy = event.orderBy;
    this.ascending = event.ascending;
    this.initData();

  }

  initData() {
    this.isDataLoading = true;
    var sub = this._service.get(this.pageIndex, this.pageSize, this.searchValue, this.orderBy, this.ascending).subscribe(res => {
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
        prop: "logo",
        title: "Logo",
        show: true,
      },

      {
        prop: "id",
        title: "Id",
        show: true,
        sortable: true

      },
      
      {
        prop: "name",
        title: "Name",
        show: true,

      },
      {
        prop: "url",
        title: "URL",
        show: true,

      },
      {
        prop: "createdAt",
        title: "Created At",
        show: true,
        sortable: true


      },
      {
        prop: "lastUpdate",
        title: "Last Update",
        show: true,
        sortable: true


      }, {
        prop: "Actions",
        title: "Actions",
        show: true,

      }
    ]
  }
  ngOnInit(): void {
    this.initCols();
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
  delete(id: number) {
    this.modalService
      .open(new MessageModal({
        title: "Confirm Message",
        content: "are you sure you want to delete this item ?", isConfirm: true, messageType: MessageTypes.Danger
      }))
      .onApprove(() => {
        this.DimLoading = true;
        var sub = this._service.delete(id).subscribe(res => {
          this.DimLoading = false;
          this.modalService.open(new MessageModal({
            title: "Success",
            content: "Item Deleted Successfully", isConfirm: false, messageType: MessageTypes.Success
          }))
          this.initData();
        }, err => {
          this.DimLoading = false;

        });
        this.subscription.add(sub);

      })

  }
  openFormModal(item: Partners) {
    this.DimLoading = true;
    this.DimLoading = false;
    const form: FormBuilderGroup[] = [
      {

        title: "English Content",
        controls: [
          {
            title: "id",
            name: "id",
            controlType: ControlTypes.Hidden,
            width: "0px",
            value: item ? item.id : undefined
          },
          {
            title: "Name",
            name: "name",
            controlType: ControlTypes.TextInput,
            width: "100%",
            value: item ? item.name.en : undefined
          },
          

        ]
      },
      {

        title: "المحتوى العربي",
        controls: [
          {
            title: "الاسم",
            name: "ar_name",
            controlType: ControlTypes.TextInput,
            width: "100%",
            value: item ? item.name.ar : undefined
          },
           

        ]
      },
      {

        title: "General",
        controls: [
          {
            title: "URL",
            name: "url",
            controlType: ControlTypes.Url,
            width: "100%",
            value: item ? item.url : undefined
          },
          {
            title: "Logo",
            name: "logo",
            controlType: ControlTypes.LocalFilePicker,
            width: "100%",
            value: item && item.logo ? item.logo.path : undefined
          },



        ]
      }
    ];
    this.modalService.open(new FormBuilderModal(
      {
        title: item ? "Update Partner Info" : "New Partner",
        controlGroups: form
      }
    )).onApprove((result) => {
      result['name'] = {
        "ar": result["ar_name"],
        "en": result["name"],
      };
       
      result['logo'] = {
        "path": result['logo']
      }
      if (item)
        this.update(result as Partners);
      else
        this.create(result as Partners);

    });


  }
  create(item: Partners) {
    this.DimLoading = true;
    var sub = this._service.post(item).subscribe(res => {
      this.initData();
      this.DimLoading = false;
      this.modalService.open(new MessageModal({
        title: "Success",
        content: "Item Created Successfully", isConfirm: false, messageType: MessageTypes.Success
      }))
    }, err => {
      console.log(err);
      this.DimLoading = false;

    })
    this.subscription.add(sub);

  }
  update(item: Partners) {
    this.DimLoading = true;
    var sub = this._service.put(item).subscribe(res => {
      this.initData();
      this.DimLoading = false;
      this.modalService.open(new MessageModal({
        title: "Success",
        content: "Item Updated Successfully", isConfirm: false, messageType: MessageTypes.Success
      }))
    }, err => {
      console.log(err);
      this.DimLoading = false;

    })
    this.subscription.add(sub);

  }

  range(total: number, beginIndex: number = 0, step: number = 1): number[] {
    let list: number[] = [];
    for (let index = beginIndex; index < total; index += step) {
      list.push(index);
    }
    return list;
  }
  downloadCSV() {
    this._service.downloadCSV();
  }
  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

}
