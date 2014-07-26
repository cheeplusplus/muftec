using System;
using System.Collections.Generic;
using Muftec.BCL.FunctionClasses;
using Muftec.Lib;
using Math = Muftec.BCL.FunctionClasses.Math;

namespace Muftec.BCL
{
    /// <summary>
    /// Descriptor class for the Muftec BCL.
    /// </summary>
    public class MuftecBaseClassLibrary : IMuftecClassLibrary
    {
        public string ClassLibraryName { get { return "Muftec Base Class Library"; } }

        public List<Type> Classes { get { return _classes; } }

        private readonly List<Type> _classes = new List<Type>
            {
                typeof(Arrays),
                typeof(Conversion),
                typeof(Float),
                typeof(InputOutput),
                typeof(Logic),
                typeof(Math),
                typeof(StackOperations),
                typeof(Strings)
            };

        public Dictionary<string, string> Defines { get { return _defines; } }

        private readonly Dictionary<string, string> _defines = new Dictionary<string, string>
        {
            // Array defines
            {"SORTTYPE_CASEINSENS", "1"},
            {"SORTTYPE_DESCENDING", "2"},
            {"SORTTYPE_SHUFFLE", "4"},
            {"SORTTYPE_CASE_ASCEND", "0"},
            {"SORTTYPE_NOCASE_ASCEND", "SORTTYPE_CASEINSENS"},
            {"SORTTYPE_CASE_DESCEND", "SORTTYPE_DESCENDING"},
            {"SORTTYPE_NOCASE_DESCEND", "SORTTYPE_CASEINSENS SORTTYPE_DESCENDING +"},
            {"}list", "} array_make"},
            {"}dict", "} 2 / array_make_dict"},
            {"}print", "} array_make array_print"},
            {"}join", "} array_make \"\" array_join"},
            {"}cat", "} array_make array_interpret"},
            {"array_intersect", "2 array_nintersect"},
            {"array_interpret", "\" \" array_join"}
        };
    }
}
