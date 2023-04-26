export interface comentarios{
   id: string,
  comentarios: [comentario]
}

export interface comentario {
    usuario_id: string,
    comentario_id: string,
    titulo: string,
    contenido: string,
    likes: [string],
    fecha_subida: string,
    aceptado: boolean
}
