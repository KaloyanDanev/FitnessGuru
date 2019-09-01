using System;
using System.Collections.Generic;
using System.Text;
using FitnessGuru.Data;
using FitnessGuru.Models.Articles;
using FitnessGuru.Models.Store;
using FitnessGuru.Services.DataServices.Articles;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace FitnessGuru.Services.DataServices.Tests
{
    public class ArticleServiceTests
    {
        [Fact]
        private List<Article> Create_Articles()
        {
            return new List<Article>
            {
                new Article
                {
                    Title = "Title for test 1",
                    ArticleDescription = "Description for test 1",
                    Content = "Content for test 1",
                    ImgUrl = "https://images-na.ssl-images-amazon.com/images/I/61Eu4XMPDFL._SY450_.jpg",
                },
                new Article
                {
                    Title = "Title for test 2",
                    ArticleDescription = "Description for test 2",
                    Content = "Content for test 2",
                    ImgUrl = "https://images-na.ssl-images-amazon.com/images/I/61Eu4XMPDFL._SY450_.jpg",
                },
                new Article
                {
                    Title = "Title for test 3",
                    ArticleDescription = "Description for test 3",
                    Content = "Content for test 3",
                    ImgUrl = "https://images-na.ssl-images-amazon.com/images/I/61Eu4XMPDFL._SY450_.jpg",
                }
                
            };
        }

        [Fact]
        public void Create_Articles_Error()
        {
              var addArticle = new Article()
                {
                    Title = "Title for test 1",
                    ArticleDescription = "Description for test 1",
                    Content = "Content for test 1",
                    ImgUrl = "https://images-na.ssl-images-amazon.com/images/I/61Eu4XMPDFL._SY450_.jpg",
            };
            Assert.Equal(addArticle.Title,addArticle.ArticleDescription);   
        }
    }
}
