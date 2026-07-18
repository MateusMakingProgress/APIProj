namespace AuthProjectAPI.Models
{
    public record PersonRequest(string Name, string LastName) { }

    public static class ValidationPersonRequest
    {
        public static bool IsValid(this PersonRequest request)
        {
            return !string.IsNullOrWhiteSpace(request.Name) && !string.IsNullOrWhiteSpace(request.LastName);
        }
    }
}
