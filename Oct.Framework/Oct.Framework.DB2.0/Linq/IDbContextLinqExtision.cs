﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oct.Framework.Core.Common;
using Oct.Framework.DB.Base;
using Oct.Framework.DB.Core;
using Oct.Framework.DB.DynamicObj;
using Oct.Framework.DB.Implementation;
using Oct.Framework.DB.Interface;
using Remotion.Linq.Parsing.Structure;

namespace Oct.Framework.DB.Linq
{
    public static class IDbContextLinqExtision
    {
        public static SqlServerQueryable<T> AsLinqQueryable<T>(this IDBContext<T> context) where T : BaseEntity<T>, new()
        {
            ISQLContext sqlContext = new SQLContext(context.Session);
            var tblName = "";
            var proxy = EntitiesProxyHelper.GetProxyInfo<T>();
            if (proxy.IsCompositeQuery)
            {
                tblName = string.Format(" ({0})  ", proxy.CompositeSql);
            }
            else
            {
                tblName = proxy.TableName;
            }
            return new SqlServerQueryable<T>(QueryParser.CreateDefault(), new SqlServerQueryExecutor(sqlContext, tblName));
        }
    }
}
