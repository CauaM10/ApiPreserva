using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoCombustivelController : ControllerBase
    {
        private readonly ITipoCombustivelRepositorio _combustivelRepositorio;

        public TipoCombustivelController(ITipoCombustivelRepositorio combustivelRepositorio)
        {
            _combustivelRepositorio = combustivelRepositorio;
        }

        [HttpGet("GetAllCombustivel")]
        public async Task<ActionResult<List<TipoCombustivelModel>>> GetAllCombustivel()
        {
            List<TipoCombustivelModel> combustiveis = await _combustivelRepositorio.GetAll();
            return Ok(combustiveis);
        }

        [HttpGet("GetCombustivelId/{id}")]
        public async Task<ActionResult<TipoCombustivelModel>> GetCombustivelId(int id)
        {
            TipoCombustivelModel combustivel = await _combustivelRepositorio.GetById(id);
            return Ok(combustivel);
        }


        [HttpPost("CreateCombustivel")]
        public async Task<ActionResult<TipoCombustivelModel>> InsertCombustivel([FromBody] TipoCombustivelModel tipoCombustivelModel)
        {
            TipoCombustivelModel combustivel = await _combustivelRepositorio.InsertCombustivel(tipoCombustivelModel);
            return Ok(combustivel);
        }

        [HttpPut("UpdateCombustivel/{id:int}")]
        public async Task<ActionResult<TipoCombustivelModel>> UpdateCombustivel(int id, [FromBody] TipoCombustivelModel tipoCombustivelModel)
        {
            tipoCombustivelModel.TipoCombustivelId = id;
            TipoCombustivelModel combustivel = await _combustivelRepositorio.UpdateCombustivel(tipoCombustivelModel, id);
            return Ok(combustivel);

        }

        [HttpDelete("DeleteCombustivel/{id:int}")]
        public async Task<ActionResult<TipoCombustivelModel>> DeleteCombustivel(int id)
        {

            bool deleted = await _combustivelRepositorio.DeleteCombustivel(id);
            return Ok(deleted);
        }
    }
}
