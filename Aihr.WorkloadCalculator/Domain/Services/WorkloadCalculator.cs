using Aihr.WorkloadCalculator.Domain.Model;

namespace Aihr.WorkloadCalculator.Domain.Services
{
    /// <summary>
    /// Default implementation of the <see cref="IWorkloadCalculator"/> interface.
    /// </summary>
    public class WorkloadCalculator : IWorkloadCalculator
    {
        /// <inheritdoc/>
        public Schedule CalculateWorkload(DateRange studyPeriod, StudyPreference studyPreference, IEnumerable<Course> curriculum)
        {
            int totalDuration = curriculum.Sum(course => course.Duration);

            int studyDaysInPeriod = studyPeriod.GetDays(workdaysOnly: !studyPreference.IncludingWeekends).Count;
            int studyHoursInPeriod = studyPreference.HoursPerDay * studyDaysInPeriod;
            if (studyHoursInPeriod < totalDuration)
            {
                throw new WorkloadTooHighException("The study hours required to complete the curriculum exceeds the available study hours in the calendar period.");
            }

            int weeksInPeriod = (int)Math.Ceiling((double)studyDaysInPeriod / (studyPreference.IncludingWeekends ? 7 : 5));
            int weeklyWorkload = (int)Math.Ceiling((double)totalDuration / weeksInPeriod);

            return new Schedule(Guid.NewGuid(), studyPeriod, curriculum, weeklyWorkload);
        }
    }
}
