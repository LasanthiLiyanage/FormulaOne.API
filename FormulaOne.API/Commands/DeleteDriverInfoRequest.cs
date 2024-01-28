using FormulaOne.Entities.Dtos.Requests;
using MediatR;

namespace FormulaOne.API.Commands
{
    public class DeleteDriverInfoRequest : IRequest<bool>
    {
        public Guid DriverId { get; }

        public DeleteDriverInfoRequest(Guid driverId)
        {
            DriverId = driverId;
        }
    }
}
