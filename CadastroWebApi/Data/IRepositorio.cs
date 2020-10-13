using CadastroWebApi.Models;
using System.Threading.Tasks;

namespace CadastroWebApi.Data
{
    public interface IRepositorio
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();
        Task<Cliente[]> GetAllClientesAsync();
        Task<Cliente> GetClienteById(long clienteId);
    }
}