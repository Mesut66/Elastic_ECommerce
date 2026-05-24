using Elastic_ECommerce.Services;
using Elastic_ECommerce.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Elastic_ECommerce.Controllers
{
    public class ECommerceController : Controller
    {

        private readonly ECommerceService _service;

        public ECommerceController(ECommerceService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Search([FromQuery] SearchPageVM searchPageView)
        {

            var (eCommerceList, totalCount, pageLinkCount) = await _service.SearchAsync(searchPageView.SearchVM, searchPageView.Page,
                searchPageView.PageSize);


            searchPageView.List = eCommerceList;
            searchPageView.TotalCount = totalCount;
            searchPageView.PageLinkCount = pageLinkCount;




            return View(searchPageView);
        }
    }
}
