import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UsersService } from '../users.service';
import { UserViewModel } from '../Models/User';
import { NgForm } from '@angular/forms';



@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {
  public Users: UserViewModel[];

  constructor(private _service: UsersService) { }

  ngOnInit() {
    this._service.getUsers().subscribe(users => {
      this.Users = users
    }, error => console.error(error));
  }

  resetForm(form?: NgForm) {
    if (form != null)
      form.reset();
    this._service.user = {

      id: null,
      FirstName: '',
      LastName: '',
      DepartmentId: null

    }
  }

  ShowForEditUser(user: UserViewModel) {
    this._service.user = Object.assign({}, user);

  }


  onDelete(id: number) {
    if (confirm('Are you sure to delete this User record?') == true) {
      this._service.deleteUser(id)
      .subscribe(x => {
        this.ngOnInit();
      });
  }
}

 
 
}
  
