import { Component, HostListener, OnInit } from '@angular/core';
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
  
  constructor() { }
  ngAfterContentInit() {
    this.top_nav = document.querySelector(".top-nav")!;
    this.bottom_nav = document.querySelector(".main-nav")!;

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
