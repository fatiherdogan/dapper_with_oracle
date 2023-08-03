using Example.Project.Dto.ExampleDto;
using Example.Project.Repository.OracleParameter;
using Example.Project.Repository.Repository;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Security.Cryptography;
using System;

namespace Example.Project.Service.ExampleServices
{
    public class exampleService : IexampleService
    {
        private readonly IexampleRepository _repository;

        public exampleService(IexampleRepository repository)
        {
            _repository = repository;
        }

        public List<TestDto> GetAllData()
        {
            try
            {
                var result = _repository.QueryMultiOutput<TestDto>("PROC NAME", null);
                return result.Item1.ToList();
            }
            catch (Exception)
            {
                return new List<TestDto>();
            }
        }

        public TestDto GetSingleData()
        {
            try
            {
                var result = _repository.QueryMultiOutput<TestDto>("PROC NAME", null);
                return result.Item1.SingleOrDefault();
            }
            catch (Exception)
            {
                return new TestDto();
            }
        }

        public int InsertData(TestDto model)
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
                return result.Item1.SingleOrDefault();
            }
            catch (System.Exception ex)
            {
                return 0;
            }
        }
    }
}
