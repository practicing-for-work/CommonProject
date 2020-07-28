using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using practicing_for_work.Model;
using Practicing_For_Work.Application.Contracts.Dtos;
using Practicing_For_Work.Application.Contracts.IService;

namespace practicing_for_work.Controllers
{
    [Route("api")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IHomeService _homeService;
        private readonly ILogger _logger;

        public HomeController(IHomeService homeService,
            ILogger logger)
        {
            _logger = logger;
            _homeService = homeService;
        }

        [HttpPost("Signin")]
        public async Task<IActionResult> SigninAsync(SigninDto dto) 
        {
            var result = await _homeService.IsValidateAsync(dto);

            if (result.Succeeded) 
            {
                _logger.LogInformation("會員 {0} 登入成功", dto.Account);
                return Ok(result.Data);
            }

            _logger.LogInformation("會員 {0} 登入失敗", dto.Account);
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }

            return ValidationProblem();
        }

        [HttpPost("Signup")]
        public async Task<IActionResult> SignupAsync(SignupDto dto) 
        {
            var result = await _homeService.CreateAsync(dto);

            if (result.Succeeded) 
            {
                _logger.LogInformation("會員 {0} 註冊成功", dto.Account);
                return Ok(result.Data);
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }

            return ValidationProblem();
        }
    }
}