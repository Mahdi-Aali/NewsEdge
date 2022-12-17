using Microsoft.AspNetCore.Components.Authorization;

namespace NewsEdge.Utilities.Blazor.Authentication;

public static class UserAuthenticationState
{
    public static async Task<string> GetUserNameAsync(this Task<AuthenticationState> authenticationState)
    {
        var auth = await authenticationState;
        return auth.User?.Identity?.Name;
    }
}
