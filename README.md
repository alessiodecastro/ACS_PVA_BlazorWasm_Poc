# Welcome to Demo App ACS - Virtual Agent!

This is a demo app with several number of missing feature implementations. Before to run please add into the project "ACS_PVA_BlazorWasm_Poc.Server" file "appsettings.json" the connection string for Azure Communication Services:

    "AzureCommunicationServices": {
        "ConnectionString": "endpoint=https://..."
      }

And in the "ACS_PVA_BlazorWasm_Poc.Client" project the file "./scripts/webChat/app-webchat.js" where at line #10 there is the endpoint token url for the virtual agent:

     const res = await fetch('https://...', { method: 'GET' });
     const { token } = await res.json();
