using WebApp.Domain.PlayerAggregate.ValueObjects;

namespace WebApp.Domain.UnitTest.PlayerAggregate.ValueObjects;

[TestClass]
public class AddressTest
{
    [TestMethod]
    public void Test_AddressValueObject_EqualValue_ReturnTrue()
    {
        var one = new Address("45 Lampkin Lane", "Haddonfield", "USA", "32342");
        var two = new Address("45 Lampkin Lane", "Haddonfield", "USA", "32342");

        Assert.IsTrue(EqualityComparer<Address>.Default.Equals(one, two));
        Assert.IsTrue(object.Equals(one, two));
        Assert.IsTrue(one.Equals(two));
        Assert.IsTrue(one == two);
    }

    [TestMethod]
    public void Test_AddressValueObject_EqualValue_ReturnFalse()
    {
        var one = new Address("45 Lampkin Lane", "Haddonfield", "USA", "32342");
        var two = new Address("46 Lampkin Lane", "Haddonfield", "USA", "32342");

        Assert.IsFalse(EqualityComparer<Address>.Default.Equals(one, two));
        Assert.IsFalse(object.Equals(one, two));
        Assert.IsFalse(one.Equals(two));
        Assert.IsFalse(one == two);
    }
}
