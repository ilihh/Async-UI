# Using async/await in Unity

Require Unity 2021.3.6f1

Type `t` is awaitable if one of the following holds:
- `t` is of compile-time type dynamic
- `t` has an accessible instance or extension method called `GetAwaiter` with no parameters and no type parameters, and a return type `A` for which all the following hold:
   - `A` implements the interface `System.Runtime.CompilerServices.INotifyCompletion`
   - `A` has an accessible, readable instance property `IsCompleted` of type `bool`
   - `A` has an accessible instance method `GetResult` with no parameters and no type parameters

[Async/Await specification](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/expressions#1188-await-expressions)

