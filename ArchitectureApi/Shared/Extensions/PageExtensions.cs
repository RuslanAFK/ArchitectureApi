namespace ArchitectureApi.Extensions;

public static class PageExtensions
{
    public static IQueryable<T> Paginate<T>(this IQueryable<T> items, int pageSize, int page)
    {
        if (pageSize == default || page == default)
            return items;
        return items.Skip((page - 1) * pageSize).Take(pageSize);
    }
}