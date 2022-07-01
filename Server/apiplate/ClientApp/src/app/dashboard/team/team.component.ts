import { Component, OnInit } from '@angular/core';
import { FuiModalService } from 'ngx-fomantic-ui';
import { Subscription } from 'rxjs';
import { Team } from 'src/app/core/models/team.model';
import { TeamService } from 'src/app/core/services/team.service';
import { Column } from 'src/app/shared/data-table/models/column.model';
import { ControlTypes } from 'src/app/shared/form-builder/models/control-type.enum';
import { FormBuilderGroup } from 'src/app/shared/form-builder/models/form-builder-group.model';
import { FormBuilderModal } from 'src/app/shared/modals/form-builder-modal/form-builder-modal.component';
import { MessageModal, MessageTypes } from 'src/app/shared/modals/message-modal/message-modal.component';

@Component({
  selector: 'app-team',
  templateUrl: './team.component.html',
  styleUrls: ['./team.component.scss']
})
export class TeamComponent implements OnInit {

  
  cols: Column[];
  data: Team[] = [];
  isDataLoading = false;
  pageIndex = 1;
  pageSize = 10;
  totalRecords = 0;
  totalPages = 1;
  DimLoading = false;
  orderBy = "priority";
  ascending = false;
  searchValue = "";
  selectedLang = "en";
  subscription = new Subscription();
  selectedContent = null;
  constructor(private _service: TeamService, private modalService: FuiModalService) {

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
        prop: "image",
        title: "Image",
        show: true,
      },

      {
        prop: "id",
        title: "Id",
        show: true,
        sortable: true

      },
      {
        prop: "priority",
        title: "Priority",
        show: true,
        sortable: true

      },

      {
        prop: "name",
        title: "Name",
        show: true,

      },
      {
        prop: "position",
        title: "Position",
        show: true,

      },
      {
        prop: "facebook",
        title: "Facebook",
        show: false,

      },
      {
        prop: "twitter",
        title: "Twitter",
        show: false,
      },
      {
        prop: "linkedIn",
        title: "LinkedIn",
        show: false,

      },
      {
        prop: "instgram",
        title: "Instagram",
        show: false,

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
  openFormModal(item: Team) {
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
          {
            title: "Position",
            name: "position",
            controlType: ControlTypes.TextInput,
            width: "100%",
            value: item ? item.position.en : undefined
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
          {
            title: "المنصب",
            name: "ar_position",
            controlType: ControlTypes.TextInput,
            width: "100%",
            value: item ? item.position.ar : undefined
          },
        

        ]
      },
      {

        title: "General",
        controls: [
          {
            title: "Priority",
            name: "priority",
            controlType: ControlTypes.NumberInput,
            width: "100%",
            value: item ? item.priority : undefined
          },
          {
            title: "Facebook",
            name: "facebook",
            icon:"facebook icon",
            controlType: ControlTypes.Url,
            width: "50%",
            value: item ? item.facebook : undefined
          },
          {
            title: "Twitter",
            name: "twitter",
            icon:"twitter icon",
            controlType: ControlTypes.Url,
            width: "50%",
            value: item ? item.twitter : undefined
          },
          {
            title: "LinkedIn",
            name: "linkedIn",
            icon:"linkedin icon",
            controlType: ControlTypes.Url,
            width: "50%",
            value: item ? item.linkedIn : undefined
          },
          {
            title: "Instagram",
            name: "Instagram",
            icon:"instagram icon",
            controlType: ControlTypes.Url,
            width: "50%",
            value: item ? item.instgram : undefined
          },
          {
            title: "Image",
            name: "image",
            controlType: ControlTypes.LocalFilePicker,
            width: "100%",
            value: item && item.image ? item.image.path : undefined
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
      result['position'] = {
        "ar": result["ar_position"],
        "en": result["position"],
      }
      result['image'] = {
        "path": result['image']
      }
      if (item)
        this.update(result as Team);
      else
        this.create(result as Team);

    });


  }
  create(item: Team) {
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
  update(item: Team) {
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
