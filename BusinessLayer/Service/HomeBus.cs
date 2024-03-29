﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using Data_Access_Layer.Repository;

namespace Business_Layer.Service
{
    public class HomeBus
    {
        private readonly ProductDAO _productRepository;

        public HomeBus(ProductDAO productRepository)
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

    }
}
