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

  ngOnInit(): void {
    this.produto = new Produto();
  }

  constructor(private produtoService: ProdutoService) {
  }

  public inputChange(files: FileList) {
    var arquivoSelecionado = files.item(0);
    this.produtoService.enviarArquivo(this.arquivoSelecionado).subscribe(
      data => {
        console.log(data);
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
