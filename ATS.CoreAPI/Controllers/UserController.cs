using ATS.CoreAPI.Bussiness;
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
    [Authorize("Bearer")]
    public class UserController : ControllerBase
    {
        private readonly IUserBusiness _userBussiness;

        public UserController(IUserBusiness userBussines)
        {
            _userBussiness = userBussines;
        }

        [HttpGet]
        public IActionResult GetUser()
        {
            var claims = User.Claims;
            var result = _userBussiness.Get(Convert.ToInt32(claims.First(claim => claim.Type.Equals("id")).Value));
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }

        [HttpGet("GetByCPF")]
        public IActionResult GetByCPF(string cpf)
        {
            var claims = User.Claims;
            var result = _userBussiness.GetByCPF(cpf);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }

        [HttpGet("GetByEmail")]
        public IActionResult GetByEmail(string email)
        {
            var claims = User.Claims;
            var result = _userBussiness.GetByEmail(email);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }

        [HttpGet("GetByUserName")]
        public IActionResult GetByUserName(string userName)
        {
            var claims = User.Claims;
            var result = _userBussiness.GetByUserName(userName);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }


        [HttpPost("Save")]
        public IActionResult Save(User user)
        {
            var result = _userBussiness.Save(user);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }

        [HttpPut("Delete")]
        public IActionResult Delete()
        {
            var claims = User.Claims;
            var result = _userBussiness.Delete(Convert.ToInt32(claims.First(claim => claim.Type.Equals("id")).Value));
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Invalid client request");
        }

        [HttpDelete("DeleteByCPF")]
        public IActionResult Delete(String cpf)
        {
            User user = _userBussiness.GetByCPF(cpf);

            if(user != null && user.ID > 0)
            {
                var result = _userBussiness.Delete(user.ID);
                if (result != null)
                    return Ok(result);
                else
                    return BadRequest("Invalid client request");
            }
            else
                return BadRequest("Invalid client request");
        }

        [HttpPost("UpdatePassword")]
        public IActionResult UpdatePassword(UserDTO user)
        {
            var claims = User.Claims;
            _userBussiness.UpdatePassword(Convert.ToInt32(claims.First(claim => claim.Type.Equals("id")).Value), user.Password);
            return NoContent();
        }
    }

}
