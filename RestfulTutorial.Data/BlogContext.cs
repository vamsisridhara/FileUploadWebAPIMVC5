using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulTutorial.Data
{
    public class BlogContext : DbContext
    {
        public BlogContext(): base("BlogContext")
        {
        }

        public DbSet<BlogPost> BlogPosts
        {
            get;
            set;
        }
    }
}
