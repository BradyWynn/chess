# How to setup vscode and build project

- Step 1. Install VSCode
  - Download and install Visual Studio Code from [here](https://code.visualstudio.com/Download)

- Step 2. Install .NET Core SDK
  - Download and install .NET Core SDK from [here](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
  - It's version 7.0, but if you installed 6.0 - it should work too

- Step 3. Install C# extension
  - Open up extensions and install *ms-dotnettools.csharp* extension
  ![image](https://i.ibb.co/XJZJxbs/Screenshot-from-2023-07-24-00-22-44.png)

- Step 4. Open folder in VSCode
  - File > Open Folder. Open the folder where Chess-Challenge.csproj file is located.
  ![image](https://i.ibb.co/jWR953w/Screenshot-from-2023-07-24-01-01-39.png)

- Step 6. Start code using F5
  - Press F5 to start debugging the project. Vscode should automaticly generate .vscode. **Enjoy coding!**

# FAQ
- Can't find Raylib
  - execute this in your cmd `dotnet add package Raylib-cs`
    - Make sure that you are at the directory that was set at step 4
