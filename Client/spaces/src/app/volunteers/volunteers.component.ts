import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { EducationLevels, genders } from '../core/constants/constants';
import { Sector } from '../core/models/sector.model';
import { Volunteer } from '../core/models/volunteer.model';
import { ContactUsService } from '../core/services/contact-us.service';
import { GlobalService } from '../core/services/global.service';
import { TranslationService } from '../core/services/translation.service';
import { VolunteersService } from '../core/services/volunteers.service';

@Component({
  selector: 'app-volunteers',
  templateUrl: './volunteers.component.html',
  styleUrls: ['./volunteers.component.scss']
})
export class VolunteersComponent implements OnInit {

  isLoading = false;
  volunteer:Volunteer = new Volunteer();
  genders = genders;
  levels = EducationLevels;
  sectors:Sector[] =[];
  constructor(private _service: VolunteersService,private toastr:ToastrService,private translationService:TranslationService,private _globalService: GlobalService) {
    this.sectors = _globalService.$sectors.value;
   }
  sendRequest() {
    console.log(this.volunteer);
    if(this.isLoading)
    return;
    this.isLoading = true;
    this._service.post(this.volunteer).subscribe({ next: (res) => {
      this.isLoading = false;
      if(this.translationService.currentLang == 'ar')
      this.toastr.success('نجاح', 'تم ارسال الطلب بنجاح');
      else
      this.toastr.success('Success', 'Request Sent Successfully!');
     }, error: (err) => { 
      
      this.isLoading = false;
      console.log(err);
      if(this.translationService.currentLang == 'ar')
      this.toastr.error('فشل', 'فشل ارسال الطلب الرجاء اعادة المحاولة');
      else
      this.toastr.error('Error', 'Failed To Send Request, please try again!');
     } })
  }
  ngOnInit(): void {
  }
}
