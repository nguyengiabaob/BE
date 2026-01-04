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

    public string date { get; set; }
}

public class Grade
{

    public DateTime date { get; set; }
    public string grade { get; set; }
    public int score { get; set; }
}



public class Student
{
        [BsonId]
        public object _id { get; set; }
    
        public Address address { get; set; }
      
        public string borough { get; set; }
   
        public string cuisine { get; set; }

        public List<Grade> grades { get; set; }
    
        public string name { get; set; }
     
        public string restaurant_id { get; set; }
        // Ignore the Action property during serialization

}

