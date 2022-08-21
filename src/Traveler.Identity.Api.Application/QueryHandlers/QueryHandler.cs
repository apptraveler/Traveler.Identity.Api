using System.Data;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Traveler.Identity.Api.Infra.CrossCutting.Environments.Configurations;
using Microsoft.Data.Sqlite;
using Traveler.Identity.Api.Application.Queries;

namespace Traveler.Identity.Api.Application.QueryHandlers;

public abstract class QueryHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : Query<TResponse>
{
    private readonly IDbConnection _dbConnection;

    protected QueryHandler(ApplicationConfiguration applicationConfiguration)
    {
        _dbConnection = new SqliteConnection(applicationConfiguration.ConnectionString);
    }

    protected IDbConnection GetDatabaseConnection()
    {
        if (_dbConnection.State == ConnectionState.Closed)
        {
            _dbConnection.Open();
        }

        return _dbConnection;
    }

    protected void CloseDatabaseConnection()
    {
        if (_dbConnection.State == ConnectionState.Open || _dbConnection.State == ConnectionState.Broken)
        {
            _dbConnection.Close();
        }
    }

    public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
}
