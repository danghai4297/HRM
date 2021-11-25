using HRMSolution.Application.System.Users.Dtos;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.NUnitTest
{
    public class TestUser : BaseTest
    {
        [OneTimeSetUp]
        public void Setup()
        {

            SeedingData.SeedData(_context);
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            _context.Database.EnsureDeleted();
        }
        //[Test, Order(1)]
        //public void Language_Create_Success()
        //{
        //    RegisterRequest create = new RegisterRequest()
        //    {
        //        UserName = "user8",
        //        Password = "Abcd1234$",
        //        ConfirmPassword = "Abcd1234$",
        //        maNhanVien = "NV0008"
        //    };
        //    var result = UserService.Register(create);
        //    Assert.That(result.Result, Is.EqualTo(true));
        //}

    }
}
