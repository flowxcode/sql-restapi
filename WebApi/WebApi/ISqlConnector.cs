using WebApi.Model;

namespace WebApi
{
    public interface ISqlConnector
    {
        List<Car> ReadCarData();
    }
}