// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
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
    [BsonId]
    public Id _id { get; set; }
    public Address address { get; set; }
    public string borough { get; set; }
    public string cuisine { get; set; }
    public List<Grade> grades { get; set; }
    public string name { get; set; }
    public string restaurant_id { get; set; }
}

