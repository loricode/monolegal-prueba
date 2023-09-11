using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EntityMonolegal.Bill
{
    public class Bill_DTO
    {


        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("fullName")]
        public string FullName { get; set; } = string.Empty;

        [BsonElement("identification")]
        public string Identification { get; set; } = string.Empty;

        [BsonElement("email")]
        public string Email { get; set; } = string.Empty;

        [BsonElement("bills")]
        public List<BillDetail_DTO> Bills { get; set; } = null!;
    }
}
