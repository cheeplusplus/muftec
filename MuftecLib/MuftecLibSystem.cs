using System;
using System.Collections.Generic;
using System.Reflection;

namespace MuftecLib
{
	public delegate void OpCodePointer(Stack<MuftecStackItem> stack);

	public class MuftecLibSystem
	{
	    private readonly Dictionary<string, OpCodePointer> _opcodeCache = new Dictionary<string, OpCodePointer>();
	    private readonly Dictionary<string, MuftecStackItem> _globalVariableList = new Dictionary<string, MuftecStackItem>();
		private List<Assembly> _libraryList = new List<Assembly>();
		
		/// <summary>
		/// Register special opcodes that must be handled from inside THIS class
		/// </summary>
		public MuftecLibSystem()
		{
			_opcodeCache.Add("@", ReadVariable);
			_opcodeCache.Add("!", SetVariable);
			_opcodeCache.Add("loadlibdll", LoadLibraryDLL);
		}

		[OpCode("!")]
		private void ReadVariable(Stack<MuftecStackItem> runtimeStack)
		{
			var item1 = Shared.Pop(runtimeStack);
			
            if (item1.Type == MuftecType.Variable)
			{
				if (_globalVariableList.ContainsKey(item1.Item.ToString()))
				{
					runtimeStack.Push(_globalVariableList[item1.Item.ToString()]);
				}
				else
				{
					throw new MuftecInvalidStackItemTypeException(runtimeStack);
				}
			}
			else
			{
				throw new MuftecInvalidStackItemTypeException(runtimeStack);
			}
		}

		[OpCode("@")]
		private void SetVariable(Stack<MuftecStackItem> runtimeStack)
		{
			var item1 = Shared.Pop(runtimeStack);
			var item2 = Shared.Pop(runtimeStack);
			
            if (item1.Type == MuftecType.Variable)
			{
				_globalVariableList.Add((string)item1.Item, item2);
			}
			else
			{
				throw new MuftecInvalidStackItemTypeException(runtimeStack);
			}
		}

		[OpCode("loadlibdll")]
		private void LoadLibraryDLL(Stack<MuftecStackItem> runtimeStack)
		{
			var item1 = Shared.Pop(runtimeStack);

			if (item1.Type == MuftecType.String)
			{
				AddLibrary((string)item1.Item);
			}
			else
			{
				throw new MuftecInvalidStackItemTypeException(runtimeStack);
			}
		}

		/// <summary>
		/// Add an external library DLL that inherits <see>IMuftecClassLibrary</see>
		/// </summary>
		/// <param name="path"></param>
		public void AddLibrary(string path)
		{
            AddLibrary(Assembly.LoadFile(path));
		}

		/// <summary>
		/// Add a library inherited from <see>IMuftecClassLibrary</see>
		/// </summary>
        /// <param name="classLibrary">Class containing opcodes</param>
        public void AddLibrary(IMuftecClassLibrary classLibrary)
		{
            var classAssembly = classLibrary.GetType().Assembly;
            AddLibrary(classAssembly);
        }

        /// <summary>
        /// Add an assembly containing classes inheriting <see>IMuftecClassLibraryCollection</see>
        /// </summary>
        /// <param name="classAssembly"></param>
        public void AddLibrary(Assembly classAssembly)
        {
            foreach (var classModule in classAssembly.GetModules())
			{
				Console.WriteLine("Module: " + classModule);

                foreach (var info in classModule.GetMethods())
			    {
					Console.WriteLine("Method: " + info);

				    var codes = (OpCodeAttribute[])info.GetCustomAttributes(typeof(OpCodeAttribute), false);
				    if (codes.Length > 0)
				    {
				        var opc = (OpCodePointer)Delegate.CreateDelegate(typeof(OpCodePointer), info);
				        _opcodeCache.Add(codes[0].OpCodeName, opc);
				    }
			    }
			}
		}

		public void ExecOpCode(string opCode, Stack<MuftecStackItem> runtimeStack)
		{
			if (!_opcodeCache.ContainsKey(opCode))
			{
				throw new MuftecGeneralException(runtimeStack);
			}

            if (Shared.IsDebug())
            {
                // TODO: Perform a mini stack trace like MUF flag DEBUG
            }

		    // Handle exception catching inside the language here
		    _opcodeCache[opCode].Invoke(runtimeStack);
		}

		public void Run(ref Queue<MuftecStackItem> execStack, Stack<MuftecStackItem> runtimeStack)
		{
		    while (execStack.Count > 0)
			{
			    var currStackItem = execStack.Dequeue();

			    if (currStackItem.Type == MuftecType.OpCode)
				{
					ExecOpCode(currStackItem.Item.ToString(), runtimeStack);
				}
				else
				{
					runtimeStack.Push(currStackItem);
				}
			}
		}
	}
}