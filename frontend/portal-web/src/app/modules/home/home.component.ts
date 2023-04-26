import { Component, OnInit, ViewChild } from '@angular/core';
import {
    KtdDragEnd,
    KtdDragStart,
    KtdGridComponent,
    KtdGridLayout,
    KtdGridLayoutItem,
    KtdResizeEnd,
    KtdResizeStart,
    ktdTrackById
} from '@katoid/angular-grid-layout';

declare const $: any;

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
 //   @ViewChild(KtdGridComponent, {static: true}) grid: KtdGridComponent;
    trackById = ktdTrackById
    cols = 6;
    rowHeight = 100;
    compactType: 'vertical' | 'horizontal' | null = 'vertical';

    layout: KtdGridLayout = [
        {id: '0', x: 0, y: 0, w: 3, h: 3},
        {id: '1', x: 3, y: 0, w: 3, h: 3},
        {id: '2', x: 0, y: 3, w: 3, h: 3},
        {id: '3', x: 3, y: 3, w: 3, h: 3},
    ];
    transitions: { name: string, value: string }[] = [
        {name: 'ease', value: 'transform 500ms ease, width 500ms ease, height 500ms ease'},
        {name: 'ease-out', value: 'transform 500ms ease-out, width 500ms ease-out, height 500ms ease-out'},
        {name: 'linear', value: 'transform 500ms linear, width 500ms linear, height 500ms linear'},
        {
            name: 'overflowing',
            value: 'transform 500ms cubic-bezier(.28,.49,.79,1.35), width 500ms cubic-bezier(.28,.49,.79,1.35), height 500ms cubic-bezier(.28,.49,.79,1.35)'
        },
        {name: 'fast', value: 'transform 200ms ease, width 200ms linear, height 200ms linear'},
        {name: 'slow-motion', value: 'transform 1000ms linear, width 1000ms linear, height 1000ms linear'},
        {name: 'transform-only', value: 'transform 500ms ease'},
    ];
    currentTransition: string = this.transitions[0].value;
  constructor() { }

  ngOnInit(): void {

  }

  onLayoutUpdated(layout: KtdGridLayout) {
    console.log('on layout updated', layout);
    this.layout = layout;
}

}
