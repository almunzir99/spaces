import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.scss']
})
export class AboutComponent implements OnInit {
  values = [
    {
      "title": "Humanity",
      "content": "Spaces bring assistance to right holder without discrimination to the targeted groups and work to alleviate human suffering wherever it may be found."
    },
    {
      "title": "Transparency",
      "content": "Transparency is a highly valued principle by almost every staff. We value transparent relationships with stakeholders."
    },
    {
      "title": "Accountability",
      "content": "Spaces staff hold themselves accountable to both those we seek to assist and those from whom we accept resources and also accountable to donors, beneficiaries and relevant authorities."
    },
    {
      "title": "Impartiality",
      "content": "Spaces makes no discrimination as nationality, race, and religious beliefs, class or political opinions, it endeavors to relieve the suffering of individuals being guided solely by their needs and to give priority to the most urgent cases of distress."
    },
    {
      "title": "Neutrality",
      "content": "In order to continue to enjoy the confidence of all ,the Spaces may not take sides in hostilities because we are working in the field of conflict mitigation and peace building sector or engage of any time in  controversies of political, racial, religious or ideological nature."
    },
    {
      "title": "Independence",
      "content": "The Spaces is independent formulate and implement their own policies independently of government policies or actions, also there are auxiliaries in the humanitarian services and subject to the laws of our country."
    },

  ];
  objectives = [
    "To promote the spirit of self-reliance.",
    "To sensitize the communities on good sanitation and affordability of clean water.",
    "Understanding the rural communities about the utilization of resilient housing.",
    "Pushing the local communities to take action on implementing the green energy",
    "Provision of the necessary skills to local communities on how they canconsume and produce locally.",
    "preparing the community of change agent.",
    "Ensure access of quality education to the less privilege families.",
    "Create networks with local, regional and international partners.",
    "Empower refugees & IDPs skills through vocational schools",
  ];
  constructor() { }

  ngOnInit(): void {
  }

}
