import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Message } from '../core/models/message.model';
import { ContactUsService } from '../core/services/contact-us.service';
import { TranslationService } from '../core/services/translation.service';

@Component({
  selector: 'app-contact-us',
  templateUrl: './contact-us.component.html',
  styleUrls: ['./contact-us.component.scss']
})
export class ContactUsComponent implements OnInit {
  isLoading = false;
  message:Message = new Message();
  constructor(private _service: ContactUsService,private toastr:ToastrService,private translationService:TranslationService) { }
  sendMessage() {
    if(this.isLoading)
    return;
    this.isLoading = true;
    this._service.postMessage(this.message).subscribe({ next: (res) => {
      this.isLoading = false;
      if(this.translationService.currentLang == 'ar')
      this.toastr.success('نجاح', 'تم ارسال الرسالة بنجاح');
      else
      this.toastr.success('Success', 'Message Sent Successfully!');
     }, error: (err) => { 
      
      this.isLoading = false;
      console.log(err);
      if(this.translationService.currentLang == 'ar')
      this.toastr.error('فشل', 'فشل ارسال الرسالة الرجاء اعادة المحاولة');
      else
      this.toastr.error('Error', 'Failed To Send Message, please try again!');
     } })
  }
  ngOnInit(): void {
  }

}
