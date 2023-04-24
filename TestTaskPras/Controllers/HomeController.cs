using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using TestTaskPrasBLL.Interfaces;

namespace TestTaskPras.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostService _postService;
        public HomeController(IPostService postService)
        {
            _postService = postService;
        }

        public async Task<IActionResult> Index()
        {
            var allPosts = await _postService.Get();
            return allPosts != null ? View(allPosts) : Problem("We haven't got any posts");
        }
        public async Task<IActionResult> List()
        {
            var allPosts = await _postService.Get();
            return allPosts != null ? View(allPosts) : Problem("We haven't got any posts");
        }
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || _postService.GetItem(id) == null)
            {
                return NotFound();
            }

            var post = await _postService.GetItem(id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }
    }
}
