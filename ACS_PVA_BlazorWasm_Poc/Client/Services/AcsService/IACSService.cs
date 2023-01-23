using ACS_PVA_BlazorWasm_Poc.Shared;

namespace ACS_PVA_BlazorWasm_Poc.Client.Services.AcsService
{
    public interface IACSService
    {
        Task<AcsIdentityToken?> GetUserIdWithToken();
    }
}
