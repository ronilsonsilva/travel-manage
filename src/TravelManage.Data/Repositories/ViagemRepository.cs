using Microsoft.EntityFrameworkCore;
using TravelManage.Domain.Entities;
using TravelManage.Infra.Data.Context;

namespace TravelManage.Infra.Data.Repositories
{
    public class ViagemRepository : RepositoryBase<Viagem>
    {
        public ViagemRepository(TravelManageContext context) : base(context)
        {
        }

        public override async Task<IList<Viagem>> Get()
        {
            return await this._context.Set<Viagem>()
                .Include(x => x.Veiculo)
                .Include(x => x.Motorista)
                .Include(x => x.Passageiro)
                .Take(100)
                .ToListAsync(); ;
        }
    }
}
