namespace Aihr.WorkloadCalculator.Domain.Model
{
    /// <summary>
    /// Represents a particular course offered through the <see cref="CourseCatalog"/>.
    /// </summary>
    public class Course
    {
        public Course(Guid id, string name, int duration)
        {
            Id = id;
            Name = name;
            Duration = duration;
        }

        /// <summary>
        /// A unique identifier for the course.
        /// </summary>
        /// <remarks>
        /// Not really needed as the data store for this POC is a local in-memory cache, but it's included for completeness.
        /// </remarks>
        public Guid Id { get; }

        /// <summary>
        /// The name of the course.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The duration of the course, expressed as the expected number of study hours.
        /// </summary>
        public int Duration { get; }
    }
}
