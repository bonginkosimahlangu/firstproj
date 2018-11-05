import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { AssetViewModel } from './Models/Asset';

@Injectable()
export class AssetService {
  baseURL: string;
  public assets: AssetViewModel[];
  public asset: AssetViewModel;
  public assetsURL = 'api/Assets/GetAllAssets';
  public assetURL = 'api/Assets/GetAssetById';
  public addassetURL = 'api/Assets/AddAsset/';
  public deleteAssetURL = 'api/Assets/Delete/?id=';
  public updateAssetURL = 'api/Assets/UpdateAsset/?id=';

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseURL = baseUrl
  }

  getAssets() {
    return this.http.get<AssetViewModel[]>(this.assetsURL);
  }

  getAsset(id: number) {
    return this.http.get<AssetViewModel>(this.assetURL + id);
  }

  addAsset(asset: AssetViewModel) {
    return this.http.post<AssetViewModel>(this.addassetURL, asset);
  }

  updateAsset(asset: AssetViewModel, id: number) {
    return this.http.put<AssetViewModel>(this.updateAssetURL + id, asset);
  }

  deleteAsset(id: number) {
    return this.http.delete<AssetViewModel>(this.deleteAssetURL + id)
  }
  
}
