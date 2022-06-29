import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { AuthService } from 'src/app/core/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  constructor(private _authService:AuthService,private router:Router) { }
  isLoading = false;
  error = true;
  subscription = new Subscription();
  ngOnInit(): void {
  }
  submit(email:string,password:string){
    this.isLoading = true;
      var sub = this._authService.login(email,password).subscribe(res => {
        console.log(res);
        this._authService.saveToken(res.data.token,res.data.id);
        this._authService.$currentUser.next(res.data);

        this.isLoading = false;
        this.router.navigate(['dashboard']);
      },err => {
        console.log(err);
        this.isLoading = false;
        

      })
      this.subscription.add(sub);
  }
  ngOnDestroy(){
    this.subscription.unsubscribe();
  }
  
}
