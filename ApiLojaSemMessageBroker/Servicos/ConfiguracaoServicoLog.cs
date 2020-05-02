using Amazon.OpsWorks.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using KissLog;
using KissLog.Apis.v1.Listeners;
using KissLog.Listeners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KissLog.AspNetCore;
using Microsoft.Extensions.Configuration;

namespace ApiLojaSemMessageBroker.Servicos
{
    public static class ConfiguracaoServicoLog
    {

        public static void Configuracao(IApplicationBuilder app, IConfiguration Configuration)
        {
            app.UseKissLogMiddleware(options => {
                options.Listeners.Add(new KissLogApiListener(new KissLog.Apis.v1.Auth.Application(
                    Configuration["KissLog.OrganizationId"],
                    Configuration["KissLog.ApplicationId"])
                ));
            });

        }
    }
}
