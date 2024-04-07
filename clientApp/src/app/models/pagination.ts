export interface Pagination{
    currentPage: number;
    itempPerPage: number;
    totalItems: Number;
    totalPages:number;
}

export class PaginatedResult<T>
{
    data: T;
    pagination: Pagination;
    constructor(data: T, pagination:Pagination )
    {
        this.data = data;
        this.pagination=pagination;
    }

}

export class PagingParams {
    pageNumber;
    pagesize;

    constructor (pageNumber=1,pageSize=10){
        this.pageNumber=pageNumber
        this.pagesize=pageSize
    }
}