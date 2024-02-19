using Dapper;
using Microsoft.Data.Sqlite;
using System.Data;

namespace EM.Repositories;

public abstract class Repo<TEntity> where TEntity : class
{
    private readonly string _databasePath;
    public IDbConnection Connection() => new SqliteConnection($"Data Source={_databasePath}");


    public Repo(string databasePath)
    {
        _databasePath = databasePath;
        DatabaseEnsureCreated();
    }

    private void DatabaseEnsureCreated()
    {
        using var connection = Connection();

        var createTables =
        @" 
            CREATE TABLE IF NOT EXISTS Categories(
                CategoryId INTEGER PRIMARY KEY,
                CategoryName TEXT
            );

            CREATE TABLE IF NOT EXISTS Product(
                ArticleNumber TEXT PRIMARY KEY,
                Title TEXT,
                CategoryId INTEGER,
                FOREIGN KET(CategoryId) REFERENCES CategoryId(Id)
            );
        ";

        connection.Execute(createTables);
    }

    public virtual async Task<TEntity> CreateAsync(string query, object param = null)
    {
        try
        {
            using var connection = Connection();
            await connection.ExecuteAsync(query, param);
            return await connection.QueryFirstOrDefaultAsync<TEntity>("SELECT last_insert_rowid()");
        }
        catch (Exception ex) { }
        return null;
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync(string query, object param = null)
    {
        try
        {
            using var connection = Connection();
            return await connection.QueryAsync<TEntity>(query, param);
        }
        catch (Exception ex) { }
        return null;
    }

    public virtual async Task<TEntity> GetAsync(string query, object param = null)
    {
        try
        {
            using var connection = Connection();
            return await connection.QueryFirstOrDefaultAsync(query, param);
        }
        catch (Exception ex) { }
        return null;
    }
}
