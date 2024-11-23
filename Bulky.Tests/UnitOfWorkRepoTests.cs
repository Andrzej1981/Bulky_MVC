using Bulky.DataAccess.Repository;
using Bulky.Models;
using BulkyWeb.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.Tests
{
    public class UnitOfWorkRepoTests
    {
        private readonly DbContextOptions<ApplicationDbContext> _options;

        public UnitOfWorkRepoTests()
        {
            _options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("unitOfWorkDb").Options;
        }

        private ApplicationDbContext CreateDbContext()=> new ApplicationDbContext(_options);




        [Fact]
        public void Add_ShouldAddCategory()
        {
            //db context
            var db = CreateDbContext();
            //category repo
            var repo = new UnitOfWork(db);
            //execute
            var category = new Category { DisplayOrder = 6, Name = "Adventure" };
            repo.Category.Add(category);
            var category2 = new Category { DisplayOrder = 1, Name = "Horror" };
            repo.Category.Add(category2);
            var category3 = new Category { DisplayOrder = 5, Name = "Sci-Fi" };
            repo.Category.Add(category3);
            var category4 = new Category { DisplayOrder = 7, Name = "Mafia" };
            repo.Category.Add(category4);
            repo.Save();
            //result
            var result = db.Categories.SingleOrDefault(u=>u.Name == "Adventure");
            //assert
            Assert.NotNull(result);
            Assert.Equal("Adventure", result.Name);
        }

       

        [Fact]
        public void Remove_ShouldRemoveCategory() 
        {
            //db context
            var db = CreateDbContext();
            //category repo
            var repo = new UnitOfWork(db);
            //find entity
            var ent = repo.Category.Get(s => s.Name == "Adventure");
            //execute
            repo.Category.Remove(ent);
            repo.Save();
            var ret = db.Categories.SingleOrDefault(s => s.Name == "Adventure");
            //assert
            Assert.Null(ret);
        }

        [Fact]
        public void Get_ShoudlReturnNameEqualHorror()
        {
            //db context
            var db = CreateDbContext();
            //category repo
            var repo = new UnitOfWork(db);
      
            //execute
            var ent = db.Categories.SingleOrDefault(s => s.Name == "Horror");
            
            //assert
            Assert.NotNull(ent);
            Assert.Equal("Horror", ent.Name);
            
        }



        

    }
}
