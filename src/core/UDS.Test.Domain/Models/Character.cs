namespace UDS.Test.Domain.Models;

public class Character
{
    public long Id { get; set; }

    public string Name { get; set; }

    public double Height { get; set; }

    public long Mass { get; set; }

    public string Gender { get; set; }

    public string Homeworld { get; set; }

    public Uri Wiki { get; set; }

    public Uri Image { get; set; }

    public long Born { get; set; }

    public string BornLocation { get; set; }

    public long Died { get; set; }

    public string DiedLocation { get; set; }

    public IList<string> Affiliations { get; set; }

    public IList<string> Masters { get; set; }

    public IList<string> Apprentices { get; set; }

    public IList<string> FormerAffiliations { get; set; }

    public Character(
        long id,
        string name,
        double height,
        long mass,
        string gender,
        string homeworld,
        Uri wiki,
        Uri image,
        long born,
        string bornLocation,
        long died,
        string diedLocation,
        IList<string> affiliations,
        IList<string> masters
    )
    {
        Id = id;
        Name = name;
        Height = height;
        Mass = mass;
        Gender = gender;
        Homeworld = homeworld;
        Wiki = wiki;
        Image = image;
        Born = born;
        BornLocation = bornLocation;
        Died = died;
        DiedLocation = diedLocation;
        Affiliations = affiliations;
        Masters = masters;
    }
}
