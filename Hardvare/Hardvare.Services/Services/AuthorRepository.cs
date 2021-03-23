using Hardvare.Services.Interfaces;

namespace Hardvare.Services.Services
{
    public class AuthorRepository : IAuthorRepository
    {
        public string GetMessage()
        {
            return "Hello World";
        }
    }
}
