using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Core.Generic_Response
{
    public class ResponseHandler
    {
        public ResponseHandler()
        {
            
        }
        public Response<T> Success<T>(T entity , object Meta = null,string message="Successfully")
        {
            return new Response<T>()
            {
                Data = entity,
                Succeeded = true,
                StatusCode = System.Net.HttpStatusCode.OK,
                Message = message,
                Meta = Meta
            };
        }
        public Response<T> NotFound<T>(T entity, object Meta = null)
        {
            return new Response<T>()
            {
                Succeeded = true,
                StatusCode = System.Net.HttpStatusCode.Created,
                Message = "Created",
                Meta= Meta
            };
        }
        public Response<T> Unauthorized<T>()
        {
            return new Response<T>()
            {
                Succeeded = false,
                StatusCode = System.Net.HttpStatusCode.Unauthorized,
                Message = "UnAthorized",
            };
        }
        public Response<T> NotFound<T>(string Message = null)
        {
            return new Response<T>()
            {
                Succeeded = false,
                StatusCode = System.Net.HttpStatusCode.Unauthorized,
                Message = Message == null ? "Not Found" : Message,
            };
        }
        public Response<T> BadRequest<T>(string Message = null)
        {
            return new Response<T>()
            {
                Succeeded = false,
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Message = Message == null ? "Bad Request": Message,
            };
        }
        public Response<T> Deleted<T>()
        {
            return new Response<T>()
            {
                Succeeded = true,
                StatusCode = System.Net.HttpStatusCode.OK,
                Message = "Deleted Successfully",
            };
        }


    }
}
