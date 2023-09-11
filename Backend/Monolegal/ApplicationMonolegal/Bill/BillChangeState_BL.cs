using ApplicationMonolegal.SendEmail;
using FluentValidation;
using MediatR;
using PersistenceMonolegal.Mongo.Bill;


namespace ApplicationMonolegal.Bill
{
    public class BillChangeState_BL
    {
        public class  BillChangeState: IRequest<Unit>
        {
            public string Identification { get; set; } = string.Empty;
            public string State { get; set; } = string.Empty;
            public string IdBill { get; set; } = string.Empty;

        }

        public class EjecutaValidacion : AbstractValidator<BillChangeState>
        {
            public EjecutaValidacion()
            {
                RuleFor(x => x.Identification).NotEmpty().WithMessage("Error_UserId_NOTEMPTY");
                RuleFor(x => x.State).NotEmpty().WithMessage("Error_State_NOTEMPTY");
                RuleFor(x => x.IdBill).NotEmpty().WithMessage("Error_IdBill_NOTEMPTY");
            }
        }

        public class Handler : IRequestHandler<BillChangeState, Unit>
        {

            private readonly IBill_PER _billRepository;

            public Handler(IBill_PER billRepository)
            {
                _billRepository = billRepository;
            }

            public async Task<Unit> Handle(BillChangeState request, CancellationToken cancellationToken)
            {

                var result = await _billRepository.ChangeStateInvoice(request.Identification, request.State, request.IdBill);

                if (result != null)
                {

                    SendEmail_BL.SendEmail(result.FullName, request.State, result.Email);

                    return Unit.Value;
                }

                throw new InvalidOperationException("Error");

            }
        }


    }
}
