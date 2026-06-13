using System.Diagnostics;

namespace ProfileProject.Domain.Entities.Profile;

public class Skill
{
    public Skill(string name, SkillLevel skillLevel)
    {
        Name = name;
        SkillLevel = skillLevel;
    }

    public int Id { get; private set; }
    public string Name { get; private set; }
    public SkillLevel SkillLevel { get; private set; }


    public Skill Update(string name, SkillLevel skillLevel)
    {
        Name = name;
        SkillLevel = skillLevel;

        return this;
    }
}
