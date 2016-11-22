using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Bar : IBar
    {
        public string AccountLastFourSuffix
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int BirthDay
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int BirthMonth
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int Id
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int JoinedDaysAgo
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string Location
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string Name
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int TotalPosts
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }
    }
    public interface IBar
    {
        int Id { get; set; }
        string Name { get; set; }
        int BirthDay { get; set; }
        int BirthMonth { get; set; }
        string AccountLastFourSuffix { get; set; }
        int JoinedDaysAgo { get; set; }
        int TotalPosts { get; set; }
        string Location { get; set; }
    }
    public class Foo
    {
        public int AccountNumber { get; set; }
        public string City { get; set; }
        public DateTime CreatedOnDateTime { get; set; }
        public DateTime DateofBirth { get; set; }
        public string FirstName { get; set; }
        public int Id { get; set; }
        public string LastName { get; set; }
        public DateTime LastUpdatedDateTime { get; set; }
        public int LogInCount { get; set; }
        public string MiddleNameOrInitial { get; set; }
        public string Title { get; set; }
        public string StateProvince { get; set; }
    }
    public class Component {
        private IBar _ibar;
        private Foo _foo;
        public Component(IBar bar)
        {
            this._ibar = bar;
            
        }
        public void testComponent() {
            this._foo = new ClassLibrary1.Foo() {
                AccountNumber = 1000,
                City = "Dallas",
                CreatedOnDateTime = DateTime.Now,
                DateofBirth = new DateTime(1990, 12, 01),
                FirstName = "Saurabh",
                LastName = "Shah",
                LastUpdatedDateTime = DateTime.Now,
                LogInCount =1,
                MiddleNameOrInitial = "S",
                StateProvince = "AR",
                Title = "Mr",
                Id =100
            };
        }
    }
}
