
using DevExpress . XtraEditors;
using System;
using System . Collections;
using System . Collections . Generic;
using System . Data;
using System . IO;
using System . Reflection;
using System . Windows . Forms;

namespace Main
{
    public partial class Form1 :FormBase
    {
        MaterileEntity.MaterielPDAEntity _pda=null;
        MaterileEntity.MaterielPDUEntity _pdu=null;
        MaterileEntity.MaterielPDCEntity _pdc=null;
        MaterileEntity.MaterielPDBEntity _pdb=null;
        MaterielBll.Bll.MaterielBll _bll=null;
        bool isOk=false;int num=0;
        string state=string.Empty,strWhere="1=1",path=string.Empty;
        DataTable tableOne,tableTwo,tableTre,tableFor,printOne,printTwo, tableTwoBZ; DataRow row;
        List<DataTable> tableList=new List<DataTable>();
        List<MaterileEntity . MaterielPDCEntity > pdcList=new List<MaterileEntity.MaterielPDCEntity>();
        Hashtable table_one_pdc=new Hashtable();
        Hashtable table_two_pdc=new Hashtable();

        public Form1 ( )
        {
            InitializeComponent ( );

            _pda = new MaterileEntity . MaterielPDAEntity ( );
            _pdu = new MaterileEntity . MaterielPDUEntity ( );
            _pdc = new MaterileEntity . MaterielPDCEntity ( );
            _pdb = new MaterileEntity . MaterielPDBEntity ( );
            _bll = new MaterielBll . Bll . MaterielBll ( );
            tableOne = new DataTable ( );
            tableTwo = new DataTable ( );
            tableTre = new DataTable ( );
            printOne = new DataTable ( );
            printTwo = new DataTable ( );

            controlUnEnable ( );

            Utility . GridViewMoHuSelect . SetFilter ( bandedGridView1 );

            FieldInfo fi = typeof ( DevExpress . Utils . Paint . XPaint ) . GetField ( "graphics" ,BindingFlags . Static | BindingFlags . NonPublic );
            fi . SetValue ( null ,new  DrawXPaint ( ) );
        }

