using AdvertisementApp.Common.Enums;

namespace AdvertisementApp.Common.ResponseObjects
{
    // response returner. implements IResponse interface
    public class Response : IResponse
    {
        public string Message { get; set; }
        public ResponseType ResponseType { get; set; }

        public Response(ResponseType responseType)
        {
            ResponseType = responseType;
        }

        public Response(string message, ResponseType responseType)
        {
            Message = message;
            ResponseType = responseType;
        }
    }
}
