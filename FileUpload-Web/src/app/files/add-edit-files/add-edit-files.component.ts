import { Component, OnInit,Input } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-add-edit-files',
  templateUrl: './add-edit-files.component.html',
  styleUrls: ['./add-edit-files.component.css']
})
export class AddEditFilesComponent implements OnInit {

  constructor(private service: SharedService) { }

  id:string;
  filePath:string;
  formData:any;
  fileLoaded:boolean;
  ngOnInit(): void {
    this.fileLoaded = false;
  }

  UploadFile(event){
    var file= event.target.files[0];
    const formData: FormData=new FormData();

    formData.append('uploadFile',file,file.name);

   this.formData = formData;
   this.fileLoaded = true;
  }

  async UploadToServer(){
    await this.service.uploadFile(this.formData).subscribe( res =>
      {
        alert(res["message"].toString());
        this.formData = null;
        this.fileLoaded = false;
      });


  }
}
