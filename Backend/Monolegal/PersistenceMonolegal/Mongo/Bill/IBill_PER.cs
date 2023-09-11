using EntityMonolegal.Bill;

namespace PersistenceMonolegal.Mongo.Bill
{
    public interface IBill_PER
    {
        public Task<Bill_DTO> GetListBill(string Identification, string State);

        public Task<Bill_DTO> ChangeStateInvoice(string Identification, string State, string IdBill);

    }
}
