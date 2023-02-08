import { Component, Input, OnInit } from '@angular/core';
import { TitleStrategy } from '@angular/router';
import { ConnectApiService } from 'src/app/connect-api.service';
import { DataLoaderService } from 'src/app/data-loader.service';


@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})

export class AddComponent implements OnInit {
  inpectionTypesList: any = [];
  inspectionsList: any = [];
  statusList: any = [];

  id: number = 0;
  status: string = "";
  comments: string = "";
  inspectionTypeId!: number;

  @Input() inspection: any;
  constructor(private apiService: ConnectApiService, private loaderService: DataLoaderService) { }


  ngOnInit(): void {
    this.loadDataFromService();
  }

  loadDataFromService(){
    this.inpectionTypesList=this.loaderService.inpectionTypesList;
    this.inspectionsList=this.loaderService.inspectionsList;
    this.statusList=this.loaderService.statusList;
  }


  addInspection() {
    this.apiService.addInspecion({
      status: this.status,
      comments: this.comments,
      inspectionTypeId: this.inspectionTypeId
    }).subscribe(res => {
      var closeModalBtn = document.getElementById('add-modal-close');
      if (closeModalBtn) {
        closeModalBtn.click();
      }
      var showAddSuccess = document.getElementById('add-success-alert');
      if (showAddSuccess) {
        showAddSuccess.style.display = "block";
      }
      setTimeout(function () {
        if (showAddSuccess) {
          showAddSuccess.style.display = "none"
        }
      }, 4000)
    })
  }
}
