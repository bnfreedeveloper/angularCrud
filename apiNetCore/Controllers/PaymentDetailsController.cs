using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiNetCore.Data;
using apiNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apiNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentDetailsController : ControllerBase
    {
        private readonly PaymentDbContext _dbcontext;

        public PaymentDetailsController(PaymentDbContext dbcontext)
        {
            this._dbcontext = dbcontext;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<PaymentDetail>>> getAll()
        {
            return Ok(await _dbcontext.PaymentDetails.ToListAsync());
        }
        [HttpPost]
        public async Task<ActionResult<PaymentDetail>> createPaymentDetail(PaymentDetail details)
        {
            await _dbcontext.AddAsync(details);
            await _dbcontext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = details.PaymentDetailsId }, details);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<PaymentDetail>> GetById(int id)
        {
            return Ok(await _dbcontext.PaymentDetails.FirstOrDefaultAsync(x => x.PaymentDetailsId == id));
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var paymentDetail = await _dbcontext.PaymentDetails.FindAsync(id);
            _dbcontext.PaymentDetails.Remove(paymentDetail);
            await _dbcontext.SaveChangesAsync();
            return Ok(new
            {
                message = "this payment details has been deleted"
            });
        }
    }
}