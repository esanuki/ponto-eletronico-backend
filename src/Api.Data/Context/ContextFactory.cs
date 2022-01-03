using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<PontoEletronicoContext>
    {
        public PontoEletronicoContext CreateDbContext(string[] args)
        {
            var connectionString = "Server=(localdb)\\MSSQLLocalDB;Initial Catalog=PontoEletronico;Integrated Security=true;";
            var optionBuilder = new DbContextOptionsBuilder<PontoEletronicoContext>();

            optionBuilder.UseSqlServer(connectionString);
            return new PontoEletronicoContext(optionBuilder.Options);
        }
    }
}
