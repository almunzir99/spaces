import { Component, OnInit } from '@angular/core';
import { FuiModalService } from 'ngx-fomantic-ui';
import { Subscription } from 'rxjs';
import { Testimonial } from 'src/app/core/models/testimonial.model';
import { TestimonialsService } from 'src/app/core/services/testimonials.service';
import { Column } from 'src/app/shared/data-table/models/column.model';
import { ControlTypes } from 'src/app/shared/form-builder/models/control-type.enum';
import { FormBuilderGroup } from 'src/app/shared/form-builder/models/form-builder-group.model';
import { FormBuilderModal } from 'src/app/shared/modals/form-builder-modal/form-builder-modal.component';
import { MessageModal, MessageTypes } from 'src/app/shared/modals/message-modal/message-modal.component';

@Component({
  selector: 'app-testimonials',
  templateUrl: './testimonials.component.html',
  styleUrls: ['./testimonials.component.scss']
})
export class TestimonialsComponent implements OnInit {

  cols: Column[];
  data: Testimonial[] = [];
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
  constructor(private _service: TestimonialsService, private modalService: FuiModalService) {

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
        prop: "id",
        title: "Id",
        show: true,
        sortable: true

      },
      {
        prop: "image",
        title: "Author Image",
        show: true,
      },
      {
        prop: "author",
        title: "Author",
        show: true,

      },
      {
        prop: "job",
        title: "Job",
        show: true,

      },
      {
        prop: "content",
        title: "Content",
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


      },
      {
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
  openFormModal(item: Testimonial) {
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
            title: "Author Name",
            name: "author",
            controlType: ControlTypes.TextInput,
            width: "100%",
            value: item ? item.author.en : undefined
          },
          {
            title: "Author Job",
            name: "job",
            controlType: ControlTypes.TextInput,
            width: "100%",
            value: item ? item.job.en : undefined
          },
          {
            title: "Testimonial Content",
            name: "content",
            controlType: ControlTypes.TextArea,
            width: "100%",
            value: item ? item.content.en : undefined
          },


        ]
      },
      {

        title: "المحتوى العربي",
        controls: [
          {
            title: "اسم الكاتب",
            name: "ar_author",
            controlType: ControlTypes.TextInput,
            width: "100%",
            value: item ? item.author.ar : undefined
          },
          {
            title: "وظيفة الكاتب",
            name: "ar_job",
            controlType: ControlTypes.TextInput,
            width: "100%",
            value: item ? item.job.ar : undefined
          },
          {
            title: "المحتوى",
            name: "ar_content",
            controlType: ControlTypes.TextArea,
            width: "100%",
            value: item ? item.content.ar : undefined
          },

        ]
      },
      {

        title: "General",
        controls: [
          {
            title: "Author Image",
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
        title: item ? "Update Testimonial Info" : "New Testimonial",
        controlGroups: form
      }
    )).onApprove((result) => {
      result['author'] = {
        "ar": result["ar_author"],
        "en": result["author"],
      };
      result['job'] = {
        "ar": result["ar_job"],
        "en": result["job"],
      }
      result['content'] = {
        "ar": result["ar_content"],
        "en": result["content"],
      }

      result['image'] = {
        "path": result['image']
      }
      if (item)
        this.update(result as Testimonial);
      else
        this.create(result as Testimonial);

    });


  }
  create(item: Testimonial) {
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
  update(item: Testimonial) {
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
