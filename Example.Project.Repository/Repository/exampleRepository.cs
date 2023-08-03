using Dapper;
using Example.Project.Repository.OracleParameter;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Diagnostics;
using System.Transactions;
using System;
using Example.Project.Repository.Context;

namespace Example.Project.Repository.Repository
{
    public class exampleRepository : IexampleRepository
    {
        public IexampleContext Context { get; }
        public exampleRepository(IexampleContext context)
        {
            Context = context;
        }

        public Tuple<IEnumerable<T1>> QueryMultiOutput<T1>(string query, System.Data.CommandType cmdType = System.Data.CommandType.StoredProcedure, OracleDynamicParameters parameters = null)
        {
            SqlMapper.GridReader reader = null;
            var _connection = Context.Connection;

            if (parameters == null)
            {
                using (var result = _connection.QueryMultiple(query, null, null, null, cmdType))
                {
                    reader = result;
                    var data1 = reader.Read<T1>().ToList();
                    return new Tuple<IEnumerable<T1>>(data1);
                }
            }
            else
            {
                using (var result = _connection.QueryMultiple(query, parameters, null, 1000000, cmdType))
                {
                    reader = result;
                    var data1 = reader.Read<T1>().ToList();
                    return new Tuple<IEnumerable<T1>>(data1);
                }
            }
        }

