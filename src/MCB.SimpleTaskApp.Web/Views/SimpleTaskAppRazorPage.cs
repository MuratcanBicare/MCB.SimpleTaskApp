using Abp.AspNetCore.Mvc.Views;

namespace MCB.SimpleTaskApp.Web.Views
{
    public abstract class SimpleTaskAppRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected SimpleTaskAppRazorPage()
        {
            LocalizationSourceName = SimpleTaskAppConsts.LocalizationSourceName;
        }
    }
}
