using HRMSolution.Application.System.Users.Dtos;
using HRMSolution.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
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
        //        UserName = "xxx",
        //        Password = "Abcd1234$",
        //        ConfirmPassword = "Abcd1234$",
        //        maNhanVien = "NV0008"
        //    };
        //    var result = UserService.Register(create);
        //    Assert.That(result.Result, Is.EqualTo(true));
        //}
        //[Test, Order(1)]
        //public void Language_GetByID_Success()
        //{
        //    var id = new Guid("69BD714F-9576-45BA-B5B7-F00649BE00DE");
        //    var result = UserService.GetById(id);
        //    Assert.That(result.Result.Id, Is.EqualTo(id));
        //}

    }
}
