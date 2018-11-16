using DevExpress . XtraBars;
using FastReport;
using FastReport . Export . Xml;
using System . Data;
using System . Windows . Forms;

namespace Main
{
    public partial class FormBase :DevExpress . XtraEditors . XtraForm
    {
        public FormBase ( )
        {
            InitializeComponent ( );

            this . toolQuery . Visibility = BarItemVisibility . Always;
            this . toolAdd . Visibility = BarItemVisibility . Always;
            this . toolEdit . Visibility = BarItemVisibility . Never;
            this . toolDelete . Visibility = BarItemVisibility . Never;
            this . toolSave . Visibility = BarItemVisibility . Never;
            this . toolCancel . Visibility = BarItemVisibility . Never;
            this . toolProv . Visibility = BarItemVisibility . Never;
            this . toolNext . Visibility = BarItemVisibility . Never;
            this . toolPrint . Visibility = BarItemVisibility . Never;
            this . toolExport . Visibility = BarItemVisibility . Never;

        }

    
        private void toolQuery_ItemClick ( object sender ,DevExpress . XtraBars . ItemClickEventArgs e )
        {
            Query ( );
        }

        protected virtual int Query ( )
        {
            return 0;
        }

        protected void queryTool ( )
        {
            this . toolQuery . Visibility = BarItemVisibility . Always;
            this . toolAdd . Visibility = BarItemVisibility . Always;
            this . toolEdit . Visibility = BarItemVisibility . Always;
            this . toolDelete . Visibility = BarItemVisibility . Always;
            this . toolSave . Visibility = BarItemVisibility . Never;
            this . toolCancel . Visibility = BarItemVisibility . Never;
            this . toolProv . Visibility = BarItemVisibility . Always;
            this . toolNext . Visibility = BarItemVisibility . Always;
            this . toolPrint . Visibility = BarItemVisibility . Always;
            this . toolExport . Visibility = BarItemVisibility . Always;
        }

        private void toolAdd_ItemClick ( object sender ,DevExpress . XtraBars . ItemClickEventArgs e )
        {
            Add ( );
        }

        protected virtual int Add ( )
        {
            return 0;
        }

        protected void addTool ( )
        {
            this . toolQuery . Visibility = BarItemVisibility . Never;
            this . toolAdd . Visibility = BarItemVisibility . Never;
            this . toolEdit . Visibility = BarItemVisibility . Never;
            this . toolDelete . Visibility = BarItemVisibility . Never;
            this . toolSave . Visibility = BarItemVisibility . Always;
            this . toolCancel . Visibility = BarItemVisibility . Always;
            this . toolProv . Visibility = BarItemVisibility . Never;
            this . toolNext . Visibility = BarItemVisibility . Never;
            this . toolPrint . Visibility = BarItemVisibility . Never;
            this . toolExport . Visibility = BarItemVisibility . Never;
        }

        private void toolEdit_ItemClick ( object sender ,DevExpress . XtraBars . ItemClickEventArgs e )
        {
            Edit ( );
        }

        protected virtual int Edit ( )
        {
            return 0;
        }

        protected void editTool ( )
        {
            this . toolQuery . Visibility = BarItemVisibility . Never;
            this . toolAdd . Visibility = BarItemVisibility . Never;
            this . toolEdit . Visibility = BarItemVisibility . Never;
            this . toolDelete . Visibility = BarItemVisibility . Never;
            this . toolSave . Visibility = BarItemVisibility . Always;
            this . toolCancel . Visibility = BarItemVisibility . Always;
            this . toolProv . Visibility = BarItemVisibility . Never;
            this . toolNext . Visibility = BarItemVisibility . Never;
            this . toolPrint . Visibility = BarItemVisibility . Never;
            this . toolExport . Visibility = BarItemVisibility . Never;
        }

        private void toolDelete_ItemClick ( object sender ,DevExpress . XtraBars . ItemClickEventArgs e )
        {
            Delete ( );
        }

        protected virtual int Delete ( )
        {
            return 0;
        }

