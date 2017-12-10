# Regulations.Gov.Client

This is a client to access documents from the Regulations.gov API.

## Quickstart

First, sign up for a [Data.gov API key](https://api.data.gov/signup/).

Add the `Regulations.Gov.Client` package to your project:

```bash
dotnet add package Regulations.Gov.Client
```

Then use it to query for regulations documents. For example, all public submissions (comments) on ["Review of Certain National Monuments Established Since 1996; Notice of Opportunity for Public Comment"](https://www.regulations.gov/document?D=DOI-2017-0002-0001)

```csharp
var client = new Regulations.Gov.Client.RegulationsGovClient();
var query = new DocumentsQuery
{
    DocketId = "DOI-2017-0002",
    Type = DocumentType.PublicSubmission,
    ResultsPerPage = 1000,
};
var pageOfResults = await _client.GetDocuments(query);
```

## Building

[![Travis](https://img.shields.io/travis/thzinc/Regulations.Gov.Client.svg)](https://travis-ci.org/thzinc/Regulations.Gov.Client)
[![NuGet](https://img.shields.io/nuget/v/Regulations.Gov.Client.svg)](https://www.nuget.org/packages/Regulations.Gov.Client/)

Ensure you have [installed .NET Core](https://www.microsoft.com/net/core)

To build a local/development cop, run the following:

```bash
dotnet restore
dotnet build
```

To run the tests:

```bash
dotnet test
```

## Code of Conduct

We are committed to fostering an open and welcoming environment. Please read our [code of conduct](CODE_OF_CONDUCT.md) before participating in or contributing to this project.

## Contributing

We welcome contributions and collaboration on this project. Please read our [contributor's guide](CONTRIBUTING.md) to understand how best to work with us.

## License and Authors

[![Daniel James logo](https://secure.gravatar.com/avatar/eaeac922b9f3cc9fd18cb9629b9e79f6.png?size=16) Daniel James](https://github.com/thzinc)

[![license](https://img.shields.io/github/license/thzinc/Regulations.Gov.Client.svg)](https://github.com/thzinc/Regulations.Gov.Client/blob/master/LICENSE)
[![GitHub contributors](https://img.shields.io/github/contributors/thzinc/Regulations.Gov.Client.svg)](https://github.com/thzinc/Regulations.Gov.Client/graphs/contributors)

This software is made available by Daniel James under the MIT license.