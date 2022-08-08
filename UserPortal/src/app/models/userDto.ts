export class UserDto {
    id: number = 0;
    nome: string = "";
    sobrenome: string = "";
    email: string = "";
    dataNascimento: string = "";
    escolaridade: Escolaridade = 0;
}

export enum Escolaridade {
    Infantil = 1,
    Fundamental = 2,
    Médio = 3,
    Superior = 4
}