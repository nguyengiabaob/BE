// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
public class Address
{
    public string building { get; set; }
    public List<double> coord { get; set; }
    public string street { get; set; }
    public string zipcode { get; set; }
}

public class Date
{

    public DateTime date { get; set; }
}

public class Grade
{
    public Date date { get; set; }
    public string grade { get; set; }
    public int score { get; set; }
}

public class Id
{

    public string oid { get; set; }
}

public class Student
{
    [BsonIgnore]
    public Id _id { get; set; }
    // [BsonIgnore]
    //     public Address address { get; set; }
    //     [BsonIgnore]
    //     public string borough { get; set; }
    //     [BsonIgnore]
    //     public string cuisine { get; set; }
    //     [BsonIgnore]
    //     public List<Grade> grades { get; set; }
    //     [BsonIgnore]
    //     public string name { get; set; }
    //     [BsonIgnore]
    //     public string restaurant_id { get; set; }
    //     [JsonIgnore]  // Ignore the Action property during serialization
    //     public Action MoveNextAction { get; set; }
}

