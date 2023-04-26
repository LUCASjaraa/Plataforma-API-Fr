export interface datointeres{

      interes_id: string,
      titulo: string,
      descripcion: string

}


export interface datointeresDTO extends Omit<datointeres, 'interes_id'>{}
