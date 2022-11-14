namespace Aihr.WorkloadCalculator.Domain.Model
{
    /// <summary>
    /// Simple structure to represent a date range given its start and end date.
    /// </summary>
    public readonly struct DateRange
    {
        public DateRange(DateTime start, DateTime end)
            : this(DateOnly.FromDateTime(start), DateOnly.FromDateTime(end))
        {
        }

        public DateRange(DateOnly start, DateOnly end)
        {
            Start = start <= end ? start : end;
            End = end > start ? end : start;
        }

        /// <summary>
        /// The starting point of the date range.
        /// </summary>
        public DateOnly Start { get; }

        /// <summary>
        /// The ending point of the date range.
        /// </summary>
        public DateOnly End { get; }

        /// <summary>
        /// A <see cref="TimeSpan"/> representing the duration of the date range.
        /// </summary>
        public TimeSpan Duration => End.ToDateTime(TimeOnly.MinValue) - Start.ToDateTime(TimeOnly.MinValue);

        /// <summary>
        /// Returns a read-only list of <see cref="DateOnly"/> instances representing the individual days in the date range; optionally constrained to only the workdays.
        /// </summary>
        /// <param name="workdaysOnly">Constrain the list to workdays (Monday thru Friday)?</param>
        /// <returns></returns>
        public IReadOnlyList<DateOnly> GetDays(bool workdaysOnly = false)
        {
            List<DateOnly> days = new(capacity: (int)Duration.TotalDays);

            for (DateOnly day = Start; day <= End; day = day.AddDays(1))
            {
                if (day.DayOfWeek is not DayOfWeek.Sunday and not DayOfWeek.Saturday || !workdaysOnly)
                {
                    days.Add(day);
                }
            }

            return days.AsReadOnly();
        }
    }
}
