# dotnet-apps 

- This is a playground for .NET and ASP.NET projects

- When talking about .NET development, it's important to understand the difference between, .NET, CLR(Common Language Runtime), and C#

- CLR:(This is the crucial component of.NET ecosystem)
It’s the execution environment for all .NET programs
Manage memory allocation and deallocation(garbage collection)
Ensure type safety and security 
Handle exception management 
All .NET languages are compiled into Intermediate Language(IL), which the CLR then executes. 

- C# is the primary language used in .NET
OOP
Syntax similar to C-style language(C++, Java)
Continually evolving 

- .NET supports multiple languages even if C# is the most popular:
VB.NET(OOP of vision basic)
F#  a functional-first programming language

- NuGet
Package manager for .NET
Allow developers  to share and consume libraries 
Simplifies dependency management in .NET projects

- Blazor: 
For building web UIs, single-page application 

### about collections

Use IEnumerable<T> for looping

Use ICollection<T> if you need .Count

Use IList<T> if you need indexing like [i]

Use List<T> only if you're creating/modifying a list➜
"WebApplication.CreateBuilder(args) is a built-in method from ASP.NET Core that gives us a pre-configured builder for web apps. The builder object lets us add services (like databases, authentication, etc.) using its Services collection. The args parameter lets us pass in configuration (like environment or settings) when the app is launched. Once we’ve added everything we need, we call Build() to create the actual app, and then Run() to start it and begin handling requests."
