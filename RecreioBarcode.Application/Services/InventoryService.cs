using AutoMapper;
using RecreioBarcode.Application.DTOs;
using RecreioBarcode.Application.Interfaces;
using RecreioBarcode.Domain.Entities;
using RecreioBarcode.Domain.UnitOfWork;


namespace RecreioBarcode.Application.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public InventoryService(
            IMapper mapper,
            IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }
        public async Task<InventoryDTO> GetById(int id)
        {
            var entity = await _uow.InventoryRepository.Get(x => x.Id == id)
                 ?? throw new KeyNotFoundException("Locação não encontrada");
            return _mapper.Map<InventoryDTO>(entity);
        }
        public async Task<IEnumerable<InventoryDTO>> GetAllActiveAsync()
        {
            var entities = await _uow.InventoryRepository.GetAllActiveAsync();            
            return _mapper.Map<IEnumerable<InventoryDTO>>(entities);
        }
        public async Task<IEnumerable<InventoryDTO>> GetAllInactiveAsync()
        {
            var entities = await _uow.InventoryRepository.GetAllInactiveAsync();
            return _mapper.Map<IEnumerable<InventoryDTO>>(entities);
        }
        public async Task<InventoryDTO> CreateFromCsv (InventoryDTO dto)
        {
            if (!ValidateFile(@".\P\A.csv"))
                throw new FileLoadException("Arquivo inválido");

            var entity = _mapper.Map<Inventory>(dto);
            var inventoryEntity = _uow.InventoryRepository.Create(entity);

            using (StreamReader sr = new(@".\P\A.csv"))
            {
                string? line;
                while((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(";");
                    if (parts.Length != 2)
                        throw new FileLoadException("Arquivo inválido");

                    var locationDto = CreateLocationDTOFromString(parts[1]);
                    var locationEntity = _mapper.Map<Location>(locationDto); 
                    if(await _uow.LocationRepository.GetByDetailsAsync(locationEntity) == null)
                    {
                        locationEntity = _uow.LocationRepository.Create(locationEntity);
                    }
                    else
                    {
                        locationEntity = await _uow.LocationRepository.GetByDetailsAsync(locationEntity);
                    }

                    var inventoryLocationDto = new InventoryLocationDTO
                    {
                        Location = locationEntity,
                        Inventory = inventoryEntity
                    };
                    var inventoryLocationEntity = _mapper.Map<InventoryLocation>(inventoryLocationDto);
                    inventoryLocationEntity = _uow.InventoryLocationRepository.Create(inventoryLocationEntity);

                    var inventoryLineDto = new InventoryLineDTO
                    {
                        InventoryLocation = inventoryLocationEntity,
                        ItemCode = parts[0]
                    };

                    var inventoryLineEntity = _mapper.Map<InventoryLine>(inventoryLineDto);
                    _uow.InventoryLineRepository.Create(inventoryLineEntity);

                }
            }
            await _uow.Commit();
            return _mapper.Map<InventoryDTO>(inventoryEntity);  
        }
        public async Task<bool> UpdateAsync(InventoryDTO dto)
        {
            var entity = await _uow.InventoryRepository.Get(x => x.Id == dto.Id)
                ?? throw new KeyNotFoundException("Inventário não encontrada");

            _mapper.Map(dto, entity);
            _uow.InventoryRepository.Update(entity);

            await _uow.Commit();
            return true;        
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _uow.InventoryRepository.Get(x => x.Id == id)
                ?? throw new KeyNotFoundException("Inventário nao encontrado");

            _uow.InventoryRepository.Delete(entity);

            await _uow.Commit();
            return true;
        }
        
        
        private bool ValidateFile(string path)
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
        private LocationDTO? CreateLocationDTOFromString(string s)
        {
            
            if(!char.TryParse(s.Substring(0,1).Trim(), out char zona))
                return null;
            if(!int.TryParse(s.Substring(1,2).Trim(), out int rua))
                return null;
            if(!int.TryParse(s.Substring(3,3).Trim(), out int estante))
                return null;
            if(!char.TryParse(s.Substring(6,1).Trim(), out char prateleira))
                return null;
            if(!int.TryParse(s.Substring(7,3).Trim(), out int numero))
                return null;

            return new LocationDTO { 
                Zona = zona,
                Rua = rua,
                Estante = estante,
                Prateleira  = prateleira,
                Numero = numero };
        }
    }
}
