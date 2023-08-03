using Example.Project.Repository.OracleParameter;
using System.Data;

namespace Example.Project.Repository.Repository
{
    public interface IexampleRepository
    {
        Tuple<IEnumerable<T1>> QueryMultiOutput<T1>(string query, System.Data.CommandType cmdType = System.Data.CommandType.StoredProcedure, OracleDynamicParameters parameters = null);

        Tuple<IEnumerable<T1>, IEnumerable<T2>> QueryMultiOutput<T1, T2>(string query, System.Data.CommandType cmdType = System.Data.CommandType.StoredProcedure, OracleDynamicParameters parameters = null);

        Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>> QueryMultiOutput<T1, T2, T3>(string query, System.Data.CommandType cmdType = System.Data.CommandType.StoredProcedure, OracleDynamicParameters parameters = null);

        Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>> QueryWithMultiOutput<T1, T2, T3>(string query, Dictionary<string, OraParam> parameters = null);
        Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>> QueryWithMultiOutput<T1, T2, T3, T4, T5>(string query, Dictionary<string, OraParam> parameters = null);
        Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>> QueryWithMultiOutput<T1, T2, T3, T4, T5, T6>(string query, Dictionary<string, OraParam> parameters = null);
        Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>> QueryWithMultiOutput<T1, T2, T3, T4, T5, T6, T7>(string query, Dictionary<string, OraParam> parameters = null);
        Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>, Tuple<IEnumerable<T8>>> QueryWithMultiOutput<T1, T2, T3, T4, T5, T6, T7, T8>(string query, Dictionary<string, OraParam> parameters = null);

        int ExecuteQuery(string query, Dictionary<string, OraParam> parameters = null);
        Tuple<IEnumerable<T1>> QueryMultiOutput<T1>(string query, Dictionary<string, OraParam> parameters = null);

    }
}
