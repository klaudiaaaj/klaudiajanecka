import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ConnectApiService {

  readonly localUrl = "https://localhost:7298/api";
  constructor(private http: HttpClient) { }

  //inpsections methods

  getInspections(): Observable<any[]> {
    return this.http.get<any>(this.localUrl + `/inspections`)
  }

  addInspecion(data: any) {
    return this.http.post<any>(this.localUrl + `/inspections`, data);
  }

  updateInspecion(data: any, id:number) {
    console.log("id", id)
    return this.http.put<any>(this.localUrl + `/inspections/${id}`, data);
  }

  deleteInspecion(id:number)
  {
    return this.http.delete(this.localUrl+ `/inspections/${id}`)
  }

   //inpsection types methods

   getInspectionTypes(): Observable<any[]> {
    return this.http.get<any>(this.localUrl + `/InspectionTypes`);
  }

  addInspecionType(data: any) {
    return this.http.post<any>(this.localUrl + `/InspectionTypes`, data);
  }

  updateInspecionType(data: any, id:number) {
    return this.http.put<any>(this.localUrl + `/InspectionTypes/${id}`, data);
  }

  deleteInspecionType(id:number)
  {
    return this.http.delete(this.localUrl+ `/InspectionTypes/${id}`)
  }


   //status methods

   getStatuses(): Observable<any[]> {
    return this.http.get<any>(this.localUrl + `/Status`);
  }

  addStatus(data: any) {
    return this.http.post<any>(this.localUrl + `/Status`, data);
  }

  updateStatus(data: any, id:number) {
    return this.http.put<any>(this.localUrl + `/Status/${id}`, data);
  }

  deleteStatus(id:number)
  {
    return this.http.delete(this.localUrl+ `/Status/${id}`)
  }

}
