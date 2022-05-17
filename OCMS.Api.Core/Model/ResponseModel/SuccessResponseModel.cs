namespace OCMS.Api.Core.Model.ResponseModel
{
    public class SuccessResponseModel<T>
    {
        public bool Status { get; set; }
        public T Model { get; set; }
    }
}
