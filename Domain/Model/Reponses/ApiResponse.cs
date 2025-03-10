using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Reponses
{
    public class ApiResponse<T>
    {
        public int StatusCode { get; set; }       // e.g., 200, 201, 204, etc.
        public string Message { get; set; }       // A brief message about the result
        public T Data { get; set; }               // The actual data payload (if any)
        public bool Success { get; set; }         // Indicates if the operation was successful
    }
}
