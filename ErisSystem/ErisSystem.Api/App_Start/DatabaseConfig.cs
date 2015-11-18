using ErisSystem.Data;
using ErisSystem.Data.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ErisSystem.Api
{
    public static class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<ErisSystemContext>());
            ErisSystemContext.Create().Database.Initialize(true);
        }
    }
}