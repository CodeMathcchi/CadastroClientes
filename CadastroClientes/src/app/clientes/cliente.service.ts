import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Cliente } from '../models/cliente';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {

  baseUrl = `${environment.UrlPrincipal}api/cliente/`;

  constructor(private http: HttpClient) { }

  getAll(): Observable<Cliente[]> {
    return this.http.get<Cliente[]>(this.baseUrl);
  }

  getById(clienteId: number): Observable<Cliente> {
    return this.http.get<Cliente>(`${this.baseUrl}${clienteId}`)
  }

  post(cliente: Cliente){
    return this.http.post(this.baseUrl, cliente);
  }

  put(clienteId: number, cliente: Cliente){
    return this.http.put(`${this.baseUrl}${clienteId}`, cliente);
  }

  delete(clienteId: number){
    return this.http.delete(`${this.baseUrl}${clienteId}`);
  }

  getEndereco(cep: string){
    console.log(cep);
    var urlApi = `https://cors-anywhere.herokuapp.com/https://viacep.com.br/ws/${cep}/json/`;
    return this.http.get(urlApi);
  }
}
