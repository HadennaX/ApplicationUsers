using ApplicationUsers.Interfaces;
using ApplicationUsers.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApplicationUsers.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IDatabaseService _databaseService;
        public UsersController(IDatabaseService databaseService)
        {
            _databaseService = databaseService;

        }

        [HttpGet()]

        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {

            return Ok( await _databaseService.QueryAsync<User>($"SELECT * FROM usuarios;"));

        }

        [HttpPost()]

        public async Task<IActionResult> CreateUser([FromQuery] User user)
        {
          await _databaseService.ExecuteAsync($"INSERT INTO Usuarios(Nome, CPF, DataNascimento, Sexo) VALUES ('{user.Nome}','{user.Cpf}','{user.DataNascimento.ToString("yyyy/MM/dd")}','{user.Sexo}')");
          return Ok();
        }

        [HttpGet()]

        public async Task<ActionResult<User>> GetUserById([FromQuery] int id)
        {

            return Ok(await _databaseService.QueryAsync<User>($"SELECT * FROM usuarios WHERE id={id};"));
        }

        [HttpPut()]

        public async Task<ActionResult> UpdateUser([FromQuery] User user)
        {
            return Ok(await _databaseService.ExecuteAsync($"UPDATE usuarios SET Nome='{user.Nome}', CPF='{user.Cpf}',DataNascimento='{user.DataNascimento}',Sexo='{user.Sexo}' WHERE id={user.Id}"));
        }

        [HttpDelete()]

        public async Task<ActionResult> DeleteUser([FromQuery] int id)
        {
            return Ok(await _databaseService.ExecuteAsync($"DELETE FROM usuarios WHERE id='{id}'"));
        }

    }
}
