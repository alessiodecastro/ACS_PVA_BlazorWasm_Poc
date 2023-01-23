using ACS_PVA_BlazorWasm_Poc.Server.Services.ACS_Service;
using ACS_PVA_BlazorWasm_Poc.Shared;
using Microsoft.AspNetCore.Mvc;

namespace ACS_PVA_BlazorWasm_Poc.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcsController : ControllerBase
    {
        private readonly IACS_Service _acsService;

        public AcsController(IACS_Service acsService)
        {
            _acsService = acsService;
        }

        [HttpGet]
        public async Task<AcsIdentityToken> GetToken()
        {
            return await _acsService.GetUserIdWithToken();
        }

    }
}
