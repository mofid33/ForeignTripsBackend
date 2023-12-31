﻿using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Foreign_Trips.Utility
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            this.AddRange(items);
        }

        public bool HasPreviousPage => PageIndex > 1;

        public bool HasNextPage => PageIndex < TotalPages;

        public static async Task<PaginatedList<T>> CreateAsync(IEnumerable<T> source, int pageIndex , int pagesize)
        {
            //var count = await source.CountAsync();
            var items =  source.Skip((pageIndex - 1) * pagesize).Take(pagesize).ToList();
            return new PaginatedList<T>(items, source.Count(), pageIndex, pagesize);
        }
    }

}
