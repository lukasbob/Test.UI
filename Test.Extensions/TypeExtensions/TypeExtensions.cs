using System;
using System.Collections.Generic;

namespace Test.Extensions.TypeExtensions
{

	public static class TypeExtensions
	{
		private static readonly List<string> NumericTypes = new List<string> {
			typeof(Byte).ToString(),
			typeof(SByte).ToString(),			
			typeof(Int16).ToString(),
			typeof(UInt16).ToString(),
			typeof(Int32).ToString(),
			typeof(UInt32).ToString(),
			typeof(Int64).ToString(),
			typeof(UInt64).ToString(),
			typeof(Single).ToString(),
			typeof(Double).ToString(),
			typeof(Decimal).ToString()
		};

		public static bool IsNumeric(this Type type) { return NumericTypes.Contains(type.ToString()); }
	}

}
