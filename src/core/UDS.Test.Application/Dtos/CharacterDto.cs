using UDS.Test.Domain.Models;

namespace UDS.Test.Application.Dtos;

public class CharacterDto
{
    public long Id { get; set; }

    public string Name { get; set; }

    public double Height { get; set; }

    public long Mass { get; set; }

    public string Gender { get; set; }

    public IList<string> HomeWorld { get; set; }

    public Uri Wiki { get; set; }

    public Uri Image { get; set; }

    public string Born { get; set; }

    public string BornLocation { get; set; }

    public long Died { get; set; }

    public string DiedLocation { get; set; }

    public IList<string> Affiliations { get; set; }

    public IList<string> Masters { get; set; }

    public IList<string> Apprentices { get; set; }

    public IList<string> FormerAffiliations { get; set; }

    public CharacterDto(long id, string name, double height, long mass, string gender, IList<string> homeWorld, Uri wiki, Uri image, string born, string bornLocation, long died, string diedLocation, IList<string> affiliations, IList<string> masters)
    {
        Id = id;
        Name = name;
        Height = height;
        Mass = mass;
        Gender = gender;
        HomeWorld = homeWorld;
        Wiki = wiki;
        Image = image;
        Born = born;
        BornLocation = bornLocation;
        Died = died;
        DiedLocation = diedLocation;
        Affiliations = affiliations;
        Masters = masters;
    }

    public static CharacterDto FromCharacter(Character character)
    {
        return new
        (
            character.Id,
            character.Name,
            character.Height,
            character.Mass,
            character.Gender,
            character.HomeWorld,
            character.Wiki,
            character.Image,
            character.Born,
            character.BornLocation,
            character.Died,
            character.DiedLocation,
            character.Affiliations,
            character.Masters
        );
    }
}
