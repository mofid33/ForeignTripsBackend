using AutoMapper;
using Foreign_Trips.Entities;
using Foreign_Trips.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Foreign_Trips.Controllers
{
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        private readonly IMapper _mapper;
        public AuthController(IAuthRepository authRepository, IMapper mapper)
        {
            _authRepository = authRepository ??
                throw new ArgumentNullException(nameof(authRepository));

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        #region login
        [HttpPost]
        [Route("Login")]
        public ActionResult<LoginDto> Login([FromBody] LoginDto
           model)
        {
            var user = _authRepository.ValidateUserCredentials(model.Username,
                model.Password);

            if (user.Result == null)
            {
                return NoContent();
            }
            var auth = _authRepository.Login(new LoginDto
            (
                user.Result.Username,
                user.Result.Password,
                user.Result.Role,
                user.Result.ID,
                null
            ));


            return Ok(auth);
        }
        #endregion 
    }
}

