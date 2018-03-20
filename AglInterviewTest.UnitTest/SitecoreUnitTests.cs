using System;
using NUnit.Framework;
using Sitecore.FakeDb;
using FluentAssertions;

namespace AglInterviewTest.UnitTest
{
    
    public class SitecoreUnitTests
    {
        [Test]
        public void ContentItemShouldExist()
        {
            //arrange
            using(var db=new Db())
            {
                var item = db.GetItem("/sitecore/content");
                item.Should().NotBeNull();
            }
        }
    }
}
