using MeArch.Module.File.Service.FileService;
using MeArch.Module.File.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeArch.Module.File.Model.Options;

namespace MeArch.Module.File.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddFileService(this IServiceCollection services, Action<FileOptions> options)
        {
            services.Configure(options);
            services.AddSingleton<IFileService, FileService>();
        }
    }
}
