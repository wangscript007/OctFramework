﻿using Oct.Framework.DB.Base;
using Oct.Framework.DB.Core;
using Oct.Framework.DB.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace Oct.Framework.Entities.Entities
{
	[Serializable]
	public partial class CommonActionInfo : BaseEntity<CommonActionInfo>
	{ 
		#region	属性
		
		private Guid _id;

		/// <summary>
		/// Id
		/// </summary>
		public Guid Id
		{
			get
			{
				return this._id;
			}
			set
			{
				this.PropChanged("Id", this._id, value);

				this._id = value;
			}
		}
		
		private string _categoryName;

		/// <summary>
		/// 分类名称
		/// </summary>
		public string CategoryName
		{
			get
			{
				return this._categoryName;
			}
			set
			{
				this.PropChanged("CategoryName", this._categoryName, value);

				this._categoryName = value;
			}
		}
		
		private string _name;

		/// <summary>
		/// Name
		/// </summary>
		public string Name
		{
			get
			{
				return this._name;
			}
			set
			{
				this.PropChanged("Name", this._name, value);

				this._name = value;
			}
		}
		
		private string _url;

		/// <summary>
		/// Url
		/// </summary>
		public string Url
		{
			get
			{
				return this._url;
			}
			set
			{
				this.PropChanged("Url", this._url, value);

				this._url = value;
			}
		}
		
		private bool _isEnable;

		/// <summary>
		/// IsEnable
		/// </summary>
		public bool IsEnable
		{
			get
			{
				return this._isEnable;
			}
			set
			{
				this.PropChanged("IsEnable", this._isEnable, value);

				this._isEnable = value;
			}
		}
		
		private bool _isVisible;

		/// <summary>
		/// IsVisible
		/// </summary>
		public bool IsVisible
		{
			get
			{
				return this._isVisible;
			}
			set
			{
				this.PropChanged("IsVisible", this._isVisible, value);

				this._isVisible = value;
			}
		}
		
		private bool _isLog;

		/// <summary>
		/// IsLog
		/// </summary>
		public bool IsLog
		{
			get
			{
				return this._isLog;
			}
			set
			{
				this.PropChanged("IsLog", this._isLog, value);

				this._isLog = value;
			}
		}
		
		private int _operation;

		/// <summary>
		/// //浏览        View =1,        //更新        Update =2,        //删除        Delete =3,        //增加        Add =4,        //导出        Export =5,        //导入        Import = 6,
		/// </summary>
		public int Operation
		{
			get
			{
				return this._operation;
			}
			set
			{
				this.PropChanged("Operation", this._operation, value);

				this._operation = value;
			}
		}
		
		private int _sort;

		/// <summary>
		/// Sort
		/// </summary>
		public int Sort
		{
			get
			{
				return this._sort;
			}
			set
			{
				this.PropChanged("Sort", this._sort, value);

				this._sort = value;
			}
		}
		
		private DateTime _createDate;

		/// <summary>
		/// CreateDate
		/// </summary>
		public DateTime CreateDate
		{
			get
			{
				return this._createDate;
			}
			set
			{
				this.PropChanged("CreateDate", this._createDate, value);

				this._createDate = value;
			}
		}
		
		private DateTime? _modifyDate;

		/// <summary>
		/// ModifyDate
		/// </summary>
		public DateTime? ModifyDate
		{
			get
			{
				return this._modifyDate;
			}
			set
			{
				this.PropChanged("ModifyDate", this._modifyDate, value);

				this._modifyDate = value;
			}
		}
		
		private Guid _menuId;

		/// <summary>
		/// MenuId
		/// </summary>
		public Guid MenuId
		{
			get
			{
				return this._menuId;
			}
			set
			{
				this.PropChanged("MenuId", this._menuId, value);

				this._menuId = value;
			}
		}
		
		#endregion

		#region 重载

		public override object PkValue
		{
			get
			{
				return this.Id; 
			}
		}

		public override string PkName
		{
			get
			{
				return "Id"; 
			}
		}

		public override bool IsIdentityPk
		{
			get 
			{
				return false; 
			}
		}

		
		private Dictionary<string, string> _props;

		public override Dictionary<string, string> Props
	    {
	        get {
				if(_props == null)
				{
					_props = new Dictionary<string, string>();
										_props.Add( "Id","Id");
										_props.Add( "CategoryName","CategoryName");
										_props.Add( "Name","Name");
										_props.Add( "Url","Url");
										_props.Add( "IsEnable","IsEnable");
										_props.Add( "IsVisible","IsVisible");
										_props.Add( "IsLog","IsLog");
										_props.Add( "Operation","Operation");
										_props.Add( "Sort","Sort");
										_props.Add( "CreateDate","CreateDate");
										_props.Add( "ModifyDate","ModifyDate");
										_props.Add( "MenuId","MenuId");
									}
				return _props;			 
			 }
	    }

		public override CommonActionInfo GetEntityFromDataRow(DataRow row)
		{
			if (row.Table.Columns.Contains("Id") && row["Id"] != null && row["Id"].ToString() != "")
			{
				this._id = new Guid(row["Id"].ToString());
			}
			if (row.Table.Columns.Contains("CategoryName") && row["CategoryName"] != null)
			{
				this._categoryName = row["CategoryName"].ToString();
			}
			if (row.Table.Columns.Contains("Name") && row["Name"] != null)
			{
				this._name = row["Name"].ToString();
			}
			if (row.Table.Columns.Contains("Url") && row["Url"] != null)
			{
				this._url = row["Url"].ToString();
			}
			if (row.Table.Columns.Contains("IsEnable") && row["IsEnable"] != null && row["IsEnable"].ToString() != "")
			{
				if ((row["IsEnable"].ToString() == "1") || (row["IsEnable"].ToString().ToLower() == "true"))
				{
					this._isEnable = true;
				}
				else
				{
					this._isEnable = false;
				}
			}
			if (row.Table.Columns.Contains("IsVisible") && row["IsVisible"] != null && row["IsVisible"].ToString() != "")
			{
				if ((row["IsVisible"].ToString() == "1") || (row["IsVisible"].ToString().ToLower() == "true"))
				{
					this._isVisible = true;
				}
				else
				{
					this._isVisible = false;
				}
			}
			if (row.Table.Columns.Contains("IsLog") && row["IsLog"] != null && row["IsLog"].ToString() != "")
			{
				if ((row["IsLog"].ToString() == "1") || (row["IsLog"].ToString().ToLower() == "true"))
				{
					this._isLog = true;
				}
				else
				{
					this._isLog = false;
				}
			}
			if (row.Table.Columns.Contains("Operation") && row["Operation"] != null && row["Operation"].ToString() != "")
			{
				this._operation = int.Parse(row["Operation"].ToString());
			}
			if (row.Table.Columns.Contains("Sort") && row["Sort"] != null && row["Sort"].ToString() != "")
			{
				this._sort = int.Parse(row["Sort"].ToString());
			}
			if (row.Table.Columns.Contains("CreateDate") && row["CreateDate"] != null && row["CreateDate"].ToString() != "")
			{
				this._createDate = DateTime.Parse(row["CreateDate"].ToString());
			}
			if (row.Table.Columns.Contains("ModifyDate") && row["ModifyDate"] != null && row["ModifyDate"].ToString() != "")
			{
				this._modifyDate = DateTime.Parse(row["ModifyDate"].ToString());
			}
			if (row.Table.Columns.Contains("MenuId") && row["MenuId"] != null && row["MenuId"].ToString() != "")
			{
				this._menuId = new Guid(row["MenuId"].ToString());
			}

			return this;
		}

		public override CommonActionInfo GetEntityFromDataReader(IDataReader reader)
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                var name = reader.GetName(i);
				if (name.ToLower() == "id" && !reader.IsDBNull(i))
{
_id = reader.GetGuid(i);
 continue;
}
if (name.ToLower() == "categoryname" && !reader.IsDBNull(i))
{
_categoryName = reader.GetString(i);
 continue;
}
if (name.ToLower() == "name" && !reader.IsDBNull(i))
{
_name = reader.GetString(i);
 continue;
}
if (name.ToLower() == "url" && !reader.IsDBNull(i))
{
_url = reader.GetString(i);
 continue;
}
if (name.ToLower() == "isenable" && !reader.IsDBNull(i))
{
_isEnable = reader.GetBoolean(i);
 continue;
}
if (name.ToLower() == "isvisible" && !reader.IsDBNull(i))
{
_isVisible = reader.GetBoolean(i);
 continue;
}
if (name.ToLower() == "islog" && !reader.IsDBNull(i))
{
_isLog = reader.GetBoolean(i);
 continue;
}
if (name.ToLower() == "operation" && !reader.IsDBNull(i))
{
_operation = reader.GetInt32(i);
 continue;
}
if (name.ToLower() == "sort" && !reader.IsDBNull(i))
{
_sort = reader.GetInt32(i);
 continue;
}
if (name.ToLower() == "createdate" && !reader.IsDBNull(i))
{
_createDate = reader.GetDateTime(i);
 continue;
}
if (name.ToLower() == "modifydate" && !reader.IsDBNull(i))
{
_modifyDate = reader.GetDateTime(i);
 continue;
}
if (name.ToLower() == "menuid" && !reader.IsDBNull(i))
{
_menuId = reader.GetGuid(i);
 continue;
}
               
}
            return this;
        }

		public override string TableName
		{
			get
			{
				return "Common_ActionInfo";
			}
		}

		public override IOctDbCommand GetInsertCmd()
		{
			var sql = @"
				INSERT INTO Common_ActionInfo (
					Id,
					CategoryName,
					Name,
					Url,
					IsEnable,
					IsVisible,
					IsLog,
					Operation,
					Sort,
					CreateDate,
					ModifyDate,
					MenuId)
				VALUES (
					@Id,
					@CategoryName,
					@Name,
					@Url,
					@IsEnable,
					@IsVisible,
					@IsLog,
					@Operation,
					@Sort,
					@CreateDate,
					@ModifyDate,
					@MenuId)";
			
			DbCommand cmd = new SqlCommand();
			var parameters = new Dictionary<string, object> {
				{"@Id", this.Id},
				{"@CategoryName", this.CategoryName},
				{"@Name", this.Name},
				{"@Url", this.Url},
				{"@IsEnable", this.IsEnable},
				{"@IsVisible", this.IsVisible},
				{"@IsLog", this.IsLog},
				{"@Operation", this.Operation},
				{"@Sort", this.Sort},
				{"@CreateDate", this.CreateDate},
				{"@ModifyDate", this.ModifyDate},
				{"@MenuId", this.MenuId}};

			return new OctDbCommand(sql, parameters);
		}

		public override IOctDbCommand GetUpdateCmd(string @where = "", IDictionary<string, object> paras = null)
		{
			var sb = new StringBuilder();
			var parameters = new Dictionary<string, object>();
          
			sb.Append("update " + this.TableName + " set ");
         
			foreach (var changedProp in this.ChangedProps)
			{
				sb.Append(string.Format("{0} = @{0},", changedProp.Key));

				parameters.Add("@" + changedProp.Key, changedProp.Value);
			}

			var sql = sb.ToString().Remove(sb.Length - 1);
			sql += string.Format(" where {0} = '{1}'", this.PkName, this.PkValue);

			if (!string.IsNullOrEmpty(@where))
				sql += " and " + @where;

			if (paras != null)
			{
				foreach (var p in paras)
				{
					parameters.Add(p.Key, p.Value);
				}
			}

			return new OctDbCommand(sql, parameters);
		}

		public override string GetDelSQL()
		{
			return string.Format("delete from {0} where {1} = '{2}'", this.TableName, this.PkName, this.PkValue);
		}

		public override string GetDelSQL(object v, string @where = "")
		{
			string sql = string.Format("delete from {0} where 1 = 1 ", this.TableName);
         
			if (v != null)
				sql += "and " + this.PkName + " = '" + v + "'";
         
			if (!string.IsNullOrEmpty(@where))
				sql += "and " + @where;

			return sql;
		}

		public override string GetModelSQL(object v)
		{
			return string.Format("select * from {0} where {1} = '{2}'", this.TableName, this.PkName, v);
		}

		public override string GetQuerySQL(string @where = "")
		{
			var sql = string.Format("select * from {0} where 1 = 1 ", this.TableName);
           
			if (!string.IsNullOrEmpty(@where))
				sql += "and " + @where;

			return sql;
		}

		#endregion
	}
}