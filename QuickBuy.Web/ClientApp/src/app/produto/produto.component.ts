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

  ngOnInit(): void {
    this.produto = new Produto();
  }

  constructor(private produtoService: ProdutoService) {
  }

  public inputChange(files: FileList) {

    this.arquivoSelecionado = files.item(0);
    this.ativar_spinner = true;

    this.produtoService.enviarArquivo(this.arquivoSelecionado).subscribe(
      data => {
        this.produto.nomeArquivo = data;
        alert(this.produto.nomeArquivo);
        console.log("Retorno da web api: " + data);
        this.ativar_spinner = false;
      },
      err => {
        console.log(err);
      }
    );
  }

  public cadastrar() {
    /*
    this.produtoService.cadastrarProduto(this.produto).subscribe(
      data => {
        console.log("Json preenchido!");
      },
      err => {
        console.log("Erro no retorno do json " + err.error);
      }
    );
    */
  }
}
