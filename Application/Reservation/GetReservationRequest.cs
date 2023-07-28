using MediatR;
using Infrastructure;

namespace Application.Reservation;

public class GetReservationsRequest : IRequest<IEnumerable<Core.Entities.Reservation>>
{
    public class GetReservationsHandler : IRequestHandler<GetReservationsRequest, IEnumerable<Core.Entities.Reservation>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetReservationsHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<IEnumerable<Core.Entities.Reservation>> Handle(GetReservationsRequest request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Reservation.GetReservations();
            return result;
        }
    }
}
