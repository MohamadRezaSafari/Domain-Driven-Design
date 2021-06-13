using HR.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HR.ShiftContext.Domain.Tests
{
    [TestClass]
    public class UnitTest1 : HRDbContext
    {

        public UnitTest1() : base(new DbContextOptions<HRDbContext>())
        {
        }

        [TestMethod]
        public void TestMethod1()
        {
            var a = DetectEntityMapping();

        }
    }
}
