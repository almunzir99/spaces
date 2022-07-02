import { Component, OnInit, ViewChild } from '@angular/core';
import { SwiperComponent } from 'swiper/angular';
import { Swiper, SwiperOptions } from 'swiper/types';
import SwiperCore, { Autoplay } from 'swiper';
import { Slider } from '../core/models/slider.model';
import { Sector } from '../core/models/sector.model';
import { Partners } from '../core/models/partners.model';
import { first, forkJoin, map, Subscription } from 'rxjs';
import { HomeService } from '../core/services/home.service';
import { Article } from '../core/models/article.model';
import { TranslationService } from '../core/services/translation.service';
import { Testimonial } from '../core/models/testimonial.model';
SwiperCore.use([Autoplay])
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  currentIndex = 0;
  swiper?: SwiperComponent;
  pageLoading = false;
  newsSliderBreakpoints = {
    
    950: {
      slidesPerView: 3,
      spaceBetween: 10
    },
    650: {
      slidesPerView: 2,
      spaceBetween: 20,
    }
  };

  config: SwiperOptions = {
    slidesPerView: 1,
    autoplay: {
      delay: 4000,
      disableOnInteraction: false,
    },
    loop: true,
    pagination: { clickable: true },
    scrollbar: { draggable: true },
  };
  onSwiper(swiper: SwiperComponent) {
    this.swiper = swiper;
  }

  onSlideChange([swiper]: Swiper[]) {
    this.currentIndex = swiper.activeIndex;
  }
  sliders: Slider[] = [];
  sectors: Sector[] = [];
  partners: Partners[] = [];
  articles: Article[] = [];
  testimonials: Testimonial[] = [];
  subscription = new Subscription();
  currentLang:string = "en";
  constructor(private _service: HomeService,private _translationService:TranslationService) { }
  loadData() {
    this.pageLoading = true;
    var obs = forkJoin([
      this._service.getSliders(),
      this._service.getSectors(),
      this._service.getPartners(),
      this._service.getArticles(),
      this._service.getTestimonials(),

    ]).pipe(map(([sliders, sectors, partners, articles,testimonials]) => {
      return { sliders, sectors, partners, articles,testimonials }
    }));
    obs.subscribe({
      next: (res) => {
        this.pageLoading = false;
        this.sliders = res.sliders.data!;
        this.sectors = res.sectors.data!;
        this.partners = res.partners.data!;
        this.articles = res.articles.data!;
        this.testimonials = res.testimonials.data!;
        this.configureNewsSliderBreakpoints();
        console.log(this.newsSliderBreakpoints)
        console.log(res)
      },
      error: (err) => {
        this.pageLoading = false;
        console.log(err);
      }
    })
  }
  configureNewsSliderBreakpoints(){
    // this.newsSliderBreakpoints[1040].slidesPerView = this.articles.length < 4 ? this.articles.length : 4;
    this.newsSliderBreakpoints[950].slidesPerView = this.articles.length < 3 ? this.articles.length : 3;
    this.newsSliderBreakpoints[650].slidesPerView = this.articles.length < 3 ? this.articles.length : 2;
  }
  ngOnInit(): void {
    this.currentLang = this._translationService.currentLang;
    this.loadData();
  }
  ngAfterViewInit() {
  }

}
