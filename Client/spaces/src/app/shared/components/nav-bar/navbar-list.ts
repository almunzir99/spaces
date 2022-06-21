import { NavBarItem } from "./navbar-item.model";

export const  navBarList:NavBarItem[] = [
    {
        title:"Home",
        route:"home"
    },
    {
        title:"Who We Are",
        route:"about"
    },
    {
        title:"What We Do",
        route:"what-we-do",
        children:[
            {
                title:"WASH",
                route:"what-we-do/wash"
            },
            {
                title:"Health",
                route:"what-we-do/health"
            },
            {
                title:"Health",
                route:"what-we-do/health"
            },
            {
                title:"FSL & Narration",
                route:"what-we-do/FSL"
            },
            {
                title:"Peace Building",
                route:"what-we-do/peace-building"
            },
            {
                title:"Emergency Intervention",
                route:"what-we-do/emergeny"
            }
             
        ]
    },
    {
        title:"Where We Work",
        route:"where-we-work"
    },
    {
        title:"Contact Us",
        route:"contact-us"
    }
];