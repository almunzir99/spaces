import { Component, OnInit, ViewChild } from '@angular/core';
import { SwiperComponent } from 'swiper/angular';
import { Swiper, SwiperOptions } from 'swiper/types';
import SwiperCore, { Autoplay } from 'swiper';
SwiperCore.use([Autoplay])
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  currentIndex = 0;
  swiper?: SwiperComponent;
  newsSliderBreakpoints = {
    1040: {
      slidesPerView: 4,
      spaceBetween: 10
    },
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
  constructor() { }

  ngOnInit(): void {
  }
  ngAfterViewInit() {
  }

}
