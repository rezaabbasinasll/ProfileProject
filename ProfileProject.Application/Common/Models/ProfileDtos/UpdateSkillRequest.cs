using ProfileProject.Domain.Entities.Profile;

namespace ProfileProject.Application.Common.Models.ProfileDtos;

public record UpdateSkillRequest(Guid profileId, int skillId, string name, SkillLevel skillLevel);