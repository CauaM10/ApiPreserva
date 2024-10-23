using Api.Models;
using Api.Repositorios;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SobreNosController : ControllerBase
    {
        private readonly ISobreNosRepositorio _sobreNosRepositorio;

        public SobreNosController(ISobreNosRepositorio sobreNosRepositorio)
        {
            _sobreNosRepositorio = sobreNosRepositorio;
        }

        [HttpGet("GetAllSobreNos")]
        public async Task<ActionResult<List<SobreNosModel>>> GetAllSobreNos()
        {
            List<SobreNosModel> sobreNoss = await _sobreNosRepositorio.GetAll();
            return Ok(sobreNoss);
        }

        [HttpGet("GetSobreNosId/{id}")]
        public async Task<ActionResult<SobreNosModel>> GetSobreNosId(int id)
        {
            SobreNosModel sobreNos = await _sobreNosRepositorio.GetById(id);
            return Ok(sobreNos);
        }


        [HttpPost("CreateSobreNos")]
        public async Task<ActionResult<SobreNosModel>> InsertSobreNos([FromBody] SobreNosModel sobreNosModel)
        {
            SobreNosModel sobreNos = await _sobreNosRepositorio.InsertSobreNos(sobreNosModel);
            return Ok(sobreNos);
        }

        [HttpPut("UpdateSobreNos/{id:int}")]
        public async Task<ActionResult<SobreNosModel>> UpdateSobreNos(int id, [FromBody] SobreNosModel sobreNosModel)
        {
            sobreNosModel.SobreNosId = id;
            SobreNosModel sobreNos = await _sobreNosRepositorio.UpdateSobreNos(sobreNosModel, id);
            return Ok(sobreNos);

        }

        [HttpDelete("DeleteSobreNos/{id:int}")]
        public async Task<ActionResult<SobreNosModel>> DeleteSobreNos(int id)
        {

            bool deleted = await _sobreNosRepositorio.DeleteSobreNos(id);
            return Ok(deleted);
        }
    }
}