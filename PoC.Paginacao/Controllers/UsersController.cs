using Microsoft.AspNetCore.Mvc;
using PoC.Paginacao.Dtos;
using PoC.Paginacao.Models;
using PoC.Paginacao.Repositories;

namespace PoC.Paginacao.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBase
    {
        [HttpGet()]
        public ActionResult<ResultListDto<User>> GetUsers([FromQuery] PaginationDto pagination,
            [FromQuery] FilterDto filter,
            [FromServices] UserRepository repository)
        {
            return Ok(repository.GetAllUsers(pagination, filter));
        }
    }
}
