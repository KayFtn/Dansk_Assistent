using System.Text.Json.Serialization;
using Newtonsoft.Json;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
public class Word{
    [JsonProperty("Engelsk")]
    public string Engelsk {get;set;}

    [JsonProperty("Dansk")]
    public string Dansk {get;set;}

    [JsonProperty("Vink")]
    public string Vink {get;set;}

    [JsonProperty("Details")]
    public string Details {get;set;}

}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.