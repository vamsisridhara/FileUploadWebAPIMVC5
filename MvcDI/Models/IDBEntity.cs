using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcDI.Models
{
    public interface IDBEntity
    {
        NorthwindEntities getDBEntity();
        
    }
    public class DBEntity : IDBEntity
    {
        public NorthwindEntities getDBEntity()
        {
            return new NorthwindEntities();
        }
    }
}
