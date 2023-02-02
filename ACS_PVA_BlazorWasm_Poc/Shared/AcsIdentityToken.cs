using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS_PVA_BlazorWasm_Poc.Shared
{
    public class AcsIdentityToken
    {
        public UserIdentity User { get; set; }
        public AccessToken Token { get; set; }
        public string CallId { get; set; }

        public class UserIdentity
        {
            public string UserId { get; set; }
        }

        public class AccessToken
        {
            public string Token { get; set; }
            public DateTime ExpiresOn { get; set; }
        }
    }
}
