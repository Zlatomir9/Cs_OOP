using Logger.Models.Common;
using Logger.Models.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace Logger.Factories
{
    public class LayoutFactory
    {
        public LayoutFactory()
        {

        }

        public ILayout CreateLayout(string layoutTypeStr)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            Type layoutType = assembly
                .GetTypes()
                .FirstOrDefault(t => t.Name.Equals(layoutTypeStr, 
                StringComparison.InvariantCultureIgnoreCase));

            if (layoutType == null)
            {
                throw new InvalidOperationException(GlobalConstants.InvalidLayoutType);
            }

            object[] ctorArgs = new object[] { };
            ILayout layout = (ILayout)Activator.CreateInstance(layoutType, ctorArgs);

            return layout;
        }
    }
}
