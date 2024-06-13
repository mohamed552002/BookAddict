import { Injectable } from "@angular/core";
import { BaseApi } from "../BaseApi";
import { HttpClient, HttpParams } from "@angular/common/http";
import { CheckoutDto } from "../../Models/CheckOutDto";
import { Observable } from "rxjs";
import { ConfirmOrderReturn } from "../../Models/ConfirmOrderReturn";

@Injectable({
  providedIn:"root"
})
export  class OrderApis extends BaseApi{
  apiUrl = this.localhost + "api/Order/"
  /**
   *
   */
  constructor(private http:HttpClient) {
    super();
  }
  ConfirmOrder(checkoutDto:CheckoutDto):Observable<ConfirmOrderReturn>{
    return this.http.post<ConfirmOrderReturn>(this.apiUrl+"ConfirmOrder/",checkoutDto.cart,{
      params: new HttpParams().set("isCashPayment",checkoutDto.isCash).set("userId",checkoutDto.userId)
    })
  }
}
