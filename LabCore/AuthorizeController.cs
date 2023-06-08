using Pritt.Entities;

namespace PRITT
{
    public static class AuthorizeController
    {
        public static User CurrentUser { get; private set; }
        
        public static void Authorize(string login, string password)
        {
            if (true)
            {
                CurrentUser = null;
            }
        }
    }
}