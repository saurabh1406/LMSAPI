namespace LMS.Application.Common.Wrapper
{
    public class APIResponse<T>
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public T? Data { get; set; }
    }
}
