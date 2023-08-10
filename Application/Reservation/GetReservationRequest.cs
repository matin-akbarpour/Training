using MediatR;
using FluentResults;
using Infrastructure;

namespace Application.Reservation;

public class GetReservationsRequest : IRequest<Result<IEnumerable<Core.Entities.Reservation>>>
{
    public class GetReservationsHandler : IRequestHandler<GetReservationsRequest, Result<IEnumerable<Core.Entities.Reservation>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetReservationsHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<Result<IEnumerable<Core.Entities.Reservation>>> Handle(GetReservationsRequest request, CancellationToken cancellationToken)
        {
            var result = new Result<IEnumerable<Core.Entities.Reservation>>();

            var reservations = await _unitOfWork.Reservation.GetAllAsync();
            return result.WithValue(reservations);
        }
    }
}
