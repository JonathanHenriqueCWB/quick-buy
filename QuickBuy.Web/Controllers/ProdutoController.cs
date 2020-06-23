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
                //Chama o método validade para verificar erros no modelo
                produto.Validate();
                //Verifica se o validade add erros no modelo
                if (produto.VerificarErros)
                {
                    return BadRequest(produto.ObterMensagensValidacao());
                }

                //_produtoRepositorio.Adicionar(produto);
                return Created("api/produto", produto);

            }catch(Exception e)
            {
                return BadRequest("Erro no Produto controller " + e.ToString());
            }
        }

        [HttpPost("EnviarArquivo")]
        public IActionResult EnviarArquivo()
        {
            try
            {
                //Recupera o formData do produto.services em um formFile
                var formFile = _httpContextAccessor.HttpContext.Request.Form.Files["arquivoEnviado"];
                //Recupera o nome do arquivo dentro do formFile
                var nomeArquivo = formFile.FileName;
                //Separa a extensão de arquivo para gerar um novo nome
                var extensao = nomeArquivo.Split(".").Last();

                string novoNome = GerarNovoNome(nomeArquivo, extensao);
                SalvarArquivo(formFile, novoNome);

                return Json(novoNome);
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }


        #region MÉTODOS UTILIZADOS PARA ENVIAR ARQUIVO PARA O SERVIDOR
        private static string GerarNovoNome(string nomeArquivo, string extensao)
        {
            var arrayNomeCompacto = Path.GetFileNameWithoutExtension(nomeArquivo).Take(10).ToArray();
            var novoNome = new String(arrayNomeCompacto).Replace(" ", "-");
                       
            novoNome = $"{novoNome}" + Guid.NewGuid().ToString() + $".{extensao}";
            //novoNome = $"{novoNome}{DateTime.Now.Year}{DateTime.Now.Month}{DateTime.Now.Day}{DateTime.Now.Hour}{DateTime.Now.Minute}{DateTime.Now.Second}.{extensao}";

            return novoNome;
        }

        private void SalvarArquivo(IFormFile formFile, string novoNome)
        {
            var pastaArquivos = _hostingEnvironment.WebRootPath + "\\arquivos\\";
            var nomeCompleto = pastaArquivos + novoNome;

            using (var streamArquivo = new FileStream(nomeCompleto, FileMode.Create))
            {
                formFile.CopyTo(streamArquivo);
            }
        }
        #endregion
    }
}