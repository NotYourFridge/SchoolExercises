using Moq;
using Xunit;

namespace Mockery{

/*

Arrange:

In this phase, you set up the necessary preconditions and context for your test. This typically involves creating objects, configuring dependencies, and preparing the environment for the specific scenario you want to test.

In your code, the "Arrange" section includes the following:

Creating a mock object mockCalculator for the ICalculator interface.
Setting up expectations for the Add method of the mock object using mockCalculator.Setup.
Specifying that when Add(2, 3) is called on the mock object, it should return 5.
Act:

This is where you invoke the method or perform the action that you want to test. In other words, it's the part of the test where you execute the code you're testing.
In your code, the "Act" section includes calling the Add method of the mock object with the arguments (2, 3) and storing the result in the result variable.
Assert:

The "Assert" phase checks whether the outcome of the action in the "Act" phase matches your expectations. You use assertions to verify that the code being tested produces the expected results.
In your code, the "Assert" section includes the Assert.Equal statement, which checks if the result is equal to 5, as expected. If the assertion passes, the test is considered successful.
So, in your example:

Arrange: You set up the mock object and its behavior.
Act: You call the method you're testing.
Assert: You verify that the result matches your expectations.
Following the AAA pattern helps keep your tests organized and easy to read, making it clear what's being tested, how it's being tested, and what success looks like.

*/

public interface ICalculator
{
    int Add(int a, int b);
    int Subtract(int a, int b);
}

public class Test{
    
[Fact]
public void TestCalculator()
{
    // Create a mock of the ICalculator interface
    var mockCalculator = new Mock<ICalculator>();

    // Set up expectations for the Add method
    mockCalculator.Setup(calc => calc.Add(2, 3))
                  .Returns(5); // Expecting Add(2, 3) to return 5

    // Use the mock in your test
    var result = mockCalculator.Object.Add(2, 3);

    // Assert the result
    Assert.Equal(5, result);
}

}




}