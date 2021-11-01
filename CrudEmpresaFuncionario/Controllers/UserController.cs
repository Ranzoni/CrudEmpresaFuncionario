using CrudEmpresaFuncionario.Domain.Entities;
using CrudEmpresaFuncionario.Infra;
using CrudEmpresaFuncionario.Services;
using Microsoft.AspNetCore.Mvc;
using System;
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
            User userFound;
            if (user.Username == "Admin" && user.Password == "@AdminCrud")
                userFound = new User(user.Username, user.Password, 0);
            else
            {
                userFound = await _userService.GetByLogin(user.Username, user.Password, user.IdCompany);
                if (userFound == null)
                    return NotFound("Usuário ou senha inválidos");
            }

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
