using Dapper;
using MediatR;
using FluentResults;
using Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace Application.Location;

public class GetLocationsRequest : IRequest<Result<IEnumerable<Core.Entities.Location>>>
{
    [Required]
    public int pageNumber { get; set; }
    [Required]
    public int pageLimit { get; set; }
    public string? title { get; set; }
    public string? locationType { get; set; }

    public class GetLocationsHandler : IRequestHandler<GetLocationsRequest, Result<IEnumerable<Core.Entities.Location>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetLocationsHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<Result<IEnumerable<Core.Entities.Location>>> Handle(GetLocationsRequest request, CancellationToken cancellationToken)
        {
            var result = new Result<IEnumerable<Core.Entities.Location>>();

            if (request.pageNumber < 1 || request.pageLimit < 1)
                return result.WithSuccess("pageNumber & pageLimit must be greater than 0");
                
            if (request.title == null)
                request.title = "";
            if (request.locationType == null)
                request.locationType = "";

            var parameters = new DynamicParameters();
            parameters.Add("pageNumber", request.pageNumber);
            parameters.Add("pageLimit", request.pageLimit);
            parameters.Add("title", request.title);
            parameters.Add("locationType", request.locationType);
            
            var locations = await _unitOfWork.Location.ExecProcedure<Core.Entities.Location>("PagingFilteringLocations", parameters);
            return result.WithValue(locations);
        }
    }
}
