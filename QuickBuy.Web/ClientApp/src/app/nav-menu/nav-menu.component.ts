import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UsuarioService } from '../services/usuario/usuario.services';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {

  //Construtor
  constructor(private router: Router, private usuarioService: UsuarioService) {
  }

  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  // ESSA VERIFICAÇÃO SERVE SOMENTE PARA RENDERIZAR O LOGIN E LOGOUT
  // Verefica se usuario está logado
  public usuarioLogado(): boolean {
    return this.usuarioService.verificarSessao();
  }

  //Limpa sessão para sair
  sair() {
    this.usuarioService.limparSessao();
  }

}
