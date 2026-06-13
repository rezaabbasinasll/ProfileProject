using ProfileProject.Domain.Entities.Profile;

namespace ProfileProject.Application.Common.Models.ProfileDtos;

public record AddSkillDto(Guid profileId, string name, SkillLevel skillLevel);