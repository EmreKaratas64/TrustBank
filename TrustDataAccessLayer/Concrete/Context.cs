using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TrustBank_EntityLayer.Concrete;

namespace TrustBank_DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-NKLMS7G\\MSSQLSERVER01;initial catalog=TrustBankDB;integrated Security=true");
        }

        public DbSet<CustomerAccount> CustomerAccounts { get; set; }

        public DbSet<CustomerAccountActivity> CustomerAccountsActivities { get; set; }
    }
}
