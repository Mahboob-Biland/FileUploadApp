import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FilesComponent } from './files/files.component';
import { ShowFilesComponent } from './Files/show-files/show-files.component';
import { AddEditFilesComponent } from './Files/add-edit-files/add-edit-files.component';
import { BannedWordsComponent } from './banned-words/banned-words.component';
import { ShowWordsComponent } from './banned-words/show-words/show-words.component';
import { AddEditWordsComponent } from './banned-words/add-edit-words/add-edit-words.component';
import { SharedService} from './shared.service'

import {HttpClientModule} from '@angular/common/http'
import {FormsModule, ReactiveFormsModule} from '@angular/forms'

@NgModule({
  declarations: [
    AppComponent,
    FilesComponent,
    ShowFilesComponent,
    AddEditFilesComponent,
    BannedWordsComponent,
    ShowWordsComponent,
    AddEditWordsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [SharedService],
  bootstrap: [AppComponent]
})
export class AppModule { }
