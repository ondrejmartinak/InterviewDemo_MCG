import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
//import { FormTransactionComponent } from './transactions/form.transaction.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
//import { HeroesComponent } from './hero/heroes.component';

@NgModule({
  declarations: [
    AppComponent,
  //  HeroesComponent,
//    FormTransactionComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
