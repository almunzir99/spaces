import { NavBarItem } from "./navbar-item.model";

export const  navBarList:NavBarItem[] = [
    {
        title:"Home",
        route:"home"
    },
    {
        title:"About",
        route:"about"
    },
    
    {
        title:"Sectors",
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
        title:"Regions",
        route:"where-we-work"
    },
    {
        title:"careers",
        route:"careers"
    },
    
    {
        title:"Contact_Us",
        route:"contact-us"
    }
];