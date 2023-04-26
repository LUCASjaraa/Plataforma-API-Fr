export interface comentario {
    usuario_id: string,
    comentario_id: string,
    titulo: string,
    contenido: string,
    likes: [string],
    fecha_subida: string,
    aceptado: boolean
}




export interface comentarioDTO extends Omit<comentario, 'comentario_id' | 'likes' | 'aceptado'> {
}
