import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { UserViewModel } from './Models/User';


@Injectable()
export class UsersService {
  baserUrl: string;
  public users: UserViewModel[];
  public user: UserViewModel;
  public usersURL = 'api/User/GetAllUsers';
  public userURL = 'api/User/GetUserById';
  public adduserUrl = 'api/User/AddUser/';
  public deleteUserURL = 'api/User/DeleteUser/?id=';
  public updateUserURL = 'api/User/UpdateUser/?id=';



  constructor(private http: HttpClient, @Inject('BASE_URL') baserUrl: string) {
    this.baserUrl = baserUrl
  }

  getUsers() {
    return this.http.get<UserViewModel[]>(this.usersURL);

  }
  getUser(id) {
    return this.http.get<UserViewModel>(this.userURL + `/${id}`);
  }

  addUser(user: UserViewModel) {
    return this.http.post<UserViewModel>(this.adduserUrl, user)
  }

  updateUser(user: UserViewModel, id: number) {
    return this.http.put<UserViewModel>(this.updateUserURL + id, user);
  }

  deleteUser(id: number) {
    return this.http.delete<UserViewModel>(this.deleteUserURL + id)
  }
}
