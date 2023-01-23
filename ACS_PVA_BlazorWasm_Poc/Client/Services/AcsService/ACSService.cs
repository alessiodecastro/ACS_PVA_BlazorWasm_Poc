using ACS_PVA_BlazorWasm_Poc.Shared;
using Microsoft.AspNetCore.Components;
using System.Net;
using System.Net.Http.Json;

namespace ACS_PVA_BlazorWasm_Poc.Client.Services.AcsService
{
    public class ACSService : IACSService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManger;

        public ACSService(HttpClient http, NavigationManager navigationManger)
        {
            _http = http;
            _navigationManger = navigationManger;
        }

        public async Task<AcsIdentityToken?> GetUserIdWithToken()
        {
            var result = await _http.GetAsync($"api/acs");
            if (result.StatusCode == HttpStatusCode.OK)
            {
                return await result.Content.ReadFromJsonAsync<AcsIdentityToken>();
            }
            return null;
        }

    }
}
