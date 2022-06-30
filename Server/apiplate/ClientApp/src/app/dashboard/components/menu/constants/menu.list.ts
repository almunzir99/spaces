import { MenuGroup } from "../models/menu.group";

export const MenuList: MenuGroup[] = [
    {
        title: "General",
        children: [
            {
                title: "Home",
                icon: "las la-home",
                route: "/dashboard/home"

            },
            {
                title: "Users",
                icon: "las la-user-friends",
                route: "/dashboard/users"
            },
            {
                title: "Roles",
                icon: "las la-users-cog",
                route: "/dashboard/roles"

            }
        ]
    },
    {
        title: "Pages",
        children: [
            {
                title: "Articles",
                icon: "las la-newspaper",
                route: "/dashboard/articles"

            },
            {
                title: "Sectors",
                icon: "las la-border-all",
                route: "/dashboard/sectors"

            },
            {
                title: "Regions",
                icon: "las la-map-marked-alt",
                route: "/dashboard/regions"

            },
            {
                title: "Projects",
                icon: "las la-clipboard-list",
                route: "/dashboard/projects"

            },
            {
                title: "Partners",
                icon: "las la-handshake",
                route: "/dashboard/partners"

            },
            {
                title: "Slider",
                icon: "las la-image",
                route: "/dashboard/slider"

            },
            {
                title: "team",
                icon: "las la-users",
                route: "/dashboard/team"

            },
            {
                title: "Testimonials",
                icon: "las la-comment",
                route: "/dashboard/testimonials"

            },
            
            {
                title: "Messages",
                icon: "las la-envelope",
                route: "/dashboard/messages"

            },
        ]
    },
    {
        title: "More",
        children: [

            {
                title: "Files Manager",
                icon: "las la-folder-open",
                route: "/dashboard/files-manager"

            },
            {
                title: "Website Content",
                icon: "las la-globe-europe",
                route: "/dashboard/cms"

            },


            {
                title: "Profile",
                icon: "las la-user-cog",
                children:[
                    {
                        title:"Basic Information",
                        route: "/dashboard/profile/edit",
                        icon:"las la-user-edit"
                    },
                    {
                        title:"change Password",
                        route: "/dashboard/profile/password",
                        icon:"las la-user-shield"
                    },
                ]

            },
            {
                title: "Settings",
                icon: "las la-cog",
                route: "/dashboard/settings"

            },
        ]
    }
];