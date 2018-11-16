namespace Main
{
    partial class FormBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components . Dispose ( );
            }
            base . Dispose ( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ( )
        {
            this.components = new System.ComponentModel.Container();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.toolQuery = new DevExpress.XtraBars.BarButtonItem();
            this.toolAdd = new DevExpress.XtraBars.BarButtonItem();
            this.toolEdit = new DevExpress.XtraBars.BarButtonItem();
            this.toolDelete = new DevExpress.XtraBars.BarButtonItem();
            this.toolSave = new DevExpress.XtraBars.BarButtonItem();
            this.toolCancel = new DevExpress.XtraBars.BarButtonItem();
            this.toolProv = new DevExpress.XtraBars.BarButtonItem();
            this.toolNext = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.skinBarSubItem1 = new DevExpress.XtraBars.SkinBarSubItem();
            this.toolPrint = new DevExpress.XtraBars.BarButtonItem();
            this.toolExport = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.Appearance.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barDockControlTop.Appearance.Options.UseFont = true;
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 29);
            this.barDockControlTop.Manager = null;
            this.barDockControlTop.Size = new System.Drawing.Size(1149, 0);
            // 
            // bar1
            // 
            this.bar1.BarAppearance.Disabled.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bar1.BarAppearance.Disabled.Options.UseFont = true;
            this.bar1.BarAppearance.Hovered.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bar1.BarAppearance.Hovered.Options.UseFont = true;
            this.bar1.BarAppearance.Normal.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bar1.BarAppearance.Normal.Options.UseFont = true;
            this.bar1.BarAppearance.Pressed.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bar1.BarAppearance.Pressed.Options.UseFont = true;
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.Text = "Tools";
            // 
            // barManager1
            // 
            this.barManager1.AllowShowToolbarsPopup = false;
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControl1);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.toolQuery,
            this.barEditItem1,
            this.toolAdd,
            this.toolEdit,
            this.toolDelete,
            this.toolSave,
            this.toolCancel,
            this.skinBarSubItem1,
            this.toolNext,
            this.toolProv,
            this.toolPrint,
            this.toolExport});
            this.barManager1.MaxItemId = 22;
            this.barManager1.OptionsLayout.AllowAddNewItems = false;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1});
            // 
            // bar2
            // 
            this.bar2.BarAppearance.Disabled.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bar2.BarAppearance.Disabled.Options.UseFont = true;
            this.bar2.BarAppearance.Hovered.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bar2.BarAppearance.Hovered.Options.UseFont = true;
            this.bar2.BarAppearance.Normal.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bar2.BarAppearance.Normal.Options.UseFont = true;
            this.bar2.BarAppearance.Pressed.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bar2.BarAppearance.Pressed.Options.UseFont = true;
            this.bar2.BarName = "Tools";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.toolQuery),
            new DevExpress.XtraBars.LinkPersistInfo(this.toolAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.toolEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.toolDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.toolSave),
            new DevExpress.XtraBars.LinkPersistInfo(this.toolCancel),
            new DevExpress.XtraBars.LinkPersistInfo(this.toolPrint),
            new DevExpress.XtraBars.LinkPersistInfo(this.toolExport),
            new DevExpress.XtraBars.LinkPersistInfo(this.toolProv),
            new DevExpress.XtraBars.LinkPersistInfo(this.toolNext)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.Text = "Tools";
            // 
            // toolQuery
            // 
            this.toolQuery.Caption = "查询";
            this.toolQuery.Id = 0;
            this.toolQuery.Name = "toolQuery";
            this.toolQuery.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.toolQuery_ItemClick);
            // 
            // toolAdd
            // 
            this.toolAdd.Caption = "新增";
            this.toolAdd.Id = 2;
            this.toolAdd.Name = "toolAdd";
            this.toolAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.toolAdd_ItemClick);
            // 
            // toolEdit
            // 
            this.toolEdit.Caption = "编辑";
            this.toolEdit.Id = 3;
            this.toolEdit.Name = "toolEdit";
            this.toolEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.toolEdit_ItemClick);
            // 
            // toolDelete
            // 
            this.toolDelete.Caption = "删除";
            this.toolDelete.Id = 4;
            this.toolDelete.Name = "toolDelete";
            this.toolDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.toolDelete_ItemClick);
            // 
            // toolSave
            // 
            this.toolSave.Caption = "保存";
            this.toolSave.Id = 5;
            this.toolSave.Name = "toolSave";
            this.toolSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.toolSave_ItemClick);
            // 
            // toolCancel
            // 
            this.toolCancel.Caption = "取消";
            this.toolCancel.Id = 6;
            this.toolCancel.Name = "toolCancel";
            this.toolCancel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.toolCancel_ItemClick);
            // 
            // toolProv
            // 
            this.toolProv.Caption = "上一个";
            this.toolProv.Id = 19;
            this.toolProv.Name = "toolProv";
            this.toolProv.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.toolProv_ItemClick);
            // 
            // toolNext
            // 
            this.toolNext.Caption = "下一个";
            this.toolNext.Id = 18;
            this.toolNext.Name = "toolNext";
            this.toolNext.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.toolNext_ItemClick);
            // 
            // barDockControl1
            // 
            this.barDockControl1.Appearance.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barDockControl1.Appearance.Options.UseFont = true;
            this.barDockControl1.CausesValidation = false;
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControl1.Location = new System.Drawing.Point(0, 0);
            this.barDockControl1.Manager = this.barManager1;
            this.barDockControl1.Size = new System.Drawing.Size(1149, 29);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 451);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1149, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 29);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 422);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1149, 29);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 422);
            // 
            // barEditItem1
            // 
            this.barEditItem1.Caption = "barEditItem1";
            this.barEditItem1.Edit = this.repositoryItemTextEdit1;
            this.barEditItem1.Id = 1;
            this.barEditItem1.Name = "barEditItem1";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // skinBarSubItem1
            // 
            this.skinBarSubItem1.Caption = "skinBarSubItem1";
            this.skinBarSubItem1.Id = 7;
            this.skinBarSubItem1.Name = "skinBarSubItem1";
            // 
            // toolPrint
            // 
            this.toolPrint.Caption = "打印";
            this.toolPrint.Id = 20;
            this.toolPrint.Name = "toolPrint";
            this.toolPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.toolPrint_ItemClick);
            // 
            // toolExport
            // 
            this.toolExport.Caption = "导出";
            this.toolExport.Id = 21;
            this.toolExport.Name = "toolExport";
            this.toolExport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.toolExport_ItemClick);
            // 
            // FormBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 451);
            this.Controls.Add(this.barDockControlTop);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControl1);
            this.Name = "FormBase";
            this.Text = "FormMain";
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress . XtraBars . BarDockControl barDockControlTop;
        private DevExpress . XtraBars . Bar bar1;
        private DevExpress . XtraBars . BarManager barManager1;
        private DevExpress . XtraBars . BarDockControl barDockControl1;
        private DevExpress . XtraBars . BarDockControl barDockControlBottom;
        private DevExpress . XtraBars . BarDockControl barDockControlLeft;
        private DevExpress . XtraBars . BarDockControl barDockControlRight;
        private DevExpress . XtraBars . BarEditItem barEditItem1;
        private DevExpress . XtraEditors . Repository . RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress . XtraBars . SkinBarSubItem skinBarSubItem1;
        protected DevExpress . XtraBars . BarButtonItem toolQuery;
        protected DevExpress . XtraBars . BarButtonItem toolAdd;
        protected DevExpress . XtraBars . BarButtonItem toolEdit;
        protected DevExpress . XtraBars . BarButtonItem toolSave;
        protected DevExpress . XtraBars . BarButtonItem toolDelete;
        protected DevExpress . XtraBars . BarButtonItem toolCancel;
        protected DevExpress . XtraBars . Bar bar2;
        protected DevExpress . XtraBars . BarButtonItem toolNext;
        protected DevExpress . XtraBars . BarButtonItem toolProv;
        protected DevExpress . XtraBars . BarButtonItem toolPrint;
        protected DevExpress . XtraBars . BarButtonItem toolExport;
    }
}