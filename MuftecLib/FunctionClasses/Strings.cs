using System;
using System.Collections.Generic;
using System.Text;

namespace MuftecLib.FunctionClasses
{
    public class Strings : IOpCode
    {
        /// <summary>
        /// strcat (str1 str2 -- str3)
        /// Concatenates the first two strings in the stack.
        /// </summary>
        /// <example>
        /// "Con" "cave" strcat ( returns ) "Concave"
        /// </example>
        /// <param name="RuntimeStack">Reference to the current execution stack</param>
        [OpCode("strcat")]
        public static void Concatenate(ref Stack<MuftecStackItem> RuntimeStack)
        {
            MuftecStackItem Item2 = Shared.Pop(ref RuntimeStack, MuftecType.String);
            MuftecStackItem Item1 = Shared.Pop(ref RuntimeStack, MuftecType.String);
            MuftecStackItem Result = new MuftecStackItem();

            Result.Type = MuftecType.String;
            Result.Item = String.Concat((string)Item1.Item,(string)Item2.Item);

            RuntimeStack.Push(Result);
        }

        /// <summary>
        /// strcmp (str1 str2 -- int1)
        /// Compares str1 and str2. Returns 1 if equal, 0 if not equal.
        /// </summary>
        /// <example>
        /// "Concave" "Spoon" strcmp ( returns ) 0
        /// </example>
        /// <param name="RuntimeStack">Reference to the current execution stack</param>
        [OpCode("strcmp")]
        public static void StringCompare(ref Stack<MuftecStackItem> RuntimeStack)
        {
            MuftecStackItem Item2 = Shared.Pop(ref RuntimeStack, MuftecType.String);
            MuftecStackItem Item1 = Shared.Pop(ref RuntimeStack, MuftecType.String);
            MuftecStackItem Result = new MuftecStackItem();

            Result.Item = ((string)Item1.Item == (string)Item2.Item);
            RuntimeStack.Push(Result);
        }

        /// <summary>
        /// strleft (str1 n1 -- str2)
        /// Returns the first n1 letters from string str1
        /// </summary>
        /// <example>
        /// "Concave" 2 strleft ( returns ) "Co"
        /// </example>
        /// <param name="RuntimeStack">Reference to the current execution stack</param>
        [OpCode("strleft")]
        public static void StrLeft(ref Stack<MuftecStackItem> RuntimeStack)
        {
            MuftecStackItem Item2 = Shared.Pop(ref RuntimeStack, MuftecType.Integer);
            MuftecStackItem Item1 = Shared.Pop(ref RuntimeStack, MuftecType.String);
            MuftecStackItem Result = new MuftecStackItem();

            Result.Type = MuftecType.String;
            Result.Item = ((string)Item1.Item).Substring(0, (int)Item2.Item);

            RuntimeStack.Push(Result);
        }

        /// <summary>
        /// strright (str1 n1 -- str2)
        /// Returns the last n1 letters from string str1
        /// </summary>
        /// <example>
        /// "Concave" 2 strright ( returns ) "ve"
        /// </example>
        /// <param name="RuntimeStack">Reference to the current execution stack</param>
        [OpCode("strright")]
        public static void StrRight(ref Stack<MuftecStackItem> RuntimeStack)
        {
            MuftecStackItem Item2 = Shared.Pop(ref RuntimeStack, MuftecType.Integer);
            MuftecStackItem Item1 = Shared.Pop(ref RuntimeStack, MuftecType.String);
            MuftecStackItem Result = new MuftecStackItem();
            string str1;
            int n1;

            Result.Type = MuftecType.String;
            str1 = (string)Item1.Item;
            n1 = (int)Item2.Item;
            Result.Item = str1.Substring(str1.Length - n1, n1);

            RuntimeStack.Push(Result);
        }

        /// <summary>
        /// strmid (str1 n1 n2 -- str2)
        /// Returns the letters between n1 and n2 from string str1
        /// </summary>
        /// <example>
        /// "Concave" 2 4 strleft ( returns ) "ncav"
        /// </example>
        /// <param name="RuntimeStack">Reference to the current execution stack</param>
        [OpCode("strmid")]
        public static void StrMid(ref Stack<MuftecStackItem> RuntimeStack)
        {
            MuftecStackItem Item3 = Shared.Pop(ref RuntimeStack, MuftecType.Integer);
            MuftecStackItem Item2 = Shared.Pop(ref RuntimeStack, MuftecType.Integer);
            MuftecStackItem Item1 = Shared.Pop(ref RuntimeStack, MuftecType.String);
            MuftecStackItem Result = new MuftecStackItem();

            Result.Type = MuftecType.String;
            Result.Item = ((string)Item1.Item).Substring((int)Item2.Item, (int)Item3.Item);

            RuntimeStack.Push(Result);
        }

