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

namespace XunitTenderTests
{
    public class RepositoryBaseTest : IClassFixture<TestFixture<Startup>>
    {
        
        [Fact]
        public void Create()
        {
            //arrange
            Mock<ApplicationDbContext> mock = new Mock<ApplicationDbContext>();
            ICollection < Post > postList = new List<Post>();
            mock.Setup(m => m.GetType().GetProperty("Post").GetValue(m,null)).Returns(postList);
            Post newPost = new Post()
            {
                PostId = 1
            };

            //act

            RepositoryBase<Post> repositoryBase = new RepositoryBase<Post>(mock.Object);
            repositoryBase.Create(newPost);

            //assert
            Assert.Contains(newPost, repositoryBase.collection);
            Assert.Contains(newPost, postList);
        }

        [Fact]
        public void Delete()
        {
            //arrange
            Mock<ApplicationDbContext> mock = new Mock<ApplicationDbContext>();
            ICollection<Post> postList = new List<Post>()
            {
            new Post()
            {
                PostId = 1
            },
            new Post()
            {
                PostId = 2
            }
            };
            mock.Setup(m => m.GetType().GetProperty("Post").GetValue(m, null)).Returns(postList);
            Post newPost = new Post()
            {
                PostId = 1
            };

            //act

            RepositoryBase<Post> repositoryBase = new RepositoryBase<Post>(mock.Object);
            repositoryBase.Delete(newPost);

            //assert
            Assert.DoesNotContain(newPost, postList);
        }

        [Fact]
        public void Update()
        {
            //arrange
            Mock<ApplicationDbContext> mock = new Mock<ApplicationDbContext>();
            ICollection<Post> postList = new List<Post>()
            {
            new Post()
            {
                PostId = 1
            },
            new Post()
            {
                PostId = 2
            }
            };
            mock.Setup(m => m.GetType().GetProperty("Post").GetValue(m, null)).Returns(postList);
            Post newPost = new Post()
            {
                PostId = 1,
                Content="newContent"
            };

            //act

            RepositoryBase<Post> repositoryBase = new RepositoryBase<Post>(mock.Object);
            repositoryBase.Update(newPost);

            //assert
            var enumerator = postList.GetEnumerator();
            Post EditedPost = null;
            while (enumerator.MoveNext())
            {
                if (enumerator.Current.PostId == 1)
                {
                    EditedPost = enumerator.Current;
                    break;
                }
            }
            Assert.Equal(newPost, EditedPost);
        }
    }
}
