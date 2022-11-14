using Aihr.WorkloadCalculator.Domain.Model;
using Aihr.WorkloadCalculator.Domain.Services;

using WorkloadCalculationService = Aihr.WorkloadCalculator.Domain.Services.WorkloadCalculator;

namespace Aihr.WorkloadCalculator.Tests
{
    [TestClass]
    public class WorkloadCalculatorTests
    {
        [TestMethod]
        public void CalculateWorkload_GivenLightWorkload_ReturnsExpectedStudyPlan()
        {
            // Arrange
            IWorkloadCalculator sut = new WorkloadCalculationService();

            DateRange studyPeriod = new(new DateOnly(2022, 10, 31), new DateOnly(2022, 11, 25));
            StudyPreference studyPreference = new(hoursPerDay: 4, includingWeekends: false); // Available: 80h (20d)
            IEnumerable<Course> curriculum = CourseCatalog.Courses.Where(c => c.Name is "Blockchain and HR" or "Global Data Integrity"); // Required: 20h

            // Act
            Schedule actual = sut.CalculateWorkload(studyPeriod, studyPreference, curriculum);

            // Assert
            Assert.AreEqual(2, actual.Curriculum.Count);
            Assert.AreEqual(5, actual.WeeklyWorkload);
        }

        [TestMethod]
        public void CalculateWorkload_GivenHeavyishWorkload_ReturnsExpectedStudyPlan()
        {
            // Arrange
            IWorkloadCalculator sut = new WorkloadCalculationService();

            DateRange studyPeriod = new(new DateOnly(2022, 11, 6), new DateOnly(2022, 11, 19));
            StudyPreference studyPreference = new(hoursPerDay: 4, includingWeekends: true); // Available: 56h (14d)
            IEnumerable<Course> curriculum = CourseCatalog.Courses.Where(c => c.Name is "Digital HR" or "Statistics in HR"); // Required: 55h

            // Act
            Schedule actual = sut.CalculateWorkload(studyPeriod, studyPreference, curriculum);

            // Assert
            Assert.AreEqual(2, actual.Curriculum.Count);
            Assert.AreEqual(28, actual.WeeklyWorkload);
        }

        [TestMethod]
        public void CalculateWorkload_GivenExcessiveWorkload_ThrowsWorkloadTooHighException()
        {
            // Arrange
            IWorkloadCalculator sut = new WorkloadCalculationService();

            DateRange studyPeriod = new(new DateOnly(2022, 11, 3), new DateOnly(2022, 11, 7));
            StudyPreference studyPreference = new(hoursPerDay: 4, includingWeekends: false); // Available: 12h (3d)
            IEnumerable<Course> curriculum = CourseCatalog.Courses.Where(c => c.Name is "Digital HR Strategy" or "Digital HR Transformation"); // Required: 18h

            // Act
            void action() => sut.CalculateWorkload(studyPeriod, studyPreference, curriculum);

            // Assert
            Assert.ThrowsException<WorkloadTooHighException>(action);
        }
    }
}
