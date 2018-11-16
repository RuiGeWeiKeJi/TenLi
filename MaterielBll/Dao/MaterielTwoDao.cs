using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;
using StudentMgr;

namespace MaterielBll . Dao
{
    public class MaterielTwoDao
    {
        /// <summary>
        /// 查询结果
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public DataTable getDataTable ( string control ,string proNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT * FROM TENPDD " );
            strSql . AppendFormat ( "WHERE PDD011='{0}' AND PDD012='{1}'" ,control ,proNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );

        }

        /// <summary>
        /// 查询结果
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public MaterileEntity . MaterielPDCEntity getDataTableOne ( string control ,string proNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PDC001,PDC005,PDC002,PDC003 FROM TENPDC " );
            strSql . AppendFormat ( "WHERE PDC001='{0}' AND PDC005='{1}'",proNum ,control );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
                return GetModel ( dt . Rows [ 0 ] );
            else
                return null;
        }

        public MaterileEntity . MaterielPDCEntity GetModel ( DataRow row )
        {
            MaterileEntity . MaterielPDCEntity model = new MaterileEntity . MaterielPDCEntity ( );

            if ( row != null )
            {
                if ( row [ "PDC001" ] != null )
                    model . PDC001 = row [ "PDC001" ] . ToString ( );
                if ( row [ "PDC002" ] != null )
                    model . PDC002 = row [ "PDC002" ] . ToString ( );
                if ( row [ "PDC003" ] != null )
                    model . PDC003 = row [ "PDC003" ] . ToString ( );
                if ( row [ "PDC005" ] != null )
                    model . PDC005 = row [ "PDC005" ] . ToString ( );
            }

            return model;

        }

    }
}
