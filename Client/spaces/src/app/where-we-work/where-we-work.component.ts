import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-where-we-work',
  templateUrl: './where-we-work.component.html',
  styleUrls: ['./where-we-work.component.scss']
})
export class WhereWeWorkComponent implements OnInit {

  constructor() { }
  selectedItem:any = null;
  states = [
    {
      "code":"KH",
      "name":"Khartoum",
      "image":"assets/images/states/KH.jpg",
      "content":"Lorem ipsum dolor sit amet consectetur adipisicing elit. Odio adipisci obcaecati fugiat molestias tempora ad, temporibus accusantium laborum. Eveniet assumenda ipsam maiores deserunt aperiam laboriosam repellendus! Nam velit numquam quos."
    },
    {
      "code":"GD",
      "name":"Al-Gadarif",
      "image":"assets/images/states/GD.jpg",
      "content":"Lorem ipsum dolor sit amet consectetur adipisicing elit. Odio adipisci obcaecati fugiat molestias tempora ad, temporibus accusantium laborum. Eveniet assumenda ipsam maiores deserunt aperiam laboriosam repellendus! Nam velit numquam quos."
    },
    {
      "code":"KA",
      "name":"Kassala",
      "image":"assets/images/states/KA.jpg",
      "content":"Lorem ipsum dolor sit amet consectetur adipisicing elit. Odio adipisci obcaecati fugiat molestias tempora ad, temporibus accusantium laborum. Eveniet assumenda ipsam maiores deserunt aperiam laboriosam repellendus! Nam velit numquam quos."
    },
    {
      "code":"RS",
      "name":"Red Sea State",
      "image":"assets/images/states/RS.jpg",
      "content":"Lorem ipsum dolor sit amet consectetur adipisicing elit. Odio adipisci obcaecati fugiat molestias tempora ad, temporibus accusantium laborum. Eveniet assumenda ipsam maiores deserunt aperiam laboriosam repellendus! Nam velit numquam quos."
    },
    {
      "code":"KN",
      "name":"Kordfan North",
      "image":"assets/images/states/KR.jpg",
      "content":"Lorem ipsum dolor sit amet consectetur adipisicing elit. Odio adipisci obcaecati fugiat molestias tempora ad, temporibus accusantium laborum. Eveniet assumenda ipsam maiores deserunt aperiam laboriosam repellendus! Nam velit numquam quos."
    },
    {
      "code":"GK",
      "name":"Kordfan West",
      "image":"assets/images/states/KR.jpg",
      "content":"Lorem ipsum dolor sit amet consectetur adipisicing elit. Odio adipisci obcaecati fugiat molestias tempora ad, temporibus accusantium laborum. Eveniet assumenda ipsam maiores deserunt aperiam laboriosam repellendus! Nam velit numquam quos."
    },
    {
      "code":"KS",
      "name":"Kordfan South",
      "image":"assets/images/states/KR.jpg",
      "content":"Lorem ipsum dolor sit amet consectetur adipisicing elit. Odio adipisci obcaecati fugiat molestias tempora ad, temporibus accusantium laborum. Eveniet assumenda ipsam maiores deserunt aperiam laboriosam repellendus! Nam velit numquam quos."
    },
    {
      "code":"DN",
      "name":"Darfur North",
      "image":"assets/images/states/DR.jpg",
      "content":"Lorem ipsum dolor sit amet consectetur adipisicing elit. Odio adipisci obcaecati fugiat molestias tempora ad, temporibus accusantium laborum. Eveniet assumenda ipsam maiores deserunt aperiam laboriosam repellendus! Nam velit numquam quos."
    },
    {
      "code":"DW",
      "name":"Darfur West",
      "image":"assets/images/states/DR.jpg",
      "content":"Lorem ipsum dolor sit amet consectetur adipisicing elit. Odio adipisci obcaecati fugiat molestias tempora ad, temporibus accusantium laborum. Eveniet assumenda ipsam maiores deserunt aperiam laboriosam repellendus! Nam velit numquam quos."
    },
    {
      "code":"DS",
      "name":"Darfur South",
      "image":"assets/images/states/DR.jpg",
      "content":"Lorem ipsum dolor sit amet consectetur adipisicing elit. Odio adipisci obcaecati fugiat molestias tempora ad, temporibus accusantium laborum. Eveniet assumenda ipsam maiores deserunt aperiam laboriosam repellendus! Nam velit numquam quos."
    },
    {
      "code":"DE",
      "name":"Darfur East",
      "image":"assets/images/states/DR.jpg",
      "content":"Lorem ipsum dolor sit amet consectetur adipisicing elit. Odio adipisci obcaecati fugiat molestias tempora ad, temporibus accusantium laborum. Eveniet assumenda ipsam maiores deserunt aperiam laboriosam repellendus! Nam velit numquam quos."
    },
    {
      "code":"DC",
      "name":"Darfur Center",
      "image":"assets/images/states/DR.jpg",
      "content":"Lorem ipsum dolor sit amet consectetur adipisicing elit. Odio adipisci obcaecati fugiat molestias tempora ad, temporibus accusantium laborum. Eveniet assumenda ipsam maiores deserunt aperiam laboriosam repellendus! Nam velit numquam quos."
    },




    {
      "code":"NB",
      "name":"Blue Nile State",
      "image":"assets/images/states/BN.jpg",
      "content":"Lorem ipsum dolor sit amet consectetur adipisicing elit. Odio adipisci obcaecati fugiat molestias tempora ad, temporibus accusantium laborum. Eveniet assumenda ipsam maiores deserunt aperiam laboriosam repellendus! Nam velit numquam quos."
    }
  ]
  ngOnInit(): void {
  }
  selectItem(code:string)
  {
    this.selectedItem = this.states.find(c => c.code == code);
  }

}