        /// <summary>
        /// explode (str1 str2 -- str... ...str int1)
        /// Seperates str1 into int1 strings using delimeter str2
        /// </summary>
        /// <example>
        /// "feed,eat,drink" "," explode ( returns ) "drink" "eat" "feed" 3
        /// </example>
        /// <param name="RuntimeStack">Reference to the current execution stack</param>
        [OpCode("explode")]
        public static void Explode(ref Stack<MuftecStackItem> RuntimeStack)
        {
            MuftecStackItem Item2 = Shared.Pop(ref RuntimeStack, MuftecType.String);
            MuftecStackItem Item1 = Shared.Pop(ref RuntimeStack, MuftecType.String);
            MuftecStackItem Result = new MuftecStackItem();
            string[] Exploded = ((string)Item1.Item).Split((char)Item2.Item);

            Result.Type = MuftecType.Integer;
            Result.Item = Exploded.Length;
            RuntimeStack.Push(Result);

            foreach (string s in Exploded)
            {
                Result.Type = MuftecType.String;
                Result.Item = s;
                RuntimeStack.Push(Result);
            }
        }

        /// <summary>
        /// instr (str1 str2 -- int1)
        /// Returns the first occurrence of string str2 in string str1. 0 if not found.
        /// </summary>
        /// <example>
        /// "Concave" "v" instr ( returns ) 6
        /// </example>
        /// <param name="RuntimeStack">Reference to the current execution stack</param>
        [OpCode("instr")]
        public static void InStr(ref Stack<MuftecStackItem> RuntimeStack)
        {
            MuftecStackItem Item2 = Shared.Pop(ref RuntimeStack, MuftecType.String);
            MuftecStackItem Item1 = Shared.Pop(ref RuntimeStack, MuftecType.String);
            MuftecStackItem Result = new MuftecStackItem();

            Result.Type = MuftecType.Integer;
            Result.Item = ((string)Item1.Item).IndexOf((string)Item2.Item);
            RuntimeStack.Push(Result);
        }

        /// <summary>
        /// rinstr (str1 str2 -- int1)
        /// Returns the last occurrence of string str2 in string str1. 0 if not found.
        /// </summary>
        /// <example>
        /// "Concave" "v" rinstr ( returns ) 2
        /// </example>
        /// <param name="RuntimeStack">Reference to the current execution stack</param>
        [OpCode("rinstr")]
        public static void InStrReverse(ref Stack<MuftecStackItem> RuntimeStack)
        {
            MuftecStackItem Item2 = Shared.Pop(ref RuntimeStack, MuftecType.String);
            MuftecStackItem Item1 = Shared.Pop(ref RuntimeStack, MuftecType.String);
            MuftecStackItem Result = new MuftecStackItem();

            Result.Type = MuftecType.Integer;
            Result.Item = ((string)Item1.Item).LastIndexOf((string)Item2.Item);
            RuntimeStack.Push(Result);
        }

        /// <summary>
        /// split (str1 str2 -- str3 str4)
        /// Splits string str1 at first occurrence of str2.
        /// </summary>
        /// <example>
        /// "Concave" "a" split ( returns ) "Conc" "ve"
        /// </example>
        /// <param name="RuntimeStack">Reference to the current execution stack</param>
        [OpCode("split")]
        public static void Split(ref Stack<MuftecStackItem> RuntimeStack)
        {
            MuftecStackItem Item2 = Shared.Pop(ref RuntimeStack, MuftecType.String);
            MuftecStackItem Item1 = Shared.Pop(ref RuntimeStack, MuftecType.String);
            MuftecStackItem Result = new MuftecStackItem();
            string str1 = (string)Item1.Item;
            string str2 = (string)Item2.Item;
            int splitPos = str1.IndexOf(str2);

            Result.Type = MuftecType.String;
            Result.Item = str1.Substring(0,splitPos);
            RuntimeStack.Push(Result);

            Result.Type = MuftecType.String;
            Result.Item = str1.Substring(splitPos + 1);
            RuntimeStack.Push(Result);
        }

        /// <summary>
        /// rsplit (str1 str2 -- str3 str4)
        /// Splits string str1 at last occurrence of str2.
        /// </summary>
        /// <example>
        /// "Concave" "c" rsplit ( returns ) "Con" "ave"
        /// </example>
        /// <param name="RuntimeStack">Reference to the current execution stack</param>
        [OpCode("rsplit")]
        public static void SplitReverse(ref Stack<MuftecStackItem> RuntimeStack)
        {
            MuftecStackItem Item2 = Shared.Pop(ref RuntimeStack, MuftecType.String);
            MuftecStackItem Item1 = Shared.Pop(ref RuntimeStack, MuftecType.String);
            MuftecStackItem Result = new MuftecStackItem();
            string str1 = (string)Item1.Item;
            string str2 = (string)Item2.Item;
            int splitPos = str1.LastIndexOf(str2);

            Result.Type = MuftecType.String;
            Result.Item = str1.Substring(0, splitPos);
            RuntimeStack.Push(Result);

            Result.Type = MuftecType.String;
            Result.Item = str1.Substring(splitPos + 1);
            RuntimeStack.Push(Result);
        }

