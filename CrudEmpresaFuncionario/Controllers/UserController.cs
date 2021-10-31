using CrudEmpresaFuncionario.Domain.Entities;
using CrudEmpresaFuncionario.Infra;
using CrudEmpresaFuncionario.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CrudEmpresaFuncionario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly CrudContext _context;
        private readonly IUserService _userService;

        public UserController(IUserService userService, CrudContext context)
        {
            _userService = userService;
            _context = context;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] User user)
        {
            var userFound = await _userService.GetByLogin(user.Username, user.Password);
            if (userFound == null)
                return NotFound("Usuário ou senha inválidos");

            var token = TokenService.GenerateToken(userFound);

            userFound.Password = "";

            return new
            {
                user = userFound,
                token = token
            };
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] User user)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await _userService.CreateAsync(user);
                    //if (_userService.Validations().Messages.Count > 0)
                    //{
                    //    transaction.Rollback();
                    //    return Ok(_userService.Validations());
                    //}

                    transaction.Commit();
                    return Ok();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return BadRequest(e.Message);
                }
            }
        }
    }
}
