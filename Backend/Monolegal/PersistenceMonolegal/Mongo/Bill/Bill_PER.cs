using EntityMonolegal.Bill;
using MongoDB.Driver;
using PersistenceMonolegal.Conexion;

namespace PersistenceMonolegal.Mongo.Bill
{
    public class Bill_PER : IBill_PER
    {

        private readonly IFactoryConnection _factoryConnection;

        public Bill_PER(IFactoryConnection factoryConnection)
        {
            _factoryConnection = factoryConnection;

        }

        public async Task<Bill_DTO> ChangeStateInvoice(string Identification, string State, string IdBill)
        {
            try
            {

                var conection = _factoryConnection.Connect();
                var billCollection = conection.GetCollection<Bill_DTO>("bills");
               
                var c = await billCollection.Find(x => x.Identification == Identification).FirstAsync();

                var filter = Builders<Bill_DTO>.Filter.Eq(x => x.Identification, Identification);

                int index = c.Bills.FindIndex(x => x.IdBill == IdBill);

                var update = Builders<Bill_DTO>.Update.Set(x => x.Bills[index].State, State);

                await billCollection.UpdateOneAsync(filter, update);

                return c;
                
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error" + ex.Message);

            }
        }

        public async Task<Bill_DTO> GetListBill(string Identification, string State)
        {
            Bill_DTO billDetail = new();

            try
            {

                var conection = _factoryConnection.Connect();
                var billCollection = conection.GetCollection<Bill_DTO>("bills");
                var result = await billCollection.Find(
                    item => item.Identification == Identification).FirstAsync();
                   
                var arr = result.Bills.FindAll(x => x.State == State);

                billDetail.Id = result.Id;
                billDetail.FullName = result.FullName;
                billDetail.Email = result.Email;
                billDetail.Identification = result.Identification;
                billDetail.Bills = arr;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error" + ex.Message);

            }
            
            return billDetail;

        }

    }
}
