import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, from } from 'rxjs';

import { Produto } from '../../model/produto';

@Injectable({
  providedIn: 'root'
})
export class ProdutoService {

  private _baseUrl: string;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._baseUrl = baseUrl;
  }

  public cadastrarProduto(produto: Produto): Observable<Produto> {

    const headers = new HttpHeaders().set('content-type', 'application/json');
    var body = {
      nome: produto.nome,
      descricao: produto.descricao,
      preco: produto.preco
    };
    return this.http.post<Produto>(this._baseUrl + "api/produto/cadastrar", body, { headers });
  }

  public alterarProduto(produto: Produto): Observable<Produto> {

    const header = new HttpHeaders().set('content-type', 'application/jeson');
    var body = {
      nome: produto.nome,
      descricao: produto.descricao,
      preco: produto.preco
    };
    return this.http.post<Produto>(this._baseUrl + "api/produto/alterar", body, { headers });
  }

  public deletarProduto(produto: Produto): Observable<Produto> {

    const headers = new HttpHeaders().set('content-type', 'application/json');
    var body = {
      nome: produto.nome,
      descricao: produto.descricao,
      preco: produto.preco
    }
    return this.http.post<Produto>(this._baseUrl + "api/produto/deletar", body, { headers });
  }
}
