using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace MCB.SimpleTaskApp
{
    [DependsOn(
        typeof(SimpleTaskAppCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class SimpleTaskAppApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SimpleTaskAppApplicationModule).GetAssembly());
        }
    }
}