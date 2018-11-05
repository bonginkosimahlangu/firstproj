import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { ManageAssetService } from '../manageasset.service';
import { ManageassetViewModel } from '../Models/manageasset';
import { UserViewModel } from '../Models/User';
import { AssetViewModel } from '../Models/Asset';
import { AssetService } from '../asset.service';
import { UsersService } from '../users.service';

@Component({
  selector: 'app-update-manage-asset',
  templateUrl: './update-manage-asset.component.html',
  styleUrls: ['./update-manage-asset.component.css']
})
export class UpdateManageAssetComponent implements OnInit {

  public allId: number;
  public ManageAssets: ManageassetViewModel;
  public Assets: AssetViewModel[];
  public Users: UserViewModel[];
  constructor(private route: ActivatedRoute, private _service: ManageAssetService, private a_service: AssetService, private u_service: UsersService, private router: Router) { }

  ngOnInit() {

    this._service.getManageAsset(this.route.snapshot.params['id']).subscribe((data: ManageassetViewModel) => {
      console.log(data);
      this.ManageAssets = data;
    }); 
 
  }


  update() {
    this._service.update(this.ManageAssets).subscribe((result) => {
      this.router.navigate(['/manageasset/']);
    }, (err) => {
      console.log(err);
    });
  }


  //listAsset() {
  //  this.a_service.getAssets().subscribe(assetsSerialNo => {
  //    this.Assets = assetsSerialNo
  //  }, error => console.error(error));
  //}

  //listUsers() {
  //  this.u_service.getUsers().subscribe(users => {
  //    this.Users = users
  //  }, error => console.error(error));
  //}

  

}





