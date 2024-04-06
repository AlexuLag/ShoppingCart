using System.Text.Json;

namespace API;

public static class HttpExtensions
{
    /// <summary>
    /// add an extension method to http response to allow add a pagination header on the response
    /// </summary>
    /// <param name="response">http response object</param>
    /// <param name="currentPage">current page sended by client</param>
    /// <param name="itemsPerPage"> number of items that user wants to receive per page</param>
    /// <param name="totalItems"> total number of items on de database </param>
    /// <param name="totalPages">number of pages based on total items and items per pega</param>
    public static void AddPaginationHeader( this HttpResponse response, int currentPage, int itemsPerPage, int totalItems, int totalPages)
    {
        var paginationHeader =  new{
            currentPage,
            itemsPerPage,
            totalItems,
            totalPages
        };
        response.Headers.Add("Pagination",JsonSerializer.Serialize(paginationHeader) );
        response.Headers.Add("Access-Control-Expose-Headers", "Pagination");
        
    }
}
