using MTCGServerCore.Request;
using HttpMethod = MTCGServerCore.Request.HttpMethod;

namespace MTCGame.API.RouteCommands
{
    internal interface IRouteParser
    {
        bool IsMatch(string resourcePath, string routePattern);
        Dictionary<string, string> ParseParameters(string resourcePath, string routePattern);
    }
}