        #region Main
        protected override int Query ( )
        {
            strWhere = "SELECT PDU001 FROM TENPDU WHERE idx=(SELECT MIN(idx) FROM TENPDU)";
            _pdu . PDU001 = _bll . getNum ( strWhere );
            if ( _pdu . PDU001 != string . Empty )
            {
                _pdu = _bll . GetDataTableTwo ( _pdu . PDU001 );
                setValue ( );
                strWhere = "1=1" + " AND PDA001='" + _pdu . PDU001 + "'";
                tableOne = _bll . getDataTable ( strWhere );
                gridControl1 . DataSource = tableOne;
                tableFor = _bll . getDataTableEnclosure ( txtContrNum . Text );
                gridControl2 . DataSource = tableFor;

                tableQuery ( );

                queryTool ( );
            }
            return base . Query ( );
        }
        protected override int Add ( )
        {
            addTool ( );
            controlEnable ( );
            controlClear ( );
            state = "add";

            strWhere = "1=2";
            tableOne = _bll . getDataTable ( strWhere );
            gridControl1 . DataSource = tableOne;
            tableFor = _bll . getDataTableEnclosure ( txtContrNum . Text );
            gridControl2 . DataSource = tableFor;
            tableQuery ( );

            return base . Add ( );
        }
        protected override int Edit ( )
        {
            editTool ( );
            controlEnable ( );
            state = "edit";
            return base . Edit ( );
        }
        protected override int Delete ( )
        {
            if ( XtraMessageBox . Show ( "确认删除?" ,"删除" ,System . Windows . Forms . MessageBoxButtons . OKCancel ) == System . Windows . Forms . DialogResult . Cancel )
                return 0;
            
            _pda . PDA001 = txtContrNum . Text;
            isOk = _bll . Delete ( _pda . PDA001 );
            if ( isOk == true )
            {
                XtraMessageBox . Show ( "成功删除" );
                controlClear ( );
                controlUnEnable ( );
                deleteTool ( );
            }
            else
                XtraMessageBox . Show ( "删除失败" );

            return base . Delete ( );
        }
        protected override int Save ( )
        {
            if ( string . IsNullOrEmpty ( txtContrNum . Text ) )
            {
                XtraMessageBox . Show ( "合同编号不可为空" );
                return 0;
            }
            if ( checkGird ( ) == false )
                return 0;

            getValue ( );
            bandedGridView1 . CloseEditor ( );
            bandedGridView1 . UpdateCurrentRow ( );

            isOk = _bll . Add ( _pdu ,tableOne ,tableFor ,table_one_pdc ,table_two_pdc );
            if ( isOk == true )
            {
                XtraMessageBox . Show ( "保存成功" );
                saveTool ( );
                controlUnEnable ( );
            }
            else
                XtraMessageBox . Show ( "保存失败" );

            return base . Save ( );
        }
        protected override int Cancel ( )
        {
            cancelTool ( );
            controlUnEnable ( );

            if ( state . Equals ( "add" ) )
            {
                controlClear ( );
                toolEdit . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
                toolDelete . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
            }

            return base . Cancel ( );
        }
        protected override int Next ( )
        {
            if ( string . IsNullOrEmpty ( _pdu . idx . ToString ( ) ) )
                return 0;
            strWhere = "SELECT idx,PDU001 FROM TENPDU WHERE idx=(SELECT MIN(idx) FROM TENPDU WHERE idx>" + _pdu . idx + ")";
            _pdu . PDU001 = _bll . getNum ( strWhere );
            if ( _pdu . PDU001 != string . Empty )
            {
                _pdu = _bll . GetDataTableTwo ( _pdu . PDU001 );
                setValue ( );
                strWhere = "1=1" + " AND PDA001='" + _pdu . PDU001 + "'";
                tableOne = _bll . getDataTable ( strWhere );
                gridControl1 . DataSource = tableOne;
                tableFor = _bll . getDataTableEnclosure ( txtContrNum . Text );
                gridControl2 . DataSource = tableFor;

                tableQuery ( );

                queryTool ( );
            }

            return base . Next ( );
        }
        protected override int Prov ( )
        {
            if ( string . IsNullOrEmpty ( _pdu . idx . ToString ( ) ) )
                return 0;
            strWhere = "SELECT idx,PDU001 FROM TENPDU WHERE idx=(SELECT MAX(idx) FROM TENPDU WHERE idx<" + _pdu . idx + ")";
            _pdu . PDU001 = _bll . getNum ( strWhere );
            if ( _pdu . PDU001 != string . Empty )
            {
                _pdu = _bll . GetDataTableTwo ( _pdu . PDU001 );
                setValue ( );
                strWhere = "1=1" + " AND PDA001='" + _pdu . PDU001 + "'";
                tableOne = _bll . getDataTable ( strWhere );
                gridControl1 . DataSource = tableOne;
                tableFor = _bll . getDataTableEnclosure ( txtContrNum . Text );
                gridControl2 . DataSource = tableFor;

                tableQuery ( );

                queryTool ( );
            }

            return base . Prov ( );
        }
        protected override void Print ( )
        {
            if ( string . IsNullOrEmpty ( txtContrNum . Text ) )
            {
                XtraMessageBox . Show ( "合同编号不可为空" );
                return ;
            }

            printOrExport ( );
            Print ( new DataTable [ ] { printOne ,printTwo } ,"销售订单.frx" );

            base . Print ( );
        }
        protected override void Export ( )
        {
            if ( string . IsNullOrEmpty ( txtContrNum . Text ) )
            {
                XtraMessageBox . Show ( "合同编号不可为空" );
                return;
            }

            printOrExport ( );
            Export ( new DataTable [ ] { printOne ,printTwo } ,"销售订单.frx" );

            base . Export ( );
        }
        #endregion

