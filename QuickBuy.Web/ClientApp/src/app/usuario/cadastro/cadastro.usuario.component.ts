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

  constructor(private usuarioService: UsuarioService) {
  }

  ngOnInit(): void {
    this.usuario = new Usuario();
  }

  public verificarSenha(): boolean {
    return this.usuario.senha === this.usuario.confirmaSenha;
  }

  public cadastrar() {
    this.usuarioService.cadastrarUsuario(this.usuario).subscribe(
      data => {

      },
      err => {

      }
    );
  }
}
