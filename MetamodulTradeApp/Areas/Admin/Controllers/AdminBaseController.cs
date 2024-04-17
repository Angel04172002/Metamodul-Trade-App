using MetamodulTradeApp.Core.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MetamodulTradeApp.Areas.Admin.Controllers
{
    [Area(AdminConstants.AdminAreaName)]
    [Authorize(Roles = AdminConstants.AdminRole)]
    public class AdminBaseController : Controller
    {
     
    }
}
