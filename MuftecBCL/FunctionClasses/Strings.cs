using System;
using System.Collections.Generic;
using MuftecLib;

namespace MuftecBCL.FunctionClasses
{
	public class Strings : IMuftecGroup
	{
		/// <summary>
		/// strcat (str1 str2 -- str3)
		/// Concatenates the first two strings in the stack.
		/// </summary>
		/// <example>
		/// "Con" "cave" strcat ( returns ) "Concave"
		/// </example>
		/// <param name="runtimeStack">Reference to the current execution stack</param>
		[OpCode("strcat")]
		public static void Concatenate(Stack<MuftecStackItem> runtimeStack)
		{
			var item2 = Shared.PopStr(runtimeStack);
			var item1 = Shared.PopStr(runtimeStack);

			runtimeStack.Push(new MuftecStackItem(String.Concat(item1, item2)));
		}

		/// <summary>
		/// strcmp (str1 str2 -- int1)
		/// Compares str1 and str2, case sensitive. Returns 1 if equal, 0 if not equal.
		/// </summary>
		/// <example>
		/// "Concave" "conCaVE" strcmp ( returns ) 0
		/// </example>
		/// <param name="runtimeStack">Reference to the current execution stack</param>
		[OpCode("strcmp")]
		public static void StringCompare(Stack<MuftecStackItem> runtimeStack)
		{
			var item2 = Shared.PopStr(runtimeStack);
			var item1 = Shared.PopStr(runtimeStack);

			runtimeStack.Push(new MuftecStackItem(item1 == item2));
		}

		/// <summary>
		/// strcmpi (str1 str2 -- int1)
		/// Compares str1 and str2, case insensitive. Returns 1 if equal, 0 if not equal.
		/// </summary>
		/// <example>
		/// "Concave" "conCaVE" strcmpi ( returns ) 1
		/// </example>
		/// <param name="runtimeStack">Reference to the current execution stack</param>
		[OpCode("strcmpi")]
		public static void StringCompareI(Stack<MuftecStackItem> runtimeStack)
		{
			var item2 = Shared.PopStr(runtimeStack);
			var item1 = Shared.PopStr(runtimeStack);

			runtimeStack.Push(new MuftecStackItem(item1.ToLower() == item2.ToLower()));
		}

		/// <summary>
		/// subst (str1 str2 str3 -- str4)
		/// Replaces str3 with str2 in str1
		/// </summary>
		/// <example>
		/// "TEST_A_B_C" " " "_" subst ( returns ) "TEST A B C"
		/// </example>
		/// <param name="runtimeStack">Reference to the current execution stack</param>
		[OpCode("subst")]
		public static void Substitute(Stack<MuftecStackItem> runtimeStack)
		{
			var item3 = Shared.PopStr(runtimeStack);
			var item2 = Shared.PopStr(runtimeStack);
			var item1 = Shared.PopStr(runtimeStack);

			runtimeStack.Push(new MuftecStackItem(item1.Replace(item3, item2)));
		}

		/// <summary>
		/// strleft (str1 n1 -- str2)
		/// Returns the first n1 letters from string str1
		/// </summary>
		/// <example>
		/// "Concave" 2 strleft ( returns ) "Co"
		/// </example>
		/// <param name="runtimeStack">Reference to the current execution stack</param>
		[OpCode("strcut")]
		public static void StrLeft(Stack<MuftecStackItem> runtimeStack)
		{
			var item2 = Shared.PopInt(runtimeStack);
			var item1 = Shared.PopStr(runtimeStack);

			runtimeStack.Push(new MuftecStackItem(item1.Substring(0, item2)));
		}

		/// <summary>
		/// strright (str1 n1 -- str2)
		/// Returns the last n1 letters from string str1
		/// </summary>
		/// <example>
		/// "Concave" 2 strright ( returns ) "ve"
		/// </example>
		/// <param name="runtimeStack">Reference to the current execution stack</param>
		[OpCode("strright")]
		public static void StrRight(Stack<MuftecStackItem> runtimeStack)
		{
			var item2 = Shared.PopInt(runtimeStack);
			var item1 = Shared.PopStr(runtimeStack);

			runtimeStack.Push(new MuftecStackItem(item1.Substring(item1.Length - item2, item2)));
		}

