namespace ArchitectureApi.Extensions;

public static class PageExtensions
{
    public static IQueryable<T> Paginate<T>(this IQueryable<T> items, int pageSize, int page)
    {
        if (page == default)
            page = 1;
        if (pageSize == default)
            pageSize = 10;
        return items.Skip((page - 1) * pageSize).Take(pageSize);
    }
}