using Aihr.WorkloadCalculator.Domain.Model;
using Aihr.WorkloadCalculator.Domain.Repositories;
using Aihr.WorkloadCalculator.Domain.Services;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Aihr.WorkloadCalculator.UI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IWorkloadCalculator workloadCalculator;
        private readonly IScheduleRepository repository;

        public IndexModel(IWorkloadCalculator workloadCalculator, IScheduleRepository repository)
        {   
            this.workloadCalculator = workloadCalculator;
            this.repository = repository;
        }

        public void OnGet()
        {
            Schedules = new List<Schedule>(repository.GetAll());
        }

        public void OnPost()
        {
            Schedules = new List<Schedule>(repository.GetAll());
            if (ModelState.IsValid)
            {
                try
                {
                    var schedule = workloadCalculator.CalculateWorkload(new DateRange((DateTime)PeriodStart!, (DateTime)PeriodEnd!),
                        new StudyPreference(HoursPerDay, IncludingWeekends), Courses.Where(c => CourseIds.Contains(c.Id)));

                    repository.Add(schedule);
                    Schedules.Add(schedule);
                }
                catch (WorkloadTooHighException exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }
        }

        [BindProperty]
        public DateTime? PeriodStart { get; set; }

        [BindProperty]
        public DateTime? PeriodEnd { get; set; }

        [BindProperty]
        public int HoursPerDay { get; set; } = 4;

        [BindProperty]
        public bool IncludingWeekends { get; set; }

        [BindNever]
        public IReadOnlyList<Course> Courses => CourseCatalog.Courses;

        [BindProperty]
        public IEnumerable<Guid> CourseIds { get; set; } = Array.Empty<Guid>();

        [BindProperty]
        public ICollection<Schedule> Schedules { get; set; } = new HashSet<Schedule>();
    }
}