		/// <summary>
		/// midstr (str1 n1 n2 -- str2)
		/// Returns the letters starting at n1 for n2 characters from string str1
		/// </summary>
		/// <example>
		/// "Concave" 3 4 midstr ( returns ) "ncav"
		/// </example>
		/// <param name="runtimeStack">Reference to the current execution stack</param>
		[OpCode("midstr")]
		public static void StrMid(Stack<MuftecStackItem> runtimeStack)
		{
			var item3 = Shared.PopInt(runtimeStack);
			var item2 = Shared.PopInt(runtimeStack);
			var item1 = Shared.PopStr(runtimeStack);

			runtimeStack.Push(new MuftecStackItem(item1.Substring(item2 + 1, item3)));
		}

		/// <summary>
		/// explode (str1 str2 -- str... ...str int1)
		/// Seperates str1 into int1 strings using delimeter str2
		/// </summary>
		/// <example>
		/// "feed,eat,drink" "," explode ( returns ) "drink" "eat" "feed" 3
		/// </example>
		/// <param name="runtimeStack">Reference to the current execution stack</param>
		[OpCode("explode")]
		public static void Explode(Stack<MuftecStackItem> runtimeStack)
		{
			var item2 = Shared.PopStr(runtimeStack);
			var item1 = Shared.PopStr(runtimeStack);
			var exploded = item1.Split(new[] { item2 }, StringSplitOptions.None);

			runtimeStack.Push(new MuftecStackItem(exploded.Length));

			foreach (var s in exploded)
			{
				runtimeStack.Push(new MuftecStackItem(s));
			}
		}

		/// <summary>
		/// instr (str1 str2 -- int1)
		/// Returns the first occurrence of string str2 in string str1. -1 if not found.
		/// </summary>
		/// <example>
		/// "Concave" "v" instr ( returns ) 6
		/// </example>
		/// <param name="runtimeStack">Reference to the current execution stack</param>
		[OpCode("instr")]
		public static void InStr(Stack<MuftecStackItem> runtimeStack)
		{
			var item2 = Shared.PopStr(runtimeStack);
			var item1 = Shared.PopStr(runtimeStack);

			runtimeStack.Push(new MuftecStackItem(item1.IndexOf(item2)));
		}

		/// <summary>
		/// rinstr (str1 str2 -- int1)
		/// Returns the last occurrence of string str2 in string str1. -1 if not found.
		/// </summary>
		/// <example>
		/// "Concave" "v" rinstr ( returns ) 2
		/// </example>
		/// <param name="runtimeStack">Reference to the current execution stack</param>
		[OpCode("rinstr")]
		public static void InStrReverse(Stack<MuftecStackItem> runtimeStack)
		{
			var item2 = Shared.PopStr(runtimeStack);
			var item1 = Shared.PopStr(runtimeStack);

			runtimeStack.Push(new MuftecStackItem(item1.LastIndexOf(item2)));
		}

		/// <summary>
		/// split (str1 str2 -- str3 str4)
		/// Splits string str1 at first occurrence of str2.
		/// </summary>
		/// <example>
		/// "Concave" "a" split ( returns ) "Conc" "ve"
		/// </example>
		/// <param name="runtimeStack">Reference to the current execution stack</param>
		[OpCode("split")]
		public static void Split(Stack<MuftecStackItem> runtimeStack)
		{
			var item2 = Shared.PopStr(runtimeStack);
			var item1 = Shared.PopStr(runtimeStack);

			var splitPos = item1.IndexOf(item2);

            runtimeStack.Push(new MuftecStackItem(item1.Substring(0, splitPos)));
            runtimeStack.Push(new MuftecStackItem(item1.Substring(splitPos)));
		}

		/// <summary>
		/// rsplit (str1 str2 -- str3 str4)
		/// Splits string str1 at last occurrence of str2.
		/// </summary>
		/// <example>
		/// "Concave" "c" rsplit ( returns ) "Con" "ave"
		/// </example>
		/// <param name="runtimeStack">Reference to the current execution stack</param>
		[OpCode("rsplit")]
		public static void SplitReverse(Stack<MuftecStackItem> runtimeStack)
		{
			var item2 = Shared.PopStr(runtimeStack);
			var item1 = Shared.PopStr(runtimeStack);

            int splitPos = item1.LastIndexOf(item2);

            runtimeStack.Push(new MuftecStackItem(item1.Substring(0, splitPos)));
            runtimeStack.Push(new MuftecStackItem(item1.Substring(splitPos)));
		}

