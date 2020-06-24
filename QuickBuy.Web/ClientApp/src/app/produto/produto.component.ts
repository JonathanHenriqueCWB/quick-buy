import { Component, OnInit } from "@angular/core"; 
import { ProdutoService } from "../services/produto/produto.services";
import { Produto } from "../model/produto";

@Component({
  selector: 'app-produto',
  templateUrl: './produto.component.html',
  styleUrls: ['./produto.component.css']
})
export class ProdutoComponent implements OnInit {
  
  public produto: Produto;
  public arquivoSelecionado: File;
  public ativar_spinner: boolean;
  public mensagem: string;

  //Construtor e método OnInit
  ngOnInit(): void {
    this.produto = new Produto();
  }
  constructor(private produtoService: ProdutoService) {
  }

  //Sobe o arquivo de imagem para o servidor e salva o nome do arquivo
  public inputChange(files: FileList) {

    this.arquivoSelecionado = files.item(0);
    this.ativarSpinner();

    this.produtoService.enviarArquivo(this.arquivoSelecionado).subscribe(
      data => {
        this.produto.nomeArquivo = data;
        this.desativarSpinner();
      },
      err => {
        console.log(err);
        this.desativarSpinner();
      }
    );
  }

  public cadastrar() {
    this.ativarSpinner();
    this.produtoService.cadastrarProduto(this.produto).subscribe(
      data => {
        this.desativarSpinner();
        console.log(data);
      },
      err => {
        this.desativarSpinner();
        console.log(err.error);
        this.mensagem = err.error;
      }
    );
  }

  //Métodos somente para ativar e deativar o efeito do spinner
  public ativarSpinner() {
    this.ativar_spinner = true;
  }
  public desativarSpinner() {
    this.ativar_spinner = false;
  }
}