        public Tuple<IEnumerable<T1>, IEnumerable<T2>> QueryMultiOutput<T1, T2>(string query, System.Data.CommandType cmdType = System.Data.CommandType.StoredProcedure, OracleDynamicParameters parameters = null)
        {
            SqlMapper.GridReader reader = null;
            var _connection = Context.Connection;

            if (parameters == null)
            {
                using (var result = _connection.QueryMultiple(query, null, null, null, cmdType))
                {
                    reader = result;
                    var data1 = reader.Read<T1>().ToList();
                    var data2 = reader.Read<T2>().ToList();
                    return new Tuple<IEnumerable<T1>, IEnumerable<T2>>(data1, data2);
                }
            }
            else
            {
                using (var result = _connection.QueryMultiple(query, parameters, null, 1000000, cmdType))
                {
                    reader = result;
                    var data1 = reader.Read<T1>().ToList();
                    var data2 = reader.Read<T2>().ToList();
                    return new Tuple<IEnumerable<T1>, IEnumerable<T2>>(data1, data2);
                }
            }
        }

        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>> QueryMultiOutput<T1, T2, T3>(string query, System.Data.CommandType cmdType = System.Data.CommandType.StoredProcedure, OracleDynamicParameters parameters = null)
        {
            SqlMapper.GridReader reader = null;
            var _connection = Context.Connection;

            if (parameters == null)
            {
                using (var result = _connection.QueryMultiple(query, null, null, null, cmdType))
                {
                    reader = result;
                    var data1 = reader.Read<T1>().ToList();
                    var data2 = reader.Read<T2>().ToList();
                    var data3 = reader.Read<T3>().ToList();
                    return new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>>(data1, data2, data3);
                }
            }
            else
            {
                using (var result = _connection.QueryMultiple(query, parameters, null, 1000000, cmdType))
                {
                    reader = result;
                    var data1 = reader.Read<T1>().ToList();
                    var data2 = reader.Read<T2>().ToList();
                    var data3 = reader.Read<T3>().ToList();
                    return new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>>(data1, data2, data3);
                }
            }
        }


        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>> QueryWithMultiOutput<T1, T2, T3>(string query, Dictionary<string, OraParam> parameters = null)
        {
            Dapper.SqlMapper.GridReader reader = null;

            try
            {
                var _connection = Context.Connection;

                if (parameters == null)
                {
                    using (var result = _connection.QueryMultiple(query, null, null, null, CommandType.StoredProcedure))
                    {
                        reader = result;
                        var data1 = reader.Read<T1>().ToList();
                        var data2 = reader.Read<T2>().ToList();
                        var data3 = reader.Read<T3>().ToList();

                        _connection.Close();
                        return new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>>(data1, data2, data3);
                    }
                }
                else
                {
                    var ps = new OracleDynamicParameters();
                    foreach (var p in parameters)
                    {
                        ps.Add(p.Key, p.Value.Value, p.Value.OraType, p.Value.Direction);
                    }
                    using (var result = _connection.QueryMultiple(query, ps, null, 1000000, CommandType.StoredProcedure))
                    {

                        var data1 = result.Read<T1>().ToList();
                        var data2 = result.Read<T2>().ToList();
                        var data3 = result.Read<T3>().ToList();
                        _connection.Close();
                        return new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>>(data1, data2, data3);
                    }
                }
            }
            catch (Exception ex)
            {
                string exMessage = ex.Message;
                throw;
            }
        }

        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>> QueryWithMultiOutput<T1, T2, T3, T4, T5>(string query, Dictionary<string, OraParam> parameters = null)
        {
            Dapper.SqlMapper.GridReader reader = null;

            try
            {
                var _connection = Context.Connection;

                if (parameters == null)
                {
                    using (var result = _connection.QueryMultiple(query, null, null, null, CommandType.StoredProcedure))
                    {
                        reader = result;
                        var data1 = reader.Read<T1>().ToList();
                        var data2 = reader.Read<T2>().ToList();
                        var data3 = reader.Read<T3>().ToList();
                        var data4 = reader.Read<T4>().ToList();
                        var data5 = reader.Read<T5>().ToList();
                        _connection.Close();
                        return new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>>(data1, data2, data3, data4, data5);
                    }
                }
                else
                {
                    var ps = new OracleDynamicParameters();
                    foreach (var p in parameters)
                    {
                        ps.Add(p.Key, p.Value.Value, p.Value.OraType, p.Value.Direction);
                    }
                    using (var result = _connection.QueryMultiple(query, ps, null, 1000000, CommandType.StoredProcedure))
                    {

                        var data1 = result.Read<T1>().ToList();
                        var data2 = result.Read<T2>().ToList();
                        var data3 = result.Read<T3>().ToList();
                        var data4 = result.Read<T4>().ToList();
                        var data5 = result.Read<T5>().ToList();
                        _connection.Close();
                        return new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>>(data1, data2, data3, data4, data5);
                    }
                }
            }
            catch (Exception ex)
            {
                string exMessage = ex.Message;
                throw;
            }
        }

        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>> QueryWithMultiOutput<T1, T2, T3, T4, T5, T6>(string query, Dictionary<string, OraParam> parameters = null)
        {
            Dapper.SqlMapper.GridReader reader = null;
            var _connection = Context.Connection;

            if (parameters == null)
            {
                using (var result = _connection.QueryMultiple(query, null, null, null, CommandType.StoredProcedure))
                {
                    reader = result;
                    var data1 = reader.Read<T1>().ToList();
                    var data2 = reader.Read<T2>().ToList();
                    var data3 = reader.Read<T3>().ToList();
                    var data4 = reader.Read<T4>().ToList();
                    var data5 = reader.Read<T5>().ToList();
                    var data6 = reader.Read<T6>().ToList();
                    _connection.Close();
                    return new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>>(data1, data2, data3, data4, data5, data6);
                }
            }
            else
            {
                var ps = new OracleDynamicParameters();
                foreach (var p in parameters)
                {
                    ps.Add(p.Key, p.Value.Value, p.Value.OraType, p.Value.Direction);
                }
                using (var result = _connection.QueryMultiple(query, ps, null, 1000000, CommandType.StoredProcedure))
                {

                    var data1 = result.Read<T1>().ToList();
                    var data2 = result.Read<T2>().ToList();
                    var data3 = result.Read<T3>().ToList();
                    var data4 = result.Read<T4>().ToList();
                    var data5 = result.Read<T5>().ToList();
                    var data6 = result.Read<T6>().ToList();
                    _connection.Close();
                    return new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>>(data1, data2, data3, data4, data5, data6);
                }
            }

        }

        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>> QueryWithMultiOutput<T1, T2, T3, T4, T5, T6, T7>(string query, Dictionary<string, OraParam> parameters = null)
        {
            Dapper.SqlMapper.GridReader reader = null;
            var _connection = Context.Connection;

            try
            {
                if (parameters == null)
                {
                    using (var result = _connection.QueryMultiple(query, null, null, null, CommandType.StoredProcedure))
                    {
                        reader = result;
                        var data1 = reader.Read<T1>().ToList();
                        var data2 = reader.Read<T2>().ToList();
                        var data3 = reader.Read<T3>().ToList();
                        var data4 = reader.Read<T4>().ToList();
                        var data5 = reader.Read<T5>().ToList();
                        var data6 = reader.Read<T6>().ToList();
                        var data7 = reader.Read<T7>().ToList();
                        _connection.Close();
                        return new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>>(data1, data2, data3, data4, data5, data6, data7);
                    }
                }
                else
                {

                    var ps = new OracleDynamicParameters();
                    foreach (var p in parameters)
                    {
                        ps.Add(p.Key, p.Value.Value, p.Value.OraType, p.Value.Direction);
                    }
                    using (var result = _connection.QueryMultiple(query, ps, null, 1000000, CommandType.StoredProcedure))
                    {

                        var data1 = result.Read<T1>().ToList();
                        var data2 = result.Read<T2>().ToList();
                        var data3 = result.Read<T3>().ToList();
                        var data4 = result.Read<T4>().ToList();
                        var data5 = result.Read<T5>().ToList();
                        var data6 = result.Read<T6>().ToList();
                        var data7 = result.Read<T7>().ToList();
                        _connection.Close();
                        return new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>>(data1, data2, data3, data4, data5, data6, data7);
                    }
                }
            }
            catch (OracleException ex)
            {
                Console.WriteLine(parameters["P_REEL_TRANSFER_NO"].Value);
                throw;
            }
        }

        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>, Tuple<IEnumerable<T8>>> QueryWithMultiOutput<T1, T2, T3, T4, T5, T6, T7, T8>(string query, Dictionary<string, OraParam> parameters = null)
        {
            Dapper.SqlMapper.GridReader reader = null;
            var _connection = Context.Connection;

            if (parameters == null)
            {
                using (var result = _connection.QueryMultiple(query, null, null, null, CommandType.StoredProcedure))
                {
                    reader = result;
                    var data1 = reader.Read<T1>().ToList();
                    var data2 = reader.Read<T2>().ToList();
                    var data3 = reader.Read<T3>().ToList();
                    var data4 = reader.Read<T4>().ToList();
                    var data5 = reader.Read<T5>().ToList();
                    var data6 = reader.Read<T6>().ToList();
                    var data7 = reader.Read<T7>().ToList();
                    var data8 = new Tuple<IEnumerable<T8>>(result.Read<T8>().ToList());
                    _connection.Close();
                    return new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>, Tuple<IEnumerable<T8>>>(data1, data2, data3, data4, data5, data6, data7, data8);
                }
            }
            else
            {
                var ps = new OracleDynamicParameters();
                foreach (var p in parameters)
                {
                    ps.Add(p.Key, p.Value.Value, p.Value.OraType, p.Value.Direction);
                }
                using (var result = _connection.QueryMultiple(query, ps, null, 1000000, CommandType.StoredProcedure))
                {
                    var data1 = result.Read<T1>().ToList();
                    var data2 = result.Read<T2>().ToList();
                    var data3 = result.Read<T3>().ToList();
                    var data4 = result.Read<T4>().ToList();
                    var data5 = result.Read<T5>().ToList();
                    var data6 = result.Read<T6>().ToList();
                    var data7 = result.Read<T7>().ToList();
                    var data8 = new Tuple<IEnumerable<T8>>(result.Read<T8>().ToList());
                    _connection.Close();
                    return new Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>, Tuple<IEnumerable<T8>>>(data1, data2, data3, data4, data5, data6, data7, data8);
                }
            }
        }


