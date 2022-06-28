import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-what-we-do',
  templateUrl: './what-we-do.component.html',
  styleUrls: ['./what-we-do.component.scss']
})
export class WhatWeDoComponent implements OnInit {
  section:string | null = null;
  constructor(private route:ActivatedRoute) { 
    route.params.subscribe(res =>{
      this.section = res['section'];
    });
  }

  ngOnInit(): void {
  }

}
