using ATS.CoreAPI.Bussiness;
using ATS.CoreAPI.Exceptions;
using ATS.CoreAPI.Model.DTO;
using ATS.CoreAPI.Model.Entitys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private ILoginBusiness _loginBussines;

        public AuthController(ILoginBusiness loginBussines)
        {
            _loginBussines = loginBussines;
        }

        [HttpPost("sigin")]
        public IActionResult Sigin([FromBody] UserDTO user)
        {
            try
            {
                if (user is null) return BadRequest("Invalid client request");
                var token = _loginBussines.ValidateCredentials(user);
                if (token is null) return Unauthorized();
                return Ok(token);
            }
            catch (UserPasswordNotSetException userException)
            {
                return StatusCode(203, userException.UserTempToken);
            }
            catch (UserNotExistsException exception)
            {
                return Unauthorized(new { ex = "UserNotExistsException", message = "Usuário não encontrado ou senha incorreta." });
            }
            catch (InactiveUserException exception)
            {
                return Unauthorized(new { ex = "InactiveUserException", message = "Usuário Inativo." });
            }
        }

        [HttpPost("generateTemporaryCredentials")]
        public IActionResult GenerateTemporaryCredentials([FromBody] User user)
        {

            if (user is null) 
                return BadRequest("Invalid client request");
            
            var token = _loginBussines.GenerateTemporaryCredentials(user);

            if (token is null) return Unauthorized();
                return Ok(token);

        }
        [HttpPost("refresh")]
        public IActionResult Refresh([FromBody] TokenDTO tokenVO)
        {
            if (tokenVO is null) return BadRequest("Invalid client request");
            var token = _loginBussines.ValidateCredentials(tokenVO);
            if (token is null) return BadRequest("Invalid client request");
            return Ok(token);
        }

        [HttpGet("revoke")]
        [Authorize("Bearer")]
        public IActionResult Revoke()
        {
            var userName = User.Identity.Name;
            var result = _loginBussines.RevokeToken(userName);
            if (result)
                return NoContent();
            else
                return BadRequest("Invalid client request");
        }
    }
}
