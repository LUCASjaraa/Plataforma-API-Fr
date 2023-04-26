import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup,Validators } from '@angular/forms';
import {formatDate} from '@angular/common';
import { SlidesService } from '../service/slides.service';
@Component({
  selector: 'app-formslides',
  templateUrl: './formslides.component.html',
  styleUrls: ['./formslides.component.scss']
})
export class FormslidesComponent implements OnInit {
  @Input() id:string = "";
  salidesFrom !:FormGroup;

  antesFile!:Blob;
  duranteFile!:Blob;
  jdespuesFile!:Blob;
  ahoraFile!:Blob;

  constructor(private readonly fb:FormBuilder,
              private slidesService:SlidesService) { }

  ngOnInit(): void {
    this.salidesFrom = this.initForm();
  }

  changeFiles(evt:any, type:any) {
    if(type=="antesFile")   { this.antesFile   = evt.target.files[0]; }
    if(type=="duranteFile")   { this.duranteFile   = evt.target.files[0]; }
    if(type=="jdespuesFile")     { this.jdespuesFile     = evt.target.files[0]; }
    if(type=="ahoraFile")     { this.ahoraFile     = evt.target.files[0]; }
  }

  initForm():FormGroup{

    return this.fb.group({
      usuario_id: ['',[Validators.required]],
      titulo:[''],

      antesFile:this.fb.control(null),
      antesfecha:[''],
      antesdescripcion:[''],

      duranteFile:this.fb.control(null),
      durantefecha:[''],
      durantedescripcion:[''],

      jdespuesFile: this.fb.control(null),
      jdespuesfecha:[''],
      jdespuesdescripcion:[''],

      ahoraFile: this.fb.control(null),
      ahorafecha:[''],
      ahoradescripcion:[''],

    })
  }
  ngSubmit(){
    const formData = new FormData();
    formData.append('usuario_id', "632a072930305800b2d85220");
    formData.append('titulo', this.salidesFrom.get("titulo")?.value);
    formData.append('fecha_subida', formatDate(new Date(), 'yyyy/MM/dd', 'en'));

    formData.append('antesFile', this.antesFile);
    formData.append('antesfecha', this.salidesFrom.get("antesfecha")?.value);
    formData.append('antesdescripcion', this.salidesFrom.get("antesdescripcion")?.value);

    formData.append('duranteFile', this.duranteFile);
    formData.append('durantefecha', this.salidesFrom.get("durantefecha")?.value);
    formData.append('durantedescripcion', this.salidesFrom.get("durantedescripcion")?.value);

    formData.append('jdespuesFile', this.jdespuesFile);
    formData.append('jdespuesfecha', this.salidesFrom.get("jdespuesfecha")?.value);
    formData.append('jdespuesdescripcion', this.salidesFrom.get("jdespuesdescripcion")?.value);

    formData.append('ahoraFile', this.ahoraFile);
    formData.append('ahorafecha', this.salidesFrom.get("ahorafecha")?.value);
    formData.append('ahoradescripcion', this.salidesFrom.get("ahoradescripcion")?.value);

    this.slidesService.addSlides(this.id,formData).subscribe(res=>{console.log(res)});

  }

}


/*

        [Required(ErrorMessage = "El usuario_id es requerido")]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? usuario_id { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? slide_id { get; set; }
        [Required(ErrorMessage = "El titulo es requerido")]
        public string? titulo { get; set; }


        public IFormFile? antesFile        { get; set; }
        public string?    antesfecha       { get; set; }
        public string?    antesdescripcion { get; set; }


        public IFormFile? duranteFile          { get; set; }
        public string?    durantefecha         { get; set; }
        public string?    durantedescripcion   { get; set; }



        public IFormFile? jdespuesFile        { get; set; }
        public string?    jdespuesfecha       { get; set; }
        public string?    jdespuesdescripcion { get; set; }


        public IFormFile? ahoraFile        { get; set; }
        public string?    ahorafecha       { get; set; }
        public string?    ahoradescripcion { get; set; }

        public List<string>? img { get; set; }
        public List<string>? fechas { get; set; }
        public List<string>? descripciones { get; set; }

        [Required(ErrorMessage = "la fecha_subida es requerida")]
        public string? fecha_subida { get; set; }

0 - antes 1 - durante 2- justo despues  3- ahora

*/
