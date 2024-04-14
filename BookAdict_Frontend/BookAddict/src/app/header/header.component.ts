import { Component, OnChanges, OnDestroy, OnInit, SimpleChanges } from '@angular/core';
import { AuthApis } from '../server/Auth.services';
import { faCartShopping,faTrash } from '@fortawesome/free-solid-svg-icons';
import { Subscription } from 'rxjs';
import { User } from '../Models/User';
import { CartApis } from '../server/CartApi.Services';
import { CartItem } from '../Models/CartItem';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent implements OnInit , OnDestroy {


  isAuthenticated:boolean = false;
  user:User;
  cartStatus = {
    Added:false,
    AddedPreviously:false,
    Removed:false
  }
  private userSub:Subscription;
  constructor(private authApis:AuthApis ){}
  //#region OnInit
  ngOnInit(){
    this.userSub = this.authApis.user.subscribe(user => {
      this.isAuthenticated = !!user
      console.log(user)
      this.user = user
    })
  }
  //#endregion

  //#region GetCartItems

  //#endregion
//#region Logout
LogOut(){
  localStorage.removeItem("User");
  localStorage.removeItem("jwtToken");
  this.isAuthenticated = false;
}
//#endregion

//#region Destroy
  ngOnDestroy(): void {
    this.userSub.unsubscribe();
  }
  //#endregion

}
