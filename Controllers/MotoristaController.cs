using Api.Models;
using Api.Repositorios;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotoristaController : ControllerBase
    {
        private readonly IMotoristaRepositorio _motoristaRepositorio;

        public MotoristaController(IMotoristaRepositorio motoristaRepositorio) 
        {
            _motoristaRepositorio = motoristaRepositorio;
        }

        [HttpGet("GetAllMotorista")]
        public async Task<ActionResult<List<MotoristaModel>>> GetAllMotorista()
        {
            List<MotoristaModel> motoristas = await _motoristaRepositorio.GetAll();
            return Ok(motoristas);
        }

        [HttpGet("GetMotoristaId/{id}")]
        public async Task<ActionResult<MotoristaModel>> GetMotoristaId(int id)
        {
            MotoristaModel motorista = await _motoristaRepositorio.GetById(id);
            return Ok(motorista);
        }


        [HttpPost("CreateMotorista")]
        public async Task<ActionResult<MotoristaModel>> InsertMotorista([FromBody] MotoristaModel motoristaModel)
        {
            MotoristaModel motorista = await _motoristaRepositorio.InsertMotorista(motoristaModel);
            return Ok(motorista);
        }

        [HttpPut("UpdateMotorista/{id:int}")]
        public async Task<ActionResult<MotoristaModel>> UpdateMotorista(int id, [FromBody] MotoristaModel motoristaModel)
        {
            motoristaModel.MotoristaId = id; 
            MotoristaModel motorista = await _motoristaRepositorio.UpdateMotorista(motoristaModel, id);
            return Ok(motorista);

        }

        [HttpDelete("DeleteMotorista/{id:int}")]
        public async Task<ActionResult<MotoristaModel>> DeleteMotorista(int id)
        {

            bool deleted = await _motoristaRepositorio.DeleteMotorista(id);
            return Ok(deleted);
        }
    }
}

