using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TestTaskPrasBLL.DTOs;
using TestTaskPrasDAL.Models.Entities;

namespace TestTaskPrasBLL.AutoMapper
{
    public class PostMapperProfile : Profile  
    {
        public PostMapperProfile()
        {
            CreateMap<Post, PostDTO>();
            CreateMap<PostDTO, Post>();

            CreateMap<Post, EditPostDTO>();
            CreateMap<EditPostDTO, Post>();

            CreateMap<Post, CreatePostDTO>();
            CreateMap<CreatePostDTO, Post>();
        }
    }
}
