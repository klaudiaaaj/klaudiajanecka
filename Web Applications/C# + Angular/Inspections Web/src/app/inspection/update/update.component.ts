import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ConnectApiService } from 'src/app/connect-api.service';

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.css']
})
export class UpdateComponent implements OnInit {
  inpectionTypesList: any = [];
  inspectionsList: any = [];
  statusList: any = [];

  @Input() inspection: any;
  id: number = 0;
  status: string = "";
  comments: string = "";
  inspectionTypeId!: number;

  constructor(private apiService: ConnectApiService) { }

  ngOnInit(): void {
    this.loadInspections();
    this.getInspectionTypes();
    this.loadStatuses();
    console.log(this.inpectionTypesList)
    this.initalizeUpdateInspectionData();
  }

  getInspectionTypes() {
    this.apiService.getInspectionTypes().subscribe((response) => {
      console.log("types", response);
      this.inpectionTypesList = response;
    });
  }

  loadInspections() {
    this.apiService.getInspections().subscribe((response) => {
      console.log(response);
      this.inspectionsList = response;
    });
  }

  loadStatuses() {
    this.apiService.getStatuses().subscribe((response) => {
      console.log(response);
      this.statusList = response;
    });
  }

  updateInspection() {
    this.apiService.updateInspecion({
      status: this.status,
      comments: this.comments,
      inspectionTypeId: this.inspectionTypeId
    }, this.id).subscribe(() => {
      var closeModalBtn = document.getElementById('add-modal-close');
      if (closeModalBtn) {
        closeModalBtn.click();
      }
      var showUpdateSuccess = document.getElementById('update-success-alert');
      if (showUpdateSuccess) {
        showUpdateSuccess.style.display = "block";
      }
      setTimeout(function () {
        if (showUpdateSuccess) {
          showUpdateSuccess.style.display = "none"
        }
      }, 4000)
    })
  }

  initalizeUpdateInspectionData() {
    this.id = this.inspection.id;
    console.log("loaded id", this.inspection)

    this.status = this.inspection.status;
    this.comments = this.inspection.comments;
    this.inspectionTypeId = this.inspection.inspectionTypeId;
  }

}
