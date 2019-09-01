using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FitnessGuru.Data;
using FitnessGuru.Models.Store;
using FitnessGuru.Services.DataServices.Store;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace FitnessGuru.Services.DataServices.Tests
{
    public class ProductServiceTests
    {
        [Fact]
        private List<Product> Create_Products()
        {
            return new List<Product>
            {
                new Product
                {
                    Title = "Title for test 1",
                    Content = "Description for test 1",
                    ImgUrl = "https://images-na.ssl-images-amazon.com/images/I/61Eu4XMPDFL._SY450_.jpg",
                    Price = 22222,
                    ProductCategoryId = 1,
                },
                new Product
                {
                    Title = "Title for test 2",
                    Content = "Description for test 2",
                    ImgUrl = "https://images-na.ssl-images-amazon.com/images/I/61Eu4XMPDFL._SY450_.jpg",
                    Price = 333,
                    ProductCategoryId = 4,
                },
                new Product
                {
                    Title = "Title for test 3",
                    Content = "Description for test 3",
                    ImgUrl = "https://images-na.ssl-images-amazon.com/images/I/61Eu4XMPDFL._SY450_.jpg",
                    Price = 2556,
                    ProductCategoryId = 2,
                }
            };
        }
    }
}