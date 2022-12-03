namespace Cliff.Test.Helpers;

public static class Arguments
{
	public static class Success
	{
		public static readonly string[] Valid = { "test", "success", "-o", "value" };
		public static readonly string[] Invalid = { "test", "success" };
	}

	public static class Fail
	{
		public static readonly string[] Default = { "test", "fail", "-o", "value" };
	}
}
