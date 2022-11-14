using Aihr.WorkloadCalculator.Domain.Model;

namespace Aihr.WorkloadCalculator.Domain.Services
{
    /// <summary>
    /// Defines the interface for a workload calculator.
    /// </summary>
    public interface IWorkloadCalculator
    {
        /// <summary>
        /// Given the period of study, the learners preference with regard to study time allocation and their desired curriculum as the inputs, returns a suggested schedule with the weekly workload.
        /// </summary>
        /// <param name="studyPeriod">A calendar period.</param>
        /// <param name="studyPreference">The study preference of the learner.</param>
        /// <param name="curriculum">The selected courses.</param>
        /// <returns></returns>
        /// <exception cref="WorkloadTooHighException">If the time required to complete the curriculum exceeds the available study time.</exception>
        Schedule CalculateWorkload(DateRange studyPeriod, StudyPreference studyPreference, IEnumerable<Course> curriculum);
    }
}
