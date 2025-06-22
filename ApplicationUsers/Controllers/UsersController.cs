using ApplicationUsers.Interfaces;
using ApplicationUsers.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApplicationUsers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IDatabaseService _databaseService;
        public UsersController(IDatabaseService databaseService)
        {
            _databaseService = databaseService;

        }

        [HttpGet()]

        public async Task<IEnumerable<User>> Get()
        {

            return await _databaseService.QueryAsync<User>($"select * FROM usuarios;");

        }

        [HttpPost()]

        public async Task<IActionResult> Post([FromQuery] User user)
        {
          await _databaseService.ExecuteAsync($"INSERT INTO Usuarios(Nome, CPF, DataNascimento, Sexo) VALUES ('{user.Nome}','{user.Cpf}','{user.DataNascimento}','{user.Sexo}')");
          return Ok();
        }

        
    }
}
