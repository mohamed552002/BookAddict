export class ApplicationUser{
  constructor(public firstName :string , public lastName:string  , public email:string , public password:string){
    this.firstName = firstName,
    this.lastName = lastName,
    this.email = email,
    this.password = password
    this.userName = email
  }
  public userName:string
}
