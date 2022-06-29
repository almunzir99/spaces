import { Directive, ElementRef, EventEmitter, HostListener, NgZone, Output } from '@angular/core';
import { fromEvent } from 'rxjs';

@Directive({
  selector: '[RippleEffect]'
})
export class RippleEffectDirective {

  element: HTMLElement;
  rippleOverlay: HTMLElement;
  reserved = false;
  constructor(elementRef: ElementRef) {
    this.element = elementRef.nativeElement as HTMLElement;
  }
  createRippleOverlay(xoffset: number, yoffset: number) {
    if(window.getComputedStyle(this.element).position != "relative" && window.getComputedStyle(this.element).position != "absolute")
    this.element.style.position = "relative";
    this.element.style.overflow = "hidden";
    this.rippleOverlay = document.createElement("div");
    this.rippleOverlay.style.height = `2px`;
    this.rippleOverlay.style.width = `2px`;
    this.rippleOverlay.style.borderRadius = `50%`;
    this.rippleOverlay.style.backgroundColor = "#ffffff35";
    this.rippleOverlay.style.position = "absolute";
    this.rippleOverlay.style.zIndex = "999";
    this.rippleOverlay.style.top = `${yoffset}px`;
    this.rippleOverlay.style.left = `${xoffset}px`;
    this.element.appendChild(this.rippleOverlay);
  }
  @HostListener("click", ['$event']) onClick($event) {
    if (this.reserved == true)
      return;
    this.reserved = true; 
    var bounds = $event.target.getBoundingClientRect();
    var x = $event.clientX - bounds.left;
    var y = $event.clientY - bounds.top;
    var maxScale = (bounds.height > bounds.width) ? bounds.height : bounds.width;
    this.createRippleOverlay(x, y);
    this.scaleAnimation(); 
    setTimeout(() => {
      this.reserved = false;
      this.element.removeChild(this.rippleOverlay);
    }, (maxScale * 10) / (maxScale / 55));
  }
  scaleAnimation() {
    var scale = 0;
    var bounds = this.element.getBoundingClientRect();
    var maxScale = (bounds.height > bounds.width) ? bounds.height : bounds.width;
    var id = null;
    clearInterval(id);
    id = setInterval(() => {
      if (scale >= maxScale) {
        clearInterval(id);
      }
      else {
        scale += (maxScale / 55);
        this.rippleOverlay.style.transform = `scale(${scale})`;
      }
    }, 10)

  }
  ngAfterViewInit() {
   
  }
}
