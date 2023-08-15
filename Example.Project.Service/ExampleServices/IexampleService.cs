using Example.Project.Dto.ExampleDto;
using Example.Project.ToolKit.Responses;

namespace Example.Project.Service.ExampleServices
{
    public interface IexampleService
    {
        EntityResponse<TestDto> GetSingleData(string id);
        EntityListResponse<TestDto> GetAllData();
        PrimitiveResponse InsertData(TestDto model);
    }
}
