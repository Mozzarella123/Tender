using System;
using System.Collections.Generic;
using System.Text;
using TenderApp;
using Xunit;
using Moq;
using TenderApp.Data;
using System.Threading.Tasks;
using TenderApp.Models.BusinessModels;
using TenderApp.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TenderApp.Data.Repositories;

namespace XunitTenderTests
{
    public class SubGroupReposTest : IClassFixture<TestFixture<Startup>>
    {
        
        [Fact]
        public void Create()
        {
            //arrange
            Mock<ApplicationDbContext> mock = new Mock<ApplicationDbContext>();
            List <SubGroup> SubGroupList = new List<SubGroup>();
            mock.Setup(m => m.SaveChanges()).Returns(()=> { return 0; });
            SubGroup newSubGroup = new SubGroup()
            {
                SubGroupId = 1
            };

            //act

            SubGroupRepos repositoryBase = new SubGroupRepos(mock.Object);
            //repositoryBase.Create(newSubGroup);

            //assert
            Assert.Contains(newSubGroup, repositoryBase.collection);
            Assert.Contains(newSubGroup, SubGroupList);
        }

        [Fact]
        public void Delete()
        {
            //arrange
            Mock<ApplicationDbContext> mock = new Mock<ApplicationDbContext>();
            List<SubGroup> SubGroupList = new List<SubGroup>();
            mock.Setup(m => m.SaveChanges()).Returns(() => { return 0; });
            SubGroup newSubGroup = new SubGroup()
            {
                SubGroupId = 1
            };

            //act

            SubGroupRepos repositoryBase = new SubGroupRepos(mock.Object);
            //repositoryBase.Delete(newSubGroup);

            //assert
            Assert.DoesNotContain(newSubGroup, SubGroupList);
        }

        [Fact]
        public void UpdateUnExisted()
        {
            //arrange
            Mock<ApplicationDbContext> mock = new Mock<ApplicationDbContext>();
            List<SubGroup> SubGroupList = new List<SubGroup>();
            mock.Setup(m => m.SaveChanges()).Returns(() => { return 0; });
            SubGroup newSubGroup = new SubGroup()
            {
                SubGroupId = 1,
                Name = "newContext"
            };

            //act

            SubGroupRepos repositoryBase = new SubGroupRepos(mock.Object);
            repositoryBase.Update(newSubGroup);

            //assert
            var enumerator = SubGroupList.GetEnumerator();
            SubGroup EditedSubGroup = null;
            while (enumerator.MoveNext())
            {
                if (enumerator.Current.SubGroupId == 1)
                {
                    EditedSubGroup = enumerator.Current;
                    break;
                }
            }
            Assert.Equal(newSubGroup, EditedSubGroup);
        }

        [Fact]
        public void Update()
        {
            //arrange
            Mock<ApplicationDbContext> mock = new Mock<ApplicationDbContext>();
            List<SubGroup> SubGroupList = new List<SubGroup>
            {
                new SubGroup()
                {
                    SubGroupId=1,
                    Name="Old"
                }
            };
            mock.Setup(m => m.SaveChanges()).Returns(() => { return 0; });
            SubGroup newSubGroup = new SubGroup()
            {
                SubGroupId = 1,
                Name = "newContext"
            };

            //act

            SubGroupRepos repositoryBase = new SubGroupRepos(mock.Object);
            repositoryBase.Update(newSubGroup);

            //assert
            var enumerator = SubGroupList.GetEnumerator();
            SubGroup EditedSubGroup = null;
            while (enumerator.MoveNext())
            {
                if (enumerator.Current.SubGroupId == 1)
                {
                    EditedSubGroup = enumerator.Current;
                    break;
                }
            }
            Assert.Equal(newSubGroup, EditedSubGroup);
        }

    }
}
