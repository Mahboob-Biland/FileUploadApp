import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {

  readonly APIUrl = 'http://localhost:8081/api/';
  readonly filesAPIUrl = 'http://localhost:8081/api/files';
  readonly bannedWordsAPIUrl = 'http://localhost:8081/api/bannedWords';
  constructor(private http:HttpClient) { }

  getFilesList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl + 'files');
  }

  uploadFile(val : any){
    return this.http.post(this.APIUrl + 'files/uploadFile',val);
  }

  deleteFile(id : any){
    return this.http.delete(this.APIUrl + 'files/'+id);
  }

  getBannedWordsList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl + 'bannedWords');
  }

  addBannedWord(val : any){
    return this.http.post(this.APIUrl + 'bannedWords/',val);
  }

  updateBannedWord(val : any){
    return this.http.put(this.APIUrl + 'bannedWords/',val);
  }

  deleteBannedWord(id : any){
    return this.http.delete(this.APIUrl + 'bannedWords/'+id);
  }
}
