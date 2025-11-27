using Microsoft.EntityFrameworkCore;

namespace hwWebAPI.Data
{
    public class ContextFactory
    {
        private const string connectionString = "Server=Srv2\\pupils;Database=BigBite;Integrated Security=SSPI;Persist Security Info=False;TrustServerCertificate=True;";

        public static BigBiteContext createContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<BigBiteContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new BigBiteContext(optionsBuilder.Options);
        }
    }
}
