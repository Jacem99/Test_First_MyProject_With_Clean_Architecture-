using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Core.Generic_Response
{
    public class Response<T>

        
    {
        public HttpStatusCode StatusCode {  get; set; }
        public string Message { get; set; }
        public bool Succeeded { get; set; }
        public T Data { get; set; }
        public object Meta { get; set; }
        public List<string> Errors { get; set; }

        public Response() { }
        public Response(T data , string message = null)
        {
            Succeeded = true;
            Message = message;
            Data = data;
        }
        public Response(string message)
        {
            Succeeded = false;
            Message = message;
        }
        public Response(string message,bool succeeded)
        {
            Succeeded=succeeded;
            Message = message;
        }
    }
}
