using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hospital2.Models
{
    public partial class Hospital2ContextPartial : IdentityDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=LAPTOP-HBKUD96R\\SQLEXPRESS;Database=HospitalLeave;Trusted_Connection=True;TrustServerCertificate=True");
            }
        }
    }
}
