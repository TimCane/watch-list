import {
  Component,
  EventEmitter,
  Input,
  Output,
  ViewChild,
} from '@angular/core';
import { User } from 'api-client';
import { MenuItem } from 'primeng/api';
import { Menu } from 'primeng/menu';

@Component({
  selector: 'editor-top-bar',
  templateUrl: './top-bar.component.html',
  styleUrls: ['./top-bar.component.scss'],
})
export class TopBarComponent {
  @ViewChild(Menu, { static: false }) menu!: Menu;
  @Output() onSidebarToggled = new EventEmitter<void>();
  @Input() user: User | null = null;

  get avatarBgColour() {
    if (this.user && this.user.name) {
      return this.getBackgroundColor(this.user.name);
    }

    return null;
  }

  get avatarTextColour() {
    if (this.avatarBgColour) {
      return this.invertColor(this.avatarBgColour);
    }

    return null;
  }

  getBackgroundColor(input: string) {
    let hash = 1995;
    input.split('').forEach((char) => {
      hash = char.charCodeAt(0) + ((hash << 5) - hash);
    });
    let colour = '#';
    for (let i = 0; i < 3; i++) {
      const value = (hash >> (i * 8)) & 0xff;
      colour += value.toString(16).padStart(2, '0');
    }
    return colour;
  }

  invertColor(hex: string) {
    if (hex.indexOf('#') === 0) {
      hex = hex.slice(1);
    }

    if (hex.length === 3) {
      hex = hex[0] + hex[0] + hex[1] + hex[1] + hex[2] + hex[2];
    }
    if (hex.length !== 6) {
      throw new Error('Invalid HEX color.');
    }
    var r = parseInt(hex.slice(0, 2), 16),
      g = parseInt(hex.slice(2, 4), 16),
      b = parseInt(hex.slice(4, 6), 16);
    return r * 0.299 + g * 0.587 + b * 0.114 > 186 ? '#000000' : '#FFFFFF';
  }

  toggleSidebar() {
    this.onSidebarToggled.emit();
  }

  onProfileMenu(event: any) {
    this.menu.toggle(event);
  }
  items: MenuItem[] = [];

  ngOnInit() {
    this.items = [
      {
        label: 'My Account',
        icon: 'pi pi-user',
        routerLink: ['/', 'account', 'profile'],
      },
      {
        label: 'Logout',
        icon: 'pi pi-sign-out',
        routerLink: ['/', 'auth', 'logout'],
      },
    ];
  }
}
