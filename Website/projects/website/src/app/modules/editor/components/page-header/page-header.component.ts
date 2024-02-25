import { Component, OnDestroy } from '@angular/core';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { MenuItem } from 'primeng/api';
import { Subject, filter, takeUntil } from 'rxjs';

export const ROUTE_DATA_BREADCRUMB = 'breadcrumb';

@Component({
  selector: 'editor-page-header',
  templateUrl: './page-header.component.html',
  styleUrls: ['./page-header.component.scss'],
})
export class PageHeaderComponent implements OnDestroy {
  private readonly destroy$ = new Subject<void>();

  pageName: string | null = null;
  home: MenuItem = { icon: 'pi pi-home', routerLink: ['/'] };
  items: MenuItem[] = [];

  constructor(private router: Router, private activatedRoute: ActivatedRoute) {}

  ngOnInit(): void {
    this.updatePage();

    this.router.events
      .pipe(
        takeUntil(this.destroy$),
        filter((event) => event instanceof NavigationEnd)
      )
      .subscribe(() => this.updatePage());
  }

  updatePage() {
    this.items = this.createBreadcrumbs(this.activatedRoute.root);
    this.pageName = this.items[this.items.length - 1].label ?? null;
  }

  private createBreadcrumbs(
    route: ActivatedRoute,
    url: string = '',
    breadcrumbs: MenuItem[] = []
  ): MenuItem[] {
    const children: ActivatedRoute[] = route.children;

    if (children.length === 0) {
      return breadcrumbs;
    }

    for (const child of children) {
      const routeURL: string = child.snapshot.url
        .map((segment) => segment.path)
        .join('/');
      if (routeURL !== '') {
        url += `/${routeURL}`;
      }

      const label = child.snapshot.data[ROUTE_DATA_BREADCRUMB];
      if (
        label != undefined &&
        label != null &&
        (breadcrumbs.length == 0 ||
          label != breadcrumbs[breadcrumbs.length - 1].label)
      ) {
        breadcrumbs.push({
          label,
          routerLink: url,
          routerLinkActiveOptions: { exact: true },
        });
      }

      return this.createBreadcrumbs(child, url, breadcrumbs);
    }

    return breadcrumbs;
  }

  ngOnDestroy(): void {
    this.destroy$.next(undefined);
    this.destroy$.complete();
  }
}
