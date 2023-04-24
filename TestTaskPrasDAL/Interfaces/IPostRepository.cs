using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskPrasDAL.Models.Entities;

namespace TestTaskPrasDAL.Interfaces
{
    public interface IPostRepository
    {
        public IEnumerable<Post> Get();
        public Task<Post> GetItem(int id);
        public Task Create(Post post);
        public Task Edit(Post post);
        public Task Delete(int id);

    }
}
