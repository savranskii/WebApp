using System.Text.Json;
using Microsoft.FluentUI.AspNetCore.Components;
using WebApp.Domain.PlayerAggregate.Entities;
using WebApp.UI.Components;
using WebApp.UI.Models;

namespace WebApp.UI.Pages;
public partial class Home
{
    private bool isLoading = true;
    private IQueryable<Player> players = new List<Player>().AsQueryable();
    private readonly GridSort<Player> sortByName = GridSort<Player>.ByAscending(p => p.Name.LastName).ThenAscending(p => p.Name.FirstName);

    protected override async Task OnInitializedAsync()
    {
        await LoadDataAsync();
    }

    private async Task LoadDataAsync()
    {
        try
        {
            using var response = await HttpClient.GetAsync("/api/v1/players");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                players = (JsonSerializer.Deserialize<List<Player>>(json) ?? new List<Player>()).AsQueryable();
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
        var dialog = await DialogService.ShowDialogAsync<PlayerDialog>(
            new PlayerDto(),
            GetDialogParamiters("Create new player"));

        var result = await dialog.Result;
        if (result is not null)
            await LoadDataAsync();
    }

    private async Task EditAsync(long id)
    {
        var player = players.Single(u => u.Id == id);
        var dialog = await DialogService.ShowDialogAsync<PlayerDialog>(new PlayerDto
        {
            Id = player.Id,
            Email = player.Email,
            FirstName = player.Name.FirstName,
            LastName = player.Name.LastName,
            Street = player.Address.Street,
            City = player.Address.City,
            Country = player.Address.Country,
            ZipCode = player.Address.ZipCode
        }, GetDialogParamiters($"Updating the player {player?.Id}"));

        var result = await dialog.Result;
        if (result is not null)
            await LoadDataAsync();
    }

    private async Task DeleteAsync(long id)
    {
        try
        {
            using var response = await HttpClient.DeleteAsync($"/api/v1/players/{id}");
            if (response.IsSuccessStatusCode)
            {
                players = players.Where(u => u.Id != id);
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
