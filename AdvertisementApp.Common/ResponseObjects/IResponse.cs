using AdvertisementApp.Common.Enums;

namespace AdvertisementApp.Common.ResponseObjects
{
    // response design pattern interface
    // this allows to get validation or not found errors with enums
    // or allows to catch success return 
    public interface IResponse
    {
        string Message { get; set; }
        ResponseType ResponseType { get; set; }

    }
}
