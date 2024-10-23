using Api.Models;
using Api.Repositorios;
using Api.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModeloController : ControllerBase
    {
        private readonly IModeloRepositorio _modeloRepositorio;

        public ModeloController(IModeloRepositorio modeloRepositorio)
        {
            _modeloRepositorio = modeloRepositorio;
        }

        [HttpGet("GetAllModelo")]
        public async Task<ActionResult<List<ModeloModel>>> GetAllModelo()
        {
            List<ModeloModel> modelos = await _modeloRepositorio.GetAll();
            return Ok(modelos);
        }

        [HttpGet("GetModeloId/{id}")]
        public async Task<ActionResult<ModeloModel>> GetModeloId(int id)
        {
            ModeloModel modelo = await _modeloRepositorio.GetById(id);
            return Ok(modelo);
        }


        [HttpPost("CreateModelo")]
        public async Task<ActionResult<ModeloModel>> InsertModelo([FromBody] ModeloModel modeloModel)
        {
            ModeloModel modelo = await _modeloRepositorio.InsertModelo(modeloModel);
            return Ok(modelo);
        }

        [HttpPut("UpdateModelo/{id:int}")]
        public async Task<ActionResult<ModeloModel>> UpdateModelo(int id, [FromBody] ModeloModel modeloModel)
        {
            modeloModel.ModeloId = id;
            ModeloModel modelo = await _modeloRepositorio.UpdateModelo(modeloModel, id);
            return Ok(modelo);

        }

        [HttpDelete("DeleteModelo/{id:int}")]
        public async Task<ActionResult<ModeloModel>> DeleteModelo(int id)
        {

            bool deleted = await _modeloRepositorio.DeleteModelo(id);
            return Ok(deleted);
        }
    }
}