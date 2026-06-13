using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProfileProject.Api.Contracts.Models;
using ProfileProject.Application.Services.Profile;
using ProfileProject.Domain.Entities.Profile;
using System.Linq.Expressions;

namespace ProfileProject.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProfileController : ControllerBase
{
    private readonly IProfileService _profileService;

    public ProfileController(IProfileService profileService)
    {
        _profileService = profileService;
    }




    [HttpGet("{Id:Guid}")]
    public async Task<ActionResult<BaseResult<ProfileEntity>>> GetById([FromRoute] Guid Id)
    {
        var result = await _profileService.GetProfileByIdAsync(Id);
        return BaseResult<ProfileEntity>.Success(result);
    }
}
