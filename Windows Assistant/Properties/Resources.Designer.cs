namespace WindowsAssistant.Properties
{
    using System;

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources
	{
        private static global::System.Resources.ResourceManager ResourceMan;
        private static global::System.Globalization.CultureInfo ResourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {  }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager
		{
            get
            {
                if (object.ReferenceEquals(ResourceMan, null))
                {
                    global::System.Resources.ResourceManager Temp = new global::System.Resources.ResourceManager("WindowsAssistant.Properties.Resources", typeof(Resources).Assembly);
                    ResourceMan = Temp;
                }

                return ResourceMan;
            }
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture
        {
            get { return ResourceCulture; }
            set { ResourceCulture = value; }
        }
    }
}