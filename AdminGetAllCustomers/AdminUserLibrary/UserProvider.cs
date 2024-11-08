﻿using AdminUserLibrary.ViewModels;
using System.Net.Http.Json;

namespace AdminUserLibrary;

public class UserProvider : IUserProvider
{
    private readonly HttpClient _httpClient;

    public UserProvider(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<CustomerViewModel>> GetAllCustomersAsync()
    {
        try
        {
            var users = await _httpClient.GetFromJsonAsync<List<CustomerViewModel>>("api/Customer/GetCustomers");
            return users ?? new List<CustomerViewModel>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return new List<CustomerViewModel>();
        }
    }
    public async Task<List<AdminViewModel>> GetAllAdminsAsync()
    {
        try
        {
            var users = await _httpClient.GetFromJsonAsync<List<AdminViewModel>>("api/Admin/GetAdmins");
            return users ?? new List<AdminViewModel>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return new List<AdminViewModel>();
        }
    }
}