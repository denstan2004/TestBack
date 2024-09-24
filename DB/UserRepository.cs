using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Dapper;
using TEST_APP.Models;

public class UserRepository
{
    private readonly string _connectionString;

    public UserRepository()
    {
        _connectionString = "Server=DENNI-PC;Database=model;Trusted_Connection=True;";
    }


    public IEnumerable<User> GetUserNames()
    {
        string query = "SELECT Id,Name,DateOfBirth as BirthDay , Married,Phone,Salary  FROM [dbo].[Users]"; 

        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            var userNames = connection.Query<User>(query).ToList();
            return userNames;
        }

    }

     public void UpdateUser(User user)
    { 
                    string query = @"UPDATE [dbo].[Users]
            SET [Name] = @Name, 
                [DateOfBirth] = @BirthDay, 
                [Married] = @Married, 
                [Phone] = @Phone, 
                [Salary] = @Salary
            WHERE [Id] = @Id";  

        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            var userNames = connection.Execute(query, new { user.Name, user.BirthDay, user.Married, user.Phone, user.Salary, user.Id });
        }
    }
    public void DeleteUser(User user)
    {
        string query = @"DELETE FROM [dbo].[Users] WHERE [Id] = @Id";

        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            var userNames = connection.Execute(query, new {  user.Id });
        }
    }

}
