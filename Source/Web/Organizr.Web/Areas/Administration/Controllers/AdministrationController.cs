namespace Organizr.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using Organizr.Common;
    using Organizr.Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class AdministrationController : BaseController
    {
    }
}
