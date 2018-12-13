﻿using StreamingWebshop.Core.DomainService;
using StreamingWebshop.Core.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace StreamingWebshop.Core.ApplicationService.Services
{
    public class ProductService : IProductService
    {
        //dep injection
        readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        //TODO!
        public Product NewProduct(string Name, 
            string Description, double RetailPrice, double WholeSalePrice,
            string Category, int Stock, string PicUrl)
        {
            var prod = new Product()
            {
                Name = Name,
                Description = Description,
                RetailPrice = RetailPrice,
                WholeSalePrice = WholeSalePrice,
                Category = Category,
                Stock = Stock,
                PicUrl = PicUrl
                
            };
            return prod;
        }

        public Product CreateProduct(Product prod)
        {
            if (prod.Name == null)
                throw new InvalidDataException("Product needs a Name");
            if (prod.Category == null)
                throw new InvalidDataException("Product needs a Type");
            if (Math.Abs(prod.RetailPrice) < 1)
                throw new InvalidDataException("Product Price needs to be more than 1");
            if (prod.Description == null)
                throw new InvalidDataException("Product needs a description");
            return _productRepository.Create(prod);
        }

        public Product DeleteProduct(int id)
        {
            return _productRepository.Delete(id);
        }

        public Product FindProductById(int id)
        {
            return _productRepository.ReadById(id);
        }

        public List<Product> GetAllProducts()
        {
            return _productRepository.ReadAll().ToList();
        }

        public List<Product> GetProductsByCategory(string category)
        {
            return _productRepository.ReadByCategory(category);
        }

        public Product UpdateProduct(Product productUpdate)
        {
            if (productUpdate.Name == null)
                throw new InvalidDataException("Product needs a Name");
            if (productUpdate.Category == null)
                throw new InvalidDataException("Product needs a Type");
            if (Math.Abs(productUpdate.RetailPrice) < 1)
                throw new InvalidDataException("Product Price needs to be more than 1");
            if (productUpdate.Description == null)
                throw new InvalidDataException("Product needs a description");
            return _productRepository.Update(productUpdate);
        }
    }
}
