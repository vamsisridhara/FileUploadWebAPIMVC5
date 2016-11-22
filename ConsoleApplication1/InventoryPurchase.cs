using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class InventoryPurchase
    {
        private int inventory;
        public int Purchase(int quantity)
        {
            if (inventory == 0)
            {
                throw new OutOfProduct();
            }
            inventory -= quantity;
            return quantity;
        }
    }

    [Serializable]
    public class OutOfProduct : Exception
    {
        public OutOfProduct()
        {
        }

        public OutOfProduct(string message) : base(message)
        {
        }

        public OutOfProduct(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected OutOfProduct(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
