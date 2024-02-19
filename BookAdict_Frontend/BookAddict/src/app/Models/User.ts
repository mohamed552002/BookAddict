

export class User{
  constructor(public firstName,public lastName, public email:string , public roles:string[] , private _token:string , private _tokenExpiresOn:Date, public isAuthenticated:boolean ,public message?){}
  get token(){
    if(!this._tokenExpiresOn || new Date() > this._tokenExpiresOn)
      return null;
    return this._token;
  }
}
