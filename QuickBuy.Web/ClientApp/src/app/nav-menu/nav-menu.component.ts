import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {

  //Construtor
  constructor(private router: Router) {
  }

  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  // Verefica se usuario está logado
  public usuarioLogado(): boolean {

    //return sessionStorage.getItem("usuario-autenticado") == "1";

    var usuarioLogado = sessionStorage.getItem("usuario-autenticado");
    if (usuarioLogado == "1") {
      return true;
    }
    return false;
  }

  //Limpa sessão para sair
  sair() {
    sessionStorage.setItem("usuario-autenticado", "");
    this.router.navigate(['/']);
  }

}
