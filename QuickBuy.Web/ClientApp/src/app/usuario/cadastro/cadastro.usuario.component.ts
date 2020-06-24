import { Component, OnInit } from '@angular/core';
import { Usuario } from '../../model/usuario';
import { UsuarioService } from '../../services/usuario/usuario.services';

@Component({
  selector: 'app-cadastro-usuario',
  templateUrl: './cadastro.usuario.component.html',
  styleUrls: ['./cadastro.usuario.component.css']
})
export class CadastroUsuarioComponent implements OnInit {    

  public usuario: Usuario;
  public ativar_spinner: boolean;

  //Propriedade que recebera um possivel erro da Web API (Uma string de exeception)
  public mensagem: string;
  //Propriedade para renderizar um link no template
  public usuarioCadastrado: boolean;

  constructor(private usuarioService: UsuarioService) {
  }

  ngOnInit(): void {
    this.usuario = new Usuario();
  }

  //Método compara as senhas para desbloquear o formulario
  public verificarSenha(): boolean {
    return this.usuario.senha === this.usuario.confirmaSenha;
  }

  //Método analisa o formulario para poder desbloquear o btn do formulario
  public verificarFormulario(): boolean {
    return this.usuario.nome != null && this.usuario.nome != ""
      && this.usuario.sobrenome != null && this.usuario.sobrenome != ""
      && this.usuario.email != null && this.usuario.email != ""
      && this.usuario.senha != null && this.usuario.senha != ""
      && this.usuario.confirmaSenha != null && this.usuario.confirmaSenha != ""
      && this.verificarSenha();
  }

  public cadastrar() {
    this.ativarSpinner();
    this.usuarioService.cadastrarUsuario(this.usuario).subscribe(
      data => {
        console.log(data);
        this.usuarioCadastrado = true;
        this.mensagem = "";
        this.desativarSpinner();
      },
      err => {
        console.log(err);
        this.usuarioCadastrado = false;
        this.mensagem = err.error;
        this.desativarSpinner();
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
