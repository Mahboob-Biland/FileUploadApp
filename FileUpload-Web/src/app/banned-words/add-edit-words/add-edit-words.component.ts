import { Component, OnInit,Input } from '@angular/core';
import { SharedService } from 'src/app/shared.service';
@Component({
  selector: 'app-add-edit-words',
  templateUrl: './add-edit-words.component.html',
  styleUrls: ['./add-edit-words.component.css']
})
export class AddEditWordsComponent implements OnInit {

  constructor(private service: SharedService) { }

  @Input() bannedWord:any;
  id:string;
  wordText:string;
  
  ngOnInit(): void {
    this.id = this.bannedWord.id;
    this.wordText = this.bannedWord.wordText;
  }

  AddBannedWord(){
    this.service.addBannedWord({ bannedWord: this.wordText}).subscribe( res =>
      {
        alert(res["message"].toString());
      });
  }

  UpdateBannedWord(){
    var val = {
      id : this.id,
      bannedWord : this.wordText
    };
    this.service.updateBannedWord(val).subscribe( res =>
      {
        alert(res["message"].toString());
      });
  } 
}