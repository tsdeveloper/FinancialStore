using FS.Identity.API.Model.Users;
using FS.Identity.API.Model.Users.Validator;
using Microsoft.AspNetCore.Mvc;

namespace FS.Identity.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;

        public AuthController(ILogger<AuthController> logger)
        {
            _logger = logger;
        }

        [HttpPut]
        public async Task<ActionResult> PutAuth(UserRegisterDTO userRegister)
        {
            var userRegisterValidator = new UserRegisterDTOValidator();
            var resultUserValidator = userRegisterValidator.Validate(userRegister);

            if (!resultUserValidator.IsValid)
            {
                return new NotFoundObjectResult(resultUserValidator.Errors);
            }
            return Ok(new
            {
                message = "Object created"
            });
        }

    }
}