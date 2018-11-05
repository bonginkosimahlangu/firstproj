import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ManageAssetService } from '../manageasset.service';
import { ManageassetViewModel } from '../Models/manageasset';
import { RouterOutlet, ActivatedRoute } from '@angular/router';
import { error } from 'protractor';

@Component({
  selector: 'app-manageasset',
  templateUrl: './manageasset.component.html',
  styleUrls: ['./manageasset.component.css']
})
export class ManageassetComponent implements OnInit {

  public allId: number;
  public ManageAssets: ManageassetViewModel[];
  public manageAsset: ManageassetViewModel;

  constructor(private route: ActivatedRoute, private _service: ManageAssetService, private service: ManageAssetService) {}

  
  ngOnInit() {
    this._service.getManageAssets().subscribe(assets => {
      this.ManageAssets = assets,
        console.log(this.ManageAssets)
    }, error => console.error(error));
     
  }

  delete(allId) {
    if (window.confirm('Are you sure you want to delete this item with Id:'+allId+'?')) {
      this.service.deleteManageAsset(allId).subscribe(manage => {
        location.reload();
      console.log(this.manageAsset)
      }, error => console.error(error));
      location.reload();
    }
    location.reload();
    console.log(allId);
  }

}
