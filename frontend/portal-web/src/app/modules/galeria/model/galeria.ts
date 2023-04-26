export interface galerias{
    id: string,
    galeria: [galeria]
}

export interface galeria{
    usuario_id: string,
    galeria_id: string,
    tipo: string,
    contenido: string,
    likes: [string],
    descripcion: string,
    fecha_subida: string,
    aceptado: boolean
  
  }