        /// <summary>
        /// strcut (str1 int1 -- str2 str3)
        /// Cuts str1 apart at after character int1.
        /// </summary>
        /// <example>
        /// "Concave" 4 strcut ( returns ) "Conc" "ave"
        /// </example>
        /// <param name="RuntimeStack">Reference to the current execution stack</param>
        [OpCode("strcut")]
        public static void StrCut(ref Stack<MuftecStackItem> RuntimeStack)
        {
            MuftecStackItem Item2 = Shared.Pop(ref RuntimeStack, MuftecType.Integer);
            MuftecStackItem Item1 = Shared.Pop(ref RuntimeStack, MuftecType.String);
            MuftecStackItem Result = new MuftecStackItem();
            string str1 = (string)Item1.Item;
            int splitPos = (int)Item2.Item;

            Result.Type = MuftecType.String;
            Result.Item = str1.Substring(0, splitPos);
            RuntimeStack.Push(Result);

            Result.Type = MuftecType.String;
            Result.Item = str1.Substring(splitPos);
            RuntimeStack.Push(Result);
        }

        /// <summary>
        /// strip (str1 -- str2)
        /// Erases leading and tailing whitespace.
        /// </summary>
        /// <example>
        /// " Concave  " strcut ( returns ) "Concave"
        /// </example>
        /// <param name="RuntimeStack">Reference to the current execution stack</param>
        [OpCode("strip")]
        public static void Strip(ref Stack<MuftecStackItem> RuntimeStack)
        {
            MuftecStackItem Item1 = Shared.Pop(ref RuntimeStack, MuftecType.String);
            MuftecStackItem Result = new MuftecStackItem();

            Result.Type = MuftecType.String;
            Result.Item = ((string)Item1.Item).Trim();
            RuntimeStack.Push(Result);
        }

        /// <summary>
        /// striplead (str1 -- str2)
        /// Erases leading whitespace.
        /// </summary>
        /// <example>
        /// " Concave  " striplead ( returns ) "Concave  "
        /// </example>
        /// <param name="RuntimeStack">Reference to the current execution stack</param>
        [OpCode("striplead")]
        public static void StripLeading(ref Stack<MuftecStackItem> RuntimeStack)
        {
            MuftecStackItem Item1 = Shared.Pop(ref RuntimeStack, MuftecType.String);
            MuftecStackItem Result = new MuftecStackItem();

            Result.Type = MuftecType.String;
            Result.Item = ((string)Item1.Item).TrimStart();
            RuntimeStack.Push(Result);
        }

        /// <summary>
        /// striptail (str1 -- str2)
        /// Erases tailing whitespace.
        /// </summary>
        /// <example>
        /// " Concave  " striptail ( returns ) " Concave"
        /// </example>
        /// <param name="RuntimeStack">Reference to the current execution stack</param>
        [OpCode("striptail")]
        public static void StripTailing(ref Stack<MuftecStackItem> RuntimeStack)
        {
            MuftecStackItem Item1 = Shared.Pop(ref RuntimeStack, MuftecType.String);
            MuftecStackItem Result = new MuftecStackItem();

            Result.Type = MuftecType.String;
            Result.Item = ((string)Item1.Item).TrimEnd();
            RuntimeStack.Push(Result);
        }

        /// <summary>
        /// strlen (str1 -- int1)
        /// Returns the length of the string.
        /// </summary>
        /// <example>
        /// "Concave" strlen ( returns ) 7
        /// </example>
        /// <param name="RuntimeStack">Reference to the current execution stack</param>
        [OpCode("strlen")]
        public static void StrLen(ref Stack<MuftecStackItem> RuntimeStack)
        {
            MuftecStackItem Item1 = Shared.Pop(ref RuntimeStack, MuftecType.String);
            MuftecStackItem Result = new MuftecStackItem();

            Result.Type = MuftecType.String;
            Result.Item = ((string)Item1.Item).Length;
            RuntimeStack.Push(Result);
        }

        /// <summary>
        /// toupper (str1 -- int1)
        /// Returns a string in all uppercase.
        /// </summary>
        /// <example>
        /// "Concave" toupper ( returns ) "CONCAVE"
        /// </example>
        /// <param name="RuntimeStack">Reference to the current execution stack</param>
        [OpCode("toupper")]
        public static void StrToUpper(ref Stack<MuftecStackItem> RuntimeStack)
        {
            MuftecStackItem Item1 = Shared.Pop(ref RuntimeStack, MuftecType.String);
            MuftecStackItem Result = new MuftecStackItem();

            Result.Type = MuftecType.String;
            Result.Item = ((string)Item1.Item).ToUpper();
            RuntimeStack.Push(Result);
        }

        /// <summary>
        /// tolower (str1 -- int1)
        /// Returns a string in all lowercase.
        /// </summary>
        /// <example>
        /// "ConCaVE" tolower ( returns ) "concave"
        /// </example>
        /// <param name="RuntimeStack">Reference to the current execution stack</param>
        [OpCode("tolower")]
        public static void StrToLower(ref Stack<MuftecStackItem> RuntimeStack)
        {
            MuftecStackItem Item1 = Shared.Pop(ref RuntimeStack, MuftecType.String);
            MuftecStackItem Result = new MuftecStackItem();

            Result.Type = MuftecType.String;
            Result.Item = ((string)Item1.Item).ToLower();
            RuntimeStack.Push(Result);
        }
    }
}
