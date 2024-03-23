using WebApp.Domain.UserAggregate.ValueObjects;

namespace WebApp.Domain.UnitTest.UserAggregate.ValueObjects;

[TestClass]
public class FullNameTest
{
    [TestMethod]
    public void Test_FullNameValueObject_EqualValue_ReturnTrue()
    {
        var one = new FullName(FirstName: "Michael", LastName: "Myers");
        var two = new FullName(FirstName: "Michael", LastName: "Myers");

        Assert.IsTrue(EqualityComparer<FullName>.Default.Equals(one, two));
        Assert.IsTrue(object.Equals(one, two));
        Assert.IsTrue(one.Equals(two));
        Assert.IsTrue(one == two);
    }

    [TestMethod]
    public void Test_FullNameValueObject_EqualValue_ReturnFalse()
    {
        var one = new FullName(FirstName: "Michael", LastName: "Myers");
        var two = new FullName(FirstName: "Freddy", LastName: "Krueger");

        Assert.IsFalse(EqualityComparer<FullName>.Default.Equals(one, two));
        Assert.IsFalse(object.Equals(one, two));
        Assert.IsFalse(one.Equals(two));
        Assert.IsFalse(one == two);
    }
}
