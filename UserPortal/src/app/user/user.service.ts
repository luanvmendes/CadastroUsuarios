import { formatDate } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserDto } from '../models/userDto';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  actionUrl = 'https://localhost:44307/api/Users';

  constructor(private http: HttpClient) { }

  listar() {
    return this.http.get<any[]>(`${this.actionUrl}`);
  }

  getById(id: number) {
    return this.http.get<any[]>(`${this.actionUrl}/${id}`);
  }

  adicionar(user: UserDto) {
    user.dataNascimento = formatDate(new Date(user.dataNascimento), 'yyyy-MM-dd', 'en-US');
    return this.http.post(`${this.actionUrl}`, JSON.stringify(user), {
      headers: {
        'Content-Type': 'application/json'
      }
    });
  }

  editar(user: UserDto) {
    user.dataNascimento = new Date(user.dataNascimento).toLocaleDateString();
    return this.http.put(`${this.actionUrl}`, JSON.stringify(user), {
      headers: {
        'Content-Type': 'application/json'
      }
    });
  }

  remover(id: number) {
    return this.http.delete(`${this.actionUrl}/${id}`);
  }

}
