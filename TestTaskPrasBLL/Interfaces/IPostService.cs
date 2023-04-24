using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskPrasBLL.DTOs;

namespace TestTaskPrasBLL.Interfaces
{
    public interface IPostService
    {
        public Task<IEnumerable<PostDTO>> Get();
        public Task<PostDTO> GetItem(int id);
        public Task Create(CreatePostDTO createPostDTO);
        public Task Edit(EditPostDTO editPost);
        public Task Delete(int id);
    }
}
