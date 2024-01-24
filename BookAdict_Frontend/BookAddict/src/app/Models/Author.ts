export class Author{
  constructor(name:string,Biography:string,ImageFile?:any,id?:number){
    this.id = id
    this.name = name
    this.Biography = Biography
    this.ImageFile = ImageFile
  }
  id:number
  name:string
  Biography:string
  ImageFile:any
  imageUrl:string

}