        #region Method
        void controlEnable ( )
        {
            txtContrNum . Enabled = txtCusNum . Enabled = txtCusContr . Enabled = txtObj . Enabled = memoRemark . Enabled = txtBuy . Enabled = txtBuyAdd . Enabled = txtBuyPer . Enabled = txtBuyPh . Enabled = txtBuyTel . Enabled = txtSup . Enabled = txtSupAdd . Enabled = txtSupPer . Enabled = txtSupPh . Enabled = txtSupTel . Enabled = true;
            btnEn . Enabled = true;
            bandedGridView1 . OptionsBehavior . Editable = true;
            gridView1 . OptionsBehavior . Editable = true;
            deTime . Enabled = true;
        }
        void controlUnEnable ( )
        {
            txtContrNum . Enabled = txtCusNum . Enabled = txtCusContr . Enabled = txtObj . Enabled = memoRemark . Enabled = txtBuy . Enabled = txtBuyAdd . Enabled = txtBuyPer . Enabled = txtBuyPh . Enabled = txtBuyTel . Enabled = txtSup . Enabled = txtSupAdd . Enabled = txtSupPer . Enabled = txtSupPh . Enabled = txtSupTel . Enabled = false;
            btnEn . Enabled = false;
            bandedGridView1 . OptionsBehavior . Editable = false;
            gridView1 . OptionsBehavior . Editable = false;
            deTime . Enabled = false;
        }
        void controlClear ( )
        {
            txtContrNum . Text = txtCusNum . Text = txtCusContr . Text = txtObj . Text = memoRemark . Text = txtBuy . Text = txtBuyAdd . Text = txtBuyPer . Text = txtBuyPh . Text = txtBuyTel . Text = txtSup . Text = txtSupAdd . Text = txtSupPer . Text = txtSupPh . Text = txtSupTel . Text = string . Empty;
            gridControl1 . DataSource = null;
            gridControl2 . DataSource = null;
            deTime . Text = string . Empty;
        }
        void getValue ( )
        {
            _pdu . PDU001 = txtContrNum . Text;
            _pdu . PDU002 = txtCusContr . Text;
            _pdu . PDU003 = txtCusNum . Text;
            _pdu . PDU004 = txtObj . Text;
            _pdu . PDU005 = memoRemark . Text;
            _pdu . PDU006 = txtBuy . Text;
            _pdu . PDU007 = txtBuyPer . Text;
            _pdu . PDU008 = txtBuyAdd . Text;
            _pdu . PDU009 = txtBuyPh . Text;
            _pdu . PDU010 = txtBuyTel . Text;
            _pdu . PDU011 = txtSup . Text;
            _pdu . PDU012 = txtSupPer . Text;
            _pdu . PDU013 = txtSupAdd . Text;
            _pdu . PDU014 = txtSupPh . Text;
            _pdu . PDU015 = txtSupTel . Text;
            if ( string . IsNullOrEmpty ( deTime . Text ) )
                _pdu . PDU016 = null;
            else
                _pdu . PDU016 = Convert . ToDateTime ( deTime . Text );
        }
        void setValue ( )
        {
            txtContrNum . Text = _pdu . PDU001;
            txtCusContr . Text = _pdu . PDU002;
            txtCusNum . Text = _pdu . PDU003;
            txtObj . Text = _pdu . PDU004;
            memoRemark . Text = _pdu . PDU005;
            txtBuy . Text = _pdu . PDU006;
            txtBuyPer . Text = _pdu . PDU007;
            txtBuyAdd . Text = _pdu . PDU008;
            txtBuyPh . Text = _pdu . PDU009;
            txtBuyTel . Text = _pdu . PDU010;
            txtSup . Text = _pdu . PDU011;
            txtSupPer . Text = _pdu . PDU012;
            txtSupAdd . Text = _pdu . PDU013;
            txtSupPh . Text = _pdu . PDU014;
            txtSupTel . Text = _pdu . PDU015;
            if ( _pdu . PDU016 != null )
                deTime . Text = _pdu . PDU016 . ToString ( );
        }
        bool checkGird ( )
        {
            isOk = true;
            if ( bandedGridView1 . DataRowCount > 0 )
            {
                DataRow row;
                for ( int i = 0 ; i < bandedGridView1 . DataRowCount ; i++ )
                {
                    row = bandedGridView1 . GetDataRow ( i );
                    if ( row [ "PDA002" ] . ToString ( ) . Trim ( ) == string . Empty )
                    {
                        row . SetColumnError ( "PDA002" ,"不可为空" );
                        isOk = false;
                        break;
                    }
                    for ( int k = 0 ; k < bandedGridView1 . DataRowCount ; k++ )
                    {
                        if ( i != k )
                        {
                            if ( row [ "PDA002" ] . ToString ( ) . Trim ( ) . Equals ( bandedGridView1 . GetDataRow ( k ) [ "PDA002" ] . ToString ( ) ) )
                            {
                                row . SetColumnError ( "PDA002" ,"品号重复" );
                                isOk = false;
                                break;
                            }
                        }
                    }
                }
            }
            return isOk;
        }
        void printOrExport ( )
        {
            printOne = _bll . printOne ( txtContrNum . Text );
            printOne . TableName = "dbo_TENPDU";
            printTwo = _bll . getDataTable ( " PDA001='" + txtContrNum . Text + "'" );
            printTwo . TableName = "dbo_TENPDA";
        }
        #endregion

