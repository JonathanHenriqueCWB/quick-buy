import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UsuarioService } from '../services/usuario/usuario.services';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {

  //Propertie somente leitura que retorna a instancia do usuario
  get usuario() {
    return this.usuarioService.usuario;
  }

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

  //Função para verificar autenticação no sistema, se o usuario está ou não logado
  public usuarioLogado(): boolean {
    return this.usuarioService.verificarSessao();
  }

  //Limpa sessão para sair
  sair() {
    this.usuarioService.limparSessao();
  }
}
