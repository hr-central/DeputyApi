namespace DeputyApi.Models
{
    internal class ErrorModel
    {
        public int Code { get; set; }
        public string Message { get; set; }
    }

    internal class ErrorContainerModel
    {
        public ErrorModel Error { get; set; }
    }
}
