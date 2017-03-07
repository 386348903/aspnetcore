using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace Gx
{
    public class Sql
    {
        #region 属性
        /// <summary>
        /// 内容
        /// </summary>
        public string NeiRong { get; set; }
        /// <summary>
        /// 表名
        /// </summary>
        public string BiaoMing { get; set; }
        /// <summary>
        /// 条件
        /// </summary>
        public string TiaoJian { get; set; }
        /// <summary>
        /// 模板类
        /// </summary>
        public object SqlParam { get; set; }
        string SqlStr { get; set; }
        #endregion
        #region 公共方法
        /// <summary>
        /// 生成Sql实例
        /// </summary>
        /// <param name="nr">内容</param>
        /// <param name="bm">表名</param>
        /// <param name="tj">条件</param>
        /// <param name="sp">模型参数</param>
        public Sql(string nr, string bm, string tj,object sp=null)
        {
            NeiRong = nr;
            BiaoMing = bm;
            TiaoJian = tj;
            SqlParam = sp;
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            SqlStr = "insert into " + BiaoMing + " " + NeiRong + ";select @@IDENTITY";
            return QueryFirst<int>();
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public int Delete()
        {
            SqlStr = "delete from " + BiaoMing + " " + TiaoJian;
            return Execute();
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public int Update()
        {
            SqlStr = "update " + BiaoMing + " set " + NeiRong + " " + TiaoJian;
            return Execute();
        }
        /// <summary>
        /// 查找有无
        /// </summary>
        /// <returns></returns>
        public bool Exists<T>()
        {
            List<T> list = SelectList<T>();
            if (list.Count > 0)
                return true;
            return false;
        }
        /// <summary>
        /// 获取整个表
        /// </summary>
        /// <typeparam name="T">模板类</typeparam>
        /// <returns></returns>
        public List<T> SelectList<T>()
        {
            SqlStr = "select " + NeiRong + " from " + BiaoMing + " " + TiaoJian;
            return QueryToList<T>();
        }
        /// <summary>
        /// 获取第一行
        /// </summary>
        /// <typeparam name="T">模板类</typeparam>
        /// <returns></returns>
        public T SelectFirst<T>()
        {
            SqlStr = "select " + NeiRong + " from " + BiaoMing + " " + TiaoJian;
            return QueryFirst<T>();
        }
        #endregion
        #region 私有方法
        static DbConnection GetOpenConnection()
        {
            var connection = new SqlConnection(@"server=.;uid=sa;pwd=xu2935945;database=DataBase;");
            connection.Open();
            return connection;
        }
        T QueryFirst<T>()
        {
            using (var connection = GetOpenConnection())
            {
                var list = connection.Query<T>(SqlStr,SqlParam).First();
                return list;
            }
        }
        List<T> QueryToList<T>()
        {
            using (var connection = GetOpenConnection())
            {
                var list = connection.Query<T>(SqlStr,SqlParam).ToList();
                return list;
            }
        }
        int Execute()
        {
            using (var connection = GetOpenConnection())
            {
                int res = connection.Execute(SqlStr, SqlParam);
                return res;
            }
        }
        #endregion

    }
}
