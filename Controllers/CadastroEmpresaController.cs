using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CadastroEmpresaController : ControllerBase
    {
        private readonly ICadastroEmpresaRepositorio _empresasRepositorio;

        public CadastroEmpresaController(ICadastroEmpresaRepositorio empresasRepositorio)
        {
            _empresasRepositorio = empresasRepositorio;
        }

        [HttpGet("GetAllEmpresas")]
        public async Task<ActionResult<List<CadastroEmpresaModel>>> GetAllCadastro()
        {
            List<CadastroEmpresaModel> empresas = await _empresasRepositorio.GetAll();
            return Ok(empresas);
        }

        [HttpGet("GetEmpresaId/{id}")]
        public async Task<ActionResult<CadastroEmpresaModel>> GetUserId(int id)
        {
            CadastroEmpresaModel empresa = await _empresasRepositorio.GetById(id);
            return Ok(empresa);
        }

        [HttpGet("Login/{email}/{senha}")]
        public async Task<ActionResult<CadastroEmpresaModel>> Login(string email, string senha)
        {
            CadastroEmpresaModel usuario = await _empresasRepositorio.Login(email, senha);
            return Ok(usuario);
        }

        [HttpPost("CreateEmpresa")]
        public async Task<ActionResult<CadastroEmpresaModel>> InsertUser([FromBody]CadastroEmpresaModel cadastroEmpresaModel)
        {
            CadastroEmpresaModel empresa = await _empresasRepositorio.InsertEmpresa(cadastroEmpresaModel);
            return Ok(empresa);
        }
        [HttpPut("UpdateEmpresa/{id:int}")]
        public async Task<ActionResult<CadastroEmpresaModel>> UpdateEmpresa(int id, [FromBody] CadastroEmpresaModel cadastroEmpresaModel)
        {
            cadastroEmpresaModel.CadastroEmpresaId = id;
            CadastroEmpresaModel empresa = await _empresasRepositorio.UpdateEmpresa(cadastroEmpresaModel, id);
            return Ok(empresa);
    
        }

        [HttpDelete("DeleteEmpresa/{id:int}")]
        public async Task<ActionResult<CadastroEmpresaModel>> DeleteEmpresa(int id)
        {

            bool deleted = await _empresasRepositorio.DeleteEmpresa(id);
            return Ok(deleted);
        }
    }
}
