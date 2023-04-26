export interface  datos {
  id?: string | undefined;
  pos: ps;
  titulo:string;
  tipo :string;
  descripcion:  string;
  zona: string;
  fecha :string;
  img : Array<Img>;
  slider:any[];
}

export interface ps {
  lat: string;
  lng:string;
}

export interface Img {
  antes: string;
  justo_despues: string;
  ahora: string;
}

export interface Slider {
  antes: string;
  ahora: string;

}

export interface CreatetDTO extends Omit<datos, 'id' | 'category'> {
}
export interface UpDTO extends Partial<datos> {}
