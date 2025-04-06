using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SlangNet.ComWrappers;


public static partial class Slang
{
    [LibraryImport("slang", EntryPoint = "slang_createGlobalSession")]
    public static partial void CreateGlobalSession(long apiVersion, out IGlobalSession globalSession);
}

