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

export interface editPuntosinteresDTO extends Partial<puntosinteres>{}


export interface CreatetDTO extends Omit<puntosinteres, 'id' | 'category' | 'pos_evento'|'camera_pose'|'audio'|'img_evento'> {

  latitud:number;
  longitud :number;
  altura :number;
  head :number;
  pitch :number;
  roll :number
  ile_antes:File;
  file_despues:File;
  fileaudio:File;
  fileimg_evento:File;

}
