namespace Sharff.ApiRest.Models
{
    public class ResultDto
    {
        public object Payload { get; set; }

        public int StatusCode { get; set; }

        public string Message { get; set; }
    }
}