        public int ExecuteQuery(string query, Dictionary<string, OraParam> parameters = null)
        {
            int result = 0;
            try
            {
                OracleDynamicParameters ps = null;
                if (parameters != null && parameters.Any())
                {
                    ps = new OracleDynamicParameters();
                    foreach (var p in parameters)
                    {
                        ps.Add(p.Key, p.Value.Value, p.Value.OraType, p.Value.Direction);
                    }
                }
                var _connection = Context.Connection;
                result = _connection.Query<int>(query, ps, null, true, null, System.Data.CommandType.StoredProcedure).Single();
                _connection.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }

        public Tuple<IEnumerable<T1>> QueryMultiOutput<T1>(string query, Dictionary<string, OraParam> parameters = null)
        {
            SqlMapper.GridReader reader = null;
            var _connection = Context.Connection;
            using (var scope = new TransactionScope())
            {
                try
                {
                    if (parameters == null)
                    {
                        using (var result = _connection.QueryMultiple(query, null, null, null, System.Data.CommandType.StoredProcedure))
                        {
                            reader = result;
                            var data1 = reader.Read<T1>().ToList();
                            scope.Complete();
                            return new Tuple<IEnumerable<T1>>(data1);
                        }
                    }
                    else
                    {
                        var ps = new OracleDynamicParameters();
                        foreach (var p in parameters)
                        {
                            ps.Add(p.Key, p.Value.Value, p.Value.OraType, p.Value.Direction);
                        }
                        using (var result = _connection.QueryMultiple(query, ps, null, 1000000, System.Data.CommandType.StoredProcedure))
                        {
                            reader = result;
                            var data1 = reader.Read<T1>().ToList();
                            scope.Complete();
                            return new Tuple<IEnumerable<T1>>(data1);
                        }
                    }
                }
                catch (Exception)
                {
                    _connection.BeginTransaction().Rollback();
                    return new Tuple<IEnumerable<T1>>(null);
                }
            }
        }

    }
}
