using System.Data;

namespace Example.Project.Repository.Context
{
    public interface IexampleContext : IDisposable
    {
        IDbConnection Connection { get; }
    }
}
