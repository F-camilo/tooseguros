using System;
using System.Threading.Tasks;
using API.Model;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using TooSeguros.Domain.Dto;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public UsuarioController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }


        /// <summary>
        /// Autenticação
        /// </summary>
        /// <param name="model"></param>
        /// <response code="200">Retorna Token de Autenticação ou JSON com um result(Boolean), message(String) e a um object(request).</response>
        [HttpPost]
        [Route("token")]
        public async Task<dynamic> Post(UsuarioDto model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new ApiResult(false, "Model inválida.", model));

                var token = await _usuarioAppService.Token(model);
                if (string.IsNullOrEmpty(token))
                    return BadRequest(new ApiResult(false, "Usuario não encontrado", model));

                model.Senha = "";
                return new 
                {
                    usuario = model,
                    token = token
                };
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResult(false, ex.InnerException.Message, model));
            }
        }
    }
}
