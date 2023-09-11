using EntityMonolegal.Bill;
using FluentValidation;
using MediatR;
using PersistenceMonolegal.Mongo.Bill;

namespace ApplicationMonolegal.Bill
{
    public class Bill_BL
    {
        public class ListBill : IRequest<Bill_DTO> 
        {
            public string Identification { get; set; } = string.Empty;
            public string State { get; set; } = string.Empty;

        }

        public class EjecutaValidacion : AbstractValidator<ListBill>
        {
            public EjecutaValidacion()
            {
                RuleFor(x => x.Identification).NotEmpty().WithMessage("Error_UserId_NOTEMPTY");
                RuleFor(x => x.State).NotEmpty().WithMessage("Error_State_NOTEMPTY");
            }
        }

        public class Handler : IRequestHandler<ListBill, Bill_DTO>
        {

            private readonly IBill_PER _billRepository;

            public Handler(IBill_PER billRepository)
            {
                _billRepository = billRepository;
            }

            public async Task<Bill_DTO> Handle(ListBill request, CancellationToken cancellationToken)
            {
                return await _billRepository.GetListBill(request.Identification, request.State);
            }
        }

    }
}
