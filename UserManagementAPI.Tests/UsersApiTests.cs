using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using UserManagementAPI.Models;
using Xunit;

namespace UserManagementAPI.Tests;

public class UsersApiTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public UsersApiTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
        _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "techhive-secret-token");
    }

    [Fact]
    public async Task CreateUser_WithInvalidEmail_ReturnsBadRequest()
    {
        var response = await _client.PostAsJsonAsync("/api/users", new User
        {
            Name = "Alice",
            Email = "not-an-email",
            Department = "HR"
        });

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task GetUser_WithMissingId_ReturnsNotFound()
    {
        var response = await _client.GetAsync("/api/users/9999");

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
}
