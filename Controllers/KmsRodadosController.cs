using Api.Models;
using Api.Repositorios;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KmsRodadosController : ControllerBase
    {
        private readonly IKmsRodadosRepositorio _kmsRodadosRepositorio;

        public KmsRodadosController(IKmsRodadosRepositorio kmsRodadosRepositorio)
        {
            _kmsRodadosRepositorio = kmsRodadosRepositorio;
        }


        [HttpGet("GetKmVeiculoMes/{id:int}/{mes:int}")]
        public async Task<ActionResult<int>> GetKmVeiculoMonth( int id, int mes )
        {
            int kmsRodadoss = await _kmsRodadosRepositorio.GetKmVeiculoMes( id, mes );
            return Ok(kmsRodadoss);
        }

        [HttpGet("GetKmVeiculoDia/{id:int}/{date}")]
        public async Task<ActionResult<KmsRodadosModel>> GetKmVeiculoDia(int id, string date)
        {
            KmsRodadosModel kmsRodadoss = await _kmsRodadosRepositorio.GetKmVeiculoDia(id, date);
            return Ok(kmsRodadoss);
        }

        [HttpGet("GetAllKmsRodados")]
        public async Task<ActionResult<List<KmsRodadosModel>>> GetAllKmsRodados()
        {
            List<KmsRodadosModel> kmsRodadoss = await _kmsRodadosRepositorio.GetAll();
            return Ok(kmsRodadoss);
        }

        [HttpGet("GetKmsRodadosId/{id}")]
        public async Task<ActionResult<KmsRodadosModel>> GetKmsRodadosId(int id)
        {
            KmsRodadosModel kmsRodados = await _kmsRodadosRepositorio.GetById(id);
            return Ok(kmsRodados);
        }


        [HttpPost("CreateKmsRodados")]
        public async Task<ActionResult<KmsRodadosModel>> InsertKmsRodados([FromBody] KmsRodadosModel kmsRodadosModel)
        {
            KmsRodadosModel kmsRodados = await _kmsRodadosRepositorio.InsertKmsRodados(kmsRodadosModel);
            return Ok(kmsRodados);
        }

        [HttpPut("UpdateKmsRodados/{id:int}")]
        public async Task<ActionResult<KmsRodadosModel>> UpdateKmsRodados(int id, [FromBody] KmsRodadosModel kmsRodadosModel)
        {
            kmsRodadosModel.KmsRodadosId = id;
            KmsRodadosModel kmsRodados = await _kmsRodadosRepositorio.UpdateKmsRodados(kmsRodadosModel, id);
            return Ok(kmsRodados);

        }

        [HttpDelete("DeleteKmsRodados/{id:int}")]
        public async Task<ActionResult<KmsRodadosModel>> DeleteKmsRodados(int id)
        {

            bool deleted = await _kmsRodadosRepositorio.DeleteKmsRodados(id);
            return Ok(deleted);
        }
    }
}

