using Azure;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Core.Wrapper
{
    public class PaginationResult<T> where T : class
    {

        public List<T> Data { get; set; }
        ///////////////////////////////
        
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
        public object Meta { get; set; }
        public int PageSize { get; set; }
        public bool HavePreviousPage => CurrentPage > 1;
        public bool HaveNextPage => CurrentPage < TotalPages;
        public List<string> Messages { get; set; } = new List<string>();   
        public bool Succeded { get; set; }


        public PaginationResult(List<T> data)
        {
            Data = data;
        }

        public PaginationResult(bool succeded, List<T> data = default, List<string> message = null, int count = 0, int page = 1, int pageSize = 10 )
        {
           Data = data; 
           CurrentPage = page;
           Succeded = succeded;
           PageSize = pageSize;
           TotalPages = (int)Math.Ceiling(count / (double)pageSize);
           Succeded = succeded;
        }
        public static PaginationResult<T> Success(List<T> data , int count , int page ,int pageSize) {
            return new(true, data, null, count, page, pageSize);        
        }
    }
}
