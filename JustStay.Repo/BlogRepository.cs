using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustStay.Repo
{
    public class BlogRepository
    {
        juststayDbEntities entities;

        public BlogRepository()
        {
            entities = new juststayDbEntities();
        }

        public List<Blog> GetBlogs(int blogCategoryId)
        {
          return  entities.Blogs.Where(b => b.BlogCategoryId == blogCategoryId || blogCategoryId ==0).OrderByDescending(B=>B.BlogDate).ToList();
        }

        public List<BlogWithDetail> GetBlogsWithDetail()
        {
            return entities.GetBlogWithDetail(0).ToList();
        }

        public Blog GetBlogById(int id)
        {
            return entities.Blogs.FirstOrDefault(b => b.BlogId == id);
        }

        public int InsertBlog(Blog blog)
        {
            blog.InsertedOn = DateTime.Now;
            entities.Blogs.Add(blog);
            entities.SaveChanges();
            return blog.BlogId;
        }

        public void UpdateRecord()
        {
            entities.SaveChanges();
        }

        public void DeletBlog(int id)
        {
            var x = entities.Blogs.FirstOrDefault(i => i.BlogId == id);
            entities.Blogs.Remove(x);
            entities.SaveChanges();
        }

        public List<BlogCategory> GetBlogCategories()
        {
            return entities.BlogCategories.ToList();
        }


    }
}
