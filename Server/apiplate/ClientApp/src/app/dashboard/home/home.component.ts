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
  isLoading = false;
  stats: Statistics;
  cards: StatisticCard[] = [];
  subscription = new Subscription();

  constructor(private _service: StatisticsService) {
    this.getStats();
  }
  initCards() {
    this.cards = [
       
      {
        title: "Articles",
        color: "#EB9710",
        icon: "las la-newspaper",
        route: "articles",
        number: this.stats.articles
      },
      {
        title: "Sectors",
        color: "#115778",
        icon: "las la-border-all",
        route: "sectors",
        number: this.stats.sectors
      },
      {
        title: "Regions",
        color: "#D32D41",
        icon: "las la-map-marked-alt",
        route: "regions",
        number: this.stats.regions
      },
      {
        title: "Projects",
        color: "#DBAE58",
        icon: "las la-clipboard-list",
        route: "projects",
        number: this.stats.projects
      },
      {
        title: "Sliders",
        color: "#1F3F49",
        icon: "las la-image",
        route: "slider",
        number: this.stats.sliders
      },
      {
        title: "Team",
        color: "#F8AA4B",
        icon: "las la-users",
        route: "team",
        number: this.stats.team
      },
       {
        title: "Testimonials",
        color: "#1AC0C6",
        icon: "las la-comment",
        route: "testimonials",
        number: this.stats.testimonials
      },
      {
        title: "Partners",
        color: "#7E909A",
        icon: "las la-handshake",
        route: "partners",
        number: this.stats.partners
      },
      {
        title: "Messages",
        color: "#543C52",
        icon: "las la-envelope",
        route: "messages",
        number: this.stats.messages
      },
    ];
  }
  getStats() {
    this.isLoading = true;
    var sub = this._service.get().subscribe(res => {
      this.stats = res.data;
      this.isLoading = false;
      this.initCards();
    }, err => {
      this.isLoading = false;
    });
    this.subscription.add(sub);
  }

  ngOnInit(): void {
  }
  ngOnDestroy() {
    this.subscription.unsubscribe();
  }
}
export interface StatisticCard {
  title: string;
  number: number;
  color: string;
  icon: string;
  route: string;
}