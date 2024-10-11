using CP2.Application.Dtos;
using CP2.Domain.Entities;
using CP2.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CP2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendedorController : ControllerBase
    {
        private readonly IVendedorApplicationService _applicationService;

        public VendedorController(IVendedorApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        /// <summary>
        /// get vendedores.
        /// </summary>
        /// <returns>Lista de vendedores.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<VendedorEntity>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get()
        {
            var objModel = _applicationService.ObterTodosVendedores();

            if (objModel is not null)
                return Ok(objModel);

            return BadRequest("erro ao obter os dados");
        }

        /// <summary>
        /// get vendedor by ID.
        /// </summary>
        /// <param name="id">ID do vendedor.</param>
        /// <returns>Vendedor correspondente ao ID fornecido.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(VendedorEntity), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetPorId(int id)
        {
            var objModel = _applicationService.ObterVendedorPorId(id);

            if (objModel is not null)
                return Ok(objModel);

            return BadRequest("Não foi possível obter os dados");
        }

        /// <summary>
        /// add vendedor
        /// </summary>
        /// <param name="entity">Dados do vendedor a ser adicionado.</param>
        /// <returns>Vendedor adicionado.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(VendedorEntity), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] VendedorDto entity)
        {
            try
            {
                var objModel = _applicationService.SalvarDadosVendedor(entity);

                if (objModel is not null)
                    return Ok(objModel);

                return BadRequest("erro ao salvar os dados");
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message,
                    status = HttpStatusCode.BadRequest,
                });
            }
        }

        /// <summary>
        /// patch vendedor by id (atualizar)
        /// </summary>
        /// <param name="id">ID do vendedor a ser atualizado.</param>
        /// <param name="entity">Novos dados do vendedor.</param>
        /// <returns>Vendedor atualizado.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(VendedorEntity), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put(int id, [FromBody] VendedorDto entity)
        {
            try
            {
                var objModel = _applicationService.EditarDadosVendedor(id, entity);

                if (objModel is not null)
                    return Ok(objModel);

                return BadRequest("erro ao salvar os dados");
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message,
                    status = HttpStatusCode.BadRequest,
                });
            }
        }

        /// <summary>
        /// delete vendedor by id.
        /// </summary>
        /// <param name="id">ID do vendedor a ser deletado.</param>
        /// <returns>Vendedor deletado.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(VendedorEntity), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id)
        {
            var objModel = _applicationService.DeletarDadosVendedor(id);

            if (objModel is not null)
                return Ok(objModel);

            return BadRequest("erro ao deletar os dados");
        }
    }
}
