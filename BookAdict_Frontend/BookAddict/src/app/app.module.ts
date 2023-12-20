import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { ContainerComponent } from './container/container.component';
import { HeaderComponent } from './container/header/header.component';
import { FirstHomePageComponent } from './container/first-home-page/first-home-page.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { BestsellersHomeComponent } from './container/bestsellers-home/bestsellers-home.component';
import { BoxHoverDirective } from './CustomDirectives/box-hover.directive';
import { LatestReviewsComponent } from './container/latest-reviews/latest-reviews.component';
@NgModule({
  declarations: [
    AppComponent,
    ContainerComponent,
    HeaderComponent,
    FirstHomePageComponent,
    BestsellersHomeComponent,
    BoxHoverDirective,
    LatestReviewsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatSlideToggleModule,
    FontAwesomeModule
  ],
  providers: [
    provideClientHydration()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
