using Volo.Abp.Reflection;

namespace DemoApp.Permissions
{
    public class DemoAppPermissions
    {
        public const string GroupName = "DemoApp";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(DemoAppPermissions));
        }
    }
}