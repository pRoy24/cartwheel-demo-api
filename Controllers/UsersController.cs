using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CartwheelApi.Models;
using System.Web.Http.Cors;

namespace CartwheelApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly CartwheelContext _context;  
        
        public UsersController(CartwheelContext context)         
        {             
            _context = context;              
            if (_context.CartwheelUsers.Count() == 0)             
            {                 
                _context.CartwheelUsers.Add(new CartwheelUser { firstName = "Test" });
                _context.SaveChanges();             
            }         
        }

        [HttpGet] 
        public ActionResult<List<CartwheelUser>> GetAll() 
        {     
            return _context.CartwheelUsers.ToList(); 
        } 
        
        [HttpGet("{id}", Name = "GetUser")] 
        public ActionResult<CartwheelUser> GetById(long id) 
        {    
            var item = _context.CartwheelUsers.Find(id);     
            if (item == null)    
            {         
                return NotFound();     
            }     
            return item; 
        }

        

        [HttpPost]
        public async Task<ActionResult<CartwheelUser>> PostCarthweelUser(CartwheelUser item)
        {
            _context.CartwheelUsers.Add(item);
            await _context.SaveChangesAsync();
        
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

    }
}
