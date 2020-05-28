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

  public mensagem: string;
  public usuarioCadastrado: boolean;

  constructor(private usuarioService: UsuarioService) {
  }

  ngOnInit(): void {
    this.usuario = new Usuario();
  }

  public verificarSenha(): boolean {
    return this.usuario.senha === this.usuario.confirmaSenha;
  }

  public verificarFormulario(): boolean {
    return this.usuario.nome != null && this.usuario.nome != ""
      && this.usuario.sobrenome != null && this.usuario.sobrenome != ""
      && this.usuario.email != null && this.usuario.email != ""
      && this.usuario.senha != null && this.usuario.senha != ""
      && this.usuario.confirmaSenha != null && this.usuario.confirmaSenha != ""
      && this.verificarSenha();
  }

  public cadastrar() {
    this.ativar_spinner = true;
        this.usuarioService.cadastrarUsuario(this.usuario).subscribe(
      data => {
        console.log(data);
        this.usuarioCadastrado = true;
        this.mensagem = "";
        this.ativar_spinner = false;
      },
      err => {
        console.log(err);
        this.usuarioCadastrado = false;
        this.mensagem = err.error;
      }
    );
  }
}
