using Dapper;
using MediatR;
using Infrastructure;

namespace Application.Location;

public class GetLocationsRequest : IRequest<IEnumerable<Core.Entities.Location>>
{
    public int pageNumber { get; set; }
    public int pageLimit { get; set; }
    public string? title { get; set; }
    public string? locationType { get; set; }

    public class GetLocationsHandler : IRequestHandler<GetLocationsRequest, IEnumerable<Core.Entities.Location>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetLocationsHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<IEnumerable<Core.Entities.Location>> Handle(GetLocationsRequest request, CancellationToken cancellationToken)
        {
            if (request.title == null)
                request.title = "";
            if (request.locationType == null)
                request.locationType = "";
            
            if (request.pageNumber < 1 || request.pageLimit < 1)
                return null!;
            
            var parameters = new DynamicParameters();
            parameters.Add("pageNumber", request.pageNumber);
            parameters.Add("pageLimit", request.pageLimit);
            parameters.Add("title", request.title);
            parameters.Add("locationType", request.locationType);
            
            var result = await _unitOfWork.Location.GetLocations(parameters);
            return result;
        }
    }
}
