using Azure;
using Microsoft.EntityFrameworkCore;

namespace Application;

public class PagedList<T> : List<T>
{
    public PagedList( IEnumerable<T> items,int count, int pageNumber, int pageSize )
    {
        CurrentPage=pageNumber;
        TotalPages= (int)Math.Ceiling(count/(double)pageSize);
        PageSize = pageSize;
        TotalCount = count;
        AddRange(items);

    }
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }

    public static async Task <PagedList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize)
    {
        //excecute first query getting the total elements in the select (select count(*) from xxx)
        var count = await source.CountAsync();
        //build expresion to send the query with pagination to database
        var items= await source.Skip((pageNumber-1)*pageSize).Take(pageSize).ToListAsync();
        return new PagedList<T>(items,count,pageNumber,pageSize);

    }
}
