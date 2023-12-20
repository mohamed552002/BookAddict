import { Directive, ElementRef, HostListener, Renderer2 } from '@angular/core';

@Directive({
  selector: '[appBoxHover]'
})
export class BoxHoverDirective {

  constructor(private element: ElementRef , private renderer:Renderer2) { }

@HostListener('mouseenter')  OnMouseEnter(){
  this.renderer.setStyle(this.element.nativeElement,"transform","translateY(-10px)")
  this.renderer.setStyle(this.element.nativeElement,"transition","0.4s")
  this.renderer.setStyle(this.element.nativeElement,"boxShadow","0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19)")
}
@HostListener('mouseleave')  OnMouseLeave(){
  this.renderer.setStyle(this.element.nativeElement,"transform","translateY(0)")
  this.renderer.setStyle(this.element.nativeElement,"transition","0.4s")
  this.renderer.setStyle(this.element.nativeElement,"boxShadow","none")
}
}
