using System.Text.Json;
using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;
using WebApp.Domain.UserAggregate.Entities;
using WebApp.UI.Components;
using WebApp.UI.Models;

namespace WebApp.UI.Pages;
public partial class Home
{
    [Inject]
    protected IMapper Mapper { get; set; } = default!;

    private bool isLoading = true;
    private IQueryable<User> users = new List<User>().AsQueryable();
    private readonly GridSort<User> sortByName = GridSort<User>.ByAscending(p => p.Name.LastName).ThenAscending(p => p.Name.FirstName);

    protected override async Task OnInitializedAsync()
    {
        await LoadDataAsync();
    }

    private async Task LoadDataAsync()
    {
        try
        {
            using var response = await HttpClient.GetAsync("/api/v1/users");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                users = (JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>()).AsQueryable();
                isLoading = false;
            }
            else ToastService.ShowError("Error occured.");
        }
        catch (Exception ex)
        {
            ToastService.ShowError($"Error occured. {ex.Message}");
        }
    }

    private async Task CreateAsync()
    {
        var dialog = await DialogService.ShowDialogAsync<UserDialog>(
            new UserDto(),
            GetDialogParamiters("Create new user"));

        var result = await dialog.Result;
        if (result is not null)
            await LoadDataAsync();
    }

    private async Task EditAsync(long id)
    {
        var user = users.Single(u => u.Id == id);
        var dialog = await DialogService.ShowDialogAsync<UserDialog>(
            Mapper.Map<UserDto>(user),
            GetDialogParamiters($"Updating the user {user?.Id}"));

        var result = await dialog.Result;
        if (result is not null)
            await LoadDataAsync();
    }

    private async Task DeleteAsync(long id)
    {
        try
        {
            using var response = await HttpClient.DeleteAsync($"/api/v1/users/{id}");
            if (response.IsSuccessStatusCode)
            {
                users = users.Where(u => u.Id != id);
            }
            else ToastService.ShowError("Error occured.");
        }
        catch (Exception ex)
        {
            ToastService.ShowError($"Error occured. {ex.Message}");
        }
    }

    private static DialogParameters GetDialogParamiters(string title) => new()
    {
        Height = "400px",
        Title = title,
        PreventDismissOnOverlayClick = true,
        PreventScroll = true,
    };
}
