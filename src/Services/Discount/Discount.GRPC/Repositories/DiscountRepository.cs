using System.Data;
using Dapper;
using Discount.GRPC.Entities;

namespace Discount.GRPC.Repositories;

public class DiscountRepository : IDiscountRepository
{
    private readonly IDbConnection _dbConnection;

    public DiscountRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<Coupon> GetDiscount(string productName)
    {
        var coupon = await _dbConnection.QueryFirstOrDefaultAsync<Coupon>
            ("SELECT * FROM Coupon WHERE ProductName = @ProductName", new { ProductName = productName });
        
        return coupon ?? new Coupon { ProductName = "No Discount", Amount = 0, Description = "No Discount Desc" };
    }

    public async Task<bool> CreateDiscount(Coupon coupon)
    {
        var affected = await _dbConnection.ExecuteAsync
            ("INSERT INTO Coupon (ProductName, Description, Amount) VALUES (@ProductName, @Description, @Amount)",
                new { ProductName = coupon.ProductName, Description = coupon.Description, Amount = coupon.Amount });
        
        return affected != 0;
    }

    public async Task<bool> UpdateDiscount(Coupon coupon)
    {
        var affected = await _dbConnection.ExecuteAsync
            ("UPDATE Coupon SET ProductName = @ProductName, Description = @Description, Amount = @Amount WHERE Id = @Id",
                new { ProductName = coupon.ProductName, Description = coupon.Description, Amount = coupon.Amount, Id = coupon.Id });
        
        return affected != 0;
    }

    public async Task<bool> DeleteDiscount(string productName)
    {
        var affected = await _dbConnection.ExecuteAsync
            ("DELETE FROM Coupon WHERE ProductName = @ProductName", new { ProductName = productName });
        
        return affected != 0;
    }
}