import { Component, OnInit, Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AssetService } from '../asset.service';
import { AssetViewModel } from '../Models/Asset';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-asset',
  templateUrl: './asset.component.html',
  styleUrls: ['./asset.component.css']
})
export class AssetComponent implements OnInit {
  public Assets: AssetViewModel[];

  constructor(private _service: AssetService) { }

  ngOnInit() {
    this._service.getAssets().subscribe(assets => {
      this.Assets = assets
    }, error=> console.error(error));
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

  showForEdit(asset : AssetViewModel) {
    this._service.asset = Object.assign({}, asset);
  }

  onDelete(id: number) {
    if(confirm('Are you sure to delete this record?') == true) {
      this._service.deleteAsset(id)
        .subscribe(x => {
          this.ngOnInit();
        });
    }
  }

  //addAsset(): void {}
}
