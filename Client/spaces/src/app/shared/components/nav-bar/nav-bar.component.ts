import { Component, HostListener, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { TranslationService } from 'src/app/core/services/translation.service';
import { navBarList } from './navbar-list';

@Component({
  selector: 'spaces-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit {
  navList = navBarList;
  opened = false;
  top_nav: Element = undefined!;
  bottom_nav: Element = undefined!;
  urlSegments:string[] = [];
  currentLang = "en";
  constructor(private translationService:TranslationService,private translate:TranslateService,private router:Router) {
    var segments = location.pathname.split('/'); 
    this.urlSegments = segments.slice(2,segments.length);
    this.currentLang =  segments[1];
    this.changeLang(this.currentLang);

  }
  ngAfterContentInit() {
    this.top_nav = document.querySelector(".top-nav")!;
    this.bottom_nav = document.querySelector(".main-nav")!;
  }
  changeLang(lang:string)
  {
    this.translationService.changeLang(lang);
    this.currentLang =  this.translationService.currentLang;
    this.translate.use(lang);
    document.dir = lang == 'ar' ? 'rtl' : 'ltr';
    var segments = [...[this.currentLang],...this.urlSegments];
    this.router.navigate(segments)
  }
  
  @HostListener('window:scroll', ['$event']) onScrollEvent($event: any) {
    if (window.pageYOffset > 80) {
      this.top_nav.classList.add('hide_top');
      this.bottom_nav.classList.add('slideDown');

    }
    else {
      this.top_nav.classList.remove('hide_top');
      this.bottom_nav.classList.remove('slideDown');

    }

  }
  ngOnInit(): void {
  }

}
