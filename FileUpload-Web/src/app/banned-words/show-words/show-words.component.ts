import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-show-words',
  templateUrl: './show-words.component.html',
  styleUrls: ['./show-words.component.css']
})
export class ShowWordsComponent implements OnInit {

  constructor(private service:SharedService) { }

  BannedWordsList : any = [];
  ModalTitle:string;
  ActivateAddEditFileComp:boolean = false;
  bannedWord:any;

  ngOnInit(): void {
    this.bannedWord={
      id:0,
      wordText: ""
    };
    this.refrishBannedWordsList();
  }

  addClick(){
    this.bannedWord={
      id:0,
      wordText: ""
    };
    this.ModalTitle="Add Banned Word";
    this.ActivateAddEditFileComp=true;
  }

  closeClick(){
    this.ActivateAddEditFileComp=false;
    this.refrishBannedWordsList();
  }
  refrishBannedWordsList(){
    this.service.getBannedWordsList().subscribe(data => {
      this.BannedWordsList= data["banndWords"];
    });
  }

  editClick(item){
    this.bannedWord=item;
    this.ModalTitle="Edit Banned Word";
    this.ActivateAddEditFileComp=true;
  }

  async deleteClick(item){
    if(confirm("Are you sure to delete this word?")){
      await this.service.deleteBannedWord(item.id).subscribe( res =>
        {
          alert(res["message"].toString());
          this.refrishBannedWordsList();
        });
    }
    
  }

}
