import { Component, Input, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup,Validators } from '@angular/forms';
import { pcategoria } from '../../categoria/model/pcategoria';
import { puntosinteres } from '../model/puntointeres';
import { PcategoriaService } from '../../categoria/service/pcategoria/pcategoria.service';
import { PuntosinteresService } from '../service/puntosinteres/puntosinteres.service';


@Component({
  selector: 'app-formpuntosinteres',
  templateUrl: './formpuntosinteres.component.html',
  styleUrls: ['./formpuntosinteres.component.scss']
})
export class FormuntosinteresComponent implements OnInit {
  @Input() escenario_id:string = ""

  @Input() fPuntoIntres:puntosinteres = {
    id           : "",
    escenario_id : "",
    categoria    : "",
    titulo       : "",
    descripcion  : "",
    zona         : "",
    fecha        : "",
    audio        : "",
    img_evento   : "",
    pos_evento  :  {
      lat : 0,
      lng : 0,
      alt : 0,
    },
    camera_pose :  {
      head : 0,
      pidch: 0,
      roll : 0,
    }
  };

  puntointeresForm!:FormGroup;
  pCategoria:pcategoria[]=[]

  constructor(
    private readonly fb:FormBuilder,
    private pInteres:PuntosinteresService,
    private pcategoriaService:PcategoriaService ) { }

  ngOnInit(): void {

    this.puntointeresForm = this.initForm();

    this.puntointeresForm.patchValue({escenario_id:this.escenario_id})

    this.pcategoriaService
        .getPcategoria()
        .subscribe(data=>{
          this.pCategoria = data;
        });
        this.onPatchValue();
  }

  onPatchValue():void{
    this.puntointeresForm.patchValue(this.fPuntoIntres)
    //this.puntointeresForm.patchValue({fecha:"2020-02-12"})
  }



  oneFileaudio!: Blob;
  twoFileaudio!: Blob;
  oneFileimg!: Blob;
  twoFileimg!: Blob;
  fileimg_evento!: Blob;
  file_antes!: Blob;
  file_despues!: Blob;


  changeFiles(evt:any, type:any) {

    if(type=="oneFileaudio")   { this.oneFileaudio   = evt.target.files[0]; }
    if(type=="twoFileaudio")   { this.twoFileaudio   = evt.target.files[0]; }

    if(type=="oneFileimg")     { this.oneFileimg     = evt.target.files[0]; }
    if(type=="twoFileimg")     { this.twoFileimg     = evt.target.files[0]; }

    if(type=="fileimg_evento") { this.fileimg_evento = evt.target.files[0]; }

    if(type=="file_antes")     { this.file_antes     = evt.target.files[0]; }
    if(type=="file_despues")   { this.file_despues   = evt.target.files[0]; }
  }




  onSubmit():void{
    const formData = new FormData();


    formData.append('escenario_id', this.escenario_id);
    formData.append('categoria', this.puntointeresForm.get("categoria")?.value);
    formData.append('titulo', this.puntointeresForm.get("titulo")?.value);

    formData.append('descripcion', this.puntointeresForm.get("descripcion")?.value);
    formData.append('descripcion_corta', this.puntointeresForm.get("descripcion_corta")?.value);


    formData.append('zona', this.puntointeresForm.get("zona")?.value);
    formData.append('fecha', this.puntointeresForm.get("fecha")?.value);

    formData.append('oneFileaudio', this.oneFileaudio);
    formData.append('twoFileaudio', this.twoFileaudio);

    formData.append('oneFileimg', this.oneFileimg);
    formData.append('twoFileimg', this.twoFileimg);

    formData.append('fileimg_evento', this.fileimg_evento);

    formData.append('addescripcion', this.puntointeresForm.get("addescripcion")?.value);

    formData.append('file_antes', this.file_antes);
    formData.append('file_despues', this.file_despues);
    console.log(((this.puntointeresForm.get("head")?.value).toString()).replace('.', ','))


    formData.append('latitud', ((this.puntointeresForm.get("latitud")?.value).toString()).replace('.', ','));
    formData.append('longitud', ((this.puntointeresForm.get("longitud")?.value).toString()).replace('.', ','));
    formData.append('altura', ((this.puntointeresForm.get("altura")?.value).toString()).replace('.', ','));

    formData.append('head', ((this.puntointeresForm.get("head")?.value).toString()).replace('.', ','));
    formData.append('pitch', ((this.puntointeresForm.get("pitch")?.value).toString()).replace('.', ','));
    formData.append('roll', ((this.puntointeresForm.get("roll")?.value).toString()).replace('.', ','));



    console.log(this.puntointeresForm.value)
    console.log(formData)


    this.pInteres.addPuntoInteres(formData).subscribe(data=>{console.log(data)})
  }



