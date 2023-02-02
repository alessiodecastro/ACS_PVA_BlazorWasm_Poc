using ACS_PVA_BlazorWasm_Poc.Server.Data;
using ACS_PVA_BlazorWasm_Poc.Shared;
using Microsoft.EntityFrameworkCore;
using Azure.Communication.Identity;
using Microsoft.AspNetCore.Server.IIS.Core;
using static ACS_PVA_BlazorWasm_Poc.Shared.AcsIdentityToken;

namespace ACS_PVA_BlazorWasm_Poc.Server.Services.ACS_Service
{
    public class ACS_Service : IACS_Service
    {
        private readonly IConfiguration _configuration;
        
        public ACS_Service(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new Exception();
        }

        public async Task<AcsIdentityToken> GetUserIdWithToken()
        {
            string? connectionString = _configuration.GetValue<string>("AzureCommunicationServices:ConnectionString");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString));  
            }

            var client = new CommunicationIdentityClient(connectionString);
            var identityResponse = await client.CreateUserAsync();
            var identity = identityResponse.Value;
            
            var tokenResponse = await client.GetTokenAsync(identity, scopes: new[] { CommunicationTokenScope.VoIP, CommunicationTokenScope.Chat });

            return new AcsIdentityToken
            {
                User = new UserIdentity
                {
                    UserId = identity.Id
                },
                Token = new AccessToken
                {
                    Token = tokenResponse.Value.Token,
                    ExpiresOn = tokenResponse.Value.ExpiresOn.Date
                },
                CallId = "31fbdc99-0d76-42ef-aafa-15684d199717" //just for testing mock //Guid.NewGuid().ToString(), 
            };
        }
    }
}
