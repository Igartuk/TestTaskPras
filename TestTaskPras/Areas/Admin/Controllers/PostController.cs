using Microsoft.AspNetCore.Mvc;
using TestTaskPrasBLL.DTOs;
using TestTaskPrasBLL.Interfaces;

namespace TestTaskPras.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PostController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IPostService _postService;
        public PostController(IPostService postService, IWebHostEnvironment hostEnvironment)
        {
            _postService = postService;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var allPosts = await _postService.Get();
            return View(allPosts);
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Subtitle,Text,ImagePath")] CreatePostDTO createPostDTO, IFormFile imagePath)
        {
            
            if (ModelState.IsValid)
            {
                
                if (imagePath != null)
                {
                    var fileName = Path.GetFileName(imagePath.FileName);
                    var filePath = Path.Combine(_hostEnvironment.WebRootPath, "images", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await imagePath.CopyToAsync(stream);
                    }

                }
                await _postService.Create(createPostDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(createPostDTO);
        }
        public async Task<IActionResult> Edit(int id)
        {
            EditPostDTO editPostDTO = new EditPostDTO();
            if (id == null || _postService.GetItem(id) == null)
            {
                return NotFound();
            }

            var post = await _postService.GetItem(id);
            if (post == null)
            {
                return NotFound();
            }
            editPostDTO.Id = post.Id;
            editPostDTO.Title = post.Title;
            editPostDTO.Text = post.Text;
            editPostDTO.Subtitle = post.Subtitle;
            editPostDTO.ImagePath = post.ImagePath;
            return View(editPostDTO);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Subtitle,Text")] EditPostDTO editPostDTO, IFormFile imagePath)
        {
            if (ModelState.IsValid)
            {
                if (imagePath != null)
                {
                    editPostDTO.ImagePath = imagePath.FileName;
                    using (var stream = new FileStream(Path.Combine(_hostEnvironment.WebRootPath, "images/", imagePath.FileName), FileMode.Create))
                    {
                        await imagePath.CopyToAsync(stream);
                    }
                }

                await _postService.Edit(editPostDTO);

                return RedirectToAction(nameof(Index));
            }
            return View(editPostDTO);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var post = await _postService.GetItem(id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _postService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
