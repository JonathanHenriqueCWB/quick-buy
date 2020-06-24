import { Component, OnInit } from "@angular/core"; 
import { Router, ActivatedRoute } from "@angular/router"

import { Usuario } from "../../model/usuario";
import { UsuarioService } from "../../services/usuario/usuario.services";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.css"]
})
export class LoginComponent implements OnInit {

  public usuario;
  public returnUrl: string;
  public mensagem: string
  public ativar_spinner: boolean;

  constructor(private router: Router, private activateRouter: ActivatedRoute, private usuarioService: UsuarioService) {
  }

  ngOnInit(): void {
    this.usuario = new Usuario();
    this.returnUrl = this.activateRouter.snapshot.queryParams['returnUrl'];
  }

  //Método criado para testar o two-way data binding
  entrar() {
    this.ativarSpinner();
    this.usuarioService.verificarUsuario(this.usuario).subscribe(
      data => {

        this.ativarSpinner();
        //Passa o json usuario para criar a sessão com mesmo nome de usuario logado
        this.usuarioService.usuario = data;
        this.desativarSpinner();
        
        if (this.returnUrl == null) {
          this.router.navigate(['/']);
        } else {
          this.router.navigate([this.returnUrl]);
        }
      },
      err => {
        console.log(err.error);
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
