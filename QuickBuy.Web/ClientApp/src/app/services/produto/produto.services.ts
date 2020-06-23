import { Injectable, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, from } from 'rxjs';

import { Produto } from '../../model/produto';

@Injectable({
  providedIn: 'root'
})
export class ProdutoService implements OnInit {

  //VARIVAEIS
  private _baseUrl: string;
  public produtos: Produto[];

  //PROPRIEDADE
  get headers(): HttpHeaders {
    return new HttpHeaders().set('content-type', 'application/json');
  }

  //CONSTRUTOR COM INJEÇÃO DE DEPENDENCIA
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._baseUrl = baseUrl;
  }

  //MÉTODO IMPLEMENTADO DO ONINIT
  ngOnInit(): void {
    this.produtos = [];
  }

  //MÉTODOS
  public cadastrarProduto(produto: Produto): Observable<Produto> {
    return this.http.post<Produto>(this._baseUrl + "api/produto/", JSON.stringify(produto), { headers: this.headers });
  }

  public alterarProduto(produto: Produto): Observable<Produto> {
    return this.http.post<Produto>(this._baseUrl + "api/produto/alterar", JSON.stringify(produto), { headers: this.headers });
  }

  public deletarProduto(produto: Produto): Observable<Produto> {
    return this.http.post<Produto>(this._baseUrl + "api/produto/deletar", JSON.stringify(produto), { headers: this.headers });
  }

  public listarProduto(): Observable<Produto[]> {
    return this.http.get<Produto[]>(this._baseUrl + "api/produto");
  }

  public obterProduto(produto: Produto): Observable<Produto> {
    return this.http.get<Produto>(this._baseUrl + "api/produto");
  }

  public enviarArquivo(arquivoSelecionado: File): Observable<string> {

    //Criação de um IformData para o arquivo, deverá ser recuperado num formFile no ProdutoController
    const formData: FormData = new FormData();
    formData.append("arquivoEnviado", arquivoSelecionado, arquivoSelecionado.name);

    return this.http.post<string>(this._baseUrl + "api/produto/enviarArquivo", formData);
  }
}
