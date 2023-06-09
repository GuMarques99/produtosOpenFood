using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace produtosOpenFood.Models
{
  public class Product
  {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("code")]
    public int code { get; set; }

    [BsonElement("status")]
    public string status { get; set; }

    [BsonElement("imported_t")]
    public DateTime imported_t { get; set; }

    [BsonElement("url")]
    public string url { get; set; }

    [BsonElement("creator")]
    public string creator { get; set; }

    [BsonElement("created_t")]
    public int? created_t { get; set; }

    [BsonElement("last_modified_t")]
    public int? last_modified_t { get; set; }

    [BsonElement("product_name")]
    public string product_name { get; set; }

    [BsonElement("quantity")]
    public string quantity { get; set; }

    [BsonElement("brands")]
    public string brands { get; set; }

    [BsonElement("categories")]
    public string categories { get; set; }

    [BsonElement("labels")]
    public string labels { get; set; }

    [BsonElement("cities")]
    public string cities { get; set; }

    [BsonElement("purchase_places")]
    public string purchase_places { get; set; }

    [BsonElement("stores")]
    public string stores { get; set; }

    [BsonElement("ingredients_text")]
    public string ingredients_text { get; set; }

    [BsonElement("traces")]
    public string traces { get; set; }

    [BsonElement("serving_size")]
    public string serving_size { get; set; }

    [BsonElement("serving_quantity")]
    public double serving_quantity { get; set; }

    [BsonElement("nutriscore_score")]
    public int nutriscore_score { get; set; }

    [BsonElement("nutriscore_grade")]
    public string nutriscore_grade { get; set; }

    [BsonElement("main_category")]
    public string main_category { get; set; }

    [BsonElement("image_url")]
    public string image_url { get; set; }
  }
}
