using Example.Project.Dto.ExampleDto;
using Example.Project.Repository.OracleParameter;
using Example.Project.Repository.Repository;
using Example.Project.ToolKit.Responses;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Reflection;

namespace Example.Project.Service.ExampleServices
{
    public class exampleService : IexampleService
    {
        private readonly IexampleRepository _repository;

        public exampleService(IexampleRepository repository)
        {
            _repository = repository;
        }

        public EntityListResponse<TestDto> GetAllData()
        {
            try
            {
                var result = _repository.QueryMultiOutput<TestDto>("PROC NAME", null);
                return new EntityListResponse<TestDto> { EntityDataList = result.Item1.ToList(), ResponseCode = ResponseCodes.Successful, ResponseErrorMessage = null, ResponseMessage = "Success" };
            }
            catch (Exception ex)
            {
                return new EntityListResponse<TestDto> { EntityDataList = null, ResponseCode = ResponseCodes.SystemError, ResponseErrorMessage = ex.Message, ResponseMessage = null };
            }
        }

        public EntityResponse<TestDto> GetSingleData(string id)
        {
            try
            {
                var prms = new Dictionary<string, OraParam>();
                prms.Add(":rec", new OraParam() { Direction = ParameterDirection.Output, OraType = OracleDbType.RefCursor });
                prms.Add("P_ID", new OraParam() { OraType = OracleDbType.Varchar2, Direction = ParameterDirection.Input, Value = id });
                var result = _repository.QueryMultiOutput<TestDto>("PROC NAME", prms);
                return new EntityResponse<TestDto> { EntityData = result.Item1.SingleOrDefault(), ResponseCode = ResponseCodes.Successful, ResponseMessage = "Success" };
            }
            catch (Exception ex)
            {
                return new EntityResponse<TestDto> { EntityData = null, ResponseCode = ResponseCodes.SystemError, ResponseErrorMessage = ex.Message };
            }
        }

        public PrimitiveResponse InsertData(TestDto model)
        {
            try
            {
                var prms = new Dictionary<string, OraParam>();
                prms.Add(":rec", new OraParam() { Direction = ParameterDirection.Output, OraType = OracleDbType.RefCursor });
                prms.Add("P_ID", new OraParam() { OraType = OracleDbType.Int32, Direction = ParameterDirection.Input, Value = model.Id });
                prms.Add("P_NAME", new OraParam() { OraType = OracleDbType.Varchar2, Direction = ParameterDirection.Input, Value = model.Name });
                prms.Add("P_SURNAME", new OraParam() { OraType = OracleDbType.Int32, Direction = ParameterDirection.Input, Value = model.Surname });
                prms.Add("P_PHONE", new OraParam() { OraType = OracleDbType.Varchar2, Direction = ParameterDirection.Input, Value = model.Phone });
                prms.Add("P_CREATED_ON", new OraParam() { OraType = OracleDbType.Date, Direction = ParameterDirection.Input, Value = model.CreatedOn });
                prms.Add("P_CREATED_BY", new OraParam() { OraType = OracleDbType.Int32, Direction = ParameterDirection.Input, Value = model.CreatedBy });
                prms.Add("P_MODIFIED_ON", new OraParam() { OraType = OracleDbType.Date, Direction = ParameterDirection.Input, Value = model.ModifiedOn });
                prms.Add("P_MODIFIED_BY", new OraParam() { OraType = OracleDbType.Int32, Direction = ParameterDirection.Input, Value = model.ModifiedBy });
                var result = _repository.QueryMultiOutput<int>("PROC NAME", prms);
                return new PrimitiveResponse { PrimitiveResponseValue = result.Item1.SingleOrDefault().ToString(), ResponseCode = ResponseCodes.Successful, ResponseMessage = "Success", };
            }
            catch (System.Exception ex)
            {
                return new PrimitiveResponse() { PrimitiveResponseValue = "-1", ResponseErrorMessage = ex.Message };
            }
        }
    }
}
