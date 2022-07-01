import { Component, OnInit } from '@angular/core';
import { FuiModalService } from 'ngx-fomantic-ui';
import { Subscription } from 'rxjs';
import { Slider } from 'src/app/core/models/slider.model';
import { SlidersService } from 'src/app/core/services/sliders.service';
import { Column } from 'src/app/shared/data-table/models/column.model';
import { ControlTypes } from 'src/app/shared/form-builder/models/control-type.enum';
import { FormBuilderGroup } from 'src/app/shared/form-builder/models/form-builder-group.model';
import { FormBuilderModal } from 'src/app/shared/modals/form-builder-modal/form-builder-modal.component';
import { MessageModal, MessageTypes } from 'src/app/shared/modals/message-modal/message-modal.component';

@Component({
  selector: 'app-slider',
  templateUrl: './slider.component.html',
  styleUrls: ['./slider.component.scss']
})
export class SliderComponent implements OnInit {

  cols: Column[];
  data: Slider[] = [];
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
  constructor(private _service: SlidersService, private modalService: FuiModalService) {

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
        prop: "title",
        title: "Title",
        show: true,

      },
      {
        prop: "subtitle",
        title: "Subtitle",
        show: true,

      },
      {
        prop: "description",
        title: "Description",
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
  openFormModal(item: Slider) {
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
            title: "Title",
            name: "title",
            controlType: ControlTypes.TextInput,
            width: "100%",
            value: item ? item.title.en : undefined
          },
          {
            title: "Subtitle",
            name: "subtitle",
            controlType: ControlTypes.TextInput,
            width: "100%",
            value: item ? item.subtitle.en : undefined
          },
          {
            title: "description",
            name: "description",
            controlType: ControlTypes.TextArea,
            width: "100%",
            value: item ? item.description.en : undefined
          },


        ]
      },
      {

        title: "المحتوى العربي",
        controls: [
          {
            title: "العنوان",
            name: "ar_title",
            controlType: ControlTypes.TextInput,
            width: "100%",
            value: item ? item.title.ar : undefined
          },
          {
            title: "العنوان الفرعي",
            name: "ar_subtitle",
            controlType: ControlTypes.TextInput,
            width: "100%",
            value: item ? item.subtitle.ar : undefined
          },
          {
            title: "",
            name: "ar_description",
            controlType: ControlTypes.TextArea,
            width: "100%",
            value: item ? item.description.ar : undefined
          },

        ]
      },
      {

        title: "General",
        controls: [
          {
            title: "URL",
            name: "url",
            icon:"linkify icon",
            controlType: ControlTypes.Url,
            width: "100%",
            value: item ? item.url : undefined
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
      result['title'] = {
        "ar": result["ar_title"],
        "en": result["title"],
      };
      result['subtitle'] = {
        "ar": result["ar_subtitle"],
        "en": result["subtitle"],
      }
      result['description'] = {
        "ar": result["ar_description"],
        "en": result["description"],
      }

      result['image'] = {
        "path": result['image']
      }
      if (item)
        this.update(result as Slider);
      else
        this.create(result as Slider);

    });


  }
  create(item: Slider) {
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
  update(item: Slider) {
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
