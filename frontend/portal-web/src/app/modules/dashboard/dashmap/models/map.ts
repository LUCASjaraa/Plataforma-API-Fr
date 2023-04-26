export interface  map {
  id?:          string | undefined;
  escenario_id: string;
  categoria:    string;
  titulo:       string;
  descripcion:  string;
  zona:         string;
  fecha :       string;
  pos_evento :  Pos_evento;
}

export interface Pos_evento {
  lat: number;
  lng: number;
  alt: number;
}
