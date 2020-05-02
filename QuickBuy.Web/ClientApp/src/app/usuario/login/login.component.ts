import { Component, OnInit } from "@angular/core"; 
import { Router, ActivatedRoute } from "@angular/router"

import { Usuario } from "../../model/usuario";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.css"]
})
export class LoginComponent implements OnInit {

  public usuario;
  public returnUrl: string;

  constructor(private router: Router, private activateRouter: ActivatedRoute) {
  }
  ngOnInit(): void {
    this.usuario = new Usuario();
    this.returnUrl = this.activateRouter.snapshot.queryParams['returnUrl'];
  }

  //Método criado para testar o two-way data binding
  entrar() {
    if (this.usuario.email == "zero@email.com" && this.usuario.senha == "Zero@1234") {

      sessionStorage.setItem("usuario-autenticado", "1");
      this.router.navigate([this.returnUrl]);  
      //this.router.navigate(['/']);

    }
  }  
}
