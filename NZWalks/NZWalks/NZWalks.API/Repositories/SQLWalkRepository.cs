﻿using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Walk>> GetAllAsync(
            string? filterOn = null,
            string? filterQuery = null,
            string? sortBy = null,
            bool isAscending = true,
            int pageNumber = 1,
            int pageSize = 1000
        )
        {
            var walks = dbContext.Walks.Include("Difficulty").Include("Region").AsQueryable();
            
            // Filter
            if (string.IsNullOrEmpty(filterOn) == false && string.IsNullOrEmpty(filterQuery) == false)
            {
                if (filterOn.Equals("Name"))
                {
                    walks = walks.Where(x => x.Name.Contains(filterQuery));
                }
            }
            // Sort
            if (string.IsNullOrEmpty(sortBy) == false)
            {
                if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAscending ? walks.OrderBy(x => x.Name) : walks.OrderByDescending(x => x.Name);
                } else if (sortBy.Equals("Length", StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAscending ? walks.OrderBy(x => x.LengthInKm) : walks.OrderByDescending(x => x.LengthInKm);
                }
            }
            // Pagination
            var skipResults = (pageNumber - 1) * pageSize;

            return await walks.Skip(skipResults).Take(pageSize).ToListAsync();
            // return await dbContext.Walks.Include("Difficulty").Include("Region").ToListAsync();
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
