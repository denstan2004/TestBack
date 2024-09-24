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

    // Конструктор приймає рядок підключення
    public UserRepository()
    {
        _connectionString = "Server=DENNI-PC;Database=model;Trusted_Connection=True;";
    }

    // Метод для отримання імен з таблиці Users
    // Метод для отримання імен з таблиці Users
    public IEnumerable<User> GetUserNames()
    {
        // Запит SQL для вибірки імен
        string query = "SELECT Id,Name,DateOfBirth as BirthDay , Married,Phone,Salary  FROM [dbo].[Users]"; // Додано квадратні дужки

        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            var userNames = connection.Query<User>(query).ToList();
            return userNames;
        }

    }
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime BirthDay { get; set; }
    public bool Married { get; set; }
    public string Phone { get; set; }
    public decimal Salary { get; set; }
    public void UpdateUser(User user)
    {
        string query = @"UPDATE [dbo].[Users]
SET [Name] = @Name, 
    [DateOfBirth] = @BirthDay, 
    [Married] = @Married, 
    [Phone] = @Phone, 
    [Salary] = @Salary
WHERE [Id] = @Id"; // Added SET keyword

        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            var userNames = connection.Execute(query, new { user.Name, user.BirthDay, user.Married, user.Phone, user.Salary, user.Id });
        }
    }


}
