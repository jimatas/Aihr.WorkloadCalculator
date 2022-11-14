namespace Aihr.WorkloadCalculator.Domain.Model
{
    /// <summary>
    /// The exception that is thrown when the time required to complete the curriculum exceeds the available study time.
    /// </summary>
    public class WorkloadTooHighException : Exception
    {
        public WorkloadTooHighException() { }
        public WorkloadTooHighException(string? message) : base(message) { }
    }
}
