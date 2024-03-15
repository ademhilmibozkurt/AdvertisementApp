
namespace AdvertisementApp.Common.ResponseObjects
{
    // response design pattern generic interface
    // this allows to get validation or not found errors with enums
    // or allows to catch success return 
    public interface IResponse<T> : IResponse
    {
        T Data { get; set; }
        List<CustomValidationError> ValidationErrors { get; set; }
    }
}
