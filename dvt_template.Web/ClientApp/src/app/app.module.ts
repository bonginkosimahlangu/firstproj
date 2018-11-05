import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule,NgControl } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { AssetService } from './asset.service';
import { AssetComponent } from './asset/asset.component';
import { Component } from '@angular/core';
import { AdduserComponent } from './adduser/adduser.component';
import { AssetaddComponent } from './assetadd/assetadd.component';
import { UsersService } from './users.service';
import { UsersComponent } from './users/users.component';
import { ManageAssetService} from './manageasset.service'
import { AddmanageassetComponent } from './addmanageasset/addmanageasset.component';
import { ManageassetComponent } from './manageasset/manageasset.component';
import { UpdateManageAssetComponent } from './update-manage-asset/update-manage-asset.component';
import { DeleteManageAssetComponent } from './delete-manage-asset/delete-manage-asset.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    AssetaddComponent,
    AssetComponent,
    AdduserComponent,
    UsersComponent,
    AddmanageassetComponent,
    ManageassetComponent,
    UpdateManageAssetComponent,
    DeleteManageAssetComponent    
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    HttpModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'Assets', component: AssetComponent },
      { path: 'Users', component: AdduserComponent },
      { path: 'manageasset', component: ManageassetComponent },
      {path:'NewManageAsset', component:AddmanageassetComponent},
      { path: 'UserList', component: UsersComponent },
      {path:'updateManageAsset/:id', component:UpdateManageAssetComponent,pathMatch:'full'}, 
      { path: 'AssetAdd', component: AssetaddComponent },
      { path: 'UserAdd', component: AdduserComponent }

    ])
  ],
  providers: [UsersService,ManageAssetService,AssetService],
  bootstrap: [AppComponent]
})
export class AppModule { }
