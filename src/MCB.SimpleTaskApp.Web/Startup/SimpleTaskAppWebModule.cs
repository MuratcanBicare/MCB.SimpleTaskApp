using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MCB.SimpleTaskApp.Configuration;
using MCB.SimpleTaskApp.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;

namespace MCB.SimpleTaskApp.Web.Startup
{
    [DependsOn(
        typeof(SimpleTaskAppApplicationModule), 
        typeof(SimpleTaskAppEntityFrameworkCoreModule), 
        typeof(AbpAspNetCoreModule))]
    public class SimpleTaskAppWebModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public SimpleTaskAppWebModule(IWebHostEnvironment env)
        {
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(SimpleTaskAppConsts.ConnectionStringName);

            Configuration.Navigation.Providers.Add<SimpleTaskAppNavigationProvider>();

            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(SimpleTaskAppApplicationModule).GetAssembly()
                );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SimpleTaskAppWebModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(SimpleTaskAppWebModule).Assembly);
        }
    }
}
