using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin;


namespace OwinSelfHost.Middleware
{
    using AppFunc = Func<IDictionary<string, object>, Task>;

    public class ColMiddleWare
    {       
        private readonly AppFunc _next;

        public ColMiddleWare(AppFunc next)
        {
            _next = next;
        }

        public async Task Invoke(IDictionary<string, object> environment)
        {
            var context = new OwinContext(environment);
            await _next(environment);            
            context.Response.OnSendingHeaders(o => context.Response.Headers.Add("x-col-header", new []{"test"}),null);
        }
    }
}