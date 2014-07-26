using System;
using System.Collections.Generic;
using Muftec.Lib;

namespace Muftec.BCL.FunctionClasses
{
    public static class Strings
    {
        /// <summary>
        /// strcat (str1 str2 -- str3)
        /// Concatenates the first two strings in the stack.
        /// </summary>
        /// <example>
        /// "Con" "cave" strcat ( returns ) "Concave"
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("strcat")]
        public static void Concatenate(OpCodeData data)
        {
            var item2 = data.RuntimeStack.PopStr();
            var item1 = data.RuntimeStack.PopStr();

            data.RuntimeStack.Push(String.Concat(item1, item2));
        }

        /// <summary>
        /// strcmp (str1 str2 -- int1)
        /// Compares str1 and str2, case sensitive. Returns 1 if equal, 0 if not equal.
        /// </summary>
        /// <example>
        /// "Concave" "conCaVE" strcmp ( returns ) 0
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("strcmp")]
        public static void StringCompare(OpCodeData data)
        {
            var item2 = data.RuntimeStack.PopStr();
            var item1 = data.RuntimeStack.PopStr();

            data.RuntimeStack.Push(item1 == item2);
        }

        /// <summary>
        /// strcmpi (str1 str2 -- int1)
        /// Compares str1 and str2, case insensitive. Returns 1 if equal, 0 if not equal.
        /// </summary>
        /// <example>
        /// "Concave" "conCaVE" strcmpi ( returns ) 1
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("strcmpi")]
        public static void StringCompareI(OpCodeData data)
        {
            var item2 = data.RuntimeStack.PopStr();
            var item1 = data.RuntimeStack.PopStr();

            data.RuntimeStack.Push(item1.ToLower() == item2.ToLower());
        }

        /// <summary>
        /// subst (str1 str2 str3 -- str4)
        /// Replaces str3 with str2 in str1
        /// </summary>
        /// <example>
        /// "TEST_A_B_C" " " "_" subst ( returns ) "TEST A B C"
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("subst")]
        public static void Substitute(OpCodeData data)
        {
            var item3 = data.RuntimeStack.PopStr();
            var item2 = data.RuntimeStack.PopStr();
            var item1 = data.RuntimeStack.PopStr();

            data.RuntimeStack.Push(item1.Replace(item3, item2));
        }

        /// <summary>
        /// strleft (str1 n1 -- str2)
        /// Returns the first n1 letters from string str1
        /// </summary>
        /// <example>
        /// "Concave" 2 strleft ( returns ) "Co"
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("strleft")]
        public static void StrLeft(OpCodeData data)
        {
            var item2 = data.RuntimeStack.PopInt();
            var item1 = data.RuntimeStack.PopStr();

            data.RuntimeStack.Push(item1.Substring(0, item2));
        }

        /// <summary>
        /// strright (str1 n1 -- str2)
        /// Returns the last n1 letters from string str1
        /// </summary>
        /// <example>
        /// "Concave" 2 strright ( returns ) "ve"
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("strright")]
        public static void StrRight(OpCodeData data)
        {
            var item2 = data.RuntimeStack.PopInt();
            var item1 = data.RuntimeStack.PopStr();

            data.RuntimeStack.Push(item1.Substring(item1.Length - item2, item2));
        }

        /// <summary>
        /// midstr (str1 n1 n2 -- str2)
        /// Returns the letters starting at n1 for n2 characters from string str1
        /// </summary>
        /// <example>
        /// "Concave" 3 4 midstr ( returns ) "ncav"
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("midstr")]
        public static void StrMid(OpCodeData data)
        {
            var item3 = data.RuntimeStack.PopInt();
            var item2 = data.RuntimeStack.PopInt();
            var item1 = data.RuntimeStack.PopStr();

            data.RuntimeStack.Push(item1.Substring(item2 + 1, item3));
        }

        /// <summary>
        /// explode (str1 str2 -- str... ...str int1)
        /// Seperates str1 into int1 strings using delimeter str2
        /// </summary>
        /// <example>
        /// "feed,eat,drink" "," explode ( returns ) "drink" "eat" "feed" 3
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("explode")]
        public static void Explode(OpCodeData data)
        {
            var item2 = data.RuntimeStack.PopStr();
            var item1 = data.RuntimeStack.PopStr();
            var exploded = item1.Split(new[] { item2 }, StringSplitOptions.None);

            data.RuntimeStack.Push(exploded.Length);

            foreach (var s in exploded)
            {
                data.RuntimeStack.Push(s);
            }
        }

        /// <summary>
        /// instr (str1 str2 -- int1)
        /// Returns the first occurrence of string str2 in string str1. -1 if not found.
        /// </summary>
        /// <example>
        /// "Concave" "v" instr ( returns ) 6
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("instr")]
        public static void InStr(OpCodeData data)
        {
            var item2 = data.RuntimeStack.PopStr();
            var item1 = data.RuntimeStack.PopStr();

            data.RuntimeStack.Push(item1.IndexOf(item2));
        }

        /// <summary>
        /// rinstr (str1 str2 -- int1)
        /// Returns the last occurrence of string str2 in string str1. -1 if not found.
        /// </summary>
        /// <example>
        /// "Concave" "v" rinstr ( returns ) 2
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("rinstr")]
        public static void InStrReverse(OpCodeData data)
        {
            var item2 = data.RuntimeStack.PopStr();
            var item1 = data.RuntimeStack.PopStr();

            data.RuntimeStack.Push(item1.LastIndexOf(item2));
        }

        /// <summary>
        /// split (str1 str2 -- str3 str4)
        /// Splits string str1 at first occurrence of str2.
        /// </summary>
        /// <example>
        /// "Concave" "a" split ( returns ) "Conc" "ve"
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("split")]
        public static void Split(OpCodeData data)
        {
            var item2 = data.RuntimeStack.PopStr();
            var item1 = data.RuntimeStack.PopStr();

            var splitPos = item1.IndexOf(item2);

            data.RuntimeStack.Push(item1.Substring(0, splitPos));
            data.RuntimeStack.Push(item1.Substring(splitPos));
        }

        /// <summary>
        /// rsplit (str1 str2 -- str3 str4)
        /// Splits string str1 at last occurrence of str2.
        /// </summary>
        /// <example>
        /// "Concave" "c" rsplit ( returns ) "Con" "ave"
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("rsplit")]
        public static void SplitReverse(OpCodeData data)
        {
            var item2 = data.RuntimeStack.PopStr();
            var item1 = data.RuntimeStack.PopStr();

            int splitPos = item1.LastIndexOf(item2);

            data.RuntimeStack.Push(item1.Substring(0, splitPos));
            data.RuntimeStack.Push(item1.Substring(splitPos));
        }

        /// <summary>
        /// strcut (str1 int1 -- str2 str3)
        /// Cuts str1 apart at after character int1.
        /// </summary>
        /// <example>
        /// "Concave" 4 strcut ( returns ) "Conc" "ave"
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("strcut")]
        public static void StrCut(OpCodeData data)
        {
            var item2 = data.RuntimeStack.PopInt();
            var item1 = data.RuntimeStack.PopStr();

            data.RuntimeStack.Push(item1.Substring(0, item2));
            data.RuntimeStack.Push(item1.Substring(item2));
        }

        /// <summary>
        /// strip (str1 -- str2)
        /// Erases leading and tailing whitespace.
        /// </summary>
        /// <example>
        /// " Concave  " strcut ( returns ) "Concave"
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("strip")]
        public static void Strip(OpCodeData data)
        {
            var item1 = data.RuntimeStack.PopStr();
            data.RuntimeStack.Push(item1.Trim());
        }

        /// <summary>
        /// striplead (str1 -- str2)
        /// Erases leading whitespace.
        /// </summary>
        /// <example>
        /// " Concave  " striplead ( returns ) "Concave  "
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("striplead")]
        public static void StripLeading(OpCodeData data)
        {
            var item1 = data.RuntimeStack.PopStr();
            data.RuntimeStack.Push(item1.TrimStart());
        }

        /// <summary>
        /// striptail (str1 -- str2)
        /// Erases tailing whitespace.
        /// </summary>
        /// <example>
        /// " Concave  " striptail ( returns ) " Concave"
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("striptail")]
        public static void StripTailing(OpCodeData data)
        {
            var item1 = data.RuntimeStack.PopStr();
            data.RuntimeStack.Push(item1.TrimEnd());
        }

        /// <summary>
        /// strlen (str1 -- int1)
        /// Returns the length of the string.
        /// </summary>
        /// <example>
        /// "Concave" strlen ( returns ) 7
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("strlen")]
        public static void StrLen(OpCodeData data)
        {
            var item1 = data.RuntimeStack.PopStr();
            data.RuntimeStack.Push(item1.Length);
        }

        /// <summary>
        /// toupper (str1 -- int1)
        /// Returns a string in all uppercase.
        /// </summary>
        /// <example>
        /// "Concave" toupper ( returns ) "CONCAVE"
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("toupper")]
        public static void StrToUpper(OpCodeData data)
        {
            var item1 = data.RuntimeStack.PopStr();
            data.RuntimeStack.Push(item1.ToUpper());
        }

        /// <summary>
        /// tolower (str1 -- int1)
        /// Returns a string in all lowercase.
        /// </summary>
        /// <example>
        /// "ConCaVE" tolower ( returns ) "concave"
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("tolower")]
        public static void StrToLower(OpCodeData data)
        {
            var item1 = data.RuntimeStack.PopStr();
            data.RuntimeStack.Push(item1.ToLower());
        }
    }
}
