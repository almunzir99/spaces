import { Component, Inject, NgZone, OnInit, SecurityContext, ViewChild } from '@angular/core';
import { SwiperComponent } from 'swiper/angular';
import { Swiper, SwiperOptions } from 'swiper/types';
import SwiperCore,  { Autoplay,Pagination,Navigation } from 'swiper';
import { Slider } from '../core/models/slider.model';
import { Sector } from '../core/models/sector.model';
import { Partners } from '../core/models/partners.model';
import { forkJoin, map, Subscription } from 'rxjs';
import { HomeService } from '../core/services/home.service';
import { Article } from '../core/models/article.model';
import { TranslationService } from '../core/services/translation.service';
import { Testimonial } from '../core/models/testimonial.model';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { Media } from '../core/models/media.model';

SwiperCore.use([Autoplay,Pagination,Navigation])

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  currentIndex = 0;
  swiper?: SwiperComponent;
  pageLoading = false;
  showMediaViewerActive = false;
  mediaType?:string;
  media!:SafeUrl[];
  selectedMediaIndex = 0;
  SecurityContext = SecurityContext;
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
    navigation:true,
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
  gallery:Media[] = [];
  mainVideo?:Media;
  constructor(@Inject('BASE_URL') public baseUrl: string,private _service: HomeService,private _translationService:TranslationService,public _sanitizer:DomSanitizer,private _ngZone:NgZone,private router:Router) { 
  }
  loadData() {
    this.pageLoading = true;
    var obs = forkJoin([
      this._service.getSliders(),
      this._service.getSectors(),
      this._service.getPartners(),
      this._service.getArticles(),
      this._service.getTestimonials(),
      this._service.getMedia(),
      this._service.getMainVideo(),



    ]).pipe(map(([sliders, sectors, partners, articles,testimonials,gallery,video]) => {
      console.log(sliders)
      return { sliders, sectors, partners, articles,testimonials,gallery,video }
    }));
   var sub = obs.subscribe({
      next: (res) => {
        this.pageLoading = false;
        this.sliders = res.sliders.data!;
        this.sectors = res.sectors.data!;
        this.partners = res.partners.data!;
        this.articles = res.articles.data!;
        this.testimonials = res.testimonials.data!;
        this.gallery = res.gallery.data?.filter(c => c.mediaType == 'image')!;
        this.mainVideo = res.video.data!;
        this.configureNewsSliderBreakpoints();
        console.log(this.newsSliderBreakpoints)
        console.log(res)
      },
      error: (err) => {
        this.pageLoading = false;
        console.log(err);
      }
    })
    this.subscription.add(sub);
  }
  configureNewsSliderBreakpoints(){
    // this.newsSliderBreakpoints[1040].slidesPerView = this.articles.length < 4 ? this.articles.length : 4;
    this.newsSliderBreakpoints[950].slidesPerView = this.articles.length < 3 ? this.articles.length : 3;
    this.newsSliderBreakpoints[650].slidesPerView = this.articles.length < 3 ? this.articles.length : 2;
  }
  showMediaViewer(type:string,media:string[],selectMediaIndex:number = 0)
  {
    this.mediaType = type;
    this.media = media.map(m =>{
      if(this.mediaType == 'video')
        return this._sanitizer.bypassSecurityTrustResourceUrl(m);
      else
      return this._sanitizer.bypassSecurityTrustUrl(m);

    });
    this.selectedMediaIndex = selectMediaIndex;
    this.showMediaViewerActive = true;
  }
  showGalleryInMediaViewer(selectMediaIndex:number)
  {
    var images = this.gallery.map(c => {
      return c.url!;
    });
    this.showMediaViewer("image",images,selectMediaIndex); 
  }
  ngZonedNavigation(url:string){
    this._ngZone.run(() =>{
      this.router.navigate([url]);
    })
  }
  closeMediaViewer()
  {
    this.showMediaViewerActive = false;
  }
  ngOnInit(): void {
    this.currentLang = this._translationService.currentLang;
    this.loadData();
    this._translationService.subscribe({next: (res) =>{
      this.currentLang = res;
  }})
  }
   
  ngAfterViewInit() {
  }
  ngOnDestroy(){
    this.subscription.unsubscribe();
  }

}
