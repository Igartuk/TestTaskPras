using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TestTaskPrasDAL.Interfaces;
using TestTaskPrasDAL.Models;
using TestTaskPrasDAL.Models.Entities;

namespace TestTaskPrasDAL.Repositories
{
    public class PostRepository: IPostRepository
    {
        private ApplicationDbContext _context;
        public PostRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Post> Get()
        {
            var posts = _context.Posts;
            return posts;
        }
        public async Task<Post> GetItem(int id)
        {
            var post =  _context.Posts.FirstOrDefault(p => p.Id == id);
            return post;
        }
        public async Task Create(Post post)
        {
           if(post != null)
            {
                _context.Posts.Add(post);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new NotImplementedException("New Url Cannot be blanc!");
            }
        }

        public async Task Delete(int id)
        {
            var url = _context.Posts.FirstOrDefault(x => x.Id == id);
            _context.Posts.Remove(url);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(Post post)
        {
            
            _context.Posts.Update(post);
            await _context.SaveChangesAsync();
        }

        

        
    }
}
