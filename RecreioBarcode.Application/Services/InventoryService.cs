
namespace RecreioBarcode.Application.Services
{
    public class InventoryService
    {
        private readonly Invetoryre _repository;
        public InventoryService(InventoryRepository repository)
        {
            _repository = repository;
        }
        public async Task CreateInventoryAsync(Inventory inventory)
        {
            await _repository.CreateInventoryAsync(inventory);
        }
    }
}
