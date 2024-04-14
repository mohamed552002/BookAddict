export class CartItem
{
  constructor(public bookId:number , public imgUrl:string, public name:string, public price:number, public numberOfItems:number = 1, public  userId:string ){}
}
