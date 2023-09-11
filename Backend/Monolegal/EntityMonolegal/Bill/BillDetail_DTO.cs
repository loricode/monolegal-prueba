using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityMonolegal.Bill
{
    public class BillDetail_DTO
    {
        [BsonElement("idBill")]
        public string IdBill { get; set; }
        
        [BsonElement("code")]
        public string Code { get; set; }

        [BsonElement("city")]
        public string City { get; set; }

        [BsonElement("totalBill")]
        public string TotalBill { get; set; }

        [BsonElement("subTotal")]
        public string subTotal { get; set; }

        [BsonElement("iva")]
        public string Iva { get; set; }

        [BsonElement("retention")]
        public string Retention { get; set; }

        [BsonElement("state")]
        public string State { get; set; } = string.Empty;

        [BsonElement("creationDate")]
        public string CreationDate { get; set; }

    }
}
