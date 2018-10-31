using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace MyNetCoreMVC_again.Models
{
    public class MyDbContentText :DbContext
    {
        public MyDbContentText(DbContextOptions<MyDbContentText> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
