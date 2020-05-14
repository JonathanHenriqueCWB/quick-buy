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
  public btnSpinner: boolean;

  constructor(private router: Router, private activateRouter: ActivatedRoute, private usuarioService: UsuarioService) {
  }

  ngOnInit(): void {
    this.usuario = new Usuario();
    this.returnUrl = this.activateRouter.snapshot.queryParams['returnUrl'];
  }

  //Método criado para testar o two-way data binding
  entrar() {
    this.btnSpinner = true;
    this.usuarioService.verificarUsuario(this.usuario).subscribe(
      data => {
        //console.log(data);
        this.usuarioService.usuario = data; //Propertie da classe de serviço usuario

        if (this.returnUrl == null) {
          this.router.navigate(['/']);
        } else {
          this.router.navigate([this.returnUrl]);
        }
      },
      err => {
        console.log(err.error);
        this.mensagem = err.error;
        this.btnSpinner = false;
      } 
    );
  }
}
