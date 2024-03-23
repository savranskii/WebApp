using WebApp.Domain.UserAggregate.Entities;
using WebApp.Domain.UserAggregate.ValueObjects;

namespace WebApp.Domain.UnitTest.UserAggregate.Entities;

[TestClass]
public class UserTest
{
    [TestMethod]
    public void Test_UserEntity_Change_ReturnTrue()
    {
        var email = "test@mail.net";
        var name = new FullName(
            FirstName: "Michael",
            LastName: "Myers"
        );
        var address = new Address(
            Street: "45 Lampkin Lane",
            City: "Haddonfield",
            Country: "USA",
            ZipCode: "32342"
        );
        var user = new User();
        user.SetEmail(email);
        user.SetName(name);
        user.SetAddress(address);

        Assert.AreEqual(user.Email, email);
        Assert.AreEqual(user.Name, name);
        Assert.AreEqual(user.Address, address);
    }
}
