import { CartItem } from "./CartItem";

export class CheckoutDto{

  constructor(public cart:CartItem[] , public isCash:boolean , public userId:string) {}
}
