import { Injectable } from '@angular/core';
import { ConnectApiService } from './connect-api.service';

@Injectable({
  providedIn: 'root'
})
export class DataLoaderService {
  inpectionTypesList: any = [];
  inspectionsList: any = [];
  statusList: any = [];

  constructor(private apiService: ConnectApiService) {
    this.loadInitData() }

  loadInitData() {
    this.loadInspections();
    this.getInspectionTypes();
    this.loadStatuses();
  }

  getInspectionTypes() {
    this.apiService.getInspectionTypes().subscribe((response) => {
      this.inpectionTypesList = response;
    });
  }

  loadInspections() {
    this.apiService.getInspections().subscribe((response) => {
      this.inspectionsList = response;
      return response
    });
  }

  loadStatuses() {
    this.apiService.getStatuses().subscribe((response) => {
      this.statusList = response;
    });
  }
}
