using CrudEmpresaFuncionario.Domain.Entities;
using CrudEmpresaFuncionario.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudEmpresaFuncionario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly IPositionService _positionService;

        public PositionController(IPositionService positionService)
        {
            _positionService = positionService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Position>>> Get()
        {
            try
            {
                var positions = await _positionService.GetAsync();
                return positions;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
