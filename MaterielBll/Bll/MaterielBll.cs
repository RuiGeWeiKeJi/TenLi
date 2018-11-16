using System;
using System . Collections;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace MaterielBll . Bll
{
    public class MaterielBll
    {
        private readonly Dao.MaterielDao dal=new Dao.MaterielDao();

        public DateTime dtOne ( )
        {
            return dal . dtOne ( );
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="contractNum"></param>
        /// <returns></returns>
        public bool Delete ( string contractNum )
        {
            return dal . Delete ( contractNum );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getDataTable ( string strWhere )
        {
            return dal . getDataTable ( strWhere );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="contractNum"></param>
        /// <returns></returns>
        public DataTable getDataTableEnclosure ( string contractNum )
        {
            return dal . getDataTableEnclosure ( contractNum );
        }


        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="_pdu"></param>
        /// <param name="tableOne"></param>
        /// <param name="tableFor"></param>
        /// <param name="tableTre"></param>
        /// <param name="_pdc"></param>
        /// <returns></returns>
        public bool Add ( MaterileEntity . MaterielPDUEntity _pdu ,DataTable tableOne ,DataTable tableFor ,Hashtable table_one_pdc ,Hashtable table_two_pdc )
        {
            return dal . Add ( _pdu ,tableOne ,tableFor ,table_one_pdc ,table_two_pdc );
        }


        /// <summary>
        /// 获取合同编号
        /// </summary>
        /// <returns></returns>
        public string getNum ( string str )
        {
            return dal.getNum ( str );
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="contractNum"></param>
        /// <returns></returns>
        public MaterileEntity . MaterielPDUEntity GetDataTableTwo ( string contractNum )
        {
            return dal . GetDataTableTwo ( contractNum );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="contractNum"></param>
        /// <returns></returns>
        public DataTable printOne ( string contractNum )
        {
            return dal . printOne ( contractNum );
        }

    }
}
