import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ManageassetViewModel } from './Models/manageasset';
import { HttpModule } from '@angular/http';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};


@Injectable()
export class ManageAssetService {
  baseUrl: string;
  public manageaseets: ManageassetViewModel[];
  public manageasset: ManageassetViewModel;
  public manageassetsURL = 'api/ManageAssets/GetManageAssets';
  public manageassetURL = 'api/ManageAssets/GetAssetById/?id=';
  public addmanageassetURL = 'api/ManageAssets/NewManageAsset/';
  public updatemanageassetURL = 'api/ManageAssets/ManageAsset/';
  public deletemanageassetURL = 'api/ManageAssets/DeleteManageAsset/?id=';

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl
  }

  getManageAssets() {
    return this.http.get<ManageassetViewModel[]>(this.manageassetsURL);
  }

  getManageAsset(id: number) {
    return this.http.get<ManageassetViewModel>(this.manageassetURL+id);
  }

  addManageAsset(manageasset: ManageassetViewModel) {
    return this.http.post<ManageassetViewModel>(this.addmanageassetURL, manageasset);
  }

  update(manageasset: ManageassetViewModel) {
    return this.http.put<ManageassetViewModel>(this.updatemanageassetURL, manageasset);
  }

  deleteManageAsset(ids:number){
    return this.http.delete<ManageassetViewModel>(this.deletemanageassetURL+ids, httpOptions)    
  }

}
