import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthService } from 'src/app/auth.service';
import { ConnectApiService } from 'src/app/connect-api.service';

@Component({
  selector: 'app-get',
  templateUrl: './get.component.html',
  styleUrls: ['./get.component.css']
})
export class GetComponent implements OnInit {

  inpectionList$!: Observable<any[]>;
  inpectionTypesList$!: Observable<any[]>;
  inpectionTypesList: any = [];
  inspectionsList: any = [];

  modalTitle: string = '';
  activateAddInspectionsComponent: boolean = false;
  activateEditInspectionsComponent: boolean = false;
  logedIn: boolean =false;

  inspection: any;
  inpectionTypesMap: Map<number, string> = new Map()

  constructor(private apiService: ConnectApiService, private auth: AuthService) { }

  ngOnInit(): void {

    if (this.auth.tokenExpired()) {
      this.loadInspections();
      this.getInspectionTypes();
      this.refreshInpectionTypesMap();
      this.logedIn=true;
    } else {
      var showDeleteSuccess = document.getElementById('unloged');
      if(showDeleteSuccess){
        showDeleteSuccess.style.display="block";
      }

    }
  }

  getInspectionTypes() {
    this.apiService.getInspectionTypes().subscribe((response) => {
      console.log(response);
      this.inpectionTypesList = response;
    });
  }

  loadInspections() {
    this.apiService.getInspections().subscribe((response) => {
      this.inspectionsList = response;
    });
  }

  refreshInpectionTypesMap() {
    this.apiService.getInspectionTypes().subscribe(data => {
      this.inpectionTypesList = data;
      for (let i = 0; i < data.length; i++) {
        this.inpectionTypesMap.set(this.inpectionTypesList[i].id,
          this.inpectionTypesList[i].inspectionName)
      }
    });

  }

  modalAdd() {
    this.inspection = {
      id: 0,
      status: null,
      commnets: null,
      inspectionTypeId: null
    }
    this.modalTitle = "Add new inspection";
    this.activateAddInspectionsComponent = true;
  }

  modalTypes() {
    this.modalTitle = "Inspection Types";
  }

  modalClose() {
    this.activateAddInspectionsComponent = false;
    this.activateEditInspectionsComponent = false;
    console.log(this.activateEditInspectionsComponent,  this.activateAddInspectionsComponent);
    this.inspectionsList = this.loadInspections();
  }

  modalUpdate(inspection: any) {
    this.activateEditInspectionsComponent = true;
    this.inspection = inspection;
  }

  delete(id: number) {
    this.apiService.deleteInspecion(id).subscribe(() => this.loadInspections());
    var showDeleteSuccess = document.getElementById('delete-success-alert');

    if(showDeleteSuccess){
      showDeleteSuccess.style.display="block";
    }

    setTimeout(function(){
      if(showDeleteSuccess)
      {
        showDeleteSuccess.style.display="none"
      }
    }, 4000)
  }
}
