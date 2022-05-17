namespace OCMS.Api.Core.Model.ResponseModel
{
    public class ErrorResponseModel<T>
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public T Error { get; set; }
    }
}
