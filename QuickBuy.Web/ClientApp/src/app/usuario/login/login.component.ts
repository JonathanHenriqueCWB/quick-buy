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
  MostrarDados() {
    alert("Email : " + this.usuario.email + ", " + "Senha: " + this.usuario.senha);
  }
  
}