        protected void deleteTool ( )
        {
            this . toolQuery . Visibility = BarItemVisibility . Always;
            this . toolAdd . Visibility = BarItemVisibility . Always;
            this . toolEdit . Visibility = BarItemVisibility . Never;
            this . toolDelete . Visibility = BarItemVisibility . Never;
            this . toolSave . Visibility = BarItemVisibility . Never;
            this . toolCancel . Visibility = BarItemVisibility . Never;
            this . toolProv . Visibility = BarItemVisibility . Always;
            this . toolNext . Visibility = BarItemVisibility . Always;
            this . toolPrint . Visibility = BarItemVisibility . Always;
            this . toolExport . Visibility = BarItemVisibility . Always;
        }

        private void toolSave_ItemClick ( object sender ,DevExpress . XtraBars . ItemClickEventArgs e )
        {
            Save ( );
        }

        protected virtual int Save ( )
        {
            return 0;
        }

        protected void saveTool ( )
        {
            this . toolQuery . Visibility = BarItemVisibility . Always;
            this . toolAdd . Visibility = BarItemVisibility . Always;
            this . toolEdit . Visibility = BarItemVisibility . Always;
            this . toolDelete . Visibility = BarItemVisibility . Always;
            this . toolSave . Visibility = BarItemVisibility . Never;
            this . toolCancel . Visibility = BarItemVisibility . Never;
            this . toolProv . Visibility = BarItemVisibility . Always;
            this . toolNext . Visibility = BarItemVisibility . Always;
            this . toolPrint . Visibility = BarItemVisibility . Always;
            this . toolExport . Visibility = BarItemVisibility . Always;
        }

        private void toolCancel_ItemClick ( object sender ,DevExpress . XtraBars . ItemClickEventArgs e )
        {
            Cancel ( );
        }

        protected virtual int Cancel ( )
        {
            return 0;
        }

        protected void cancelTool ( )
        {
            this . toolQuery . Visibility = BarItemVisibility . Always;
            this . toolAdd . Visibility = BarItemVisibility . Always;
            this . toolEdit . Visibility = BarItemVisibility . Always;
            this . toolDelete . Visibility = BarItemVisibility . Always;
            this . toolSave . Visibility = BarItemVisibility . Never;
            this . toolCancel . Visibility = BarItemVisibility . Never;
            this . toolProv . Visibility = BarItemVisibility . Always;
            this . toolNext . Visibility = BarItemVisibility . Always;
            this . toolPrint . Visibility = BarItemVisibility . Always;
            this . toolExport . Visibility = BarItemVisibility . Always;
        }

        private void toolProv_ItemClick ( object sender ,ItemClickEventArgs e )
        {
            Prov ( );
        }

        protected virtual int Prov ( )
        {
            return 0;
        }

        private void toolNext_ItemClick ( object sender ,ItemClickEventArgs e )
        {
            Next ( );
        }

        protected virtual int Next ( )
        {
            return 0;
        }

        private void toolPrint_ItemClick ( object sender ,ItemClickEventArgs e )
        {
            Print ( );
        }

        protected virtual void Print ( )
        {

        }

        protected void Print (DataTable[] table,string fileName )
        {
            DataSet ds = new DataSet ( );
            if ( table . Length > 0 )
            {
                for ( int i = 0 ; i < table . Length ; i++ )
                {
                    ds . Tables . Add ( table [ i ] );
                }
            }

            if ( ds != null && ds . Tables . Count > 0 )
            {
                string file = Application . StartupPath + "\\" + fileName + "";
                Report report = new Report ( );
                report . Load ( file );
                report . RegisterData ( ds );
                report . Show ( );
            }
        }

        private void toolExport_ItemClick ( object sender ,ItemClickEventArgs e )
        {
            Export ( );
        }

        protected virtual void Export ( )
        {

        }

        protected void Export ( DataTable [ ] table ,string fileName )
        {
            DataSet ds = new DataSet ( );
            if ( table . Length > 0 )
            {
                for ( int i = 0 ; i < table . Length ; i++ )
                {
                    ds . Tables . Add ( table [ i ] );
                }
            }

            if ( ds != null && ds . Tables . Count > 0 )
            {
                string file = Application . StartupPath + "\\" + fileName + "";
                Report report = new Report ( );
                report . Load ( file );
                report . RegisterData ( ds );
                report . Prepare ( );
                XMLExport exprots = new XMLExport ( );
                exprots . Export ( report );
            }
        }

    }
}