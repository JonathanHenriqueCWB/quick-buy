using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickBuy.Domain.Contratos;
using QuickBuy.Domain.Entidades;
using System;
using System.IO;
using System.Linq;

namespace QuickBuy.Web.Controllers
{
    [Route("api/[Controller]")]
    public class ProdutoController : Controller
    {
        #region Construtor DI
        private readonly IProdutoRepositorio _produtoRepositorio;
        private IHttpContextAccessor _httpContextAccessor;
        private IHostingEnvironment _hostingEnvironment;
        public ProdutoController(IProdutoRepositorio produtoRepositorio, IHttpContextAccessor httpContextAccessor, IHostingEnvironment hostingEnvironment)
        {
            _produtoRepositorio = produtoRepositorio;
            _httpContextAccessor = httpContextAccessor;
            _hostingEnvironment = hostingEnvironment;
        }
        #endregion

        [HttpGet]
        public IActionResult Get()
        { 
            try
            {
                return Ok(_produtoRepositorio.ObterTodos());
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]Produto produto)
        {
            try
            {
                _produtoRepositorio.Adicionar(produto);
                return Created("api/produto", produto);

            }catch(Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [HttpPost("EnviarArquivo")]
        public IActionResult EnviarArquivo()
        {
            try
            {
                var formFile = _httpContextAccessor.HttpContext.Request.Form.Files["arquivoEnviado"];
                var nomeArquivo = formFile.FileName;
                var extensao = nomeArquivo.Split(".").Last();
                var arrayNomeCompacto = Path.GetFileNameWithoutExtension(nomeArquivo).Take(10).ToArray();
                var novoNome = new String(arrayNomeCompacto).Replace(" ", "-") + "." + extensao;
                var pastaArquivos = _hostingEnvironment.WebRootPath + "\\Arquivos\\";
                var nomeCompleto = pastaArquivos + novoNome;

                using (var streamArquivo = new FileStream(nomeArquivo, FileMode.Create)) {
                    formFile.CopyTo(streamArquivo);
                }

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }
    }
}