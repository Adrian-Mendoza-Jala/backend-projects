using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder_Pattern
{
    public class ProductBuilder : IProductNameStep, IProductDescriptionStep, IProductPriceStep, IProductBuildStep
    {
        private Product _product = new Product();

        public IProductDescriptionStep SetName(string name)
        {
            _product.Name = name;
            return this;
        }

        public IProductPriceStep SetDescription(string description)
        {
            _product.Description = description;
            return this;
        }

        public IProductBuildStep SetPrice(int price)
        {
            _product.Price = price;
            return this;
        }

        public Product Build()
        {
            return _product;
        }
    }
}
