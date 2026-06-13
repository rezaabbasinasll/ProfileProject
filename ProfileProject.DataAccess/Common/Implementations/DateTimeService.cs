using System;
using ProfileProject.Domain.Common.Interfaces;

namespace ProfileProject.DataAccess.Common.Implementations;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.UtcNow;
}
