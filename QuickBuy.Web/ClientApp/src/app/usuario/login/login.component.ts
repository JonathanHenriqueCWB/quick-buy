import { Component } from "@angular/core"; 
import { Usuario } from "../../model/usuario";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.css"]
})
export class LoginComponent {

  public usuario;

  constructor() {
    this.usuario = new Usuario();
  }

  //Método criado para testar o two-way data binding
  entrar() {
    if (this.usuario.email == "zero@email.com" && this.usuario.senha == "Zero@1234") {

    }    
  }  
}
