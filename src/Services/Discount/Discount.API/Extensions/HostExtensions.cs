using System.Data;
using Npgsql;

namespace Discount.API.Extensions;

public static class HostExtensions
{
    public static IHost MigrateDatabase<TContext>(this IHost host, int? retry = 0)
{
    if (retry == null) return host;

    using (var scope = host.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var logger = services.GetRequiredService<ILogger<TContext>>();
        var connection = services.GetRequiredService<IDbConnection>();

        for (int retryAttempt = 0; retryAttempt < retry.Value; retryAttempt++)
        {
            try
            {
                logger.LogInformation("Migrating PostgreSQL database");

                ExecuteDatabaseMigration(connection);

                logger.LogInformation("Migrated PostgreSQL database");

                return host;
            }
            catch (NpgsqlException ex)
            {
                logger.LogError(ex, "An error occurred while migrating the PostgreSQL database");

                Thread.Sleep(2000); // This could be a configuration-based value
            }
        }
    }

    return host;
}

private static void ExecuteDatabaseMigration(IDbConnection connection)
{
    connection.Open();

    using var command = connection.CreateCommand();
    command.Connection = connection;

    command.CommandText = "DROP TABLE IF EXISTS Coupon";
    command.ExecuteNonQuery();

    command.CommandText = @"CREATE TABLE Coupon(Id SERIAL PRIMARY KEY, 
                                                ProductName VARCHAR(24) NOT NULL,
                                                Description TEXT,
                                                Amount INT)";

    command.ExecuteNonQuery();

    command.CommandText = "INSERT INTO Coupon(ProductName, Description, Amount) VALUES('IPhone X', 'IPhone Discount', 150);";
    command.ExecuteNonQuery();

    command.CommandText = "INSERT INTO Coupon(ProductName, Description, Amount) VALUES('Samsung 10', 'Samsung Discount', 100);";
    command.ExecuteNonQuery();
}
}