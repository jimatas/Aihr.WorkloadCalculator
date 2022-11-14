namespace Aihr.WorkloadCalculator.Domain.Model
{
    /// <summary>
    /// Represents the catalog of all courses a learner can take. 
    /// </summary>
    /// <remarks>
    /// Implemented as a publicly accessible static list for expedience.
    /// </remarks>
    public static class CourseCatalog
    {
        /// <summary>
        /// A read-only list view of all the courses offered.
        /// </summary>
        public static IReadOnlyList<Course> Courses { get; } = new[]
        {
            new Course(Guid.NewGuid(), "Blockchain and HR", 8),
            new Course(Guid.NewGuid(), "Compensation & Benefits", 32),
            new Course(Guid.NewGuid(), "Digital HR", 40),
            new Course(Guid.NewGuid(), "Digital HR Strategy", 10),
            new Course(Guid.NewGuid(), "Digital HR Transformation", 8),
            new Course(Guid.NewGuid(), "Diversity & Inclusion", 20),
            new Course(Guid.NewGuid(), "Employee Experience & Design Thinking", 12),
            new Course(Guid.NewGuid(), "Employer Branding", 6),
            new Course(Guid.NewGuid(), "Global Data Integrity", 12),
            new Course(Guid.NewGuid(), "Hiring & Recruitment Strategy", 15),
            new Course(Guid.NewGuid(), "HR Analytics Leader", 21),
            new Course(Guid.NewGuid(), "HR Business Partner 2.0", 40),
            new Course(Guid.NewGuid(), "HR Data Analyst", 18),
            new Course(Guid.NewGuid(), "HR Data Science in R", 12),
            new Course(Guid.NewGuid(), "HR Data Visualization", 12),
            new Course(Guid.NewGuid(), "HR Metrics & Reporting", 40),
            new Course(Guid.NewGuid(), "Learning & Development", 30),
            new Course(Guid.NewGuid(), "Organizational Development", 30),
            new Course(Guid.NewGuid(), "People Analytics", 40),
            new Course(Guid.NewGuid(), "Statistics in HR", 15),
            new Course(Guid.NewGuid(), "Strategic HR Leadership", 34),
            new Course(Guid.NewGuid(), "Strategic HR Metrics", 17),
            new Course(Guid.NewGuid(), "Talent Acquisition", 40)
        };
    }
}
