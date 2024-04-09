using WebApp.Domain.PlayerAggregate.Entities;
using WebApp.Domain.PlayerAggregate.ValueObjects;

namespace WebApp.Domain.UnitTest.PlayerAggregate.Entities;

[TestClass]
public class PlayerTest
{
    [TestMethod]
    public void Test_PlayerEntity_Change_ReturnTrue()
    {
        const string email = "test@mail.net";
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
        var player = new Player();
        player.SetEmail(email);
        player.SetName(name);
        player.SetAddress(address);

        Assert.AreEqual(player.Email, email);
        Assert.AreEqual(player.Name, name);
        Assert.AreEqual(player.Address, address);
    }
}
