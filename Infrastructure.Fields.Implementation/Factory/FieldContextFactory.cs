using Infrastructure.Fields.Implementation.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Infrastructure.Fields.Implementation.Factory
{
    public class FieldContextFactory : IDesignTimeDbContextFactory<FieldContext>
    {
        public FieldContext CreateDbContext(string[] args)
        {
            var coreAssemblyDirectoryPath = Path.GetDirectoryName(typeof(FieldContextFactory).Assembly.Location);
            if (coreAssemblyDirectoryPath == null)
            {
                throw new Exception("Could not find location! " + typeof(FieldContextFactory).FullName);
            }
            var directoryInfo = new DirectoryInfo(coreAssemblyDirectoryPath);
            Console.WriteLine(directoryInfo.FullName);
            while (!DirectoryContains(directoryInfo.FullName, "FieldsCatalog"))
            {
                if (directoryInfo.Parent == null)
                {
                    throw new Exception("Could not find content FieldsCatalog folder");
                }

                directoryInfo = directoryInfo.Parent;
            }
            Console.WriteLine(directoryInfo.FullName);
            var webHostFolder = Path.Combine(directoryInfo.FullName, "FlowApplication", "FieldsCatalog");
            if (!Directory.Exists(webHostFolder))
            {
                throw new Exception($"Could not find root folder of the web project! {webHostFolder}");
            }
            Console.WriteLine();

            var optionsBuilder = new DbContextOptionsBuilder<FieldContext>();

            optionsBuilder.UseSqlServer(
                sqlServerOptionsAction: o => o.MigrationsAssembly("Infrastructure.Fields.Implementation")
            );
            return new FieldContext(optionsBuilder.Options);
        }

        private static bool DirectoryContains(string directory, string fileName)
        {
            return Directory.GetDirectories(directory).Any(filePath => {
                var webHostFolder = Path.Combine(filePath, "FieldsCatalog");
                return Directory.Exists(webHostFolder);
            });
        }
    }
}
