using Oct.Framework.Entities;
using Oct.Framework.Entities.Entities;
using System;
using System.Collections.Generic;

namespace Oct.Framework.Services
{
    public interface ICommonUserService
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Add(CommonUser entity);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Modify(CommonUser entity);

        /// <summary>
        /// 根据一个实体对象删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Delete(CommonUser entity);

        /// <summary>
        /// 根据主键删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(Guid id);

        /// <summary>
        /// 根据条件删除 参数键为@拼接的参数，值为参数值
        /// </summary>
        /// <param name="where"></param>
        /// <param name="paras">参数键为@拼接的参数，值为参数值</param>
        /// <returns></returns>
        bool Delete(string where, IDictionary<string, object> paras);

        /// <summary>
        /// 通过主键获取一个对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CommonUser GetModel(Guid id);

        /// <summary>
        /// 通过条件获取对象 参数键为@拼接的参数，值为参数值
        /// </summary>
        /// <param name="where"></param>
        /// <param name="paras">参数键为@拼接的参数，值为参数值</param>
        /// <returns></returns>
        List<CommonUser> GetModels(string where, IDictionary<string, object> paras);

        /// <summary>
        /// 分页获取
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <param name="paras"> 参数键为@拼接的参数，值为参数值</param>
        /// <param name="total"></param>
        /// <returns></returns>
        List<CommonUser> GetModels(int pageIndex, int pageSize, string where, string order, IDictionary<string, object> paras, out int total);

        void Authorization(Guid userId, Guid[] roles);

        List<CommonUserAcrions> GetUserActions(string aUseridUserid, Dictionary<string, object> dictionary, string dSort);
    }

    public class CommonUserService : BaseService, ICommonUserService
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Add(CommonUser entity)
        {
            this.Validate(entity);

            using (var context = new DbContext())
            {
                context.CommonUserContext.Add(entity);

                return context.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Modify(CommonUser entity)
        {
            this.Validate(entity);

            using (var context = new DbContext())
            {
                context.CommonUserContext.Update(entity);

                return context.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// 根据一个实体对象删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Delete(CommonUser entity)
        {
            using (var context = new DbContext())
            {
                context.CommonUserContext.Delete(entity);

                return context.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// 根据主键删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(Guid id)
        {
            using (var context = new DbContext())
            {
                context.CommonUserContext.Delete(id);

                return context.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// 根据条件删除 参数键为@拼接的参数，值为参数值
        /// </summary>
        /// <param name="where"></param>
        /// <param name="paras">参数键为@拼接的参数，值为参数值</param>
        /// <returns></returns>
        public bool Delete(string @where, IDictionary<string, object> paras)
        {
            using (var context = new DbContext())
            {
                context.CommonUserContext.Delete(@where, paras);

                return context.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// 通过主键获取一个对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CommonUser GetModel(Guid id)
        {
            using (var context = new DbContext())
            {
                return context.CommonUserContext.GetModel(id);
            }
        }

        /// <summary>
        /// 通过条件获取对象 参数键为@拼接的参数，值为参数值
        /// </summary>
        /// <param name="where"></param>
        /// <param name="paras">参数键为@拼接的参数，值为参数值</param>
        /// <returns></returns>
        public List<CommonUser> GetModels(string @where, IDictionary<string, object> paras)
        {
            using (var context = new DbContext())
            {
                return context.CommonUserContext.Query(@where, paras);
            }
        }

        /// <summary>
        /// 分页获取
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <param name="paras"> 参数键为@拼接的参数，值为参数值</param>
        /// <param name="total"></param>
        /// <returns></returns>
        public List<CommonUser> GetModels(int pageIndex, int pageSize, string @where, string order, IDictionary<string, object> paras, out int total)
        {
            using (var context = new DbContext())
            {
                return context.CommonUserContext.QueryPage(where, paras, order, pageIndex, pageSize, out total);
            }
        }

        public void Authorization(Guid userId, Guid[] roles)
        {
            using (var context = new DbContext())
            {
                context.CommonUserRoleContext.Delete("userid=@userid",
                    new Dictionary<string, object>() { { "@userid", userId } });
                if (roles != null)
                {
                    foreach (var chkRole in roles)
                    {
                        context.CommonUserRoleContext.Add(new CommonUserRole()
                        {
                            CreateDate = DateTime.Now,
                            Id = Guid.NewGuid(),
                            ModifyDate = null,
                            RoleId = chkRole,
                            UserId = userId
                        });
                    }
                }
                context.SaveChanges();
            }

        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="where"></param>
        /// <param name="para"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public List<CommonUserAcrions> GetUserActions(string where, Dictionary<string, object> para, string order)
        {
            using (var context = new DbContext())
            {
                return context.CommonUserAcrionsContext.Query(where, para, order);
            }
        }
    }
}
