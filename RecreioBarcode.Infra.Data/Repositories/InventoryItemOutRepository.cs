using Microsoft.EntityFrameworkCore;
using RecreioBarcode.Domain.Entities;
using RecreioBarcode.Domain.Interfaces;
using RecreioBarcode.Infra.Data.Context;

namespace RecreioBarcode.Infra.Data.Repositories
{
    public class InventoryItemOutRepository : Repository<InventoryItemOut>, IInventoryItemOutRepository
    {
        public InventoryItemOutRepository(ApplicationContext context) : base(context) { }

    }
}
