using System;
using System.Collections.Generic;
using System.Text;
using FitnessGuru.Models.Articles;
using Xunit;

namespace FitnessGuru.Services.DataServices.Tests
{
    public class CategoryServiceTest
    {
        [Fact]
        private List<Category> Create_Category()
        {
            return new List<Category>
            {
                new Category
                {
                    Name = "Name for test 1",
                    Id = 1
                },
                new Category
                {
                    Name = "Name for test 2",
                    Id = 2
                },
                new Category
                {
                    Name = "Name for test 3",
                    Id = 3
                }
            };
        }
    }
}