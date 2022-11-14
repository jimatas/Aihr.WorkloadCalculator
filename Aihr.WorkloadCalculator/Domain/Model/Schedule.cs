using Aihr.WorkloadCalculator.Domain.Services;

namespace Aihr.WorkloadCalculator.Domain.Model
{
    /// <summary>
    /// Encapsulates the output of the <see cref="IWorkloadCalculator"/> service.
    /// It contains the selected curriculum, the study period, and the approximate weekly workload.
    /// </summary>
    public class Schedule
    {
        public Schedule(Guid id, DateRange period, IEnumerable<Course> curriculum, int weeklyWorkload)
        {
            Id = id;
            Period = period;
            Curriculum = new List<Course>(curriculum).AsReadOnly();
            WeeklyWorkload = weeklyWorkload;
        }

        /// <summary>
        /// A unique identifier for the schedule.
        /// </summary>
        /// <remarks>
        /// Not really needed as the data store for this POC is a local in-memory cache, but it's included for completeness.
        /// </remarks>
        public Guid Id { get; }

        /// <summary>
        /// The period of study selected by the learner.
        /// </summary>
        public DateRange Period { get; }

        /// <summary>
        /// The courses selected by the learner.
        /// </summary>
        public IReadOnlyCollection<Course> Curriculum { get; }

        /// <summary>
        /// The weekly workload as the approximate number of study hours per week.
        /// </summary>
        public int WeeklyWorkload { get; }
    }
}
