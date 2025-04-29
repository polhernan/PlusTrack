namespace PlusTrack.API.Application.Commands.Routes
{
    public class CreateRouteCommand : IRequest<Domain.Entities.Route>
    {

        public DateTime DayOfRoute { get; }


        public CreateRouteCommand(DateTime dayOfRoute)
        {
            DayOfRoute = dayOfRoute;
        }
    }
}
