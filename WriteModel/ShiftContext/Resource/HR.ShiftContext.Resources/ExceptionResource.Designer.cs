﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HR.ShiftContext.Resources {
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
    public class ExceptionResource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ExceptionResource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("HR.ShiftContext.Resources.ExceptionResource", typeof(ExceptionResource).Assembly);
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
        ///   Looks up a localized string similar to ساعت شروع شیفت باید کوچک تر از ساعت پایان شیفت باشد.
        /// </summary>
        public static string InvalidShiftTimeRangeException {
            get {
                return ResourceManager.GetString("InvalidShiftTimeRangeException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to الگوی شیفت نامعتبر است.
        /// </summary>
        public static string ShiftTemplateExistsException {
            get {
                return ResourceManager.GetString("ShiftTemplateExistsException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to کد الگوی شیفت الزامی است.
        /// </summary>
        public static string ShiftTemplateIdRequiredException {
            get {
                return ResourceManager.GetString("ShiftTemplateIdRequiredException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to عنوان الگوی شیفت الزامی است.
        /// </summary>
        public static string ShiftTemplateTitleRequiredException {
            get {
                return ResourceManager.GetString("ShiftTemplateTitleRequiredException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to بازه ساعتی شیفت تعریف نشده است.
        /// </summary>
        public static string ShiftTimeRequiredException {
            get {
                return ResourceManager.GetString("ShiftTimeRequiredException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to عنوان شیفت الزامی است.
        /// </summary>
        public static string ShiftTitleRequiredException {
            get {
                return ResourceManager.GetString("ShiftTitleRequiredException", resourceCulture);
            }
        }
    }
}