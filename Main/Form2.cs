using System . Data;

namespace Main
{
    public partial class Form2 :FormBase
    {
        MaterileEntity.MaterielPDCEntity _pdc=null;
        MaterileEntity.MaterielPDDEntity _pdd=null;
        MaterielBll.Bll.MaterielTwoBll _bll=null;
        DataTable table;

        public Form2 ( DataTable tableOne ,MaterileEntity . MaterielPDCEntity _pdc ,string ContrNum ,string productNum,string productName )
        {
            InitializeComponent ( );

            this . _pdc = new MaterileEntity . MaterielPDCEntity ( );
            _pdd = new MaterileEntity . MaterielPDDEntity ( );
            _bll = new MaterielBll . Bll . MaterielTwoBll ( );

            toolQuery . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
            toolAdd . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
            toolDelete . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
            toolEdit . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
            toolSave . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
            toolCancel . Visibility = DevExpress . XtraBars . BarItemVisibility . Always;
            toolProv . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
            toolNext . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
            toolPrint . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;
            toolExport . Visibility = DevExpress . XtraBars . BarItemVisibility . Never;

            this . txtContrNum . Text = ContrNum;
            this . txtCusNum . Tag = productNum;
            this . txtCusNum . Text = productName;

            this . table = tableOne;
            this . _pdc = _pdc;

            query ( );
        }

        void query ( )
        {
            //tableOne = _bll . getDataTableOne ( txtContrNum . Text ,txtCusNum . Tag . ToString ( ) );
            if ( _pdc != null  )
            {
                txtCusContr . Text = _pdc . PDC002;
                txtObj . Text = _pdc . PDC003;
            }
            else
                txtCusContr . Text = txtObj . Text = string . Empty;
            //table = _bll . getDataTable ( txtContrNum . Text ,txtCusNum . Tag . ToString ( ) );
            gridControl1 . DataSource = table;
           
        }

        protected override int Save ( )
        {
            gridView1 . CloseEditor ( );
            gridView1 . UpdateCurrentRow ( );
            
            _pdc . PDC001 = txtCusNum . Tag . ToString ( );
            _pdc . PDC002 = txtCusContr . Text;
            _pdc . PDC003 = txtObj . Text;
            _pdc . PDC005 = txtContrNum . Text;

            this . DialogResult = System . Windows . Forms . DialogResult . OK;
            return base . Save ( );
        }

        protected override int Cancel ( )
        {
            this . DialogResult = System . Windows . Forms . DialogResult . Cancel;
            return base . Cancel ( );
        }

        public DataTable getTable
        {
            get
            {
                return table;
            }
        }

        public MaterileEntity . MaterielPDCEntity getPdc
        {
            get
            {
                return _pdc;
            }
        }

        private void gridView1_InitNewRow ( object sender ,DevExpress . XtraGrid . Views . Grid . InitNewRowEventArgs e )
        {
            DevExpress . XtraGrid . Views . Grid . GridView view = sender as DevExpress . XtraGrid . Views . Grid . GridView;
            string str = ( gridView1 . RowCount  ) . ToString ( );
            str = str . PadLeft ( 3 ,'0' );
            view . SetRowCellValue ( e . RowHandle ,view . Columns [ "PDD002" ] ,str );
        }

    }
}