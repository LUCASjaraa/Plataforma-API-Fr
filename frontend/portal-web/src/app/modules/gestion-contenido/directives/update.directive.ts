import { Directive, Input, OnChanges, SimpleChanges, TemplateRef, ViewContainerRef } from '@angular/core';

@Directive({
  selector: '[appUpdate]'
})
export class UpdateDirective implements OnChanges
{

  @Input() appUpdate !:number;

  constructor(
    private templateRef: TemplateRef<any>,
    private viewContainerRef: ViewContainerRef)
    { }
    ngOnChanges(changes: SimpleChanges): void {
        if(changes["appUpdate"] && changes["appUpdate"].previousValue != undefined){
          this.viewContainerRef.clear();
          this.viewContainerRef.createEmbeddedView(this.templateRef);
        }
    }
}

