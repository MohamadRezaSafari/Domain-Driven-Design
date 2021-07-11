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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("HR.EmployeeContext.Resources.ExceptionResource", typeof(ExceptionResource).Assembly);
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
        ///   Looks up a localized string similar to تاریخ نمی تواند خالی باشد.
        /// </summary>
        public static string DateTimeRequiredException {
            get {
                return ResourceManager.GetString("DateTimeRequiredException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to کد پرسنلی موجود نمی باشد.
        /// </summary>
        public static string EmployeeIdRequiredException {
            get {
                return ResourceManager.GetString("EmployeeIdRequiredException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to پرسنل موجود نمی باشد.
        /// </summary>
        public static string EmployeeIsExistsException {
            get {
                return ResourceManager.GetString("EmployeeIsExistsException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to کد پرسنلی در سیستم فعال نمی باشد.
        /// </summary>
        public static string EmployeeIsNotActiveException {
            get {
                return ResourceManager.GetString("EmployeeIsNotActiveException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ساعت شروع نامعتبر می باشد.
        /// </summary>
        public static string EmployeeStartTimeException {
            get {
                return ResourceManager.GetString("EmployeeStartTimeException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to تاریخ پایان قرارداد نباید خالی باشد.
        /// </summary>
        public static string EmptyEmployeeContractEndTimeException {
            get {
                return ResourceManager.GetString("EmptyEmployeeContractEndTimeException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to تاریخ شروع قرارداد نباید خالی باشد.
        /// </summary>
        public static string EmptyEmployeeContractStartTimeException {
            get {
                return ResourceManager.GetString("EmptyEmployeeContractStartTimeException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to واحد سازمانی نباید خالی باشد.
        /// </summary>
        public static string EmptyEmployeeContractUnitIdException {
            get {
                return ResourceManager.GetString("EmptyEmployeeContractUnitIdException", resourceCulture);
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
        ///   Looks up a localized string similar to قبل از انعقاد قرار داد باید به پرسنل شیف تخصیص داده شود.
        /// </summary>
        public static string EmptyShiftAssignedException {
            get {
                return ResourceManager.GetString("EmptyShiftAssignedException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to کد پرسنلی نمی تواند خالی باشد.
        /// </summary>
        public static string EmptyShiftIdException {
            get {
                return ResourceManager.GetString("EmptyShiftIdException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to نام نمی تواند خالی باشد.
        /// </summary>
        public static string FirstNameRequiredException {
            get {
                return ResourceManager.GetString("FirstNameRequiredException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to امکان تردد در روز تعطیل وجود ندارد.
        /// </summary>
        public static string HolidayException {
            get {
                return ResourceManager.GetString("HolidayException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ساعت تردد متناسب با شیفت تخصیص داده شده نیست.
        /// </summary>
        public static string InvalidDateTimeAccordingToShiftSegmentException {
            get {
                return ResourceManager.GetString("InvalidDateTimeAccordingToShiftSegmentException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to تردد مورد نظر خارج از شیفت انتصابی است.
        /// </summary>
        public static string InvalidEmployeeIO {
            get {
                return ResourceManager.GetString("InvalidEmployeeIO", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to تاریخ اتمام قرارداد بزرگتر یا مساوی  تاریخ تسویه باشد.
        /// </summary>
        public static string InvalidEmployeeSettlementDateException {
            get {
                return ResourceManager.GetString("InvalidEmployeeSettlementDateException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to نام خانوادگی نباید خالی باشد.
        /// </summary>
        public static string LastNameRequiredException {
            get {
                return ResourceManager.GetString("LastNameRequiredException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to شیفت نباید خالی باشد.
        /// </summary>
        public static string ShiftIdDontExistException {
            get {
                return ResourceManager.GetString("ShiftIdDontExistException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to شیفت مورد نظر نا معتبر است.
        /// </summary>
        public static string ShiftIdNotExistsException {
            get {
                return ResourceManager.GetString("ShiftIdNotExistsException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ساعت شروع نامعتبر است.
        /// </summary>
        public static string StartTimeIsLowException {
            get {
                return ResourceManager.GetString("StartTimeIsLowException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to تاریخ شروع نباید بزرگتر از تاریخ پایان باشد.
        /// </summary>
        public static string StartTimeShouldBeLessThanException {
            get {
                return ResourceManager.GetString("StartTimeShouldBeLessThanException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to کد واحد نامعتبر می باشد.
        /// </summary>
        public static string UnitIdNotExistsException {
            get {
                return ResourceManager.GetString("UnitIdNotExistsException", resourceCulture);
            }
        }
    }
}
