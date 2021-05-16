import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FilesComponent } from './files/files.component';
import { BannedWordsComponent } from './banned-words/banned-words.component';

const routes: Routes = [
  { path : 'files', component: FilesComponent },
  { path : 'bannedWords', component: BannedWordsComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
