namespace Cliff.Test.Helpers;

public static class Arguments
{
    public static class Success
    {
        public static string[] Valid = { "test", "success", "-o", "value" };
        public static string[] Invalid = { "test", "success" };
    }
    
    public static class Fail
    {
        public static string[] Default = { "test", "fail", "-o", "value" };
    }
}