using CP2.Application.Dtos;
using CP2.Domain.Entities;
using CP2.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CP2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorApplicationService _applicationService;

        public FornecedorController(IFornecedorApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        /// <summary>
        /// get para fornecedores.
        /// </summary>
        /// <returns>Lista de fornecedores.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<FornecedorEntity>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get()
        {
            var objModel = _applicationService.ObterTodosFornecedores();

            if (objModel is not null)
                return Ok(objModel);

            return BadRequest("erro obter os dados");
        }

        /// <summary>
        /// get fornecedor by id
        /// </summary>
        /// <param name="id">ID do fornecedor.</param>
        /// <returns>Fornecedor correspondente ao ID fornecido.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(FornecedorEntity), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetPorId(int id)
        {
            var objModel = _applicationService.ObterFornecedorPorId(id);

            if (objModel is not null)
                return Ok(objModel);

            return BadRequest("erro obter os dados");
        }

        /// <summary>
        /// add um fornecedor
        /// </summary>
        /// <param name="entity">Dados do fornecedor a ser adicionado.</param>
        /// <returns>Fornecedor adicionado.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(FornecedorEntity), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] FornecedorDto entity)
        {
            try
            {
                var objModel = _applicationService.SalvarDadosFornecedor(entity);

                if (objModel is not null)
                    return Ok(objModel);

                return BadRequest("erro ao  salvar os dados");
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
        /// patch fornecedores (atualizar)
        /// </summary>
        /// <param name="id">ID do fornecedor a ser atualizado.</param>
        /// <param name="entity">Novos dados do fornecedor.</param>
        /// <returns>Fornecedor atualizado.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(FornecedorEntity), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put(int id, [FromBody] FornecedorDto entity)
        {
            try
            {
                var objModel = _applicationService.EditarDadosFornecedor(id, entity);

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
        /// delete fornecedor by id
        /// </summary>
        /// <param name="id">ID do fornecedor a ser deletado.</param>
        /// <returns>Fornecedor deletado.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(FornecedorEntity), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id)
        {
            var objModel = _applicationService.DeletarDadosFornecedor(id);

            if (objModel is not null)
                return Ok(objModel);

            return BadRequest("erro ao deletar os dados");
        }
    }
}
