# PortalAPI

A lightweight C# client library for interacting with Huron Portal WebServices APIs.

## Features

- Simple wrapper around Portal WebServices API endpoints
- Basic Authentication support
- JSON deserialization into strongly typed objects
- Compatible with:
  - .NET Standard 2.0
  - .NET 8.0+

## Installation

Install from NuGet:

```bash
dotnet add package BrandonPowers.PortalAPI
```

Or through the NuGet Package Manager:

```powershell
Install-Package BrandonPowers.PortalAPI
```

---

## Usage

### Example

```csharp
using PortalAPI;
using System;
using System.Text;

string domain = "example.huronportal.com";
string apiPath = "MyAPI";

string credential = Convert.ToBase64String(
    Encoding.UTF8.GetBytes("username:password")
);

HuronAPIData data = HuronAPI.GetAPIData(
    domain,
    apiPath,
    credential
);
```

---

## Authentication

PortalAPI uses HTTP Basic Authentication.

Credentials must be passed as a Base64-encoded string in the format:

```text
username:password
```

Example:

```csharp
string credential = Convert.ToBase64String(
    Encoding.UTF8.GetBytes("username:password")
);
```

---

## API Endpoint Format

PortalAPI automatically builds requests using the following format:

```text
https://{domain}/api/click/datamanagement/{apiPath}
```

Example:

```text
https://example.huronportal.com/api/click/datamanagement/MyAPI
```

---

## Requirements

- .NET Standard 2.0 or later
- .NET 8.0 or later

---

## Notes

This library is intended to simplify interactions with Huron Portal WebServices APIs.

This is an unofficial client library and is not affiliated with or endorsed by Huron.

---

## License

MIT License
