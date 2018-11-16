using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;
using StudentMgr;
using System . Collections;
using System . Data;
using System . Data . SqlClient;

namespace MaterielBll . Dao
{
    public class MaterielDao
    {
        public DateTime dtOne ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT GETDATE() t" );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "t" ] . ToString ( ) ) )
                    return DateTime . Now;
                else
                    return Convert . ToDateTime ( dt . Rows [ 0 ] [ "t" ] . ToString ( ) );
            }
            else
                return DateTime . Now;
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="contractNum"></param>
        /// <returns></returns>
        public bool Delete ( string contractNum )
        {
            ArrayList SQLString = new ArrayList ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM TENPDA " );
            strSql . AppendFormat ( "WHERE PDA001='{0}'" ,contractNum );
            SQLString . Add ( strSql );
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM TENPDU " );
            strSql . AppendFormat ( "WHERE PDU001='{0}'" ,contractNum );
            SQLString . Add ( strSql );

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getDataTable ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT * FROM TENPDA " );
            strSql . Append ( "WHERE " + strWhere );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="contractNum"></param>
        /// <returns></returns>
        public DataTable getDataTableEnclosure (string contractNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT * FROM TENPDB " );
            strSql . AppendFormat ( "WHERE PDB001='{0}'" ,contractNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        DateTime dtime ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT GETDATE() t" );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "t" ] . ToString ( ) ) )
                    return DateTime . Now;
                else
                    return Convert . ToDateTime ( dt . Rows [ 0 ] [ "t" ] . ToString ( ) );
            }
            else
                return DateTime . Now;
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
        public bool Add ( MaterileEntity . MaterielPDUEntity _pdu,DataTable tableOne,DataTable tableFor,Hashtable table_one_pdc ,Hashtable table_two_pdc )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );

            add_one ( SQLString ,strSql ,_pdu ,tableOne ,tableFor );

            if ( table_two_pdc .Count >0 )
            {
                add_two ( SQLString ,strSql ,table_one_pdc ,table_two_pdc );
            }

            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        void add_one ( Hashtable SQLString ,StringBuilder strSql ,MaterileEntity . MaterielPDUEntity _pdu ,DataTable tableOne ,DataTable tableFor )
        {
            add_pdu ( SQLString ,strSql ,_pdu );

            add_pda ( SQLString ,strSql ,_pdu . PDU001 ,tableOne );

            add_pdb ( SQLString ,strSql ,tableFor ,_pdu . PDU001 );
        }

        public DataTable dt_one ( string contracNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PDA002 FROM TENPDA " );
            strSql . AppendFormat ( "WHERE PDA001='{0}'" ,contracNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        bool Exists_pdu ( string contracNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT COUNT(1) FROM TENPDU " );
            strSql . AppendFormat ( "WHERE PDU001='{0}'",contracNum );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        void add_pdu ( Hashtable SQLString ,StringBuilder strSql ,MaterileEntity . MaterielPDUEntity _pdu )
        {
            strSql = new StringBuilder ( );
            if ( Exists_pdu ( _pdu . PDU001 ) == false )
            {
                strSql . Append ( "INSERT INTO TENPDU (" );
                strSql . Append ( "PDU001,PDU002,PDU003,PDU004,PDU005,PDU006,PDU007,PDU008,PDU009,PDU010,PDU011,PDU012,PDU013,PDU014,PDU015,PDU016) " );
                strSql . Append ( "VALUES (" );
                strSql . Append ( "@PDU001,@PDU002,@PDU003,@PDU004,@PDU005,@PDU006,@PDU007,@PDU008,@PDU009,@PDU010,@PDU011,@PDU012,@PDU013,@PDU014,@PDU015,@PDU016)" );
                SqlParameter [ ] parameter = {
                new SqlParameter("@PDU001",SqlDbType.NVarChar,200),
                new SqlParameter("@PDU002",SqlDbType.NVarChar,200),
                new SqlParameter("@PDU003",SqlDbType.NVarChar,200),
                new SqlParameter("@PDU004",SqlDbType.NVarChar,200),
                new SqlParameter("@PDU005",SqlDbType.NVarChar,500),
                new SqlParameter("@PDU006",SqlDbType.NVarChar,200),
                new SqlParameter("@PDU007",SqlDbType.NVarChar,200),
                new SqlParameter("@PDU008",SqlDbType.NVarChar,200),
                new SqlParameter("@PDU009",SqlDbType.NVarChar,200),
                new SqlParameter("@PDU010",SqlDbType.NVarChar,200),
                new SqlParameter("@PDU011",SqlDbType.NVarChar,200),
                new SqlParameter("@PDU012",SqlDbType.NVarChar,200),
                new SqlParameter("@PDU013",SqlDbType.NVarChar,200),
                new SqlParameter("@PDU014",SqlDbType.NVarChar,200),
                new SqlParameter("@PDU015",SqlDbType.NVarChar,200),
                new SqlParameter("@PDU016",SqlDbType.Date)
            };
                parameter [ 0 ] . Value = _pdu . PDU001;
                parameter [ 1 ] . Value = _pdu . PDU002;
                parameter [ 2 ] . Value = _pdu . PDU003;
                parameter [ 3 ] . Value = _pdu . PDU004;
                parameter [ 4 ] . Value = _pdu . PDU005;
                parameter [ 5 ] . Value = _pdu . PDU006;
                parameter [ 6 ] . Value = _pdu . PDU007;
                parameter [ 7 ] . Value = _pdu . PDU008;
                parameter [ 8 ] . Value = _pdu . PDU009;
                parameter [ 9 ] . Value = _pdu . PDU010;
                parameter [ 10 ] . Value = _pdu . PDU011;
                parameter [ 11 ] . Value = _pdu . PDU012;
                parameter [ 12 ] . Value = _pdu . PDU013;
                parameter [ 13 ] . Value = _pdu . PDU014;
                parameter [ 14 ] . Value = _pdu . PDU015;
                parameter [ 15 ] . Value = _pdu . PDU016;
                SQLString . Add ( strSql ,parameter );
            }
            else
            {
                strSql . Append ( "UPDATE TENPDU SET " );
                strSql . Append ( "PDU002=@PDU002," );
                strSql . Append ( "PDU003=@PDU003," );
                strSql . Append ( "PDU004=@PDU004," );
                strSql . Append ( "PDU005=@PDU005," );
                strSql . Append ( "PDU006=@PDU006," );
                strSql . Append ( "PDU007=@PDU007," );
                strSql . Append ( "PDU008=@PDU008," );
                strSql . Append ( "PDU009=@PDU009," );
                strSql . Append ( "PDU010=@PDU010," );
                strSql . Append ( "PDU011=@PDU011," );
                strSql . Append ( "PDU012=@PDU012," );
                strSql . Append ( "PDU013=@PDU013," );
                strSql . Append ( "PDU014=@PDU014," );
                strSql . Append ( "PDU015=@PDU015," );
                strSql . Append ( "PDU016=@PDU016 " );
                strSql . Append ( "WHERE PDU001=@PDU001" );
                SqlParameter [ ] parameter = {
                new SqlParameter("@PDU001",SqlDbType.NVarChar,200),
                new SqlParameter("@PDU002",SqlDbType.NVarChar,200),
                new SqlParameter("@PDU003",SqlDbType.NVarChar,200),
                new SqlParameter("@PDU004",SqlDbType.NVarChar,200),
                new SqlParameter("@PDU005",SqlDbType.NVarChar,500),
                new SqlParameter("@PDU006",SqlDbType.NVarChar,200),
                new SqlParameter("@PDU007",SqlDbType.NVarChar,200),
                new SqlParameter("@PDU008",SqlDbType.NVarChar,200),
                new SqlParameter("@PDU009",SqlDbType.NVarChar,200),
                new SqlParameter("@PDU010",SqlDbType.NVarChar,200),
                new SqlParameter("@PDU011",SqlDbType.NVarChar,200),
                new SqlParameter("@PDU012",SqlDbType.NVarChar,200),
                new SqlParameter("@PDU013",SqlDbType.NVarChar,200),
                new SqlParameter("@PDU014",SqlDbType.NVarChar,200),
                new SqlParameter("@PDU015",SqlDbType.NVarChar,200),
                new SqlParameter("@PDU016",SqlDbType.Date)
            };
                parameter [ 0 ] . Value = _pdu . PDU001;
                parameter [ 1 ] . Value = _pdu . PDU002;
                parameter [ 2 ] . Value = _pdu . PDU003;
                parameter [ 3 ] . Value = _pdu . PDU004;
                parameter [ 4 ] . Value = _pdu . PDU005;
                parameter [ 5 ] . Value = _pdu . PDU006;
                parameter [ 6 ] . Value = _pdu . PDU007;
                parameter [ 7 ] . Value = _pdu . PDU008;
                parameter [ 8 ] . Value = _pdu . PDU009;
                parameter [ 9 ] . Value = _pdu . PDU010;
                parameter [ 10 ] . Value = _pdu . PDU011;
                parameter [ 11 ] . Value = _pdu . PDU012;
                parameter [ 12 ] . Value = _pdu . PDU013;
                parameter [ 13 ] . Value = _pdu . PDU014;
                parameter [ 14 ] . Value = _pdu . PDU015;
                parameter [ 15 ] . Value = _pdu . PDU016;
                SQLString . Add ( strSql ,parameter );
            }
        }

        void add_pda ( Hashtable SQLString ,StringBuilder strSql ,string contractNum ,DataTable tableOne )
        {
            MaterileEntity . MaterielPDAEntity _pda = new MaterileEntity . MaterielPDAEntity ( );
            _pda . PDA001 = contractNum;
            DataTable dt = dt_one ( _pda . PDA001 );
            for ( int i = 0 ; i < tableOne . Rows . Count ; i++ )
            {
                _pda . PDA002 = tableOne . Rows [ i ] [ "PDA002" ] . ToString ( );
                _pda . PDA003 = tableOne . Rows [ i ] [ "PDA003" ] . ToString ( );
                _pda . PDA004 = string . IsNullOrEmpty ( tableOne . Rows [ i ] [ "PDA004" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableOne . Rows [ i ] [ "PDA004" ] . ToString ( ) );
                _pda . PDA005 = tableOne . Rows [ i ] [ "PDA005" ] . ToString ( );
                _pda . PDA006 = string . IsNullOrEmpty ( tableOne . Rows [ i ] [ "PDA006" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( tableOne . Rows [ i ] [ "PDA006" ] . ToString ( ) );
                _pda . PDA007 = tableOne . Rows [ i ] [ "PDA007" ] . ToString ( );
                _pda . PDA008 = string . IsNullOrEmpty ( tableOne . Rows [ i ] [ "PDA008" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( tableOne . Rows [ i ] [ "PDA008" ] . ToString ( ) );
                _pda . PDA009 = string . IsNullOrEmpty ( tableOne . Rows [ i ] [ "PDA009" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( tableOne . Rows [ i ] [ "PDA009" ] . ToString ( ) );
                _pda . PDA010 = string . IsNullOrEmpty ( tableOne . Rows [ i ] [ "PDA010" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( tableOne . Rows [ i ] [ "PDA010" ] . ToString ( ) );
                _pda . PDA011 = tableOne . Rows [ i ] [ "PDA011" ] . ToString ( );
                _pda . PDA012 = string . IsNullOrEmpty ( tableOne . Rows [ i ] [ "PDA012" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( tableOne . Rows [ i ] [ "PDA012" ] . ToString ( ) );
                _pda . PDA013 = string . IsNullOrEmpty ( tableOne . Rows [ i ] [ "PDA013" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( tableOne . Rows [ i ] [ "PDA013" ] . ToString ( ) );
                _pda . PDA014 = string . IsNullOrEmpty ( tableOne . Rows [ i ] [ "PDA014" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( tableOne . Rows [ i ] [ "PDA014" ] . ToString ( ) );
                _pda . PDA015 = string . IsNullOrEmpty ( tableOne . Rows [ i ] [ "PDA015" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableOne . Rows [ i ] [ "PDA015" ] . ToString ( ) );
                _pda . PDA016 = tableOne . Rows [ i ] [ "PDA016" ] . ToString ( );
                _pda . PDA017 = string . IsNullOrEmpty ( tableOne . Rows [ i ] [ "PDA017" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( tableOne . Rows [ i ] [ "PDA017" ] . ToString ( ) );
                _pda . PDA018 = tableOne . Rows [ i ] [ "PDA018" ] . ToString ( );

                if ( dt . Select ( "PDA002='" + _pda . PDA002 + "'" ) . Length < 1 )
                    add_pda ( SQLString ,strSql ,_pda );
                else
                    edit_pda ( SQLString ,strSql ,_pda );
            }

            for ( int i = 0 ; i < dt . Rows . Count ; i++ )
            {
                _pda . PDA002 = dt . Rows [ i ] [ "PDA002" ] . ToString ( );
                if ( tableOne . Select ( "PDA002='" + _pda . PDA002 + "'" ) . Length < 1 )
                    delete_pda ( SQLString ,strSql ,_pda );
            }
        }

        void add_pda ( Hashtable SQLString ,StringBuilder strSql ,MaterileEntity . MaterielPDAEntity _pda )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO TENPDA (" );
            strSql . Append ( "PDA001,PDA002,PDA003,PDA004,PDA005,PDA006,PDA007,PDA008,PDA009,PDA010,PDA011,PDA012,PDA013,PDA014,PDA015,PDA016,PDA017,PDA018) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@PDA001,@PDA002,@PDA003,@PDA004,@PDA005,@PDA006,@PDA007,@PDA008,@PDA009,@PDA010,@PDA011,@PDA012,@PDA013,@PDA014,@PDA015,@PDA016,@PDA017,@PDA018)" );
            SqlParameter [ ] paramete = {
                        new SqlParameter("@PDA001",SqlDbType.NVarChar,200),
                        new SqlParameter("@PDA002",SqlDbType.NVarChar,200),
                        new SqlParameter("@PDA003",SqlDbType.NVarChar,200),
                        new SqlParameter("@PDA004",SqlDbType.Int),
                        new SqlParameter("@PDA005",SqlDbType.NVarChar,5),
                        new SqlParameter("@PDA006",SqlDbType.Decimal,10),
                        new SqlParameter("@PDA007",SqlDbType.NVarChar,200),
                        new SqlParameter("@PDA008",SqlDbType.Decimal,5),
                        new SqlParameter("@PDA009",SqlDbType.Decimal,5),
                        new SqlParameter("@PDA010",SqlDbType.Decimal,5),
                        new SqlParameter("@PDA011",SqlDbType.NVarChar,200),
                        new SqlParameter("@PDA012",SqlDbType.Decimal,5),
                        new SqlParameter("@PDA013",SqlDbType.Decimal,5),
                        new SqlParameter("@PDA014",SqlDbType.Decimal,5),
                        new SqlParameter("@PDA015",SqlDbType.Int),
                        new SqlParameter("@PDA016",SqlDbType.NVarChar,200),
                        new SqlParameter("@PDA017",SqlDbType.Decimal,5),
                        new SqlParameter("@PDA018",SqlDbType.NVarChar,200)
                    };
            paramete [ 0 ] . Value = _pda . PDA001;
            paramete [ 1 ] . Value = _pda . PDA002;
            paramete [ 2 ] . Value = _pda . PDA003;
            paramete [ 3 ] . Value = _pda . PDA004;
            paramete [ 4 ] . Value = _pda . PDA005;
            paramete [ 5 ] . Value = _pda . PDA006;
            paramete [ 6 ] . Value = _pda . PDA007;
            paramete [ 7 ] . Value = _pda . PDA008;
            paramete [ 8 ] . Value = _pda . PDA009;
            paramete [ 9 ] . Value = _pda . PDA010;
            paramete [ 10 ] . Value = _pda . PDA011;
            paramete [ 11 ] . Value = _pda . PDA012;
            paramete [ 12 ] . Value = _pda . PDA013;
            paramete [ 13 ] . Value = _pda . PDA014;
            paramete [ 14 ] . Value = _pda . PDA015;
            paramete [ 15 ] . Value = _pda . PDA016;
            paramete [ 16 ] . Value = _pda . PDA017;
            paramete [ 17 ] . Value = _pda . PDA018;
            SQLString . Add ( strSql ,paramete );
        }

        void edit_pda ( Hashtable SQLString ,StringBuilder strSql ,MaterileEntity . MaterielPDAEntity _pda )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE TENPDA SET " );
            strSql . Append ( "PDA003=@PDA003," );
            strSql . Append ( "PDA004=@PDA004," );
            strSql . Append ( "PDA005=@PDA005," );
            strSql . Append ( "PDA006=@PDA006," );
            strSql . Append ( "PDA007=@PDA007," );
            strSql . Append ( "PDA008=@PDA008," );
            strSql . Append ( "PDA009=@PDA009," );
            strSql . Append ( "PDA010=@PDA010," );
            strSql . Append ( "PDA011=@PDA011," );
            strSql . Append ( "PDA012=@PDA012," );
            strSql . Append ( "PDA013=@PDA013," );
            strSql . Append ( "PDA014=@PDA014," );
            strSql . Append ( "PDA015=@PDA015," );
            strSql . Append ( "PDA016=@PDA016," );
            strSql . Append ( "PDA017=@PDA017," );
            strSql . Append ( "PDA018=@PDA018 " );
            strSql . Append ( "WHERE PDA001=@PDA001 AND " );
            strSql . Append ( "PDA002=@PDA002" );
            SqlParameter [ ] paramete = {
                        new SqlParameter("@PDA001",SqlDbType.NVarChar,200),
                        new SqlParameter("@PDA002",SqlDbType.NVarChar,200),
                        new SqlParameter("@PDA003",SqlDbType.NVarChar,200),
                        new SqlParameter("@PDA004",SqlDbType.Int),
                        new SqlParameter("@PDA005",SqlDbType.NVarChar,5),
                        new SqlParameter("@PDA006",SqlDbType.Decimal,10),
                        new SqlParameter("@PDA007",SqlDbType.NVarChar,200),
                        new SqlParameter("@PDA008",SqlDbType.Decimal,5),
                        new SqlParameter("@PDA009",SqlDbType.Decimal,5),
                        new SqlParameter("@PDA010",SqlDbType.Decimal,5),
                        new SqlParameter("@PDA011",SqlDbType.NVarChar,200),
                        new SqlParameter("@PDA012",SqlDbType.Decimal,5),
                        new SqlParameter("@PDA013",SqlDbType.Decimal,5),
                        new SqlParameter("@PDA014",SqlDbType.Decimal,5),
                        new SqlParameter("@PDA015",SqlDbType.Int),
                        new SqlParameter("@PDA016",SqlDbType.NVarChar,200),
                        new SqlParameter("@PDA017",SqlDbType.Decimal,5),
                        new SqlParameter("@PDA018",SqlDbType.NVarChar,200)
                    };
            paramete [ 0 ] . Value = _pda . PDA001;
            paramete [ 1 ] . Value = _pda . PDA002;
            paramete [ 2 ] . Value = _pda . PDA003;
            paramete [ 3 ] . Value = _pda . PDA004;
            paramete [ 4 ] . Value = _pda . PDA005;
            paramete [ 5 ] . Value = _pda . PDA006;
            paramete [ 6 ] . Value = _pda . PDA007;
            paramete [ 7 ] . Value = _pda . PDA008;
            paramete [ 8 ] . Value = _pda . PDA009;
            paramete [ 9 ] . Value = _pda . PDA010;
            paramete [ 10 ] . Value = _pda . PDA011;
            paramete [ 11 ] . Value = _pda . PDA012;
            paramete [ 12 ] . Value = _pda . PDA013;
            paramete [ 13 ] . Value = _pda . PDA014;
            paramete [ 14 ] . Value = _pda . PDA015;
            paramete [ 15 ] . Value = _pda . PDA016;
            paramete [ 16 ] . Value = _pda . PDA017;
            paramete [ 17 ] . Value = _pda . PDA018;
            SQLString . Add ( strSql ,paramete );
        }

        void delete_pda ( Hashtable SQLString ,StringBuilder strSql ,MaterileEntity . MaterielPDAEntity _pda )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM TENPDA " );
            strSql . AppendFormat ( "WHERE PDA001='{0}' AND PDA002='{1}'" ,_pda . PDA001 ,_pda . PDA002 );
            SQLString . Add ( strSql ,null );
        }

        public DataTable dt_pdb ( string contractNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT PDB002 FROM TENPDB " );
            strSql . AppendFormat ( "WHERE PDB001='{0}'" ,contractNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        void add_pdb ( Hashtable SQLString ,StringBuilder strSql ,DataTable table ,string contractNum )
        {
            MaterileEntity . MaterielPDBEntity _pdb = new MaterileEntity . MaterielPDBEntity ( );
            _pdb . PDB001 = contractNum;
            DataTable dt = dt_pdb ( _pdb . PDB001 );
            for ( int i = 0 ; i < table . Rows . Count ; i++ )
            {
                _pdb . PDB002 = table . Rows [ i ] [ "PDB002" ] . ToString ( );
                _pdb . PDB003 = table . Rows [ i ] [ "PDB003" ] . ToString ( );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "PDB004" ] . ToString ( ) ) )
                    _pdb . PDB004 = null;
                else
                    _pdb . PDB004 = Convert . ToDateTime ( table . Rows [ i ] [ "PDB004" ] . ToString ( ) );
                if ( string . IsNullOrEmpty ( table . Rows [ i ] [ "PDB005" ] . ToString ( ) ) )
                    _pdb . PDB005 = new byte [ 0 ];
                else
                    _pdb . PDB005 = ( byte [ ] ) table . Rows [ i ] [ "PDB005" ];

                if ( dt . Select ( "PDB002='" + _pdb . PDB002 + "'" ) . Length < 1 )
                    add_pdu_one ( SQLString ,strSql ,_pdb );
                else
                    edit_pdu_one ( SQLString ,strSql ,_pdb );
            }

            for ( int i = 0 ; i < dt . Rows . Count ; i++ )
            {
                _pdb . PDB002 = dt . Rows [ i ] [ "PDB002" ] . ToString ( );
                if ( table . Select ( "PDB002='" + _pdb . PDB002 + "'" ) . Length < 1 )
                    delete_pdu_one ( SQLString ,strSql ,_pdb );
            }

        }

        void add_pdu_one ( Hashtable SQLString ,StringBuilder strSql ,MaterileEntity . MaterielPDBEntity _pdb )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO TENPDB( " );
            strSql . Append ( "PDB001,PDB002,PDB003,PDB004,PDB005) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@PDB001,@PDB002,@PDB003,@PDB004,@PDB005) " );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PDB001",SqlDbType.NVarChar,200),
                new SqlParameter("@PDB002",SqlDbType.NVarChar,200),
                new SqlParameter("@PDB003",SqlDbType.NVarChar,20),
                new SqlParameter("@PDB004",SqlDbType.Date),
                new SqlParameter("@PDB005",SqlDbType.Image)
            };
            parameter [ 0 ] . Value = _pdb . PDB001;
            parameter [ 1 ] . Value = _pdb . PDB002;
            parameter [ 2 ] . Value = _pdb . PDB003;
            parameter [ 3 ] . Value = _pdb . PDB004;
            parameter [ 4 ] . Value = _pdb . PDB005;
            SQLString . Add ( strSql ,parameter );
        }

        void edit_pdu_one ( Hashtable SQLString ,StringBuilder strSql ,MaterileEntity . MaterielPDBEntity _pdb )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE TENPDB SET " );
            strSql . Append ( "PDB003=@PDB003," );
            strSql . Append ( "PDB004=@PDB004," );
            strSql . Append ( "PDB005=@PDB005 " );
            strSql . Append ( "WHERE PDB001=@PDB001 AND PDB002=@PDB002" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PDB001",SqlDbType.NVarChar,200),
                new SqlParameter("@PDB002",SqlDbType.NVarChar,200),
                new SqlParameter("@PDB003",SqlDbType.NVarChar,20),
                new SqlParameter("@PDB004",SqlDbType.Date),
                new SqlParameter("@PDB005",SqlDbType.Image)
            };
            parameter [ 0 ] . Value = _pdb . PDB001;
            parameter [ 1 ] . Value = _pdb . PDB002;
            parameter [ 2 ] . Value = _pdb . PDB003;
            parameter [ 3 ] . Value = _pdb . PDB004;
            parameter [ 4 ] . Value = _pdb . PDB005;
            SQLString . Add ( strSql ,parameter );
        }

        void delete_pdu_one ( Hashtable SQLString ,StringBuilder strSql ,MaterileEntity . MaterielPDBEntity _pdb )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM TENPDB " );
            strSql . AppendFormat ( "WHERE PDB001='{0}' AND PDB002='{1}'" ,_pdb . PDB001 ,_pdb . PDB002 );
            SQLString . Add ( strSql ,null );
        }

        void add_two ( Hashtable SQLString ,StringBuilder strSql,Hashtable table_one_pdc ,Hashtable table_two_pdc )
        {
            add_pdc ( SQLString ,strSql ,table_two_pdc );
            add_pdd ( SQLString ,strSql ,table_one_pdc ,table_two_pdc );
        }

        bool Exists_pdc ( MaterileEntity . MaterielPDCEntity _pdc )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT COUNT(1) FROM TENPDC " );
            strSql . AppendFormat ( "WHERE PDC001='{0}' AND PDC005='{1}'" ,_pdc . PDC001 ,_pdc . PDC005 );

            return SqlHelper . Exists ( strSql . ToString ( ) );
        }

        void add_pdc ( Hashtable SQLString ,StringBuilder strSql ,Hashtable table_two_pdc )
        {
            foreach ( MaterileEntity . MaterielPDCEntity _pdc in table_two_pdc.Values )
            {
                strSql = new StringBuilder ( );
                _pdc . PDC004 = dtime ( );
                if ( Exists_pdc ( _pdc ) == true )
                {
                    strSql . Append ( "UPDATE TENPDC SET " );
                    strSql . Append ( "PDC002=@PDC002," );
                    strSql . Append ( "PDC003=@PDC003," );
                    strSql . Append ( "PDC004=@PDC004 " );
                    strSql . Append ( "WHERE PDC001=@PDC001 AND " );
                    strSql . Append ( "PDC005=@PDC005 " );
                    SqlParameter [ ] parameter = {
                                    new SqlParameter("@PDC001",SqlDbType.NVarChar,200),
                                    new SqlParameter("@PDC002",SqlDbType.NVarChar,200),
                                    new SqlParameter("@PDC003",SqlDbType.NVarChar,200),
                                    new SqlParameter("@PDC004",SqlDbType.Date),
                                    new SqlParameter("@PDC005",SqlDbType.NVarChar,200)
                                 };
                    parameter [ 0 ] . Value = _pdc . PDC001;
                    parameter [ 1 ] . Value = _pdc . PDC002;
                    parameter [ 2 ] . Value = _pdc . PDC003;
                    parameter [ 3 ] . Value = _pdc . PDC004;
                    parameter [ 4 ] . Value = _pdc . PDC005;

                    SQLString . Add ( strSql ,parameter );
                }
                else
                {
                    strSql . Append ( "INSERT INTO TENPDC (" );
                    strSql . Append ( "PDC001,PDC002,PDC003,PDC004,PDC005) " );
                    strSql . Append ( "VALUES (" );
                    strSql . Append ( "@PDC001,@PDC002,@PDC003,@PDC004,@PDC005) " );
                    SqlParameter [ ] parameter = {
                                    new SqlParameter("@PDC001",SqlDbType.NVarChar,200),
                                    new SqlParameter("@PDC002",SqlDbType.NVarChar,200),
                                    new SqlParameter("@PDC003",SqlDbType.NVarChar,200),
                                    new SqlParameter("@PDC004",SqlDbType.Date),
                                    new SqlParameter("@PDC005",SqlDbType.NVarChar,200)
                                };
                    parameter [ 0 ] . Value = _pdc . PDC001;
                    parameter [ 1 ] . Value = _pdc . PDC002;
                    parameter [ 2 ] . Value = _pdc . PDC003;
                    parameter [ 3 ] . Value = _pdc . PDC004;
                    parameter [ 4 ] . Value = _pdc . PDC005;
                    SQLString . Add ( strSql ,parameter );
                }
            }
        }

        DataTable dtpdd ( string controlNum,string proNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT * FROM TENPDD " );
            strSql . AppendFormat ( "WHERE PDD011='{0}' AND PDD012='{1}'" ,controlNum ,proNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        void add_pdd ( Hashtable SQLString ,StringBuilder strSql ,Hashtable table_one_pdc ,Hashtable table_two_pdc )
        {
            foreach ( string key in table_two_pdc.Keys )
            {
                MaterileEntity . MaterielPDCEntity _pdc = ( MaterileEntity . MaterielPDCEntity ) table_two_pdc [ key ];
                MaterileEntity . MaterielPDDEntity _pdd = new MaterileEntity . MaterielPDDEntity ( );
                _pdd . PDD001 = _pdc . PDC002;
                _pdd . PDD011 = _pdc . PDC005;
                _pdd . PDD012 = _pdc . PDC001;
                DataTable tableTre = ( DataTable ) table_one_pdc [ key ];
                DataTable dt = dtpdd ( _pdd . PDD011 ,_pdd . PDD012 );
                List<string> strList = new List<string> ( );
                for ( int i = 0 ; i < tableTre . Rows . Count ; i++ )
                {
                    _pdd . PDD002 = tableTre . Rows [ i ] [ "PDD002" ] . ToString ( );
                    _pdd . PDD003 = tableTre . Rows [ i ] [ "PDD003" ] . ToString ( );
                    _pdd . PDD004 = tableTre . Rows [ i ] [ "PDD004" ] . ToString ( );
                    _pdd . PDD005 = tableTre . Rows [ i ] [ "PDD005" ] . ToString ( );
                    _pdd . PDD006 = string . IsNullOrEmpty ( tableTre . Rows [ i ] [ "PDD006" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tableTre . Rows [ i ] [ "PDD006" ] . ToString ( ) );
                    _pdd . PDD007 = tableTre . Rows [ i ] [ "PDD007" ] . ToString ( );
                    _pdd . PDD008 = tableTre . Rows [ i ] [ "PDD008" ] . ToString ( );
                    _pdd . PDD009 = tableTre . Rows [ i ] [ "PDD009" ] . ToString ( );

                    if ( dt . Select ( "PDD002='" + _pdd . PDD002 + "'" ) . Length > 0 )
                    {
                        //if ( dt . Select ( "PDD002='" + _pdd . PDD002 + "' AND PDD003='" + _pdd . PDD003 + "' AND PDD004='" + _pdd . PDD004 + "' AND PDD005='" + _pdd . PDD005 + "' AND PDD006='" + _pdd . PDD006 + "' AND PDD007='" + _pdd . PDD007 + "' AND PDD008='" + _pdd . PDD008 + "' AND PDD009='" + _pdd . PDD009 + "' AND PDD011='" + _pdd . PDD011 + "' AND PDD012='" + _pdd . PDD012 + "'" ) . Length < 1 )
                        //{
                        //    _pdd . PDD002 = dt . Compute ( "max(PDD002)" ,null ) . ToString ( );
                        //    _pdd . PDD002 = ( Convert . ToInt32 ( _pdd . PDD002 ) + 1 ) . ToString ( );
                        //    _pdd . PDD002 = _pdd . PDD002 . PadLeft ( 3 ,'0' );
                        //    if ( strList . Contains ( _pdd . PDD002 ) == false )
                        //        strList . Add ( _pdd . PDD002 );
                        //    else
                        //    {
                        //        _pdd . PDD002 = strList . Max ( );
                        //        _pdd . PDD002 = ( Convert . ToInt32 ( _pdd . PDD002 ) + 1 ) . ToString ( );
                        //        _pdd . PDD002 = _pdd . PDD002 . PadLeft ( 3 ,'0' );
                        //        strList . Add ( _pdd . PDD002 );
                        //    }
                        //    add_pdd_one ( SQLString ,strSql ,_pdd );
                        //}
                        //else
                            edit_pdd ( SQLString ,strSql ,_pdd );
                    }
                    else
                        add_pdd_one ( SQLString ,strSql ,_pdd );
                }
            }           
        }

        void edit_pdd ( Hashtable SQLString ,StringBuilder strSql ,MaterileEntity . MaterielPDDEntity _pdd )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE TENPDD SET " );
            strSql . Append ( "PDD003=@PDD003," );
            strSql . Append ( "PDD004=@PDD004," );
            strSql . Append ( "PDD005=@PDD005," );
            strSql . Append ( "PDD006=@PDD006," );
            strSql . Append ( "PDD007=@PDD007," );
            strSql . Append ( "PDD008=@PDD008," );
            strSql . Append ( "PDD009=@PDD009," );
            strSql . Append ( "PDD001=@PDD001 " );
            strSql . Append ( "WHERE " );
            strSql . Append ( "PDD002=@PDD002 AND PDD011=@PDD011 AND PDD012=@PDD012" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PDD001",SqlDbType.NVarChar,200),
                new SqlParameter("@PDD002",SqlDbType.NVarChar,10),
                new SqlParameter("@PDD003",SqlDbType.NVarChar,200),
                new SqlParameter("@PDD004",SqlDbType.NVarChar,200),
                new SqlParameter("@PDD005",SqlDbType.NVarChar,200),
                new SqlParameter("@PDD006",SqlDbType.Int),
                new SqlParameter("@PDD007",SqlDbType.NVarChar,200),
                new SqlParameter("@PDD008",SqlDbType.NVarChar,200),
                new SqlParameter("@PDD009",SqlDbType.NVarChar,200),
                new SqlParameter("@PDD011",SqlDbType.NVarChar,200),
                new SqlParameter("@PDD012",SqlDbType.NVarChar,200)
            };
            parameter [ 0 ] . Value = _pdd . PDD001;
            parameter [ 1 ] . Value = _pdd . PDD002;
            parameter [ 2 ] . Value = _pdd . PDD003;
            parameter [ 3 ] . Value = _pdd . PDD004;
            parameter [ 4 ] . Value = _pdd . PDD005;
            parameter [ 5 ] . Value = _pdd . PDD006;
            parameter [ 6 ] . Value = _pdd . PDD007;
            parameter [ 7 ] . Value = _pdd . PDD008;
            parameter [ 8 ] . Value = _pdd . PDD009;
            parameter [ 9 ] . Value = _pdd . PDD011;
            parameter [ 10 ] . Value = _pdd . PDD012;
            SQLString . Add ( strSql ,parameter );
        }

        void add_pdd_one ( Hashtable SQLString ,StringBuilder strSql ,MaterileEntity . MaterielPDDEntity _pdd )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO TENPDD (" );
            strSql . Append ( "PDD001,PDD002,PDD003,PDD004,PDD005,PDD006,PDD007,PDD008,PDD009,PDD011,PDD012) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@PDD001,@PDD002,@PDD003,@PDD004,@PDD005,@PDD006,@PDD007,@PDD008,@PDD009,@PDD011,@PDD012)" );
            SqlParameter [ ] parameter = {
                new SqlParameter("@PDD001",SqlDbType.NVarChar,200),
                new SqlParameter("@PDD002",SqlDbType.NVarChar,10),
                new SqlParameter("@PDD003",SqlDbType.NVarChar,200),
                new SqlParameter("@PDD004",SqlDbType.NVarChar,200),
                new SqlParameter("@PDD005",SqlDbType.NVarChar,200),
                new SqlParameter("@PDD006",SqlDbType.Int),
                new SqlParameter("@PDD007",SqlDbType.NVarChar,200),
                new SqlParameter("@PDD008",SqlDbType.NVarChar,200),
                new SqlParameter("@PDD009",SqlDbType.NVarChar,200),
                new SqlParameter("@PDD011",SqlDbType.NVarChar,200),
                new SqlParameter("@PDD012",SqlDbType.NVarChar,200),
            };
            parameter [ 0 ] . Value = _pdd . PDD001;
            parameter [ 1 ] . Value = _pdd . PDD002;
            parameter [ 2 ] . Value = _pdd . PDD003;
            parameter [ 3 ] . Value = _pdd . PDD004;
            parameter [ 4 ] . Value = _pdd . PDD005;
            parameter [ 5 ] . Value = _pdd . PDD006;
            parameter [ 6 ] . Value = _pdd . PDD007;
            parameter [ 7 ] . Value = _pdd . PDD008;
            parameter [ 8 ] . Value = _pdd . PDD009;
            parameter [ 9 ] . Value = _pdd . PDD011;
            parameter [ 10 ] . Value = _pdd . PDD012;
            SQLString . Add ( strSql ,parameter );
        }

        /// <summary>
        /// 获取合同编号
        /// </summary>
        /// <returns></returns>
        public string getNum (string str )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( str );

            DataTable dt = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "PDU001" ] . ToString ( ) ) )
                    return string . Empty;
                else
                    return dt . Rows [ 0 ] [ "PDU001" ] . ToString ( );
            }
            else
                return string . Empty;
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="contractNum"></param>
        /// <returns></returns>
        public MaterileEntity . MaterielPDUEntity GetDataTableTwo ( string contractNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT * FROM TENPDU " );
            strSql . AppendFormat ( "WHERE PDU001='{0}'" ,contractNum );

            DataTable dt= SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );

            return GetModel ( dt . Rows [ 0 ] );
        }

        public MaterileEntity . MaterielPDUEntity GetModel ( DataRow row )
        {
            MaterileEntity . MaterielPDUEntity model = new MaterileEntity . MaterielPDUEntity ( );

            if ( row != null )
            {
                if ( row [ "idx" ] != null )
                    model . idx = int . Parse ( row [ "idx" ] . ToString ( ) );
                if ( row [ "PDU001" ] != null )
                    model . PDU001 = row [ "PDU001" ] . ToString ( );
                if ( row [ "PDU002" ] != null )
                    model . PDU002 = row [ "PDU002" ] . ToString ( );
                if ( row [ "PDU003" ] != null )
                    model . PDU003 = row [ "PDU003" ] . ToString ( );
                if ( row [ "PDU004" ] != null )
                    model . PDU004 = row [ "PDU004" ] . ToString ( );
                if ( row [ "PDU005" ] != null )
                    model . PDU005 = row [ "PDU005" ] . ToString ( );
                if ( row [ "PDU006" ] != null )
                    model . PDU006 = row [ "PDU006" ] . ToString ( );
                if ( row [ "PDU007" ] != null )
                    model . PDU007 = row [ "PDU007" ] . ToString ( );
                if ( row [ "PDU008" ] != null )
                    model . PDU008 = row [ "PDU008" ] . ToString ( );
                if ( row [ "PDU009" ] != null )
                    model . PDU009 = row [ "PDU009" ] . ToString ( );
                if ( row [ "PDU010" ] != null )
                    model . PDU010 = row [ "PDU010" ] . ToString ( );
                if ( row [ "PDU011" ] != null )
                    model . PDU011 = row [ "PDU011" ] . ToString ( );
                if ( row [ "PDU012" ] != null )
                    model . PDU012 = row [ "PDU012" ] . ToString ( );
                if ( row [ "PDU013" ] != null )
                    model . PDU013 = row [ "PDU013" ] . ToString ( );
                if ( row [ "PDU014" ] != null )
                    model . PDU014 = row [ "PDU014" ] . ToString ( );
                if ( row [ "PDU015" ] != null )
                    model . PDU015 = row [ "PDU015" ] . ToString ( );
                if ( row [ "PDU016" ] != null )
                    model . PDU016 = DateTime . Parse ( row [ "PDU016" ] . ToString ( ) );
            }

            return model;
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="contractNum"></param>
        /// <returns></returns>
        public DataTable printOne ( string contractNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT * FROM TENPDU " );
            strSql . AppendFormat ( "WHERE PDU001='{0}'" ,contractNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

    }
}
