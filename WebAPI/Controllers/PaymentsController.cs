using Business.Abstract;
using Entities.Concrete;
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
    public class PaymentsController : ControllerBase
    {
        IRentalService _rentalService;

        public PaymentsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpPost("executepayment")]
        public IActionResult ExecutePayment(Payment payment)
        {
            var result = _rentalService.Add(payment.Rental);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
