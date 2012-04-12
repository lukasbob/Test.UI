using System;
namespace Test.Extensions.StringExtensions {
	public static class StringExtensions {
		/// <summary>
		/// Determines whether the specified input string is null or empty.
		/// </summary>
		/// <param name="inputString">The input string.</param>
		/// <returns>
		///   <c>true</c> if the specified input string is null or empty; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsNullOrEmpty(this string inputString) {
			return string.IsNullOrEmpty(inputString);
		}
		
		/// <summary>
		/// Parses the current string as an enum value. Failure to parse the input string returns the default value.
		/// </summary>
		/// <returns>
		/// The enum.
		/// </returns>
		/// <param name='inputString'>
		/// Input string.
		/// </param>
		/// <param name='defaultValue'>
		/// Default value.
		/// </param>
		/// <typeparam name='T'>
		/// An Enum type parameter.
		/// </typeparam>
		public static T AsEnum<T>(this string inputString, T defaultValue) {
			try {
				var val = Enum.Parse(typeof(T), inputString);
				return (T)val;
			} catch (Exception ex) {
				return defaultValue;
			}

		}
	}
}
