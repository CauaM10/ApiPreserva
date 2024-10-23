using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private readonly IMarcaRepositorio _marcaRepositorio;

        public MarcaController(IMarcaRepositorio marcaRepositorio)
        {
            _marcaRepositorio = marcaRepositorio;
        }

        [HttpGet("GetAllMarca")]
        public async Task<ActionResult<List<MarcaModel>>> GetAllMarca()
        {
            List<MarcaModel> marcas = await _marcaRepositorio.GetAll();
            return Ok(marcas);
        }

        [HttpGet("GetMarcaId/{id}")]
        public async Task<ActionResult<MarcaModel>> GetMarcaId(int id)
        {
            MarcaModel marca = await _marcaRepositorio.GetById(id);
            return Ok(marca);
        }


        [HttpPost("CreateMarca")]
        public async Task<ActionResult<MarcaModel>> InsertMarca([FromBody] MarcaModel marcaModel)
        {
            MarcaModel marca = await _marcaRepositorio.InsertMarca(marcaModel);
            return Ok(marca);
        }

        [HttpPut("UpdateMarca/{id:int}")]
        public async Task<ActionResult<MarcaModel>> UpdateMarca(int id, [FromBody] MarcaModel marcaModel)
        {
            marcaModel.MarcaId = id;
            MarcaModel marca = await _marcaRepositorio.UpdateMarca(marcaModel, id);
            return Ok(marca);

        }

        [HttpDelete("DeleteMarca/{id:int}")]
        public async Task<ActionResult<MarcaModel>> DeleteMarca(int id)
        {

            bool deleted = await _marcaRepositorio.DeleteMarca(id);
            return Ok(deleted);
        }
    }
}
