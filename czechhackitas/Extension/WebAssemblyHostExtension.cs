using Microsoft.JSInterop;
using System.Globalization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace czechhackitas.Extension
{
    public class WebAssemblyHostExtension
    {
        private const string DefaultCulture = "en-US";
        private const string BlazorCultureGetFunction = "blazorCulture.get";
        public static async Task SetDefaultCulture(WebAssemblyHost host)
        {
            var jsInterop = host.Services.GetRequiredService<IJSRuntime>();
            var result = await jsInterop.InvokeAsync<string>(BlazorCultureGetFunction);

            CultureInfo culture;
            if (!string.IsNullOrWhiteSpace(result))
                culture = new CultureInfo(result);
            else
                culture = new CultureInfo(DefaultCulture);
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
        }
    }
}