		/// <summary>
		/// strcut (str1 int1 -- str2 str3)
		/// Cuts str1 apart at after character int1.
		/// </summary>
		/// <example>
		/// "Concave" 4 strcut ( returns ) "Conc" "ave"
		/// </example>
		/// <param name="runtimeStack">Reference to the current execution stack</param>
		[OpCode("strcut")]
		public static void StrCut(Stack<MuftecStackItem> runtimeStack)
		{
			var item2 = Shared.PopInt(runtimeStack);
			var item1 = Shared.PopStr(runtimeStack);

            runtimeStack.Push(new MuftecStackItem(item1.Substring(0, item2)));
            runtimeStack.Push(new MuftecStackItem(item1.Substring(item2)));
		}

		/// <summary>
		/// strip (str1 -- str2)
		/// Erases leading and tailing whitespace.
		/// </summary>
		/// <example>
		/// " Concave  " strcut ( returns ) "Concave"
		/// </example>
		/// <param name="runtimeStack">Reference to the current execution stack</param>
		[OpCode("strip")]
		public static void Strip(Stack<MuftecStackItem> runtimeStack)
		{
			var item1 = Shared.PopStr(runtimeStack);
			runtimeStack.Push(new MuftecStackItem(item1.Trim()));
		}

		/// <summary>
		/// striplead (str1 -- str2)
		/// Erases leading whitespace.
		/// </summary>
		/// <example>
		/// " Concave  " striplead ( returns ) "Concave  "
		/// </example>
		/// <param name="runtimeStack">Reference to the current execution stack</param>
		[OpCode("striplead")]
		public static void StripLeading(Stack<MuftecStackItem> runtimeStack)
		{
			var item1 = Shared.PopStr(runtimeStack);
			runtimeStack.Push(new MuftecStackItem(item1.TrimStart()));
		}

		/// <summary>
		/// striptail (str1 -- str2)
		/// Erases tailing whitespace.
		/// </summary>
		/// <example>
		/// " Concave  " striptail ( returns ) " Concave"
		/// </example>
		/// <param name="runtimeStack">Reference to the current execution stack</param>
		[OpCode("striptail")]
		public static void StripTailing(Stack<MuftecStackItem> runtimeStack)
		{
			var item1 = Shared.PopStr(runtimeStack);
			runtimeStack.Push(new MuftecStackItem(item1.TrimEnd()));
		}

		/// <summary>
		/// strlen (str1 -- int1)
		/// Returns the length of the string.
		/// </summary>
		/// <example>
		/// "Concave" strlen ( returns ) 7
		/// </example>
		/// <param name="runtimeStack">Reference to the current execution stack</param>
		[OpCode("strlen")]
		public static void StrLen(Stack<MuftecStackItem> runtimeStack)
		{
			var item1 = Shared.PopStr(runtimeStack);
			runtimeStack.Push(new MuftecStackItem(item1.Length));
		}

		/// <summary>
		/// toupper (str1 -- int1)
		/// Returns a string in all uppercase.
		/// </summary>
		/// <example>
		/// "Concave" toupper ( returns ) "CONCAVE"
		/// </example>
		/// <param name="runtimeStack">Reference to the current execution stack</param>
		[OpCode("toupper")]
		public static void StrToUpper(Stack<MuftecStackItem> runtimeStack)
		{
			var item1 = Shared.PopStr(runtimeStack);
			runtimeStack.Push(new MuftecStackItem(item1.ToUpper()));
		}

		/// <summary>
		/// tolower (str1 -- int1)
		/// Returns a string in all lowercase.
		/// </summary>
		/// <example>
		/// "ConCaVE" tolower ( returns ) "concave"
		/// </example>
		/// <param name="runtimeStack">Reference to the current execution stack</param>
		[OpCode("tolower")]
		public static void StrToLower(Stack<MuftecStackItem> runtimeStack)
		{
			var item1 = Shared.PopStr(runtimeStack);
			runtimeStack.Push(new MuftecStackItem(item1.ToLower()));
		}
	}
}
