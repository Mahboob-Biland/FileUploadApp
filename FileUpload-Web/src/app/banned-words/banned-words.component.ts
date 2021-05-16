import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-banned-words',
  templateUrl: './banned-words.component.html',
  styleUrls: ['./banned-words.component.css']
})
export class BannedWordsComponent implements OnInit {

  constructor(private service:SharedService) { }

  ngOnInit(): void {
  }


}
