using Api.Models;
using Api.Repositorios;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoRepositorio _veiculoRepositorio;

        public VeiculoController(IVeiculoRepositorio veiculoRepositorio)
        {
            _veiculoRepositorio = veiculoRepositorio;
        }

        [HttpGet("GetAllVeiculo")]
        public async Task<ActionResult<List<VeiculoModel>>> GetAllVeiculo()
        {
            List<VeiculoModel> veiculos = await _veiculoRepositorio.GetAll();
            return Ok(veiculos);
        }

        [HttpGet("GetVeiculoId/{id}")]
        public async Task<ActionResult<VeiculoModel>> GetVeiculoId(int id)
        {
            VeiculoModel veiculo = await _veiculoRepositorio.GetById(id);
            return Ok(veiculo);
        }


        [HttpPost("CreateVeiculo")]
        public async Task<ActionResult<VeiculoModel>> InsertVeiculo([FromBody] VeiculoModel veiculoModel)
        {
            VeiculoModel veiculo = await _veiculoRepositorio.InsertVeiculo(veiculoModel);
            return Ok(veiculo);
        }

        [HttpPut("UpdateVeiculo/{id:int}")]
        public async Task<ActionResult<VeiculoModel>> UpdateVeiculo(int id, [FromBody] VeiculoModel veiculoModel)
        {
            veiculoModel.VeiculoId = id;
            VeiculoModel veiculo = await _veiculoRepositorio.UpdateVeiculo(veiculoModel, id);
            return Ok(veiculo);

        }

        [HttpDelete("DeleteVeiculo/{id:int}")]
        public async Task<ActionResult<VeiculoModel>> DeleteVeiculo(int id)
        {

            bool deleted = await _veiculoRepositorio.DeleteVeiculo(id);
            return Ok(deleted);
        }
    }
}

