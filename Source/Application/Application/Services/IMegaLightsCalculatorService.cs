namespace Application.Services
{
    public interface IMegaLightsCalculatorService
    {
        double CalculateStopsByDistance(double distanceInMegaLights, string megaLights, string consumables);
    }
}
