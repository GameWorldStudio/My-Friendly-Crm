namespace My_Friendly_CRM.Model
{
    public class Response<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
        public int ReturnCode { get; set; }
    }
}
