import { Component, OnInit } from '@angular/core';
import { Validators } from '@angular/forms';
import { FuiModalService } from 'ngx-fomantic-ui';
import { Subscription } from 'rxjs';
import { User } from 'src/app/core/models/user.model';
import { AuthService } from 'src/app/core/services/auth.service';
import { UsersService } from 'src/app/core/services/users.service';
import { ControlTypes } from 'src/app/shared/form-builder/models/control-type.enum';
import { FormBuilderGroup } from 'src/app/shared/form-builder/models/form-builder-group.model';
import { MessageModal, MessageTypes } from 'src/app/shared/modals/message-modal/message-modal.component';
 

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {
  currentUser: User;
  formGroups: FormBuilderGroup[];
  loading = false;
  subscription = new Subscription();
  constructor(private authService: AuthService, private userService: UsersService, private modalService: FuiModalService) {
    this.getCurrentUser();
  }
  initFormGroups() {
    this.formGroups = [
      {

        title: undefined,
        controls: [
          {
            title: "id",
            name: "id",
            controlType: ControlTypes.Hidden,
            width: "0px",
            value: this.currentUser ? this.currentUser.id : undefined
          },
          {
            title: "username",
            name: "username",
            icon: "user tie icon",
            controlType: ControlTypes.TextInput,
            width: "50%",
            value: this.currentUser ? this.currentUser.username : undefined,
            validators: [
              Validators.required,
              Validators.minLength(8),
              Validators.maxLength(25),
            ]
          },
          {
            title: "phone",
            name: "phone",
            icon: "phone icon",
            controlType: ControlTypes.NumberInput,
            width: "50%",
            value: this.currentUser ? this.currentUser.phone : undefined,
            validators: [
              Validators.required,
              Validators.minLength(10),
              Validators.maxLength(12),

            ]

          },
          {
            title: "email",
            name: "email",
            icon: "mail icon",
            controlType: ControlTypes.TextInput,
            width: "100%",
            value: this.currentUser ? this.currentUser.email : undefined,
            validators: [
              Validators.required

            ]

          },
          
          {
            title: "image",
            name: "image",
            controlType: ControlTypes.LocalFilePicker,
            width: "100%",
            value: this.currentUser ? this.currentUser.image : undefined,

          },


        ]
      }
    ];
  }
  submit(user: User) { 
    /** mapping user */
    this.currentUser.id = user.id;
    this.currentUser.username = user.username;
    this.currentUser.email = user.email;
    this.currentUser.phone = user.phone;
    this.currentUser.image = user.image;
    this.currentUser.password = user.password;


    this.loading = true;
   var sub = this.userService.put(this.currentUser).subscribe(res => {
      this.modalService.open(new MessageModal({
        title: "Success",
        content: "Item Updated Successfully, please logout to save changes", isConfirm: false, messageType: MessageTypes.Success
      }))
      this.loading = false;

    }, err => { 
      this.loading = false;

    });
    this.subscription.add(sub);
  }
  getCurrentUser() {
    this.authService.$currentUser.subscribe(res => {
      this.currentUser = res;
      this.initFormGroups();

    })
  }
  ngOnInit(): void {
  }
  ngOnDestroy (){
    this.subscription.unsubscribe();
  }
}
