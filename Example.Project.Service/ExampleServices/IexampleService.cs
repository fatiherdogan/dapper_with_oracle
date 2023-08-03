using Example.Project.Dto.ExampleDto;

namespace Example.Project.Service.ExampleServices
{
    public interface IexampleService
    {
        TestDto GetSingleData();
        List<TestDto> GetAllData();
        int InsertData(TestDto model);
    }
}
