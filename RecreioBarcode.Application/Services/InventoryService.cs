using AutoMapper;
using RecreioBarcode.Application.DTOs;
using RecreioBarcode.Application.Interfaces;
using RecreioBarcode.Domain.Entities;
using RecreioBarcode.Domain.Interfaces;

namespace RecreioBarcode.Application.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IMapper _mapper;
        private readonly IInventoryRepository _inventoryRepository;

        private readonly IInventoryLineService _inventoryLineService;
        private readonly IInventoryLocationService _inventoryLocationService;
        private readonly ILocationService _locationService;

        public InventoryService(
            IMapper mapper,
            IInventoryRepository inventoryRepository
            ,
            IInventoryLineService inventoryLineService,
            IInventoryLocationService inventoryLocationService,
            ILocationService locationService)
        {
            _inventoryRepository = inventoryRepository;
            _inventoryLineService = inventoryLineService;
            _inventoryLocationService = inventoryLocationService;
            _locationService = locationService;
            _mapper = mapper;
        }
        public async Task<InventoryDTO> GetByIdAsync(int id)
        {
            var entity = await _inventoryRepository.GetByIdAsync(id)
                 ?? throw new KeyNotFoundException("Locação não encontrada");
            return _mapper.Map<InventoryDTO>(entity);
        }
        public async Task<IEnumerable<InventoryDTO>> GetAllActiveAsync()
        {
            var entities = await _inventoryRepository.GetAllActiveAsync();            
            return _mapper.Map<IEnumerable<InventoryDTO>>(entities);
        }

        public async Task<IEnumerable<InventoryDTO>> GetAllInactiveAsync()
        {
            var entities = await _repository.GetAllInactiveAsync();
            return _mapper.Map<IEnumerable<InventoryDTO>>(entities);
        }
        public async Task<int> CreateFromCsv (InventoryDTO dto)
        {
            if (!ValidateFile(dto.ChargerFilePath))
                throw new FileLoadException("Arquivo inválido");

            var fileName = @".\LoadFIles\" + dto.Name + "-" + new Guid().ToString() + ".csv";

            File.Copy(dto.ChargerFilePath,fileName);

            using (StreamReader sr = new(fileName))
            {
                string? line;
                while((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(";");
                    if (parts.Length != 2)
                        break;

                    var d = CreateLocationDTOFromString(line[1]);
                    

                    if (_locationService.GetByDetailsAsync(d.Zona, d.Rua, d.Estante, d.Prateleira, d.Numero) == null)
                        await _locationService.CreateAsync(d); 
                }
            }
  

            return 1;  
        }
        public async Task CreateAsync(InventoryDTO dto)
        {
            var entity = _mapper.Map<Inventory >(dto);
            await _inventoryRepository.CreateAsync(entity);
        }
        public async Task UpdateAsync(InventoryDTO dto)
        {
            var entity = await _inventoryRepository.GetByIdAsync(dto.Id)
                ?? throw new KeyNotFoundException("Locação não encontrada");
            _mapper.Map(dto, entity);
            await _inventoryRepository.UpdateAsync(entity);
        }
        public async Task DeleteAsync(int id)
        {
            var entity = await _inventoryRepository.GetByIdAsync(id)
                ?? throw new KeyNotFoundException("Locação não encontrada");
            await _inventoryRepository.DeleteAsync(entity);
        }

        public bool ValidateFile(string path)
        {
            if (!File.Exists(path))
                return false;
            if (Path.GetExtension(path) is not ".csv" or ".txt")
                return false;

            string firstLine = File.ReadLines(path).First();

            if (firstLine is null or "")
                return false;
            if (firstLine.Count(c => c == ';') != 1)
                return false;

            return true;
        }

        private LocationDTO CreateLocationDTOFromString(string s)
        {
            LocationDTO dto = new();

        }




    }
}
