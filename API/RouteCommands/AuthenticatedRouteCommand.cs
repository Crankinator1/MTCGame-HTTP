using MTCGServerCore.Response;
using MTCGServerCore.Routing;
using MTCGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTCGame.API.RouteCommands
{
    internal abstract class AuthenticatedRouteCommand : IRouteCommand
    {
        public User Identity { get; private set; }

        public AuthenticatedRouteCommand(User identity)
        {
            Identity = identity;
        }

        public abstract Response Execute();
    }
}
