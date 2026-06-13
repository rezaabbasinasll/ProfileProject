using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProfileProject.DataAccess.Common.Implementations;
using ProfileProject.DataAccess.Persistence;
using ProfileProject.Domain.Common;
using ProfileProject.Domain.Entities.Profile;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace ProfileProject.DataAccess.Profile;

public class ProfileRepository : BaseRepository<ProfileEntity>, IProfileRepository
{
    public ProfileRepository(ApplicationDbContext db) : base(db)
    {
    }

    public async Task<ProfileEntity?> GetProfileWithSkillsAsync(Guid profileId)
    {
        return await DbSet
            .Include(x => x.Skills)
            .FirstOrDefaultAsync(x =>
                x.Id == profileId &&
                !x.IsDeleted);
    }

    public async Task<bool> EmailExistsAsync(string email)
    {
        return await DbSet
            .AnyAsync(x =>
                x.Email == email &&
                !x.IsDeleted);
    }
}