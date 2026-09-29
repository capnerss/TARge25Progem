using Microsoft.EntityFrameworkCore;
using System.Xml;
using TARge25Shop.Core.Domain;
using TARge25Shop.Core.Dto;
using TARge25Shop.Core.ServiceInterface;
using TARge25Shop.Data;

namespace TARge25Shop.ApplicationServices.Services
{
    public class RealEstateServices : IRealEstateServices
    {
        private readonly TARge25ShopContext _context;

        public RealEstateServices(TARge25ShopContext context)
        {
            _context = context;
        }

        public async Task<RealEstate> Create(RealEstateDto dto)
        {
            RealEstate realestate = new();

            realestate.Id = Guid.NewGuid();
            realestate.Area = dto.Area;
            realestate.Location = dto.Location;
            realestate.RoomNumber = dto.RoomNumber;
            realestate.BuildingType = dto.BuildingType;
            realestate.CreatedAt = DateTime.Now;
            realestate.ModifiedAt = DateTime.Now;

            _context.RealEstates.Add(realestate);
            await _context.SaveChangesAsync();

            return realestate;
        }

        public async Task<RealEstate> Update(RealEstateDto dto)
        {
            RealEstate realestate = new();

            realestate.Id = dto.Id;
            realestate.Area = dto.Area;
            realestate.Location = dto.Location;
            realestate.RoomNumber = dto.RoomNumber;
            realestate.BuildingType = dto.BuildingType;
            realestate.CreatedAt = dto.CreatedAt;
            realestate.ModifiedAt = DateTime.Now;

            _context.RealEstates.Update(realestate);
            await _context.SaveChangesAsync();

            return realestate;
        }

        public async Task<RealEstate> DetailAsync(Guid id)
        {
            var realestate = await _context.RealEstates
                .FirstOrDefaultAsync(x => x.Id == id);

            return realestate;
        }

        public async Task<RealEstate> Delete(Guid id)
        {
            var result = await _context.RealEstates
                .FirstOrDefaultAsync(x => x.Id == id);

            if (result != null)
            {
                _context.RealEstates.Remove(result);
                await _context.SaveChangesAsync();
            }

            return result;
        }
    }
}
