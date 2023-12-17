using ArchitectureApi.Dtos;

namespace ArchitectureApi.Extensions;

public static class FilterExtensions
{
    public static IQueryable<DoctorDto> Filter(this IQueryable<DoctorDto> doctors, string? filter)
    {
        if (filter == null)
            return doctors;
        return doctors.Where(x => x.FullName.Contains(filter) || x.DoctorType.Contains(filter));
    }
}