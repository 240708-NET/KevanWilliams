namespace testProject.Tests;
using Xunit;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        string foo = "hello";
        bool isEmpty = string.isEmpty(foo);
       
        Assert.True(isEmpty);
    }
}