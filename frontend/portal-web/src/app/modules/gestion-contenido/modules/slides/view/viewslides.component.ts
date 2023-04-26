import { Component, Input, OnInit } from '@angular/core';
import { slides } from '../model/slides';
import { SlidesService } from '../service/slides.service';
import { PageEvent } from '@angular/material/paginator';
@Component({
  selector: 'app-viewslides',
  templateUrl: './viewslides.component.html',
  styleUrls: ['./viewslides.component.scss']
})
export class ViewslidesComponent implements OnInit {
  @Input() id:string = "";
  slides:slides[] = []
  vSlides:boolean = true;
  page_zise : number = 1;
  page_number:number = 1;

  constructor(private slidesService:SlidesService) { }

  ngOnInit(): void {
    this.slidesService.getSlides(this.id)
    .subscribe(data => {
      this.slides = data;
    })
  }
  addSlides(){
    this.vSlides =!this.vSlides;
  }
  handlePage(e:PageEvent){
    this.page_zise   = e.pageSize;
    this.page_number = e.pageIndex + 1
  }

}
