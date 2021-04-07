using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditScoresController : ControllerBase
    {
        ICreditScoreService _creditScoreService;

        public CreditScoresController(ICreditScoreService creditScoreService)
        {
            _creditScoreService = creditScoreService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _creditScoreService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbycustomerid")]
        public IActionResult GetByCustomerId(int customerId)
        {
            var result = _creditScoreService.GetByCustomerId(customerId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
