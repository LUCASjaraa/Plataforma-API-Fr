export interface  datos2 {
  id?         : string | undefined;
  descripcion : string;
  fecha       : string;
  titulo      : string;
  tipo        : string;
  zona        : string;

  camera_pose : cam_pose;
  comentarios : com[];
  galeria     : gal[];
  memoria     : mem[];
  pos_camara  : pos_cam;
  pos_evento  : pos_cam;
  relatos     : relato[];
  slider      : slid[];
  valoraciones: val[];
  videos      : video[];
  visitas     : visita[];
 
}

export interface cam_pose {
  head : number;
  pidch: number;
  roll : number; 
}

export interface com {
  aceptado    : boolean;
  contenido   : string;
  fecha_subida: string;
  likes       : mg[];
  titulo      : string;
  usuario_id ?: string;
}

export interface mg {
  creationTime : string;
  increment    : number;
  machine      : number;
  pid          : number;
  timestamp    : number;

}

export interface gal {
  aceptado     : boolean;
  descripcion  : string;
  fecha_subida : string;
  likes        : mg[];
  url          : string;
  usuario_id  ?: string;
}

export interface mem {
  fechas      : string[];
  img_url     : string[];
  titulo      : string;
  usuario_id ?: string;
}

export interface pos_cam {
  lat : number;
  lng : number;
  alt?: number
}

export interface relato {
  aceptado    : boolean;
  descripcion : string;
  fecha_subida: string;
  likes       : mg;
  url         : string;
  usuario_id ?: string;
}

export interface slid {
  url_antes   : string;
  url_despues : string;

}

export interface val {
  fecha_val    : string;
  usuario_id  ?: string;
  val_inmersion: number;
  val_interes  : number;
  
}

export interface video {
  aceptado    : boolean;
  descripcion : string;
  fecha_subida: string;
  likes       : mg;
  url         : string;
  usuario_id ?: string;
}

export interface visita {
  fecha_visita  : string;
  usuario_id   ?: string;
}

