using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using TravelManage.Domain.Entities;
using TravelManage.Infra.Data.Context;

namespace TravelManage.Infra.Data.Repositories
{
    public class TipoPagamentoRepository : RepositoryBase<TipoPagamento>
    {
        public TipoPagamentoRepository(TravelManageContext context) : base(context)
        {
        }

        public override async Task<TipoPagamento> Get(int id)
        {
            return await Get(x => x.Codigo == id).FirstOrDefaultAsync();
        }
    }

}
