import { Component, OnInit } from '@angular/core';
import { UsersService } from '../users.service';
import { UserViewModel } from '../Models/User';
import { Location } from '@angular/common';

@Component({
  selector: 'app-adduser',
  templateUrl: './adduser.component.html',
  styleUrls: ['./adduser.component.css']
})
export class AdduserComponent implements OnInit {

  public user: UserViewModel;
  id: number;
  FirstName: string;
  LastName: string;
  DepartmentId: string;

  myform: any;
  constructor(private _service: UsersService, private location:Location) { }

  ngOnInit() {
  }
  onSubmit(user: UserViewModel) {
    this.user = { id: this.id, FirstName: this.FirstName, LastName: this.LastName, DepartmentId: this.DepartmentId };
    if (user.id == null) {

      this._service.addUser(user).subscribe(user => {

      }, error => console.error(error));
      console.log("Form Submitted", this.user);

    }
    else {
      this._service.updateUser(user, user.id).subscribe(asset => {
        this.location.back();
      }, error => console.error(error));
      console.log("Form Submitted!", this.user);
    };
  }

  
}

