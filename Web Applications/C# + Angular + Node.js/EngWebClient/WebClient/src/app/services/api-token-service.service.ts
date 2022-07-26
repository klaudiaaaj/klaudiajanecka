import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import IdTokenPostDto, { IdTokenGetDto } from '../models/IdTokenDto';
import { Platform } from './../models/PlatformDto';
import { ApiUserServiceService } from './api-user-service.service';

@Injectable({
  providedIn: 'root'
})
export class ApiTokenServiceService extends ApiUserServiceService{

  constructor(protected httpClient: HttpClient) { 
    super(httpClient)
  }
  createIdToken(idToken: IdTokenPostDto): Observable<IdTokenGetDto> {
    return this.httpClient.post<IdTokenGetDto>(environment.baseUrl+`/IdTokens`, idToken);     
  }

  getPlatformList(): Observable<Platform[]>{ 
    return this.httpClient.get<Platform[]>(environment.baseUrl+'/Platforms'); 
  }
}
