import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { MenuItem } from 'primeng/api';

@Component({
  selector: 'editor-side-bar',
  templateUrl: './side-bar.component.html',
  styleUrls: ['./side-bar.component.scss'],
})
export class SideBarComponent implements OnInit {
  @Input() toggle: boolean = false;
  @Output() onSidebarToggle = new EventEmitter<void>();

  toggleSidebar() {
    this.onSidebarToggle.emit();
  }

  items: MenuItem[] = [];

  ngOnInit() {
    this.items = [
      {
        label: 'Dashboard',
        icon: 'pi pi-fw pi-chart-bar',
        routerLink: ['/', 'editor', 'dashboard'],
        routerLinkActiveOptions: { exact: true },
      },
      {
        label: 'Movies',
        icon: 'pi pi-fw pi-ticket',
        routerLink: ['/', 'editor', 'movies'],
        routerLinkActiveOptions: { exact: true },
      },

      {
        label: 'Collections',
        icon: 'pi pi-fw pi-filter-fill',
        routerLink: ['/', 'editor', 'collections'],
        routerLinkActiveOptions: { exact: true },
      },
      {
        label: 'Credits',
        icon: 'pi pi-fw pi-id-card',
        routerLink: ['/', 'editor', 'credits'],
        routerLinkActiveOptions: { exact: true },
      },
      {
        label: 'Genres',
        icon: 'pi pi-fw pi-list',
        routerLink: ['/', 'editor', 'genres'],
        routerLinkActiveOptions: { exact: true },
      },
      {
        label: 'Keywords',
        icon: 'pi pi-fw pi-hashtag',
        routerLink: ['/', 'editor', 'keywords'],
        routerLinkActiveOptions: { exact: true },
      },
      {
        label: 'Languages',
        icon: 'pi pi-fw pi-language',
        routerLink: ['/', 'editor', 'languages'],
        routerLinkActiveOptions: { exact: true },
      },

      {
        label: 'Production Companies',
        icon: 'pi pi-fw pi-building',
        routerLink: ['/', 'editor', 'production-companies'],
        routerLinkActiveOptions: { exact: true },
      },
      {
        label: 'Production Countries',
        icon: 'pi pi-fw pi-globe',
        routerLink: ['/', 'editor', 'production-countries'],
        routerLinkActiveOptions: { exact: true },
      },
    ];
  }
}
