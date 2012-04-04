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
	}
}
