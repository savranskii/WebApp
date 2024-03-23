using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;
using WebApp.UI.Models;

namespace WebApp.UI.Components;

public partial class UserDialog
{
    [Parameter]
    public UserDto Content { get; set; } = default!;

    [CascadingParameter]
    public FluentDialog? Dialog { get; set; }

    private async Task SaveAsync()
    {
        try
        {
            var content = new StringContent(JsonSerializer.Serialize(Content), Encoding.UTF8, "application/json");
            var isSuccess = Content.Id is null
                ? await CreateUserAsync(content)
                : await UpdateUserAsync(content);

            if (isSuccess)
            {
                ToastService.ShowSuccess("User saved.");
                await Dialog!.CloseAsync(Content);
            }
            else ToastService.ShowError($"Error occured.");
        }
        catch (Exception ex)
        {
            ToastService.ShowError($"Error occured. {ex.Message}");
        }
    }

    private async Task<bool> CreateUserAsync(StringContent content)
    {
        using var response = await HttpClient.PostAsync("/api/v1/users", content);
        return response.IsSuccessStatusCode;
    }

    private async Task<bool> UpdateUserAsync(StringContent content)
    {
        using var response = await HttpClient.PutAsync("/api/v1/users", content);
        return response.IsSuccessStatusCode;
    }

    private async Task CancelAsync()
    {
        await Dialog!.CancelAsync();
    }
}
