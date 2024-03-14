using Sales.Shared.Entites;

namespace Sales.API.Data
{
    //
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        //Metodo para alimentar la base de datos
        public async Task SeedAsync()
        {
            //Metodo para llenar la base de datos
            await _context.Database.EnsureCreatedAsync();
            await CheckCountriesAsync();
        }

        private async Task CheckCountriesAsync()
        {
            //Valida si no hay registro en la base de dato
            if (!_context.Countries.Any())
            {
                _context.Countries.Add(new Country { Name = "Colombia" });
                _context.Countries.Add(new Country { Name = "Estados Unidos" });
                _context.Countries.Add(new Country { Name = "Perú" });
                _context.Countries.Add(new Country { Name = "México" });
                await _context.SaveChangesAsync();
            }
     
        }
    }
}

