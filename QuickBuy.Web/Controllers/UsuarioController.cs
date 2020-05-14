using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuickBuy.Domain.Contratos;
using QuickBuy.Domain.Entidades;

namespace QuickBuy.Web.Controllers
{
    [Route("api/[Controller]")]
    public class UsuarioController : Controller
    {
        #region Injeção de dependencia
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        #endregion

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok();
            }
            catch (Exeption ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        public ActionResult Post()
        {
            try
            {
                return Ok();
            }
            catch (Exeption ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost("VeriricarUsuario")]
        public ActionResult VerificarUsuario([FromBody] Usuario usuario)
        {
            try
            {
                var usuarioRetorno = _usuarioRepositorio.ValidarLogin(usuario.Email, usuario.Senha);
                if (usuarioRetorno != null)
                {
                    string u = JsonConvert.SerializeObject(usuarioRetorno);
                    return Ok(u);
                }
                return BadRequest("Usuario ou senha invalido");
            }
            catch (Exeption ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
