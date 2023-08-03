using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Example.Project.Repository.OracleParameter
{
    public class OraParam
    {
        public object Value { get; set; }
        public ParameterDirection Direction { get; set; }
        public OracleDbType OraType { get; set; }
    }
}
