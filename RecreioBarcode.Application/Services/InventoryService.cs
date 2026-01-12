using AutoMapper;
using RecreioBarcode.Application.DTOs;
using RecreioBarcode.Application.Interfaces;
using RecreioBarcode.Domain.Entities;
using RecreioBarcode.Domain.UnitOfWork;
using System.Linq.Expressions;


namespace RecreioBarcode.Application.Services;

public class InventoryService(IMapper mapper, IUnitOfWork uow) : IInventoryService
{
    private readonly IMapper _mapper = mapper;
    private readonly IUnitOfWork _uow = uow;

    public async Task<InventoryDTO> GetAsync(Expression<Func<Inventory,bool>> predicate)
    {
        var entity = await _uow.InventoryRepository.Get(predicate);
        return _mapper.Map<InventoryDTO>(entity);
    }
    public async Task<IEnumerable<InventoryDTO>> GetAllAsync(Expression<Func<Inventory, bool>> predicate)
    {
        var entities = await _uow.InventoryRepository.GetAll(predicate);            
        return _mapper.Map<IEnumerable<InventoryDTO>>(entities);
    }
    //public async Task<InventoryDTO> CreateFromCsvAsync(InventoryDTO dto)
    //{
    //    if (!ValidateFile(@".\P\A.csv"))
    //        throw new FileLoadException("Arquivo inválido");

    //    var entity = _mapper.Map<Inventory>(dto);
    //    var inventoryEntity = _uow.InventoryRepository.Create(entity);

    //    using (StreamReader sr = new(@".\P\A.csv"))
    //    {
    //        string? line;
    //        while((line = sr.ReadLine()) != null)
    //        {
    //            string[] parts = line.Split(";");
    //            if (parts.Length != 2)
    //                throw new FileLoadException("Arquivo inválido");

    //            var locationDto = CreateLocationDTOFromString(parts[1]);
    //            var locationEntity = _mapper.Map<Location>(locationDto); 
    //            if(await _uow.LocationRepository.GetByDetailsAsync(locationEntity) == null)
    //            {
    //                locationEntity = _uow.LocationRepository.Create(locationEntity);
    //            }
    //            else
    //            {
    //                locationEntity = await _uow.LocationRepository.GetByDetailsAsync(locationEntity);
    //            }

    //            var inventoryLocationDto = new InventoryLocationDTO
    //            {
    //                Location = locationEntity,
    //                Inventory = inventoryEntity
    //            };
    //            var inventoryLocationEntity = _mapper.Map<InventoryLocation>(inventoryLocationDto);
    //            inventoryLocationEntity = _uow.InventoryLocationRepository.Create(inventoryLocationEntity);

    //            var inventoryLineDto = new InventoryLineDTO
    //            {
    //                InventoryLocation = inventoryLocationEntity,
    //                ItemCode = parts[0]
    //            };

    //            var inventoryLineEntity = _mapper.Map<InventoryLine>(inventoryLineDto);
    //            _uow.InventoryLineRepository.Create(inventoryLineEntity);

    //        }
    //    }
    //    await _uow.Commit();
    //    return _mapper.Map<InventoryDTO>(inventoryEntity);  
    //}
    public async Task<bool> UpdateAsync(InventoryDTO dto)
    {
        var entity = await _uow.InventoryRepository.Get(x => x.Id == dto.Id);
        if(entity is null)
            return false;

        _mapper.Map(dto, entity);
        _uow.InventoryRepository.Update(entity);
        await _uow.Commit();
        return true;        
    }
    public async Task<bool> DeleteAsync(InventoryDTO dto)
    {
        var entity = await _uow.InventoryRepository.Get(x => x.Id == dto.Id);
        if(entity == null)
            return false;

        _mapper.Map(dto, entity);
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
        return true;  
    }
    private bool ValidateLine(string line)
    {
        if (string.IsNullOrWhiteSpace(line))
            return false;
        if (line.Count(c => c == ';') != 1)
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
