﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace maktoob.CrossCuttingConcerns.Properties {
    using System;
    
    
    /// <summary>
    /// A strongly-typed resource class, for looking up localized strings, formatting them, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilderEx class via the ResXFileCodeGeneratorEx custom tool.
    // To add or remove a member, edit your .ResX file then rerun the ResXFileCodeGeneratorEx custom tool or rebuild your VS.NET project.
    // Copyright (c) Dmytro Kryvko 2006-2020 (http://dmytro.kryvko.googlepages.com/)
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("DMKSoftware.CodeGenerators.Tools.StronglyTypedResourceBuilderEx", "2.6.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
#if !SILVERLIGHT
    [global::System.Reflection.ObfuscationAttribute(Exclude=true, ApplyToMembers=true)]
#endif
    [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public partial class Errors {
        
        private static global::System.Resources.ResourceManager _resourceManager;
        
        private static object _internalSyncObject;
        
        private static global::System.Globalization.CultureInfo _resourceCulture;
        
        /// <summary>
        /// Initializes a Errors object.
        /// </summary>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        public Errors() {
        }
        
        /// <summary>
        /// Thread safe lock object used by this class.
        /// </summary>
        public static object InternalSyncObject {
            get {
                if (object.ReferenceEquals(_internalSyncObject, null)) {
                    global::System.Threading.Interlocked.CompareExchange(ref _internalSyncObject, new object(), null);
                }
                return _internalSyncObject;
            }
        }
        
        /// <summary>
        /// Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(_resourceManager, null)) {
                    global::System.Threading.Monitor.Enter(InternalSyncObject);
                    try {
                        if (object.ReferenceEquals(_resourceManager, null)) {
                            global::System.Threading.Interlocked.Exchange(ref _resourceManager, new global::System.Resources.ResourceManager("maktoob.CrossCuttingConcerns.Properties.Errors", typeof(Errors).Assembly));
                        }
                    }
                    finally {
                        global::System.Threading.Monitor.Exit(InternalSyncObject);
                    }
                }
                return _resourceManager;
            }
        }
        
        /// <summary>
        /// Overrides the current thread's CurrentUICulture property for all
        /// resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return _resourceCulture;
            }
            set {
                _resourceCulture = value;
            }
        }
        
        /// <summary>
        /// Looks up a localized string similar to 'Optimistic concurrency failure, object has been modified.'.
        /// </summary>
        public static string ConcurrencyFailure {
            get {
                return ResourceManager.GetString(ResourceNames.ConcurrencyFailure, _resourceCulture);
            }
        }
        
        /// <summary>
        /// Looks up a localized string similar to 'An unknown failure has occurred.'.
        /// </summary>
        public static string DefaultError {
            get {
                return ResourceManager.GetString(ResourceNames.DefaultError, _resourceCulture);
            }
        }
        
        /// <summary>
        /// Looks up a localized string similar to 'User already in group &apos;{0}&apos;.'.
        /// </summary>
        public static string UserAlreadyInGroup {
            get {
                return ResourceManager.GetString(ResourceNames.UserAlreadyInGroup, _resourceCulture);
            }
        }
        
        /// <summary>
        /// Looks up a localized string similar to 'User is not in group &apos;{0}&apos;.'.
        /// </summary>
        public static string UserNotInGroup {
            get {
                return ResourceManager.GetString(ResourceNames.UserNotInGroup, _resourceCulture);
            }
        }
        
        /// <summary>
        /// Formats a localized string similar to 'User already in group &apos;{0}&apos;.'.
        /// </summary>
        /// <param name="arg0">An object (0) to format.</param>
        /// <returns>A copy of format string in which the format items have been replaced by the String equivalent of the corresponding instances of Object in arguments.</returns>
        public static string UserAlreadyInGroupFormat(object arg0) {
            return string.Format(_resourceCulture, UserAlreadyInGroup, arg0);
        }
        
        /// <summary>
        /// Formats a localized string similar to 'User is not in group &apos;{0}&apos;.'.
        /// </summary>
        /// <param name="arg0">An object (0) to format.</param>
        /// <returns>A copy of format string in which the format items have been replaced by the String equivalent of the corresponding instances of Object in arguments.</returns>
        public static string UserNotInGroupFormat(object arg0) {
            return string.Format(_resourceCulture, UserNotInGroup, arg0);
        }
        
        /// <summary>
        /// Lists all the resource names as constant string fields.
        /// </summary>
        public class ResourceNames {
            
            /// <summary>
            /// Stores the resource name 'ConcurrencyFailure'.
            /// </summary>
            public const string ConcurrencyFailure = "ConcurrencyFailure";
            
            /// <summary>
            /// Stores the resource name 'DefaultError'.
            /// </summary>
            public const string DefaultError = "DefaultError";
            
            /// <summary>
            /// Stores the resource name 'UserAlreadyInGroup'.
            /// </summary>
            public const string UserAlreadyInGroup = "UserAlreadyInGroup";
            
            /// <summary>
            /// Stores the resource name 'UserNotInGroup'.
            /// </summary>
            public const string UserNotInGroup = "UserNotInGroup";
        }
    }
}