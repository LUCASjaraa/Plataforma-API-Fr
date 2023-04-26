export interface  puntosinteres {
  id           : string;
  escenario_id : string;
  categoria : string;
  titulo:string;
  descripcion : string;
  zona:string;
  fecha       : string;
  audio : string;
  img_evento: string;
  pos_evento  : Pos_evento;
  camera_pose : Camera_pose;
}

export interface Pos_evento {
  lat : number;
  lng : number;
  alt : number
}

export interface Camera_pose {
  head : number;
  pidch: number;
  roll : number;
}



export interface Datos_interes{

  interes_id:string
  titulo:string;
  imagen_url:string;
  descripcion:string;

}

export interface Galeria {

  usuario_id: string;
  galeria_id: string;
  tipo: string;
  contenido: string;
  likes        : [string];
  descripcion  : string;
  fecha_subida : string;
  aceptado     : boolean;

}

export interface Comentarios {

  usuario_id: string;
  comentario_id: string;
  titulo      : string;
  contenido   : string;
  likes        : [string];
  fecha_subida: string;
  aceptado    : boolean;

}

export interface Relato {

  usuario_id: string;
  relato_id: string;
  titulo: string;
  contenido : string;
  likes        : [string];
  fecha_subida: string;
  aceptado    : boolean;
}

export interface Valoraciones {
  usuario_id  : string;
  val_interes  : number;
  val_inmersion: number;
  fecha_val    : string;

}

export interface Memoria {
  usuario_id: string;
  memoria_id: string;
  titulo: string;
  img: [string],
  fechas: [string]
}

export interface Slider {
  url_antes   : string;
  url_despues : string;

}

export interface Visita {
  usuario_id   : string;
  fecha_visita  : string;

}


export interface editPuntosinteresDTO extends Partial<puntosinteres>{}
