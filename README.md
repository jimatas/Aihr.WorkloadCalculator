AIHR Coding Assignment - Workload Calculator
==

This project implements a fictitious microservice for a workload calculator. It’s a complete solution, from a backend database to a frontend web UI, although it takes quite a few shortcuts to achieve this. The focus was primarily on modeling the domain and its logic.

The Visual Studio solution consists of three .NET 6.0 projects, one of which contains (a minimal set of) unit tests.

What would constitute the domain and infrastructure layers are both located in the `Aihr.WorkloadCalculator` project for convenience. An application layer, which would be typical in this setup, was omitted to save time. The frontend, located in the `Aihr.WorkloadCalculator.UI` project, references the domain and uses its model and services directly. Normally the frontend would not take a direct dependency on the domain but instead would communicate with the application or use-case layer through something like a web API.

Since developing a frontend is not my area of expertise, I’ve opted for the easiest technology to hack one together: ASP.NET Razor Pages. There is no attempt at styling other than some basic markup and out-of-the-box bootstrap styles.

Another shortcut is the use of a local in-memory cache as the backing database, although it is abstracted behind a repository interface. The calculation results, which as part of the assignment had to be stored in a database, are therefore not truly persistent.

Altogether there’s quite some room for improvement but it would require more time.

### Running the application

In Visual Studio set `Aihr.WorkloadCalculator.UI` as the startup project and hit F5 (or Ctrl + F5).

Alternatively, run the project from source code using the `dotnet run` command.
