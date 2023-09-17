# LinkClip
LinkClip is a free tool to shorten URLs and generate short links .
## Built Using
 * ![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white) <br/>
 * ![MicrosoftSQLServer](https://img.shields.io/badge/Microsoft%20SQL%20Server-CC2927?style=for-the-badge&logo=microsoft%20sql%20server&logoColor=white) <br/>
 * ![Bootstrap](https://img.shields.io/badge/bootstrap-%238511FA.svg?style=for-the-badge&logo=bootstrap&logoColor=white) 

## Installation
* Open the project in Visual Studio <br/>
* store your Sql Server database address in LinkClip.Web => appsetting.json => ConnectionStrings => LinkClipConnection

```
"ConnectionStrings": {
  "LinkClipConnection": "Data Source=.;Initial Catalog=LinkClipDb;Integrated Security=True;TrustServerCertificate=True"
}
```
* Build & Start The App . Migrations will be performed automatically .

