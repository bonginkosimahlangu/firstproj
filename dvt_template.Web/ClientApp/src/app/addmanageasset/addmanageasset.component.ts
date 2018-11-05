import { Component, OnInit, Input } from '@angular/core';
import { AssetService } from '../asset.service';
import { AssetViewModel } from '../Models/Asset';
import { UsersService } from '../users.service';
import { UserViewModel } from '../Models/User';
import { error } from 'util';
import { ManageAssetService } from '../manageasset.service';
import { ManageassetViewModel } from '../Models/manageasset';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { Location } from '@angular/common';

@Component({
  selector: 'app-addmanageasset',
  templateUrl: './addmanageasset.component.html',
  styleUrls: ['./addmanageasset.component.css']
})
export class AddmanageassetComponent implements OnInit {
  public manageAsset: ManageassetViewModel;

  @Input() AllocationID: number; UserID: number; SerialNumber: number;  DateAllocated: Date;  AssetStatusID: number;


  public AssetsSerialNo: AssetViewModel[];
  public Users: UserViewModel[];
  constructor(private router: Router, private _service: ManageAssetService, private a_service: AssetService, private u_service: UsersService, private location: Location) { }

  ngOnInit() {

    this.listAsset();
    this.listUsers();
  }

  listAsset() {
    this.a_service.getAssets().subscribe(assetsSerialNo => {
      this.AssetsSerialNo = assetsSerialNo
    }, error => console.error(error));
  }

  listUsers() {
    this.u_service.getUsers().subscribe(users => {
      this.Users = users
    }, error => console.error(error));
  }

  onSubmit(manageAsset: ManageassetViewModel) {
    this.manageAsset = { AllocationID: this.AllocationID, UserID: this.UserID, SerialNumber: this.SerialNumber, DateAllocated:this.DateAllocated , AssetStatusID:this.AssetStatusID}
    this._service.addManageAsset(manageAsset).subscribe(manageAsset => {
      this.location.back();
      console.log(manageAsset);    
    }, error => console.error(error));   
    console.log("Form Submitted!", manageAsset); 
  }
 
}





