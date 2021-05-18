import { Component, OnInit } from '@angular/core';
import { SharedService} from 'src/app/shared.service'

@Component({
  selector: 'app-show-files',
  templateUrl: './show-files.component.html',
  styleUrls: ['./show-files.component.css']
})
export class ShowFilesComponent implements OnInit {

  constructor(private service:SharedService) { }

  FilesList : any = [];
  ModalTitle:string;
  ActivateAddEditFileComp:boolean = false;

  ngOnInit(): void {
    this.refrishFilesList();
  }

  addClick(){
    this.ModalTitle="Upload File";
    this.ActivateAddEditFileComp=true;
  }

  closeClick(){
    this.ActivateAddEditFileComp=false;
    this.refrishFilesList();
  }
  refrishFilesList(){
    this.service.getFilesList().subscribe(data => {
      this.FilesList = data["fileInfo"];
    });
  }

  async deleteClick(item){
    if(confirm("Are you sure to delete this word?")){
      await this.service.deleteFile(item.id).subscribe( res =>
        {
          alert(res["message"].toString());
          this.refrishFilesList();
        });
    }
  }

}