  /**
   *
   *
   *
   *
   */
  initForm():FormGroup{
    return this.fb.group({

      categoria:['',[Validators.required]],
      titulo:['',[Validators.required]],

      descripcion:['',[Validators.required]],
      descripcion_corta:['',[Validators.required]],

      zona:['',[Validators.required]],
      fecha:['',[Validators.required]],

      oneFileaudio:['',[Validators.required]],
      twoFileaudio:['',[Validators.required]],

      oneFileimg:['',[Validators.required]],
      twoFileimg:['',[Validators.required]],

      fileimg_evento:['',[Validators.required]],

      addescripcion:['',[Validators.required]],

      file_antes:['',[Validators.required]],
      file_despues:['',[Validators.required]],

      latitud:[0,[Validators.required]],
      longitud:[0,[Validators.required]],
      altura:[0,[Validators.required]],

      head:[0,[Validators.required]],
      pitch:[0,[Validators.required]],
      roll:[0,[Validators.required]],

    })
  }





}
/*
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup,Validators } from '@angular/forms';
import { SubirarchivoService } from '../service/subirarchivo/subirarchivo.service';



@Component({
  selector: 'app-fgaleria',
  templateUrl: './formgaleria.component.html',
  styleUrls: ['./formgaleria.component.scss']
})
export class FgaleriaComponent implements OnInit {
  galeriaForm!:FormGroup;
  constructor(private readonly fb: FormBuilder,
              private subirarchivoService:SubirarchivoService)
              {}
  ngOnInit() : void {

    this.galeriaForm = this.initForm();

  }

  fileToUpload!: Blob;
  changeFile(evt:any) {
     this.fileToUpload = evt.target.files[0];
  }

  initForm():FormGroup{
    return this.fb.group({
      file: this.fb.control(null),
      usuario_id:['637691b6ab9ffb9d80d0f5e5',[Validators.required]],
      descripcion:['buena foto',[Validators.required]],
      fecha_subida:['2022/01/20',[Validators.required]],
    })
  }

  submit(): void {
     const formData = new FormData();
     formData.append('archivo', this.fileToUpload);
     formData.append('tipo', this.fileToUpload.type);
     formData.append('usuario_id', this.galeriaForm.get("usuario_id")?.value);
     formData.append('descripcion', this.galeriaForm.get("descripcion")?.value);
     formData.append('fecha_subida', this.galeriaForm.get("fecha_subida")?.value);
     console.log(this.fileToUpload);
     this.subirarchivoService.subirArchivo(formData).subscribe(data=>{console.log(data)});
  }
}




  initPos_evento():FormGroup{
    return this.fb.group({
      lat: ['',[Validators.required]],
      lng: ['',[Validators.required]],
      alt: ['',[Validators.required]],
    })
  }

  initCamera_pose():FormGroup{
    return this.fb.group({
      head: ['',[Validators.required]],
      pitch: ['',[Validators.required]],
      roll: ['',[Validators.required]],
    })
  }

  initSlider(): FormGroup{
    return this.fb.group({
      url_antes:['',[Validators.required]],
      url_despues:['',[Validators.required]]
    });
  }




*/
