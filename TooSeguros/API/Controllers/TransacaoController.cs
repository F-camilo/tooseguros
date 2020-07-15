using System;
using System.Threading.Tasks;
using API.Model;
using Application.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TooSeguros.Domain.Dto;
using TooSeguros.Domain.Exceptions;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransacaoController : ControllerBase
    {
        private readonly ITransacaoAppService _transacaoAppService;

        public TransacaoController(ITransacaoAppService transacaoAppService)
        {
            _transacaoAppService = transacaoAppService;
        }


        /// <summary>
        /// Criar uma nova Transação Débito na Origem e Crédito no Destino
        /// </summary>
        /// <param name="model"></param>
        /// <response code="200">Retorna JSON com um result(Boolean), message(String) e a um object(request).</response>
        [HttpPost]
        [Route("debitcredit")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Post(TransacaoDto model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new ApiResult(false, "Model inválida.", model));

                await _transacaoAppService.CreateTransactionDebitAndCredit(model);
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

        /// <summary>
        /// Criar uma nova Transação de Débito
        /// </summary>
        /// <param name="model"></param>
        /// <response code="200">Retorna JSON com um result(Boolean), message(String) e a um object(request).</response>
        [HttpPost]
        [Route("debit")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> debit(TransacaoDebitDto model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new ApiResult(false, "Model inválida.", model));

                await _transacaoAppService.CreateTransactionDebit(model);
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

        /// <summary>
        /// Criar uma nova Transação de Crédito
        /// </summary>
        /// <param name="model"></param>
        /// <response code="200">Retorna JSON com um result(Boolean), message(String) e a um object(request).</response>
        [HttpPost]
        [Route("credit")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> credit(TransacaoCreditDto model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new ApiResult(false, "Model inválida.", model));

                await _transacaoAppService.CreateTransactionCredit(model);
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
