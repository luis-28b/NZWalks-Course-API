using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Repositories
{
    public class SQLWalkRepository : IWalkRepository
    {
        private readonly NZWalksDbContext dbContext;

        public SQLWalkRepository(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Walk> CreateAsync(Walk walk)
        {
            await dbContext.Walks.AddAsync(walk);
            await dbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk?> DeleteAsync(Guid id)
        {
            var walkToDelete = await dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (walkToDelete == null)
            {
                return null;
            }
            dbContext.Walks.Remove(walkToDelete);
            await dbContext.SaveChangesAsync();
            return walkToDelete;
        }

        public async Task<List<Walk>> GetAllAsync()
        {
            return await dbContext.Walks.Include("Difficulty").Include("Region").ToListAsync();
        }

        public async Task<Walk?> GetByIdAsync(Guid id)
        {
            return await dbContext.Walks.Include("Difficulty").Include("Region").FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Walk?> UpdateAsync(Guid id, UpdateWalkRequestDTO updateWalkRequestDTO)
        {
            var walkToUpdate = await dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (walkToUpdate == null)
            {
                return null;
            }
            walkToUpdate.Name = updateWalkRequestDTO.Name;
            walkToUpdate.Description = updateWalkRequestDTO.Description;
            walkToUpdate.DifficultyId = updateWalkRequestDTO.DifficultyId;
            walkToUpdate.LengthInKm = updateWalkRequestDTO.LengthInKm;
            walkToUpdate.WalkImageUrl = updateWalkRequestDTO.WalkImageUrl;
            walkToUpdate.RegionId = updateWalkRequestDTO.RegionId;
            await dbContext.SaveChangesAsync();
            return walkToUpdate;
        }
    }
}
