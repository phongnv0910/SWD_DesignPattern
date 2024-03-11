using Data_Access_Layer.Repository;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace Business_Layer.Service
{
	public class ProductBus
	{
		private readonly ProductDAO _productRepository;

		public ProductBus(ProductDAO productRepository)
		{
			_productRepository = productRepository;
		}
		public List<Product> GetListProduct()
		{
			return _productRepository.GetAll().ToList();
		}

		public async Task DeleteProduct(int id)
		{
			var productToDelete = _productRepository.GetById(id);
			if (productToDelete != null)
			{
				_productRepository.Delete(productToDelete);
				await _productRepository.SaveChangesAsync();
			}
		}

		public async Task UpdateProduct(Product product)
		{
			var existingProduct = _productRepository.GetById(product.Id);
			if (existingProduct != null)
			{
				existingProduct.Quantity = product.Quantity;
				existingProduct.Color = product.Color;
				_productRepository.Update(existingProduct);
				await _productRepository.SaveChangesAsync();
			}
		}

        public async Task<Product> GetProductById(int id)
        {
			return _productRepository.GetById(id);
        }
    }
}

