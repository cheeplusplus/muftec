using System;
using MuftecLib;

namespace MuftecBCL
{
	[MuftecClassLibrary("Muftec Base Class Library")]
	public class MuftecBaseClassLibrary : IMuftecClassLibrary
	{
		public string ClassLibraryName { get { return "Muftec Base Class Library"; } }
	}
}
