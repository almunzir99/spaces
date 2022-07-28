import { Component, Inject, OnInit } from '@angular/core';
import { navBarList } from '../nav-bar/navbar-list';

@Component({
  selector: 'spaces-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.scss']
})
export class FooterComponent implements OnInit {
  links = navBarList;
  constructor(@Inject('BASE_URL') public baseUrl: string) { }

  ngOnInit(): void {
  }

}
