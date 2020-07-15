using System;
using System.Threading.Tasks;
using API.Model;
using Application.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TooSeguros.Domain.Entities;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LancamentoController : ControllerBase
    {
        private readonly ILancamentoAppService _lancamentoAppService;

        public LancamentoController(ILancamentoAppService lancamentoAppService)
        {
            _lancamentoAppService = lancamentoAppService;
        }

        /// <summary>
        /// Criar um novo Lançamento
        /// </summary>
        /// <param name="model"></param>
        /// <response code="200">Retorna JSON com um result(Boolean), message(String) e a um object(request).</response>
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Post(Lancamento model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new ApiResult(false, "Model inválida.", model));

                await _lancamentoAppService.CreateLancamento(model);
                return Ok(new ApiResult());
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResult(false, ex.InnerException.Message, model));
            }
        }
    }
}
