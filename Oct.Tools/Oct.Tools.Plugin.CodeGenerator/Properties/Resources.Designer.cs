﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18444
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Oct.Tools.Plugin.CodeGenerator.Properties {
    using System;
    
    
    /// <summary>
    ///   一个强类型的资源类，用于查找本地化的字符串等。
    /// </summary>
    // 此类是由 StronglyTypedResourceBuilder
    // 类通过类似于 ResGen 或 Visual Studio 的工具自动生成的。
    // 若要添加或移除成员，请编辑 .ResX 文件，然后重新运行 ResGen
    // (以 /str 作为命令选项)，或重新生成 VS 项目。
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   返回此类使用的缓存的 ResourceManager 实例。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Oct.Tools.Plugin.CodeGenerator.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   使用此强类型资源类，为所有资源查找
        ///   重写当前线程的 CurrentUICulture 属性。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   查找类似 CREATE TABLE [dbo].[Common_RoleInfo](
        ///	[Id] [uniqueidentifier] NOT NULL,
        ///	[Name] [nvarchar](50) NOT NULL,
        ///	[Code] [nvarchar](50) NOT NULL,
        ///	[IsEnable] [bit] NOT NULL,
        ///	[IsSysDefault] [bit] NOT NULL,
        ///	[CreateDate] [datetime] NOT NULL,
        ///	[ModifyDate] [datetime] NULL,
        /// CONSTRAINT [PK__RoleInfo__3214EC0735FCF52C] PRIMARY KEY CLUSTERED 
        ///(
        ///	[Id] ASC
        ///)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
        ///) ON [PRIMARY] 的本地化字符串。
        /// </summary>
        internal static string A_Common_RoleInfo {
            get {
                return ResourceManager.GetString("A_Common_RoleInfo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 CREATE TABLE [dbo].[Common_MenuInfo](
        ///	[Id] [uniqueidentifier] NOT NULL,
        ///	[Name] [nvarchar](50) NOT NULL,
        ///	[IsAllowAnonymousAccess] [bit] NULL,
        ///	[IsEnable] [bit] NOT NULL,
        ///	[Sort] [int] NOT NULL,
        ///	[CreateDate] [datetime] NOT NULL,
        ///	[ModifyDate] [datetime] NULL,
        /// CONSTRAINT [PK__MenuInfo__3214EC071D314762] PRIMARY KEY CLUSTERED 
        ///(
        ///	[Id] ASC
        ///)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
        ///) ON [PRIMARY] 的本地化字符串。
        /// </summary>
        internal static string B_Common_MenuInfo {
            get {
                return ResourceManager.GetString("B_Common_MenuInfo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 CREATE TABLE [dbo].[Common_ActionInfo](
        ///	[Id] [uniqueidentifier] NOT NULL,
        ///	[CategoryName] [nvarchar](50) NULL,
        ///	[Name] [nvarchar](50) NOT NULL,
        ///	[Url] [nvarchar](100) NOT NULL,
        ///	[IsEnable] [bit] NOT NULL,
        ///	[IsVisible] [bit] NOT NULL,
        ///	[IsLog] [bit] NOT NULL,
        ///	[Operation] [int] NOT NULL,
        ///	[Sort] [int] NOT NULL,
        ///	[CreateDate] [datetime] NOT NULL,
        ///	[ModifyDate] [datetime] NULL,
        ///	[MenuId] [uniqueidentifier] NOT NULL,
        /// CONSTRAINT [PK__ActionIn__3214EC072101D846] PRIMARY KEY CLUSTERED 
        ///(
        ///	[Id] ASC [字符串的其余部分被截断]&quot;; 的本地化字符串。
        /// </summary>
        internal static string C_Common_ActionInfo {
            get {
                return ResourceManager.GetString("C_Common_ActionInfo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 CREATE TABLE [dbo].[Common_RoleAction](
        ///	[Id] [uniqueidentifier] NOT NULL,
        ///	[ActionId] [uniqueidentifier] NOT NULL,
        ///	[RoleId] [uniqueidentifier] NOT NULL,
        ///	[CreateDate] [datetime] NULL,
        ///	[ModifyDate] [datetime] NULL,
        /// CONSTRAINT [PK_Common_RoleAction] PRIMARY KEY CLUSTERED 
        ///(
        ///	[Id] ASC
        ///)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
        ///) ON [PRIMARY] 的本地化字符串。
        /// </summary>
        internal static string D_Common_RoleAction {
            get {
                return ResourceManager.GetString("D_Common_RoleAction", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 CREATE TABLE [dbo].[Common_User](
        ///	[Id] [uniqueidentifier] NOT NULL,
        ///	[Account] [nvarchar](50) NOT NULL,
        ///	[UserName] [nvarchar](50) NOT NULL,
        ///	[Password] [nvarchar](50) NOT NULL,
        ///	[Status] [int] NOT NULL,
        ///	[CreateDate] [datetime] NOT NULL,
        ///	[CreateUserId] [uniqueidentifier] NULL,
        ///	[ModifyUserId] [uniqueidentifier] NULL,
        ///	[ModifyDate] [datetime] NULL,
        ///	[Phone] [nvarchar](50) NULL,
        ///	[Email] [nvarchar](100) NULL,
        ///	[Fax] [nvarchar](50) NULL,
        ///	[QQ] [nvarchar](50) NULL,
        ///	[Address] [nvarchar](100) NU [字符串的其余部分被截断]&quot;; 的本地化字符串。
        /// </summary>
        internal static string E_Common_User {
            get {
                return ResourceManager.GetString("E_Common_User", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 CREATE TABLE [dbo].[Common_UserRole](
        ///	[Id] [uniqueidentifier] NOT NULL,
        ///	[UserId] [uniqueidentifier] NOT NULL,
        ///	[RoleId] [uniqueidentifier] NOT NULL,
        ///	[CreateDate] [datetime] NULL,
        ///	[ModifyDate] [datetime] NULL,
        /// CONSTRAINT [PK_Common_UserRole] PRIMARY KEY CLUSTERED 
        ///(
        ///	[Id] ASC
        ///)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
        ///) ON [PRIMARY] 的本地化字符串。
        /// </summary>
        internal static string F_Common_UserRole {
            get {
                return ResourceManager.GetString("F_Common_UserRole", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 EXEC sys.sp_addextendedproperty @name=N&apos;MS_Description&apos;, @value=N&apos;是否系统默认角色&apos; , @level0type=N&apos;SCHEMA&apos;,@level0name=N&apos;dbo&apos;, @level1type=N&apos;TABLE&apos;,@level1name=N&apos;Common_RoleInfo&apos;, @level2type=N&apos;COLUMN&apos;,@level2name=N&apos;IsSysDefault&apos;
        ///EXEC sys.sp_addextendedproperty @name=N&apos;MS_Description&apos;, @value=N&apos;分类名称&apos; , @level0type=N&apos;SCHEMA&apos;,@level0name=N&apos;dbo&apos;, @level1type=N&apos;TABLE&apos;,@level1name=N&apos;Common_ActionInfo&apos;, @level2type=N&apos;COLUMN&apos;,@level2name=N&apos;CategoryName&apos;
        ///EXEC sys.sp_addextendedproperty @name=N&apos;MS_Description&apos;, @value=N&apos; [字符串的其余部分被截断]&quot;; 的本地化字符串。
        /// </summary>
        internal static string G_AddColumnDescription {
            get {
                return ResourceManager.GetString("G_AddColumnDescription", resourceCulture);
            }
        }
    }
}
