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
                route:"wash"
            },
            {
                title:"Health",
                route:"health"
            },
            {
                title:"Protection",
                route:"Protection"
            },
            {
                title:"FSL & Narration",
                route:"FSL"
            },
            {
                title:"Peace Building",
                route:"peace-building"
            },
            {
                title:"Education",
                route:"peace-building"
            },
            {
                title:"Emergency Intervention",
                route:"emergeny"
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