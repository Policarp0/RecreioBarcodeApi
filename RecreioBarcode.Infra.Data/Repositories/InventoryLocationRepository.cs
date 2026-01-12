using Microsoft.EntityFrameworkCore;
using RecreioBarcode.Domain.Entities;
using RecreioBarcode.Domain.Interfaces;
using RecreioBarcode.Infra.Data.Context;

namespace RecreioBarcode.Infra.Data.Repositories
{
    public class InventoryLocationRepository : Repository<InventoryLocation>, IInventoryLocationRepository
    {
        public InventoryLocationRepository(ApplicationContext context) : base(context) { }

        
    }
}
