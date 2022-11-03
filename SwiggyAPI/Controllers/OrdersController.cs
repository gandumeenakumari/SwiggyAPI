using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwiggyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwiggyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly UserContext _context;
        public OrdersController(UserContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _context.Orders.ToListAsync();
            return Ok(orders);
        }
        [HttpPost]
        public async Task<IActionResult> AddOrders([FromBody] Orders orders)
        {
            await _context.Orders.AddAsync(orders);
            await _context.SaveChangesAsync();
            return Ok(orders);
        }
        
       
    }
}
