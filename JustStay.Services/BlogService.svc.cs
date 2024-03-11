using JustStay.Repo;
using JustStay.Services.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace JustStay.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BlogService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select BlogService.svc or BlogService.svc.cs at the Solution Explorer and start debugging.
    public class BlogService : IBlogService
    {
        BlogRepository blogRepository;

        public BlogService()
        {
            blogRepository = new BlogRepository();
        }

        public List<BlogDto> GetBlogs(int blogCategoryId)
        {
            var blogs = blogRepository.GetBlogs(blogCategoryId);

           List<BlogDto> blogList =
           blogs.ConvertAll(x => new BlogDto
           {
               BlogId = x.BlogId,
               BlogCategoryId = x.BlogCategoryId,
               BlogTitle = x.BlogTitle, 
               BlogDate = x.BlogDate,
               InsertedOn = x.InsertedOn,
               BlogImageNewName=x.BlogImageNewName,
           });
            return blogList;
        }

        public List<BlogWithDetail> GetBlogsWithDetail()
        {
            return blogRepository.GetBlogsWithDetail();
        }

        public BlogDto GetBlogById(int id)
        {
            Blog blog = blogRepository.GetBlogById(id);
            BlogDto dto = new BlogDto();
            FillBlogDto(blog, dto);
            return dto;
        }

        public int InsertBlog(BlogDto blogDto)
        {
            Blog blog = new Blog();
            FillBlog(blog, blogDto);
            return blogRepository.InsertBlog(blog);
        }

        public void UpdateBlog(BlogDto blogDto)
        {
            Blog blog = blogRepository.GetBlogById(blogDto.BlogId);
            FillBlog(blog, blogDto);
            blog.UpdatedOn = DateTime.Now;
            blogRepository.UpdateRecord();
        }

        public void UpdateBlogImage(BlogDto blogDto)
        {
            Blog blog = blogRepository.GetBlogById(blogDto.BlogId);
            blog.BlogImageName = blogDto.BlogImageName;
            blog.BlogImageNewName = blogDto.BlogImageNewName;
            blog.UpdatedOn = DateTime.Now;
            blogRepository.UpdateRecord();
        }

        public void DeletBlog(int id)
        {
            blogRepository.DeletBlog(id);
        }

        public List<BlogCatgoryDto> GetBlogCategories()
        {
            var blogList = blogRepository.GetBlogCategories();
            if (blogList == null) return null;

            List<BlogCatgoryDto> catDtoList =
            blogList.ConvertAll(x => new BlogCatgoryDto
            {
                BlogCategoryId = x.BlogCategoryId,
                Name = x.Name
            });

            return catDtoList;
        }

        #region "  Private MEthods "

        private void FillBlog(Blog blog, BlogDto blogDto)
        {
            blog.BlogTitle = blogDto.BlogTitle;
            blog.BlogCategoryId = blogDto.BlogCategoryId;
            blog.BlogContent = blogDto.BlogContent;
            blog.BlogDate = blogDto.BlogDate;
        }

        private void FillBlogDto(Blog blog, BlogDto blogDto)
        {
            blogDto.BlogTitle = blog.BlogTitle;
            blogDto.BlogCategoryId = blog.BlogCategoryId;
            blogDto.BlogContent = blog.BlogContent;
            blogDto.BlogDate = blog.BlogDate;
            blogDto.BlogImageName = blog.BlogImageName;
            blogDto.BlogImageNewName = blog.BlogImageNewName;
        }


        #endregion
    }
}
