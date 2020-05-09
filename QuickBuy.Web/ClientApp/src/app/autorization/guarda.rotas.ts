import { Injectable } from "@angular/core";
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from "@angular/router";
import { UsuarioService } from "../services/usuario/usuario.services";

@Injectable({
  providedIn: 'root'
})
export class GuardaRotas implements CanActivate {

  constructor(private router: Router, private usuarioService: UsuarioService) {
  }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    if (this.usuarioService.verificarSessao()) {
      return true;
    }
    this.router.navigate(['/entrar'], { queryParams: { returnUrl: state.url } });
    return false;
  }
}

