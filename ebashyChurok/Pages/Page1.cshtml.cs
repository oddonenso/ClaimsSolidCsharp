using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ebashyChurok.Pages
{
    public class Page1Model : PageModel
    {
        [Authorize(Policy= "Autorization")]
        public void OnGet()
        {
        }
    }
}
