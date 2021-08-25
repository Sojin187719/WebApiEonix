using Core.EonixDBContext;
using Eonix.Configuration;
using Microsoft.AspNetCore.Mvc;


namespace Api.Controllers
{
    public class BaseController : Controller
    {
        protected readonly GlobalSettings _globalSettings;
        protected readonly EonixContext _eonixContext;
        public BaseController(GlobalSettings globalSettings,
                              EonixContext eonixContext)
        {
            _globalSettings = globalSettings;
            _eonixContext = eonixContext;
        }
    }
}
