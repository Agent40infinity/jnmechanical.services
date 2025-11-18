using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace jnmechanical.services.Components
{
    public static class Navigation
    {
        public static bool visited = false;

        public const int duration = 1000;
        public const int transition = 500;

        public static async Task NavigateTo(NavigationManager navManager, IJSRuntime js, string page)
        {
            page = StringCorrection(page);

            await js.InvokeVoidAsync("FadeOut", transition);
            await Task.Delay(transition);
            navManager.NavigateTo(page);
            await js.InvokeVoidAsync("FadeIn", transition);
        }

        private static string StringCorrection(string title)
        {
            return title.Replace(' ', '-');
        }
    }
}
