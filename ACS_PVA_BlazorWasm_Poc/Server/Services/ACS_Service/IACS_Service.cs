using ACS_PVA_BlazorWasm_Poc.Shared;

namespace ACS_PVA_BlazorWasm_Poc.Server.Services.ACS_Service
{
    public interface IACS_Service
    {
        Task<AcsIdentityToken> GetUserIdWithToken();
    }
}
