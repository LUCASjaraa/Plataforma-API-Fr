
export interface escenario{
  id: string;
  titulo: string;
  short_descrip : string;
  long_descrip: string;
  ciudades: [string];
  slides : [slides];
  lat_long: [lat_lng];

}

export interface slides{
  slide_id : string;
  titulo   : string;
  img_url  : string;
  fecha    : string
}


export interface lat_lng{
  lat: number;
  lng: number;
}


export interface AddEscenario extends Partial<Omit<escenario, 'id'>>{}

export interface viewEscenario extends Partial<Omit<escenario, 'id' | 'long_descrip' | 'lat_long' >> {}

export interface editEscenariDTO extends Partial<escenario>{}

export interface slideDTO{
  titulo   : string;
  file  : Blob;
  fecha    : string

}
export interface addSlide
{
  file:Blob;
  index:number;

}


export interface addescenario{
  id: string;
  titulo: string;
  short_descrip : string;
  long_descrip: string;
  ciudades: [string];
  slides : [sslides];
  lat_long: [lat_lng];

}

export interface sslides{

  titulo   : string;
  img_url  : Blob;
  fecha    : string
}
