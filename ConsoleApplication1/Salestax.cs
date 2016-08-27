using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication1
{
    //test
    public abstract class Product
    {
        public decimal Price { get; set; }
        public string Name { get; set; }
        public ProductType ProductType { get; set; }

        protected decimal _importDutyTax = 0;
        public virtual decimal ImportDutyTax
        {
            get { return _importDutyTax; }
            set { _importDutyTax = value; }
        }

        protected decimal _salesTax = 0;
        public virtual decimal SalesTax
        {
            get { return _salesTax; }
            set { _salesTax = value; }
        }

        public Product(string Name, decimal Price, ProductType productType)
        {
            this.Name = Name;
            this.Price = Price;
            ProductType = productType;
        }

        public Product(string Name, decimal Price, ProductType productType, ImportDuty importDuty) 
            : this(Name, Price, productType)
        {
            this.SalesTax = Math.Round((Price * ((decimal)ImportDuty.SalesTax / 100)),2);
        }
        public override string ToString()
        {
            return String.Format("{0} :{1}", this.Name, 
                this.Price + this.ImportDutyTax + this.SalesTax);
        }
    }

    public class Book : Product
    {
        public Book(string Name, decimal Price, ProductType productType)
            : base(Name, Price, productType) { }
        public Book(string Name, decimal Price, ProductType productType, ImportDuty importDuty)
            : base(Name, Price, productType, importDuty) { }
    }

    public class Food : Product
    {
        public Food(string Name, decimal Price, ProductType productType) 
            : base(Name, Price, productType) { }
        public Food(string Name, decimal Price, ProductType productType, ImportDuty importDuty)
            : base(Name, Price, productType, importDuty)
        {
            this.ImportDutyTax = Math.Round((Price * ((decimal)ImportDuty.ImportDutyTax / 100)),2);
            if(importDuty == ImportDuty.ImportDutyTax)
            {
                this.SalesTax = 0;
            }
        }
    }

    public class Medical : Product
    {
        public Medical(string Name, decimal Price, ProductType productType)
            : base(Name, Price, productType) { }
        public Medical(string Name, decimal Price, ProductType productType, ImportDuty importDuty)
            : base(Name, Price, productType, importDuty) { }
    }
    public class Music : Product
    {
        public Music(string Name, decimal Price, ProductType productType) 
            : base(Name, Price, productType) { }
        public Music(string Name, decimal Price, ProductType productType, ImportDuty importDuty)
            : base(Name, Price, productType, importDuty)
        {
            this.SalesTax = Math.Round((Price * ((decimal)ImportDuty.SalesTax / 100)),2);
        }
    }
    public class OtherProduct : Product
    {
        public OtherProduct(string Name, decimal Price, ProductType productType) 
            : base(Name, Price, productType) {
            this.SalesTax = Math.Round((Price * ((decimal)ImportDuty.SalesTax / 100)),2);
        }
        public OtherProduct(string Name, decimal Price, ProductType productType, ImportDuty importDuty)
            : base(Name, Price, productType, importDuty)
        {
            this.ImportDutyTax = Math.Round((Price * ((decimal)ImportDuty.ImportDutyTax / 100)),2);
        }
    }
    public enum ImportDuty
    {
        ImportDutyTax = 5,
        SalesTax = 10
    }
    public enum ProductType
    {
        Book,
        Food,
        Music,
        Medical,
        Other
    }
    public interface IShoppingCart
    {
        List<Product> ProductsList { get; set; }
        String calcuateTax();
    }
    public class ShoppingCart : IShoppingCart
    {
        public List<Product> ProductsList { get; set; }
        public String calcuateTax()
        {
            decimal total = 0;
            decimal salesTax = 0;
            decimal importDutyTax = 0;
            StringBuilder output = new StringBuilder();
            foreach (Product product in this.ProductsList)
            {
                salesTax += product.SalesTax;
                importDutyTax +=product.ImportDutyTax;
                output.Append(product.ToString() + "\n");
                total += (product.Price + product.ImportDutyTax + product.SalesTax);
            }
            output.Append("Sales Taxes:" + (salesTax + importDutyTax) + "\n" + "Total:" + total + "\n");
            return output.ToString();
        }
    }
}
