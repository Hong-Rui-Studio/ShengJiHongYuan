using System.Reflection;

namespace Repository
{
    public class RepositoryCore
    {

        public static string GetAssemblyName() 
        {
            return Assembly.GetExecutingAssembly().GetName().Name;
        }

    }
}
