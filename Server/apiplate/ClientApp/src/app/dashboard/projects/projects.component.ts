import { Component, OnInit } from '@angular/core';
import { Validators } from '@angular/forms';
import { FuiModalService } from 'ngx-fomantic-ui';
import { Subscription } from 'rxjs';
import { Project } from 'src/app/core/models/project.model';
import { Region } from 'src/app/core/models/region.model';
import { Sector } from 'src/app/core/models/sector.model';
import { AuthService } from 'src/app/core/services/auth.service';
import { ProjectsService } from 'src/app/core/services/projects.service';
import { RegionsService } from 'src/app/core/services/regions.service';
import { SectorsService } from 'src/app/core/services/sectors.service';
import { UsersService } from 'src/app/core/services/users.service';
import { Column } from 'src/app/shared/data-table/models/column.model';
import { ControlTypes } from 'src/app/shared/form-builder/models/control-type.enum';
import { FormBuilderGroup } from 'src/app/shared/form-builder/models/form-builder-group.model';
import { FormBuilderModal } from 'src/app/shared/modals/form-builder-modal/form-builder-modal.component';
import { MessageModal, MessageTypes } from 'src/app/shared/modals/message-modal/message-modal.component';

@Component({
  selector: 'app-projects',
  templateUrl: './projects.component.html',
  styleUrls: ['./projects.component.scss']
})
export class ProjectsComponent implements OnInit {

  cols: Column[];
  data: Project[] = [];
  regions:Region[] =[];
  sectors:Sector[] =[];
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
  selectedContent = null;
  selectedRegion:number = null;
  selectedSector:number = null;

  subscription = new Subscription();

  constructor(private sectorsService: SectorsService, private regionsService: RegionsService, private authService: AuthService, private userService: UsersService, private _service: ProjectsService, private modalService: FuiModalService) {

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
    var sub = this._service.get(this.pageIndex, this.pageSize, this.searchValue, this.orderBy, this.ascending,this.selectedSector,this.selectedRegion).subscribe(res => {
      this.data = res.data;
      this.totalRecords = res.totalRecords;
      this.totalPages = res.totalPages;
      // this.isDataLoading = false;
      if(this.regions.length == 0)
      this.loadRegions();
      if(this.sectors.length == 0)
      this.loadSectors();
      if(this.sectors.length > 0 && this.regions.length > 0)
      this.isDataLoading = false;
    }, err => {
      this.isDataLoading = false;

    });
    this.subscription.add(sub);
  }
  loadSectors() {
    this.isDataLoading = true;
    var sub = this.sectorsService.get(this.pageIndex, this.pageSize, this.searchValue, this.orderBy, this.ascending).subscribe(res => {
      this.sectors = res.data;
      this.totalRecords = res.totalRecords;
      this.totalPages = res.totalPages;
      this.isDataLoading = false;


    }, err => {
      this.isDataLoading = false;

    });
    this.subscription.add(sub);
  }
  loadRegions() {
    this.isDataLoading = true;
    var sub = this.regionsService.get(this.pageIndex, this.pageSize, this.searchValue, this.orderBy, this.ascending).subscribe(res => {
      this.regions = res.data;
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
        title: "title",
        show: true,

      },
      {
        prop: "subtitle",
        title: "Subtitle",
        show: true,

      },
      {
        prop: "content",
        title: "Content",
        show: true,

      },
      {
        prop: "author",
        title: "Author",
        show: true,

      },
      {
        prop: "region",
        title: "Region",
        show: true,

      },
      {
        prop: "sector",
        title: "Sector",
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
  selectedRegionChanged(id: number) {
    this.selectedRegion = id;
    this.initData();

  }
  selectedSectorChanged(id: number) {
    this.selectedRegion = id;
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
  openFormModal(item: Project) {
    this.DimLoading = true;
    var sub = this.userService.get().subscribe(res => {
      this.DimLoading = false;
      var users = res.data;
      if (users.length == 0)
        users.push(this.authService.$currentUser.value);
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
              title: "title",
              name: "title",
              controlType: ControlTypes.TextInput,
              width: "100%",
              value: item ? item.title.en : undefined
            },
            {
              title: "subtitle",
              name: "subtitle",
              controlType: ControlTypes.TextInput,
              width: "100%",
              value: item ? item.subtitle.en : undefined
            },
            {
              title: "content",
              name: "content",
              controlType: ControlTypes.RichTextEditor,
              width: "100%",
              value: item ? item.content.en : undefined
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
              title: "المحتوى",
              name: "ar_content",
              controlType: ControlTypes.RichTextEditor,
              width: "100%",
              value: item ? item.content.ar : undefined
            },
          ]
        },
        {

          title: "General",
          controls: [
            {
              title: "Image",
              name: "image",
              controlType: ControlTypes.LocalFilePicker,
              width: "100%",
              value: item && item.image ? item.image.path : undefined
            },
            {
              title: "author",
              name: "AuthorId",
              controlType: ControlTypes.Selection,
              data: res.data,
              isObjectData: true,
              labelProp: "username",
              valueProp: "id",
              width: "100%",
              value: item ? item.author : undefined,
              

            },
            {
              title: "region",
              name: "regionId",
              controlType: ControlTypes.Selection,
              data: this.regions,
              isObjectData: true,
              labelProp: "title.en",
              valueProp: "id",
              width: "50%",
              value: item ? item.regionId : undefined,
              

            },
            {
              title: "sector",
              name: "sectorId",
              controlType: ControlTypes.Selection,
              data: this.sectors,
              isObjectData: true,
              labelProp: "title.en",
              valueProp: "id",
              width: "50%",
              value: item ? item.sectorId : undefined,
              

            },




          ]
        }
      ];
      this.modalService.open(new FormBuilderModal(
        {
          title: item ? "Update Project Info" : "New Project",
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
        result['content'] = {
          "ar": result["ar_content"],
          "en": result["content"],
        }
        result['image'] = {
          "path": result['image']
        }
        if (item)
          this.update(result as Project);
        else
          this.create(result as Project);

      });
    }, err => {
      this.DimLoading = false;

    });

  }
  create(item: Project) {
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
  update(item: Project) {
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
