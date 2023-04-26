
export interface Quiz {
    
    id?: string | undefined;
    instrucciones?: string;
    logo_trivia?: string;
    preguntas?: Pregunta[];
    puntajes?: Puntaje[];
    
}

export interface Pregunta {
    pregunta_id?: string | undefined;
    preguntaText: string;
    imagen: string[];
    explicacion: string;
    categoria?: string | undefined;
    dificultad: string;
    alternativas: Alternativa[];
}

export interface Puntaje {
    usuario_id?: string | undefined;
    puntaje: number;
    fecha: string;
    cantcorrectas: number;
    cantincorrectas: number;
}

export interface Alternativa {
    alternativaText: string;
    correcto: boolean;
}