using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace MvcDI.Models
{
    public interface IProductRepository
    {
        List<ProductVM> getProducts(CategoryInput input);

    }
    public class ProductRepository : IProductRepository
    {
        private IDBEntity dbEntity;
        public ProductRepository(IDBEntity _dbEntity)
        {
            this.dbEntity = _dbEntity;
        }

        public List<ProductVM> getProducts(CategoryInput input)
        {
            var products = this.dbEntity.getDBEntity().Products.Where(x => x.CategoryID == input.CategoryID)
                            .Select(x => x).ToList();
            Mapper.Initialize(cfg => cfg.CreateMap<Product, ProductVM>());
            var lst = Mapper.Map<List<Product>, List<ProductVM>>(products);
            //Mapper.Initialize(cfg => cfg.CreateMap<Product, ProductVM>()
            //             .ForMember(dest => dest.ProductID, opt => opt.MapFrom(src => src.ProductID))
            //             .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductName)
            //                 ));
            //List<ProductVM> lst = new List<ProductVM>();
            //foreach (var item in products)
            //{
            //    var destprod = AutoMapper.Mapper.Map<Product, ProductVM>(item);
            //    lst.Add(destprod);
            //}
            return lst;
        }
    }
    public class CategoryInput
    {
        public Nullable<int> CategoryID { get; set; }
    }
    public class ProductVM
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public Nullable<int> SupplierID { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public string QuantityPerUnit { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public Nullable<short> UnitsInStock { get; set; }
        public Nullable<short> UnitsOnOrder { get; set; }
        public Nullable<short> ReorderLevel { get; set; }
        public bool Discontinued { get; set; }

        //public CategoryVM Category { get; set; }

    }
    public class CategoryVM
    {
        public CategoryVM()
        {
            this.Products = new HashSet<ProductVM>();
        }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }

        public  ICollection<ProductVM> Products { get; set; }
    }
}
