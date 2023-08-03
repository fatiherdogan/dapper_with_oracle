using Dapper;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Example.Project.Repository.OracleParameter
{
    public class OracleDynamicParameters : Dapper.SqlMapper.IDynamicParameters
    {
        private static Dictionary<SqlMapper.Identity, Action<IDbCommand, object>> paramReaderCache = new Dictionary<SqlMapper.Identity, Action<IDbCommand, object>>();

        private Dictionary<string, ParamInfo> parameters = new Dictionary<string, ParamInfo>();
        private List<object> templates;

        private class ParamInfo
        {

            public string Name { get; set; }

            public object Value { get; set; }

            public ParameterDirection ParameterDirection { get; set; }

            public OracleDbType? DbType { get; set; }

            public int? Size { get; set; }

            public IDbDataParameter AttachedParam { get; set; }
        }

        public OracleDynamicParameters()
        {
        }

        public OracleDynamicParameters(object template)
        {
            AddDynamicParams(template);
        }

        public void AddDynamicParams(
#if CSHARP30
			object param
#else
 dynamic param
#endif
 )
        {
            var obj = param as object;
            if (obj != null)
            {
                var subDynamic = obj as OracleDynamicParameters;
                if (subDynamic == null)
                {
                    var dictionary = obj as IEnumerable<KeyValuePair<string, object>>;
                    if (dictionary == null)
                    {
                        templates = templates ?? new List<object>();
                        templates.Add(obj);
                    }
                    else
                    {
                        foreach (var kvp in dictionary)
                        {
#if CSHARP30
							Add(kvp.Key, kvp.Value, null, null, null);
#else
                            Add(kvp.Key, kvp.Value);
#endif
                        }
                    }
                }
                else
                {
                    if (subDynamic.parameters != null)
                    {
                        foreach (var kvp in subDynamic.parameters)
                        {
                            parameters.Add(kvp.Key, kvp.Value);
                        }
                    }

                    if (subDynamic.templates != null)
                    {
                        templates = templates ?? new List<object>();
                        foreach (var t in subDynamic.templates)
                        {
                            templates.Add(t);
                        }
                    }
                }
            }
        }

        public void Add(
#if CSHARP30
			string name, object value, DbType? dbType, ParameterDirection? direction, int? size
#else
 string name, object value = null, OracleDbType? dbType = null, ParameterDirection? direction = null, int? size = null
#endif
 )
        {
            parameters[Clean(name)] = new ParamInfo() { Name = name, Value = value, ParameterDirection = direction ?? ParameterDirection.Input, DbType = dbType, Size = size };
        }

        private static string Clean(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                switch (name[0])
                {
                    case '@':
                    case ':':
                    case '?':
                        return name.Substring(1);
                }
            }
            return name;
        }

        void SqlMapper.IDynamicParameters.AddParameters(IDbCommand command, SqlMapper.Identity identity)
        {
            AddParameters(command, identity);
        }

        protected void AddParameters(IDbCommand command, SqlMapper.Identity identity)
        {
            if (templates != null)
            {
                foreach (var template in templates)
                {
                    var newIdent = identity.ForDynamicParameters(template.GetType());
                    Action<IDbCommand, object> appender;

                    lock (paramReaderCache)
                    {
                        if (!paramReaderCache.TryGetValue(newIdent, out appender))
                        {
                            appender = SqlMapper.CreateParamInfoGenerator(newIdent, false, false);
                            paramReaderCache[newIdent] = appender;
                        }
                    }

                    appender(command, template);
                }
            }

            foreach (var param in parameters.Values)
            {
                string name = Clean(param.Name);
                bool add = !((OracleCommand)command).Parameters.Contains(name);
                Oracle.ManagedDataAccess.Client.OracleParameter p;
                if (add)
                {
                    p = ((OracleCommand)command).CreateParameter();
                    p.ParameterName = name;
                }
                else
                {
                    p = ((OracleCommand)command).Parameters[name];
                }
                var val = param.Value;
                p.Value = val ?? DBNull.Value;
                p.Direction = param.ParameterDirection;
                var s = val as string;
                if (s != null)
                {
                    if (s.Length <= 4000)
                    {
                        p.Size = 4000;
                    }
                }
                if (param.Size != null)
                {
                    p.Size = param.Size.Value;
                }
                if (param.DbType != null)
                {
                    p.OracleDbType = param.DbType.Value;
                }
                if (add)
                {
                    if (param.DbType != null && param.DbType == OracleDbType.RefCursor)
                    {
                        p.OracleDbType = OracleDbType.RefCursor;
                        ((OracleCommand)command).Parameters.Add(p);
                    }
                    else
                    {
                        ((OracleCommand)command).Parameters.Add(p);
                    }
                }
                param.AttachedParam = p;
            }
        }


        public IEnumerable<string> ParameterNames
        {
            get
            {
                return parameters.Select(p => p.Key);
            }
        }


        public T Get<T>(string name)
        {
            var val = parameters[Clean(name)].AttachedParam.Value;
            if (val == DBNull.Value)
            {
                if (default(T) != null)
                {
                    throw new ApplicationException("Attempting to cast a DBNull to a non nullable type!");
                }
                return default(T);
            }
            return (T)val;
        }
    }
}
