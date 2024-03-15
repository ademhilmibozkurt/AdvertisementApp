using AdvertisementApp.Common.Enums;

namespace AdvertisementApp.Common.ResponseObjects
{
    // generic response returner. implements IResponse interface
    public class Response<T> : Response, IResponse<T>
    {
        public T Data {  get; set; }

        // managing errors
        public List<CustomValidationError> ValidationErrors { get; set; }

        public Response(T data, ResponseType responseType) : base(responseType)
        {
            Data = data;
        }

        public Response(string message, ResponseType responseType) : base(message, responseType)
        {
            
        }
        
        public Response(T data, ResponseType responseType, List<CustomValidationError> errors) : base(ResponseType.ValidationError)
        {
            Data = data;
            ValidationErrors = errors;
        }

    }
}
