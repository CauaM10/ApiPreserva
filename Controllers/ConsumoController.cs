using Api.Models;
using Api.Repositorios;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumoController : ControllerBase
    {
        private readonly IConsumoRepositorio _consumoRepositorio;

        public ConsumoController(IConsumoRepositorio consumoRepositorio)
        {
            _consumoRepositorio = consumoRepositorio;
        }

        [HttpGet("GetAllConsumo")]
        public async Task<ActionResult<List<ConsumoModel>>> GetAllConsumo()
        {
            List<ConsumoModel> consumos = await _consumoRepositorio.GetAll();
            return Ok(consumos);
        }

        [HttpGet("GetConsumoId/{id}")]
        public async Task<ActionResult<ConsumoModel>> GetConsumoId(int id)
        {
            ConsumoModel consumo = await _consumoRepositorio.GetById(id);
            return Ok(consumo);
        }


        [HttpPost("CreateConsumo")]
        public async Task<ActionResult<ConsumoModel>> InsertConsumo([FromBody] ConsumoModel consumoModel)
        {
            ConsumoModel consumo = await _consumoRepositorio.InsertConsumo(consumoModel);
            return Ok(consumo);
        }

        [HttpPut("UpdateConsumo/{id:int}")]
        public async Task<ActionResult<ConsumoModel>> UpdateConsumo(int id, [FromBody] ConsumoModel consumoModel)
        {
            consumoModel.ConsumoId = id;
            ConsumoModel consumo = await _consumoRepositorio.UpdateConsumo(consumoModel, id);
            return Ok(consumo);

        }

        [HttpDelete("DeleteConsumo/{id:int}")]
        public async Task<ActionResult<ConsumoModel>> DeleteConsumo(int id)
        {

            bool deleted = await _consumoRepositorio.DeleteConsumo(id);
            return Ok(deleted);
        }
    }
}