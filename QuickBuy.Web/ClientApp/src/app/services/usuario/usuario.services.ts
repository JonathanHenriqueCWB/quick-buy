import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Usuario } from '../../model/usuario';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  // VARIAVEIS
  private baseURL: string;
  private _usuario: Usuario;

  //PROPERTIES
  set usuario(usuario: Usuario) {    
    sessionStorage.setItem('usuario-autenticado', JSON.stringify(usuario));
    this._usuario = usuario;
  }

  get usuario(): Usuario {
    let usuario_json = sessionStorage.getItem('usuario-autenticado');
    this._usuario = JSON.parse(usuario_json);
    return this._usuario;
  }

  // CONSTRUTOR
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseURL = baseUrl;
  }

  // METODOS
  public verificarSessao(): boolean {
    return this._usuario != null && this._usuario.email != "" && this.usuario.senha != "";
  }

  public limparSessao() {
    sessionStorage.setItem('usuario-autenticado', '');
    this._usuario = null;
  }

  public verificarUsuario(usuario: Usuario): Observable<Usuario> {
    const headers = new HttpHeaders().set('content-type', 'application/json');
    var body = {
      email: usuario.email,
      senha: usuario.senha
    }

    //this.baseURL = Raiz do site, exemplo: http://www.quickbuy.com/
    return this.http.post<Usuario>(this.baseURL + "api/usuario/veriricarUsuario", body, { headers });
  }

  public cadastrarUsuario(usuario: Usuario): Observable<Usuario> {
    const headers = new HttpHeaders().set('content-type', 'application/json');
    var body = {
      email: usuario.email,
      senha: usuario.senha,
      confirmarSenha: usuario.confirmaSenha,
      nome: usuario.nome,
      sobrenome: usuario.sobrenome
    }

    return this.http.post<Usuario>(this.baseURL + "api/usuario", body, { headers });
  }
}
