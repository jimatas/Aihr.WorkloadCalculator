using Aihr.WorkloadCalculator.Domain.Model;

namespace Aihr.WorkloadCalculator.Tests
{
    [TestClass]
    public class DateRangeTests
    {
        [DataTestMethod]
        [DataRow("2022-11-03", "2022-11-07", false, 5)]
        [DataRow("2022-11-03", "2022-11-07", true, 3)]
        [DataRow("2022-11-06", "2022-11-19", false, 14)]
        [DataRow("2022-11-06", "2022-11-19", true, 10)]
        public void GetDays_GivenVariableInput_ReturnsExpectedNumberDays(string startDate, string endDate, bool workdaysOnly, int expected)
        {
            // Arrange
            DateRange sut = new(DateOnly.Parse(startDate), DateOnly.Parse(endDate));

            // Act
            int actual = sut.GetDays(workdaysOnly).Count;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
