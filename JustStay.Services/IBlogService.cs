using JustStay.Repo;
using JustStay.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace JustStay.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBlogService" in both code and config file together.
    [ServiceContract]
    public interface IBlogService
    {
        [OperationContract]
        List<BlogDto> GetBlogs(int blogCategoryId);

        [OperationContract]
        List<BlogWithDetail> GetBlogsWithDetail();

        [OperationContract]
        BlogDto GetBlogById(int id);

        [OperationContract]
        int InsertBlog(BlogDto blogDto);

        [OperationContract]
        void UpdateBlog(BlogDto blogDto);

        [OperationContract]
        void UpdateBlogImage(BlogDto blogDto);

        [OperationContract]
        void DeletBlog(int id);

        [OperationContract]
        List<BlogCatgoryDto> GetBlogCategories();
    }
}
