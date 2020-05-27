using PowerPack.API.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using PowerPack.API.Middlewares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PowerPack.API.Middlewares
{
    public class FailingStartupFilter : IStartupFilter
    {
        private readonly Action<FailingOptions> _options;
        public FailingStartupFilter(Action<FailingOptions> optionsAction)
        {
            _options = optionsAction;
        }

        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app =>
            {
                app.UseFailingMiddleware(_options);
                next(app);
            };
        }
    }
}
