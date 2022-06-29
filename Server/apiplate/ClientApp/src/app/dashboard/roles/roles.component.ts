import { Component, OnInit } from '@angular/core';
import { FuiModalService, ModalSize } from 'ngx-fomantic-ui';
import { Permission } from 'src/app/core/models/permission.model';
import { Role } from 'src/app/core/models/role.model';
import { RolesService } from 'src/app/core/services/roles.service';
import { Column } from 'src/app/shared/data-table/models/column.model';
import { ControlTypes } from 'src/app/shared/form-builder/models/control-type.enum';
import { FormBuilderGroup } from 'src/app/shared/form-builder/models/form-builder-group.model';
import { FormBuilderModal } from 'src/app/shared/modals/form-builder-modal/form-builder-modal.component';
import { MessageModal, MessageTypes } from 'src/app/shared/modals/message-modal/message-modal.component';


@Component({
  selector: 'app-roles',
  templateUrl: './roles.component.html',
  styleUrls: ['./roles.component.scss']
})
export class RolesComponent implements OnInit {
  cols: Column[];
  data: Role[] = [];
  pageIndex = 1;
  pageSize = 10;
  totalRecords = 0;
  totalPages = 1;
  DimLoading = false;
  orderBy = "lastUpdate";
  ascending = false;
  searchValue = "";
  isLoading = false;
  selectedRole:Role;
  showPermissionsModal = false;

  constructor(private _service: RolesService, private modalService: FuiModalService) {
  }
  ngOnInit(): void {
    this.initCols();
    this.initData();

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
  pageIndexChanged(index: number) {
    this.pageIndex = index;
    this.initData();

  }
  pageSizeChanged(size: number) {
    this.pageSize = size;
    this.initData();

  }
  onManagePermissionClicked(role:Role){
    this.showPermissionsModal = true;
    this.selectedRole = role;
  }
  PermissionModalDismissed(){
    this.showPermissionsModal = false;

  }
  initData() {
    this.isLoading = true;
    this._service.get(this.pageIndex, this.pageSize, this.searchValue, this.orderBy, this.ascending).subscribe(res => {
      this.data = res.data;
      this.totalRecords = res.totalRecords;
      this.totalPages = res.totalPages;
      this.isLoading = false;

    }, err => {
      this.isLoading = false;

    });
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
        title: "Title",
        prop: "title",
        show: true,
        sortable: true
      },
      {
        title: "createdAt",
        prop: "createdAt",
        show: true,
        sortable: true
      },
      {
        title: "lastUpdate",
        prop: "lastUpdate",
        show: true,
        sortable: true
      },
      {
        title: "Manage Permissions",
        prop: "permission",
        show: true,
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
  GetPermissions(obj: any): string[] {
    let permissions = [];
    for (const key in obj) {
      if (key.includes("Permissions"))
        permissions.push(key);
    }
    return permissions;
  }

  onApply(role: Role) {
    this.DimLoading = true;
    this._service.put(role).subscribe(res => {
      this.DimLoading = false;
      this.initData();
      this.modalService.open(new MessageModal({
        title: "Success",
        content: "Item Updated Successfully", isConfirm: false, messageType: MessageTypes.Success
      }));

    }, err => {
      console.log(err);


    });
  }
  editForm(role:Role = null) {
    var defaultPermission: Permission = {
      create: false,
      delete: false,
      update: false,
      read: false
    }
    var controls: FormBuilderGroup[] = [
      {
        title: undefined,
        controls: [
          {
            title: "Role Title",
            name: "title",
            controlType: ControlTypes.TextInput,
            width: "100%",
            icon: "options icon",
            value:(role) ? role.title : null
          }
        ]
      }
    ];
    this.modalService.open(new FormBuilderModal({ title: "New Role", controlGroups: controls }, ModalSize.Mini)).onApprove(result => {
      
      this.DimLoading = true;
      if(role == null)
      {
        role = {
          title: result['title'],
          rolesPermissions: defaultPermission,
          usersPermissions: defaultPermission,
          messagesPermissions: defaultPermission,
  
        }
        this._service.post(role).subscribe(res => {
          this.DimLoading = false;
          this.initData();
          this.modalService.open(new MessageModal({
            title: "Success",
            content: "Item Created Successfully", isConfirm: false, messageType: MessageTypes.Success
          }));
        }, err => {
          this.DimLoading = false;
          this.modalService.open(new MessageModal({
            title: "Error",
            content: "Operation Failed", isConfirm: false, messageType: MessageTypes.Danger
          }));
        });
      }
      else{
        this._service.patchTitle(role.id,result['title']).subscribe(res => {
          this.DimLoading = false;
          this.initData();
          this.modalService.open(new MessageModal({
            title: "Success",
            content: "Item updated Successfully", isConfirm: false, messageType: MessageTypes.Success
          }));
        }, err => {
          this.DimLoading = false;
          this.modalService.open(new MessageModal({
            title: "Error",
            content: "Operation Failed", isConfirm: false, messageType: MessageTypes.Danger
          }));
        });
      }
    });

  }
  delete(id: number) {
    this.modalService.open(new MessageModal({ title: "Confirm", content: "are you sure you want to delete this item ?", isConfirm: true, messageType: MessageTypes.Warning })).onApprove(() => {
      this.DimLoading = true;
      this._service.delete(id).subscribe(res => {
        this.DimLoading = false;
        this.initData();
        this.modalService.open(new MessageModal({
          title: "Success",
          content: "Item Updated Successfully", isConfirm: false, messageType: MessageTypes.Success
        }));
      }, err => {
        this.DimLoading = false;
        console.log(err);
        this.modalService.open(new MessageModal({
          title: "Error",
          content: "Operation Failed", isConfirm: false, messageType: MessageTypes.Danger
        }));
      });
    })
  }


}
