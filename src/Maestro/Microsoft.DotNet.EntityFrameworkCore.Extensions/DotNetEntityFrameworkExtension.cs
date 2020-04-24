// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.DotNet.EntityFrameworkCore.Extensions
{
    public class DotNetEntityFrameworkExtension : DbContextOptionsExtensionInfo, IDbContextOptionsExtension
    {
        public DotNetEntityFrameworkExtension(IDbContextOptionsExtension extension) : base(extension)
        {
        }

        public void ApplyServices(IServiceCollection services)
        {
            services.AddSingleton<IMigrationsAnnotationProvider, SystemVersionedSqlServerMigrationsAnnotationProvider>();
            services.AddSingleton<IMigrationsSqlGenerator, SystemVersionedSqlServerMigrationsSqlGenerator>();
        }

        public override long GetServiceProviderHashCode()
        {
            return 0;
        }

        public override void PopulateDebugInfo(IDictionary<string, string> debugInfo)
        {
        }

        public void Validate(IDbContextOptions options)
        {
        }

        public DbContextOptionsExtensionInfo Info => this;

        public override bool IsDatabaseProvider => true;

        public override string LogFragment => "SystemVersioning Enabled";
    }
}
