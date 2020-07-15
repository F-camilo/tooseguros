using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Model;
using Application.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TooSeguros.Domain.Entities;
using TooSeguros.Domain.Exceptions;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContaCorrenteController : ControllerBase
    {
        private readonly IContaCorrenteAppService _contaCorrenteAppService;

        public ContaCorrenteController(IContaCorrenteAppService contaCorrenteAppService)
        {
            _contaCorrenteAppService = contaCorrenteAppService;
        }

        /// <summary>
        /// Buscar Conta Corrente
        /// </summary>
        /// <response code="200">Retorna Lista de Conta Corrente e seus Lançamentos.</response>
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IEnumerable<ContaCorrente>> Get()
        {
            return await _contaCorrenteAppService.GetAllContaCorrente();
        }

        /// <summary>
        /// Criar uma nova Conta Corrente
        /// </summary>
        /// <param name="model"></param>
        /// <response code="200">Retorna JSON com um result(Boolean), message(String) e a um object(request).</response>
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Post(ContaCorrente model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new ApiResult(false, "Model inválida.", model));

                await _contaCorrenteAppService.CreateContaCorrente(model);
                return Ok(new ApiResult(model));
            }
            catch (TransacaoException tex)
            {
                return BadRequest(new ApiResult(false, tex.Message, model));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResult(false, ex.InnerException.Message, model));
            }
        }
    }
}
