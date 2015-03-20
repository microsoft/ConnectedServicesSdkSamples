# ConnectedServices-ProviderAuthorSamples
======================================

This repository contains everything you need to get started building a Connected Services extension.

The respository is made up of 3 top-level directories:

* **docs**.  Contains a [walk-through] to get you started building your own extension
  and [API documentation] to explain what extensibility points are available.

* **Externals**.  Contains the latest Connected Services binaries that you can reference, and the
  latest VSIX installers for both the Connected Services core and the Salesforce extension.

* **src**.  Contains several sample providers for the 3 UI Templates (SinglePage, Grid & Wizard) as well as Design Time Auth and Handlers for adding files to your project.  You can use these to jumpstart your
  development, or as a reference.

[walk-through]: https://github.com/Microsoft/ConnectedServices-ProviderAuthorSamples/blob/master/docs/Creating%20a%20Connected%20Service%20Extension.docx
[API documentation]: https://github.com/Microsoft/ConnectedServices-ProviderAuthorSamples/blob/master/docs/Connected%20Services%20Extensibility%20API%20Contracts.docx

## Getting Started

To get started, ensure you have [Visual Studio 2015 RC] and the [Visual Studio 2015 SDK] installed.  Also, ensure you have
installed the [latest Connected Services VSIX]**.  From there, you can start by reading the walk-through document to get
started building your extension.

[Visual Studio 2015 RC]: http://www.visualstudio.com/en-us/downloads/visual-studio-2015-downloads-vs
[Visual Studio 2015 SDK]: http://www.microsoft.com/en-us/download/details.aspx?id=44932
[latest Connected Services VSIX]: https://github.com/Microsoft/ConnectedServices-ProviderAuthorSamples/blob/master/Externals/Microsoft.VisualStudio.ConnectedServices.vsix

\*\* *Please note:* Since you will be using the latest Connected Services bits, you will encounter the following issues:

1. The Azure and Office 365 Connected Services no longer work.
2. If you receive the error *The 'Visual Studio Component Model Host Package' package did not load correctly.* 
the first time loading Visual Studio after installing this extension follow these steps:

  * Close all instances of Visual Studio
  * Delete the following directory: %LocalAppData%\Microsoft\VisualStudio\14.0\ComponentModelCache
  * Open Visual Studio again
