using Api.Models;
using Api.Repositorios;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LugarController : ControllerBase
    {
        private readonly ILugarRepositorio _lugarRepositorio;

        public LugarController(ILugarRepositorio lugarRepositorio)
        {
            _lugarRepositorio = lugarRepositorio;
        }

        [HttpGet("GetAllLugar")]
        public async Task<ActionResult<List<LugarModel>>> GetAllLugar()
        {
            List<LugarModel> lugares = await _lugarRepositorio.GetAll();
            return Ok(lugares);
        }

        [HttpGet("GetLugarId/{id}")]
        public async Task<ActionResult<LugarModel>> GetLugarId(int id)
        {
            LugarModel lugar = await _lugarRepositorio.GetById(id);
            return Ok(lugar);
        }


        [HttpPost("CreateLugar")]
        public async Task<ActionResult<LugarModel>> InsertLugar([FromBody] LugarModel lugarModel)
        {
            LugarModel lugar = await _lugarRepositorio.InsertLugar(lugarModel);
            return Ok(lugar);
        }

        [HttpPut("UpdateLugar/{id:int}")]
        public async Task<ActionResult<LugarModel>> UpdateLugar(int id, [FromBody] LugarModel lugarModel)
        {
            lugarModel.LugarId = id;
            LugarModel lugar = await _lugarRepositorio.UpdateLugar(lugarModel, id);
            return Ok(lugar);

        }

        [HttpDelete("DeleteLugar/{id:int}")]
        public async Task<ActionResult<LugarModel>> DeleteLugar(int id)
        {

            bool deleted = await _lugarRepositorio.DeleteLugar(id);
            return Ok(deleted);
        }
    }
}

