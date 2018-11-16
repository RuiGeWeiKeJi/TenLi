using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace MaterielBll . Bll
{
    public class MaterielTwoBll
    {
        private readonly Dao.MaterielTwoDao dal=new Dao.MaterielTwoDao();

        /// <summary>
        /// 查询结果
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public DataTable getDataTable ( string control ,string proNum )
        {
            return dal . getDataTable ( control ,proNum );
        }

        /// <summary>
        /// 查询结果
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public MaterileEntity . MaterielPDCEntity getDataTableOne ( string control ,string proNum)
        {
            return dal . getDataTableOne ( control ,proNum );
        }

    }
}
