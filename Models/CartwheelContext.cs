using Microsoft.EntityFrameworkCore;  

namespace CartwheelApi.Models {     
public class CartwheelContext : DbContext     
  {         
    public CartwheelContext(DbContextOptions<CartwheelContext> options)                            : base(options)         
{         
}       
    public DbSet<CartwheelUser> CartwheelUsers { get; set; }     
  
   } 
}