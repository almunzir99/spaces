import { Component, OnInit } from '@angular/core';
import { navBarList } from './navbar-list';

@Component({
  selector: 'spaces-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit {
  navList = navBarList;
  opened = false;
  constructor() { }

  ngOnInit(): void {
  }

}
