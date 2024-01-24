import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { ContainerComponent } from './container/container.component';
import { HeaderComponent } from './header/header.component';
import { FirstHomePageComponent } from './container/home/first-home-page/first-home-page.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { BestsellersHomeComponent } from './container/home/bestsellers-home/bestsellers-home.component';
import { BoxHoverDirective } from './CustomDirectives/box-hover.directive';
import { LatestReviewsComponent } from './container/home/latest-reviews/latest-reviews.component';
import {HomeComponent} from './container/home/home.component';
import { AdminDashboardComponent } from './container/admin-dashboard/admin-dashboard.component';
import { SidebarDashboardComponent } from './container/admin-dashboard/sidebar-dashboard/sidebar-dashboard.component';
import { BookAdminComponent } from './container/admin-dashboard/book-admin/book-admin.component';
import { AddBookComponent } from './container/admin-dashboard/book-admin/add-book/add-book.component';
import { AuthorAdminComponent } from './container/admin-dashboard/author-admin/author-admin.component';
import { AddAuthorComponent } from './container/admin-dashboard/author-admin/add-author/add-author.component';
import { CategoryAdminComponent } from './container/admin-dashboard/category-admin/category-admin.component';
import { AddCategoryComponent } from './container/admin-dashboard/category-admin/add-category/add-category.component'
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, provideHttpClient, withFetch } from '@angular/common/http';
import { EditCategoryComponent } from './container/admin-dashboard/category-admin/edit-category/edit-category.component';
import { EditBookComponent } from './container/admin-dashboard/book-admin/edit-book/edit-book.component';
import { EditAuthorComponent } from './container/admin-dashboard/author-admin/edit-author/edit-author.component';
@NgModule({
  declarations: [
    AppComponent,
    ContainerComponent,
    HeaderComponent,
    FirstHomePageComponent,
    BestsellersHomeComponent,
    BoxHoverDirective,
    LatestReviewsComponent,
    HomeComponent,
    AdminDashboardComponent,
    SidebarDashboardComponent,
    BookAdminComponent,
    AddBookComponent,
    AuthorAdminComponent,
    AddAuthorComponent,
    CategoryAdminComponent,
    AddCategoryComponent,
    EditCategoryComponent,
    EditBookComponent,
    EditAuthorComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatSlideToggleModule,
    FontAwesomeModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [
    provideClientHydration(),
    provideHttpClient(withFetch())
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
