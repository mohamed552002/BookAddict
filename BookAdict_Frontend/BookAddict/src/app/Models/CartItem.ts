export class CartItem
{
  constructor(public bookId:number , public imgUrl:string, public name:string, public singlePrice:number, public quantity:number = 1, public  userId:string ){}
}
