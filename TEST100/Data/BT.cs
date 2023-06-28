using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TEST100.Models;

    public class BT : DbContext
    {
        public BT (DbContextOptions<BT> options)
            : base(options)
        {
        }

        public DbSet<TEST100.Models.NVVBN> NVVBN { get; set; } = default!;

        public DbSet<TEST100.Models.NVVHN> NVVHN { get; set; } = default!;
    }
