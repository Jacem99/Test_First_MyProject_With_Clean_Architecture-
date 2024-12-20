﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Core.Wrapper
{
    public static class QuerableExtentions
    {
        public static async Task<PaginationResult<T>> ToPaginationListAsync<T>(this IQueryable<T> source, int pageNumber, int pageSize) where T : class
        {
            if (source == null) throw new Exception("Empty");

            pageNumber  = pageNumber ==0 ? 1 : pageNumber;
            pageSize = pageSize == 0 ? 10 : pageSize;

            int count = await source.AsNoTracking().CountAsync();
            if (count == 0) return PaginationResult<T>.Success(new List<T>() , count , pageNumber , pageSize);

       
            pageNumber  = pageNumber <=0 ? 1 : pageNumber;
            var item = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return PaginationResult<T>.Success(item , count , pageNumber , pageSize);   
        }
    }
}
