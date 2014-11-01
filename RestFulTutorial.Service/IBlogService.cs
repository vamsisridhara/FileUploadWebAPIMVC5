using RestfulTutorial.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
namespace RestfulTutorial.Service
{
    [ServiceContract]
    public interface IBlogService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/Posts")]
        BlogPost[] GetBlogPosts();

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/Post")]
        BlogPost CreateBlogPost(BlogPost post);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/Post")]
        BlogPost UpdateBlogPost(BlogPost post);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/Post/{id}")]
        void DeleteBlogPost(string id);
    }

    
}
