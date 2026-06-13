using ProfileProject.Domain.Common;
using ProfileProject.Domain.Common.Exceptions;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace ProfileProject.Domain.Entities.Profile;

public class ProfileEntity : BaseEntity
{
    // use dapper cast
    private ProfileEntity() { }


    public ProfileEntity(string fullName, string email, string? bio = null)
    {
        FullName = fullName;
        Email = email;
        Bio = bio;
        Validator();
    }

    public string FullName { get; private set; }
    public string Email { get; private set; }
    public string? Bio { get; private set; }
    public List<Skill> Skills { get; private set; } = [];

    protected override void Validator()
    {
        if (string.IsNullOrWhiteSpace(FullName))
            throw new DomainException(DomainErrors.FullNameIsRequired);

        if (string.IsNullOrWhiteSpace(Email))
            throw new DomainException(DomainErrors.EmailIsRequired);
    }


    public ProfileEntity UpdateFullName(string fullName)
    {
        if (string.IsNullOrWhiteSpace(fullName))
            throw new DomainException(DomainErrors.FullNameIsRequired);

        FullName = fullName;
        return this;
    }

    public ProfileEntity AddSkill(Skill skill)
    {
        if (Skills.Any(x => x.Name == skill.Name))
            throw new DomainException(DomainErrors.SkilAllreadyExist);

        Skills.Add(skill);
        return this;
    }

    public ProfileEntity UpdateSkill(Skill skill)
    {
        if (!Skills.Any(x => x.Id == skill.Id))
            throw new DomainException(DomainErrors.SkillNotFound);


        var index = Skills.FindIndex(x => x.Id == skill.Id);       
        Skills[index] = skill;

        return this;
    }
}