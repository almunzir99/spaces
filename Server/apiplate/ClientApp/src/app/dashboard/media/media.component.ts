import { Component, OnInit } from '@angular/core';
import { FuiModalService } from 'ngx-fomantic-ui';
import { Subscription } from 'rxjs';
import { Image } from 'src/app/core/models/image.model';
import { Media } from 'src/app/core/models/media.model';
import { MediaService } from 'src/app/core/services/media.service';
import { Column } from 'src/app/shared/data-table/models/column.model';
import { ControlTypes } from 'src/app/shared/form-builder/models/control-type.enum';
import { FormBuilderGroup } from 'src/app/shared/form-builder/models/form-builder-group.model';
import { FormBuilderModal } from 'src/app/shared/modals/form-builder-modal/form-builder-modal.component';
import { MessageModal, MessageTypes } from 'src/app/shared/modals/message-modal/message-modal.component';

@Component({
  selector: 'app-media',
  templateUrl: './media.component.html',
  styleUrls: ['./media.component.scss']
})
export class MediaComponent implements OnInit {

  cols: Column[];
  data: Media[] = [];
  isDataLoading = false;
  pageIndex = 1;
  pageSize = 10;
  totalRecords = 0;
  totalPages = 1;
  DimLoading = false;
  orderBy = "mainVideo";
  ascending = false;
  searchValue = "";
  subscription = new Subscription();
  constructor(private _service: MediaService, private modalService: FuiModalService) {

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
        prop: "thumbnail",
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
        prop: "url",
        title: "Url",
        show: true,

      },
      {
        prop: "mediaType",
        title: "Media Type",
        show: true,
        sortable: true


      },
      {
        prop: "mainVideo",
        title: "Main Video",
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
  openFormModal(item: Media) {
    this.DimLoading = true;
    this.DimLoading = false;
    const form: FormBuilderGroup[] = [
      {

        title: "General",
        controls: [
          {
            title: "id",
            name: "id",
            controlType: ControlTypes.Hidden,
            width: "0px",
            value: item ? item.id : undefined
          },
          {
            title: "Image",
            name: "thumbnail",
            controlType: ControlTypes.LocalFilePicker,
            width: "100%",
            value: item && item.thumbnail ? item.thumbnail.path : undefined
          },
          {
            title: "URL",
            name: "url",
            icon: "linkify icon",
            controlType: ControlTypes.Url,
            width: "100%",
            value: item ? item.url : undefined
          },
          {
            title: "Media Type",
            name: "mediaType",
            controlType: ControlTypes.Selection,
            data: [
              "image",
              "video"
            ],
            width: "100%",
            value: item ? item.mediaType : undefined
          },
          {
            title: "Main Video",
            name: "mainVideo",
            controlType: ControlTypes.CheckBox,

            width: "100%",
            value: item ? item.mainVideo : undefined
          },

        ]
      }
    ];
    this.modalService.open(new FormBuilderModal(
      {
        title: item ? "Update Media Info" : "New Media",
        controlGroups: form
      }
    )).onApprove((result) => {
      result['thumbnail'] = {
        "path": result['thumbnail']
      }
      if (item)
        this.update(result as Media);
      else
        this.create(result as Media);

    });


  }
  openMultiImagesModal() {
    this.DimLoading = true;
    this.DimLoading = false;
    const form: FormBuilderGroup[] = [
      {

        title: "General",
        controls: [
          {
            title: "Images",
            name: "images",
            controlType: ControlTypes.LocalFilePicker,
            width: "100%",
          },
        ]
      }
    ];
    this.modalService.open(new FormBuilderModal(
      {
        title: "Upload Multi Images",
        controlGroups: form
      }
    )).onApprove((result) => {
      var images = (result['images'] as string[]).map(c =>{
        return {path:c};
      });
      this.addMultiImages(images as Image[]);

    });


  }
  addMultiImages(items: Image[]) {
    this.DimLoading = true;
    var sub = this._service.postMulitImage(items).subscribe(res => {
      this.initData();
      this.DimLoading = false;
      this.modalService.open(new MessageModal({
        title: "Success",
        content: "Items images Successfully", isConfirm: false, messageType: MessageTypes.Success
      }))
    }, err => {
      console.log(err);
      this.DimLoading = false;

    })
    this.subscription.add(sub);
  }
  create(item: Media) {
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
  update(item: Media) {
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

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }


}
