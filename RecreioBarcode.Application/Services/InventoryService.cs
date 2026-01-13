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

    public async Task<InventoryDTO> GetAsync(Expression<Func<Inventory, bool>> predicate)
    {
        var entity = await _uow.InventoryRepository.Get(predicate);
        return _mapper.Map<InventoryDTO>(entity);
    }
    public async Task<IEnumerable<InventoryDTO>> GetAllAsync(Expression<Func<Inventory, bool>> predicate)
    {
        var entities = await _uow.InventoryRepository.GetAll(predicate);
        return _mapper.Map<IEnumerable<InventoryDTO>>(entities);
    }
    public async Task<InventoryDTO?> CreateFromCsvAsync(Stream stream)
    {
        InventoryDTO inventoryDto = new InventoryDTO();
        var inventoryEntity = _uow.InventoryRepository.Create(_mapper.Map<Inventory>(inventoryDto));

        if (stream is null)
            return null;

        using (StreamReader sr = new StreamReader(stream))
        {
            string? line;
            while ((line = sr.ReadLine()) != null)
            {
                if (!ValidateLine(line))
                    return null;

                string[] parts = line.Split(";");

                var locationDto = CreateLocationDTOFromString(parts[1]);
                if (locationDto == null)
                    return null;

                var locationEntity = await _uow.LocationRepository.Get(x =>
                    x.Zona == locationDto.Zona &&
                    x.Rua == locationDto.Rua &&
                    x.Estante == locationDto.Estante &&
                    x.Prateleira == locationDto.Prateleira &&
                    x.Numero == locationDto.Numero);
                if (locationEntity == null)
                {
                    locationEntity = _uow.LocationRepository.Create(_mapper.Map<Location>(locationDto));
                }
                else
                    _mapper.Map(locationDto, locationEntity);

                var inventoryLocationDto = new InventoryLocationDTO
                {
                    Inventory = inventoryDto,
                    Location = locationDto,
                };
                var inventoryLocationEntity = await _uow.InventoryLocationRepository.Get(x => x.Inventory == inventoryEntity && x.Location == locationEntity);
                if (inventoryLocationEntity == null)
                {
                    _mapper.Map(inventoryLocationDto, inventoryLocationEntity);
                    inventoryLocationEntity = _uow.InventoryLocationRepository.Create(inventoryLocationEntity);
                }
                else
                    _mapper.Map(inventoryLocationDto, inventoryLocationEntity);

                var inventoryLineDto = new InventoryLineDTO
                {
                    InventoryLocation = inventoryLocationDto,
                    ItemCode = parts[0]
                };
                var inventoryLineEntity = _mapper.Map<InventoryLine>(inventoryLineDto);
                _uow.InventoryLineRepository.Create(inventoryLineEntity);
            }
        }
        await _uow.Commit();
        return _mapper.Map<InventoryDTO>(inventoryEntity);
    }
    public async Task<bool> UpdateAsync(int id, UpdateInventoryDTO dto)
    {
        var entity = await _uow.InventoryRepository.Get(x => x.Id == id);
        if (entity is null)
            return false;

        _mapper.Map(dto, entity);
        _uow.InventoryRepository.Update(entity);
        await _uow.Commit();
        return true;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _uow.InventoryRepository.Get(x => x.Id == id);
        if (entity is null)
            return false;

        _uow.InventoryRepository.Delete(entity);
        await _uow.Commit();
        return true;
    }

    private bool ValidateLine(string line)
    {
        if (string.IsNullOrWhiteSpace(line))
            return false;
        if (line.Count(c => c == ';') != 1)
            return false;
        if (line.Length > 28)
            return false;

        return true;
    }

    private LocationDTO? CreateLocationDTOFromString(string s)
    {
        if (!char.TryParse(s.Substring(0, 1).Trim(), out char zona))
            return null;
        if (!int.TryParse(s.Substring(1, 2).Trim(), out int rua))
            return null;
        if (!int.TryParse(s.Substring(3, 3).Trim(), out int estante))
            return null;
        if (!char.TryParse(s.Substring(6, 1).Trim(), out char prateleira))
            return null;
        if (!int.TryParse(s.Substring(7, 3).Trim(), out int numero))
            return null;

        return new LocationDTO
        {
            Zona = zona,
            Rua = rua,
            Estante = estante,
            Prateleira = prateleira,
            Numero = numero
        };
    }
}
