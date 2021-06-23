﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HR.EmployeeContext.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ExceptionShiftAssignment {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ExceptionShiftAssignment() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("HR.EmployeeContext.Resources.ExceptionShiftAssignment", typeof(ExceptionShiftAssignment).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to تاریخ شروع نباید خالی باشد.
        /// </summary>
        public static string EmployeeStartTimeException {
            get {
                return ResourceManager.GetString("EmployeeStartTimeException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to کد پرسنلی نمی تواند خالی باشد.
        /// </summary>
        public static string EmptyEmployeeIdException {
            get {
                return ResourceManager.GetString("EmptyEmployeeIdException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to تاریخ اتمام شیف نباید خالی باشد.
        /// </summary>
        public static string EmptyEndTimeException {
            get {
                return ResourceManager.GetString("EmptyEndTimeException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to شناسه شیفت نباید خالی باشد.
        /// </summary>
        public static string EmptyShiftIdException {
            get {
                return ResourceManager.GetString("EmptyShiftIdException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to نام خانوادگی نمی تواند خالی باشد.
        /// </summary>
        public static string LastNameRequiredException {
            get {
                return ResourceManager.GetString("LastNameRequiredException", resourceCulture);
            }
        }
    }
}