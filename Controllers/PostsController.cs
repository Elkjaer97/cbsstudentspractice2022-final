using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using FinalPrac.Data;
using FinalPrac.Models;

namespace FinalPrac.Controllers
{
    [Authorize]
    public class PostsController : Controller
    {
        private DBContext _context;

        private readonly UserManager<IdentityUser> _userManager; //læses op på

        public PostsController(DBContext context, UserManager<IdentityUser> userManager) //Skal læses på
        {
            _userManager = userManager;
            this._context = context;
        }

        

        // GET: Posts
        [AllowAnonymous]
        public IActionResult Index(string SearchString = "")
        {
            if (SearchString == null)
            {
                SearchString = "";
            }
             
             var posts = _context.Post.Include(u => u.User).Where(x => x.Title.Contains(SearchString));
        

            ViewBag.SearchString = SearchString;
            //The ViewBag in ASP.NET MVC is used to transfer temporary data (which is not included in the model) from the controller to the view.

            var vm = new PostIndexVm
            {
                Posts = posts.ToList(),
                SearchString = SearchString
            };

            return View(vm);
        }

        // GET: Posts/Create
        public IActionResult Create()
        {
            // ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id"); måske fjerne comment
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Title,Text,Status")] Post post)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
                post.UserId = user.Id;

                post.Created = DateTime.Now; //Gør vores timestamp er fra i dag
                _context.Post.Add(post);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: POSTS/DETAILS/5
        public async Task<IActionResult> Details(int? id)
        {
            Post p = _context.Post.
            Include(u => u.User).
            Include( x => x.Comments).
            ThenInclude(x => x.User).First(x => x.Id == id);

            var vm = new PostIndexVm
            {
                Post = p
            };

            return View(vm);
        }

        // GET: Posts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Post == null)
            {
                return NotFound();
            }

            var post = await _context.Post.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", post.UserId);
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Text,Created,Status,UserId")] Post post)
        {
            if (id != post.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(post);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", post.UserId);
            return View(post);
        }

        // GET: Posts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Post == null)
            {
                return NotFound();
            }

            var post = await _context.Post
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Post == null)
            {
                return Problem("Entity set 'DBContext.Post'  is null.");
            }
            var post = await _context.Post.FindAsync(id);
            if (post != null)
            {
                _context.Post.Remove(post);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(int id)
        {
          return _context.Post.Any(e => e.Id == id);
        }

        public IActionResult RedirectCreateComment(int Id){
            return RedirectToAction("Create", "Comments", new { PostId = Id });
        }

        public IActionResult RedirectDeleteComment(int Id){
            return RedirectToAction("Delete", "Comments", new { id = Id });
        }

    }
}


    

