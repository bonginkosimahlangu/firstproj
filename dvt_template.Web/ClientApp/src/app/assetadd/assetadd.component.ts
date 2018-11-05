import { Component, OnInit } from '@angular/core';

import { NgForm } from '@angular/forms';
import { AssetViewModel } from '../Models/Asset';
import { AssetService } from '../asset.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-assetadd',
  templateUrl: './assetadd.component.html',
  styleUrls: ['./assetadd.component.css']
})
export class AssetaddComponent implements OnInit {
  public asset: AssetViewModel;

  SerialNumber: number;
  AssetModel: string;
  AssetTypeId: number;

  myform: any;

  constructor(private _service: AssetService, private location: Location) { }

  ngOnInit() {
    //this.resetForm();
  }

  resetForm(form?: NgForm) {
    if (form != null)
      form.reset();
    this._service.asset = {
      SerialNumber: null,
      AssetModel: '',
      AssetTypeId: null
    }
  }

  onSubmit(asset: AssetViewModel) {
    this.asset = { SerialNumber: this.SerialNumber, AssetModel: this.AssetModel, AssetTypeId: this.AssetTypeId };
    if (asset.SerialNumber == null) {
      this._service.addAsset(asset).subscribe(asset => {
        this.location.back();
      }, error => console.error(error));
      console.log("Form Submitted!", this.asset);
    }
    else {
      this._service.updateAsset(asset, asset.SerialNumber).subscribe(asset => {
        this.location.back();
      }, error => console.error(error));
      console.log("Form Submitted!", this.asset);
    };
  }

  goBack(): void {
    this.location.back();
  }

}
