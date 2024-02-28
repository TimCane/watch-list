import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { MenuItem } from 'primeng/api';
import { Subject, filter, takeUntil } from 'rxjs';
import { AppState } from '../../app.state';
import { selectUser } from '../shared/state/authentication.selectors';
import { ROUTE_DATA_BREADCRUMB } from './components/page-header/page-header.component';
import { updateBreadcrumbs } from './state/editor/editor.action';

@Component({
  selector: 'editor',
  templateUrl: './editor.component.html',
  styleUrls: ['./editor.component.scss'],
})
export class EditorComponent implements OnInit, OnDestroy {
  private readonly destroy$ = new Subject<void>();

  user$ = this.store.select(selectUser);

  constructor(
    private store: Store<AppState>,
    private router: Router,
    private activatedRoute: ActivatedRoute
  ) {}

  sidebarToggle: boolean = false;

  onSidebarToggled() {
    this.sidebarToggle = !this.sidebarToggle;
  }

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
    this.store.dispatch(
      updateBreadcrumbs({
        breadcrumbs: this.createBreadcrumbs(this.activatedRoute.root),
      })
    );
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