        #region Event
        //附件
        private void btnEn_Click ( object sender ,EventArgs e )
        {
            OpenFileDialog open = new OpenFileDialog ( );
            open . Filter = "所有文件|*";
            if ( open . ShowDialog ( ) == DialogResult . OK )
            {
                path = open . FileName;
                _pdb . PDB001 = txtContrNum . Text;
                _pdb . PDB002 = open . SafeFileName;
                _pdb . PDB003 =  Path . GetExtension ( path );
                _pdb . PDB004 = _bll . dtOne ( );

                FileStream fs = new FileStream ( path ,FileMode . Open ,FileAccess . Read );
                BinaryReader br = new BinaryReader ( fs );
                _pdb . PDB005 =  br . ReadBytes ( ( int ) fs . Length );
               
                row = tableFor . NewRow ( );
                row [ "PDB001" ] = _pdb . PDB001;
                row [ "PDB002" ] = _pdb . PDB002;
                row [ "PDB003" ] = _pdb . PDB003;
                row [ "PDB004" ] = _pdb . PDB004;
                row [ "PDB005" ] = _pdb . PDB005;
                tableFor . Rows . Add ( row );
            }

        }
        //标准配置
        void tableQuery ( )
        {
            MaterielBll . Bll . MaterielTwoBll _bllbz = new MaterielBll . Bll . MaterielTwoBll ( );
            _pdc = _bllbz . getDataTableOne ( txtContrNum . Text ,_pda . PDA002 );
            tableTwoBZ = _bllbz . getDataTable ( txtContrNum . Text ,_pda . PDA002 );
        }
        private void repositoryItemButtonEdit1_Click ( object sender ,EventArgs e )
        {
             num = bandedGridView1 . FocusedRowHandle;
            tableTre = new DataTable ( );
            _pdc = new MaterileEntity . MaterielPDCEntity ( );
            if ( num >= 0 && num <= bandedGridView1 . DataRowCount - 1 )
            {
                _pda . PDA002 = bandedGridView1 . GetDataRow ( num ) [ "PDA002" ] . ToString ( );
                _pda . PDA003 = bandedGridView1 . GetDataRow ( num ) [ "PDA003" ] . ToString ( );

                tableQuery ( );

                if ( table_two_pdc . ContainsKey ( _pda . PDA002 + _pda . PDA003 ) )
                {
                    _pdc = ( MaterileEntity . MaterielPDCEntity ) table_two_pdc [ _pda . PDA002 + _pda . PDA003 ];
                }
                if ( table_one_pdc . ContainsKey ( _pda . PDA002 + _pda . PDA003 ) )
                {
                    tableTwoBZ = ( DataTable ) table_one_pdc [ _pda . PDA002 + _pda . PDA003 ];
                }


                Form2 from = new Form2 ( tableTwoBZ ,_pdc ,txtContrNum . Text ,_pda . PDA002 ,_pda . PDA003 );
                DialogResult result = from . ShowDialog ( );
                if ( result == DialogResult . OK )
                {
                    tableTre = from . getTable;
                    if ( table_one_pdc . ContainsKey ( _pda . PDA002 + _pda . PDA003 ) )
                    {
                        table_one_pdc . Remove ( _pda . PDA002 + _pda . PDA003 );
                        table_one_pdc . Add ( _pda . PDA002 + _pda . PDA003 ,tableTre );
                    }
                    else
                        table_one_pdc . Add ( _pda . PDA002 + _pda . PDA003 ,tableTre );
                    _pdc = from . getPdc;
                    if ( table_two_pdc . ContainsKey ( _pda . PDA002 + _pda . PDA003 ) )
                    {
                        table_two_pdc . Remove ( _pda . PDA002 + _pda . PDA003 );
                        table_two_pdc . Add ( _pda . PDA002 + _pda . PDA003 ,_pdc = from . getPdc );
                    }
                    else
                        table_two_pdc . Add ( _pda . PDA002 + _pda . PDA003 ,_pdc = from . getPdc );
                }
            }
        }
        //删除
        private void repositoryItemButtonEdit2_Click ( object sender ,EventArgs e )
        {
            num = gridView1 . FocusedRowHandle;
            if ( num >= 0 && num <= gridView1 . RowCount - 1 )
            {
                if ( !string . IsNullOrEmpty ( gridView1 . GetDataRow ( num ) [ "PDB002" ] . ToString ( ) ) )
                {
                    if ( XtraMessageBox . Show ( "确认删除?" ,"删除" ,MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                        return;
                    row = tableFor . Rows [ num ];
                    tableFor . Rows . RemoveAt ( num );
                }
            }
        }
        //下载
        private void repositoryItemButtonEdit3_Click ( object sender ,EventArgs e )
        {
            num = gridView1 . FocusedRowHandle;
            if ( num >= 0 && num <= gridView1 . RowCount - 1 )
            {
                if ( ( ( byte [ ] ) gridView1 . GetDataRow ( num ) [ "PDB005" ] ) . Length == 0 )
                    return;
                _pdb . PDB005 = ( Byte [ ] ) gridView1 . GetDataRow ( num ) [ "PDB005" ];
                _pdb . PDB002 = gridView1 . GetDataRow ( num ) [ "PDB002" ] . ToString ( );

                SaveFileDialog save = new SaveFileDialog ( );
                save . Filter = "所有文件|*";
                save . FileName = _pdb . PDB002;
                if ( save . ShowDialog ( ) == DialogResult . OK )
                {
                    FileStream fs;
                    FileInfo fi = new System . IO . FileInfo ( save . FileName );
                    fs = fi . OpenWrite ( );
                    fs . Write ( _pdb . PDB005 ,0 ,_pdb . PDB005 . Length );
                    fs . Close ( );
                }
            }
        }
        #endregion

    }
}
