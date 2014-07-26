using System;
using System.Collections.Generic;

namespace Muftec.Lib
{
    public interface IMuftecClassLibrary
    {
        string ClassLibraryName { get; }
        List<Type> Classes { get; }
        Dictionary<string, string> Defines { get; }
    }
}
