using Newtonsoft.Json;
using UDS.Test.Repositories.Converters;

namespace UDS.Test.Repositories.Responses;

public record CharacterResponse
{
    public long Id { get; set; }

    public string Name { get; set; }

    public double Height { get; set; }

    public long Mass { get; set; }

    public string Gender { get; set; }

    [JsonConverter(typeof(SingleOrArrayConverter))]
    public IList<string> Homeworld { get; set; } = [];

    public Uri Wiki { get; set; }

    public Uri Image { get; set; }

    public string Born { get; set; }

    public string BornLocation { get; set; }

    public long Died { get; set; }

    public string DiedLocation { get; set; }

    public IList<string> Affiliations { get; set; }

    [JsonConverter(typeof(SingleOrArrayConverter))]
    public IList<string> Masters { get; set; } = [];
}
