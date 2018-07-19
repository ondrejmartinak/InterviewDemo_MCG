using System.Collections.Generic;

namespace Microgen.Sites.Interview.Models
{
    public class CustomResponse<T>
    {
        public T Data { get; set; }

        public List<string> Errors { get; set; }

        public object Resources { get; set; }
    }
}