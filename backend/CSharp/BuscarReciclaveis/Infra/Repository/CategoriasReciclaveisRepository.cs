using BuscarReciclaveis.Domain.Entidades;
using BuscarReciclaveis.Domain.Enums;
using BuscarReciclaveis.Domain.Interfaces.Repository;
using BuscarReciclaveis.Infra.Database;
using Microsoft.EntityFrameworkCore;

namespace BuscarReciclaveis.Infra.Repository
{
    public class CategoriasReciclaveisRepository : BaseRepository<CategoriasReciclaveis>, ICategoriasReciclaveisRepository
    {
        public CategoriasReciclaveisRepository(AppDbContext appDbContext) : base(appDbContext){ }

        public void Delete(int Id)
        {
            var caregoria = DbSet.First(x => x.Id == Id);

            if (caregoria.Status != Status.Excluido)
            {
                caregoria.Status = Status.Excluido;
                _context.Update(caregoria);
                SaveChanges();
            }
        }

        public async Task<IList<CategoriasReciclaveis>> SelectAllAsync()
        {
            var query = await _context.Set<CategoriasReciclaveis>()
                .Where(x => x.Status == Status.Ativo)
                .ToListAsync();

            return query;
        }
    }
}