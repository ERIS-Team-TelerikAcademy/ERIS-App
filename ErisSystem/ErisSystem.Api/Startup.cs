using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ErisSystem.Api.Migrations;
using ErisSystem.Data;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ErisSystem.Api.Startup))]

namespace ErisSystem.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ErisSystemContext, Configuration>());

            ConfigureAuth(app);
        }
    }
}
