using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskPrasBLL.DTOs;
using TestTaskPrasBLL.Interfaces;
using TestTaskPrasDAL.Interfaces;
using TestTaskPrasDAL.Models.Entities;
using TestTaskPrasDAL.Repositories;

namespace TestTaskPrasBLL.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        public PostService(IPostRepository postRepository,IMapper mapper) 
        {
            _postRepository= postRepository;
            _mapper= mapper;
        }
        public async Task<IEnumerable<PostDTO>> Get()
        {
            var posts = _postRepository.Get();
            var postDTOs = _mapper.Map<IEnumerable<PostDTO>>(posts);
            return postDTOs;
        }

        public async Task<PostDTO> GetItem(int id)
        {
            var post = await _postRepository.GetItem(id);
            var postDTO = _mapper.Map<PostDTO>(post);

            return postDTO ;
        }
        public async Task Create(CreatePostDTO createPostDTO)
        {

            var postEntity = _mapper.Map<Post>(createPostDTO);
            postEntity.ImagePath = createPostDTO.ImagePath.FileName;
            await _postRepository.Create(postEntity);
        }

        public async Task Delete(int id) =>  await _postRepository.Delete(id);
        

        public async Task Edit(EditPostDTO editPost)
        {
            var postEntity = _mapper.Map<Post>(editPost);
            await _postRepository.Edit(postEntity);
        }

        
    }
}
