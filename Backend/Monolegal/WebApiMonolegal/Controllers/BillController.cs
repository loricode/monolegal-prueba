using ApplicationMonolegal.Bill;
using EntityMonolegal.Bill;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApiMonolegal.Controllers
{
    public class BillController : ControllerBaseApi
    {
        /// <summary>        
        /// Obtiene el listado de facturas
        /// </summary>
        /// <param name="Identification">Identificador del usuario</param>
        /// <param name="State">Estado de la factura</param>
        /// <returns>
        /// {IEnumerable<Bill_DTO>} Retorna lista de facturas
        /// </returns>
        //http://localhost:5000/api/Bill/List
        [HttpPost("List")]
        public async Task<Bill_DTO> List(Bill_BL.ListBill Data)
        {
            return await Mediator.Send(Data);
        }

        /// <summary>        
        /// Obtiene el listado de facturas
        /// </summary>
        /// <param name="Identification">Identificador del usuario</param>
        /// <param name="State">Estado de la factura</param>
        /// <param name="State">Estado de la factura</param>
        /// <returns>
        /// {IEnumerable<Bill_DTO>} Retorna lista de facturas
        /// </returns>
        //http://localhost:5000/api/Bill/ChangeState
        [HttpPost("ChangeState")]
        public async Task<Unit> ChangeState(BillChangeState_BL.BillChangeState Data)
        {
            return await Mediator.Send(Data);
        }

    }
}
