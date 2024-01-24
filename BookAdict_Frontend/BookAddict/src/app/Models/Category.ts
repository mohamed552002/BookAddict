export class Category{
  constructor(Name:string , IsActive:boolean, Description:string,Id?:number){
    this.Id = Id
    this.Name = Name;
    this.IsActive = IsActive;
    this.Description = Description;
  }
  Id:number
  Name:string;
  IsActive:boolean;
  Description:string;
}
