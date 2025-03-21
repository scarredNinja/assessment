
# Read For Dispatch Integration

This repo covers the projects to run the Ready For Dispatch API

It is broken up into three parts:

-> Function App
-> ASP .Net Core API
-> Tests

I have added an Activity Flow diagram to show the basic flow of the dispatch process.

I ran out of time to draw up UML Class Diagrams - these were hand drawn.

## Considerations

In terms of deploymnet, I would look at using Azure DevOps pipelines tied to the GitHub (or DevOps) repo to build and then release.

Release managment could also be handled by an external tool like Octopus etc if that is the standard.

the azure-pipeline.yaml is not complete and woudl need to be updated.
