using System.Reflection;

namespace Services
{
    public class ServicesCore
    {
        public static string GetAssemblyName() 
        {
            return Assembly.GetExecutingAssembly().GetName().Name;
        }
    }
}
