# assessment

This project covers the ReadyForDispatchApp

The function handles the the incoming POST request and allows it to handle any roputing, security requests and retries.

The app as it stands does not contain all functionality, considerations below.

I went with the Function App to handle the incoming requests as it can run serverless and doesnt require an environment to be maintained. 
Now, depending on the other APIs in use within the software envoirnment this approach could be changed as either the API standalone within its own VM, handling the routing, security etc separatly. This would be if IaaS is the model of development being used.

I went this way to lessen the overhead of operating VMs.

## Considerations

The function app currently has not auth but additons wopuld be made to enhance the authenication to ensure security is mantained - this could be with ŌAuth 2.0 in using Azure or using the same security patterns as other internal/external apis
