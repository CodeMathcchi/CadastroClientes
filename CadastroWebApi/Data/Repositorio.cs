using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CadastroWebApi.Models;

namespace CadastroWebApi.Data
{
    public class Repositorio : IRepositorio
    {
        private readonly DataContext Context;

        public Repositorio(DataContext context)
        {
            Context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            Context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            Context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            Context.Remove(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await Context.SaveChangesAsync()) > 0;
        }
        
        public async Task<Cliente[]> GetAllClientesAsync()
        {
            IQueryable<Cliente> query = Context.Clientes;

            query.AsNoTracking().OrderBy(c => c.ClienteId);
            return await query.ToArrayAsync();
        }

        public async Task<Cliente> GetClienteById(long clienteId)
        {
            IQueryable<Cliente> query = Context.Clientes;

            return await query.AsNoTracking()
                            .Where(c => c.ClienteId == clienteId)
                            .FirstOrDefaultAsync();
        }
    }
}