namespace Aihr.WorkloadCalculator.Domain.Model
{
    /// <summary>
    /// Represents a learners study time allocation preference. That is, the number of hours per day they can allocate to study.
    /// </summary>
    public readonly struct StudyPreference
    {
        public StudyPreference(int hoursPerDay, bool includingWeekends)
        {
            if (hoursPerDay is < 1 or > 24)
            {
                throw new ArgumentOutOfRangeException(
                    paramName: nameof(hoursPerDay),
                    actualValue: hoursPerDay,
                    message: "Value must be a positive integer between 1 and 24.");
            }

            HoursPerDay = hoursPerDay;
            IncludingWeekends = includingWeekends;
        }

        /// <summary>
        /// The hours per day the learner is willing to study.
        /// </summary>
        public int HoursPerDay { get; }

        /// <summary>
        /// Indicates whether the learner is willing to study in the weekends.
        /// </summary>
        public bool IncludingWeekends { get; }
    }
}
