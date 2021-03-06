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
	public partial class CommonRoleInfo : BaseEntity<CommonRoleInfo>
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
		
		private string _code;

		/// <summary>
		/// Code
		/// </summary>
		public string Code
		{
			get
			{
				return this._code;
			}
			set
			{
				this.PropChanged("Code", this._code, value);

				this._code = value;
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
		
		private bool _isSysDefault;

		/// <summary>
		/// 是否系统默认角色
		/// </summary>
		public bool IsSysDefault
		{
			get
			{
				return this._isSysDefault;
			}
			set
			{
				this.PropChanged("IsSysDefault", this._isSysDefault, value);

				this._isSysDefault = value;
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
										_props.Add( "Name","Name");
										_props.Add( "Code","Code");
										_props.Add( "IsEnable","IsEnable");
										_props.Add( "IsSysDefault","IsSysDefault");
										_props.Add( "CreateDate","CreateDate");
										_props.Add( "ModifyDate","ModifyDate");
									}
				return _props;			 
			 }
	    }

		public override CommonRoleInfo GetEntityFromDataRow(DataRow row)
		{
			if (row.Table.Columns.Contains("Id") && row["Id"] != null && row["Id"].ToString() != "")
			{
				this._id = new Guid(row["Id"].ToString());
			}
			if (row.Table.Columns.Contains("Name") && row["Name"] != null)
			{
				this._name = row["Name"].ToString();
			}
			if (row.Table.Columns.Contains("Code") && row["Code"] != null)
			{
				this._code = row["Code"].ToString();
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
			if (row.Table.Columns.Contains("IsSysDefault") && row["IsSysDefault"] != null && row["IsSysDefault"].ToString() != "")
			{
				if ((row["IsSysDefault"].ToString() == "1") || (row["IsSysDefault"].ToString().ToLower() == "true"))
				{
					this._isSysDefault = true;
				}
				else
				{
					this._isSysDefault = false;
				}
			}
			if (row.Table.Columns.Contains("CreateDate") && row["CreateDate"] != null && row["CreateDate"].ToString() != "")
			{
				this._createDate = DateTime.Parse(row["CreateDate"].ToString());
			}
			if (row.Table.Columns.Contains("ModifyDate") && row["ModifyDate"] != null && row["ModifyDate"].ToString() != "")
			{
				this._modifyDate = DateTime.Parse(row["ModifyDate"].ToString());
			}

			return this;
		}

		public override CommonRoleInfo GetEntityFromDataReader(IDataReader reader)
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                var name = reader.GetName(i);
				if (name.ToLower() == "id" && !reader.IsDBNull(i))
{
_id = reader.GetGuid(i);
 continue;
}
if (name.ToLower() == "name" && !reader.IsDBNull(i))
{
_name = reader.GetString(i);
 continue;
}
if (name.ToLower() == "code" && !reader.IsDBNull(i))
{
_code = reader.GetString(i);
 continue;
}
if (name.ToLower() == "isenable" && !reader.IsDBNull(i))
{
_isEnable = reader.GetBoolean(i);
 continue;
}
if (name.ToLower() == "issysdefault" && !reader.IsDBNull(i))
{
_isSysDefault = reader.GetBoolean(i);
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
               
}
            return this;
        }

		public override string TableName
		{
			get
			{
				return "Common_RoleInfo";
			}
		}

		public override IOctDbCommand GetInsertCmd()
		{
			var sql = @"
				INSERT INTO Common_RoleInfo (
					Id,
					Name,
					Code,
					IsEnable,
					IsSysDefault,
					CreateDate,
					ModifyDate)
				VALUES (
					@Id,
					@Name,
					@Code,
					@IsEnable,
					@IsSysDefault,
					@CreateDate,
					@ModifyDate)";
			
			DbCommand cmd = new SqlCommand();
			var parameters = new Dictionary<string, object> {
				{"@Id", this.Id},
				{"@Name", this.Name},
				{"@Code", this.Code},
				{"@IsEnable", this.IsEnable},
				{"@IsSysDefault", this.IsSysDefault},
				{"@CreateDate", this.CreateDate},
				{"@ModifyDate", this.ModifyDate}};

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