import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { Statistics } from 'src/app/core/models/statistics.model';
import { StatisticsService } from 'src/app/core/services/statistics.service';
 
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  isLoading  = false;
  stats:Statistics;
  subscription = new Subscription();
  
  constructor(private _service:StatisticsService) {
    this.getStats();
  }
  getStats() {
    this.isLoading = true;
    var sub =this._service.get().subscribe(res => {
      this.stats = res.data;
      this.isLoading = false;
    },err =>{
        this.isLoading = false;
    });
    this.subscription.add(sub);
  }

  ngOnInit(): void {
  }
  ngOnDestroy (){
    this.subscription.unsubscribe();
  }
}
