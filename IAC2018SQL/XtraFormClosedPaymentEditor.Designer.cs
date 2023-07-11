namespace IAC2021SQL
{
    partial class XtraFormClosedPaymentEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions4 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XtraFormClosedPaymentEditor));
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions5 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions windowsUIButtonImageOptions6 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonImageOptions();
            this.iacDataSet = new IAC2021SQL.IACDataSet();
            this.bindingSourceCUSTOMER = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceDEALER = new System.Windows.Forms.BindingSource(this.components);
            this.customerTableAdapter = new IAC2021SQL.IACDataSetTableAdapters.CUSTOMERTableAdapter();
            this.paycodeTableAdapter = new IAC2021SQL.IACDataSetTableAdapters.PAYCODETableAdapter();
            this.bindingSourcePAYMENT = new System.Windows.Forms.BindingSource(this.components);
            this.paymenttypeTableAdapter = new IAC2021SQL.IACDataSetTableAdapters.PAYMENTTYPETableAdapter();
            this.dataLayoutPayment = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.windowsUIButtonPanel1 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel();
            this.textEditExtensionCount = new DevExpress.XtraEditors.TextEdit();
            this.textEditAmount = new DevExpress.XtraEditors.TextEdit();
            this.dateEditISFDate = new DevExpress.XtraEditors.DateEdit();
            this.textEditIncome = new DevExpress.XtraEditors.TextEdit();
            this.textEditOverPayment = new DevExpress.XtraEditors.TextEdit();
            this.checkEditEFT = new DevExpress.XtraEditors.CheckEdit();
            this.dateEditPaymentDate = new DevExpress.XtraEditors.DateEdit();
            this.lookUpEditPaymentType = new DevExpress.XtraEditors.LookUpEdit();
            this.bindingSourcePAYMENTTYPE = new System.Windows.Forms.BindingSource(this.components);
            this.lookUpEditPaymentCode = new DevExpress.XtraEditors.LookUpEdit();
            this.bindingSourcePAYCODE = new System.Windows.Forms.BindingSource(this.components);
            this.textEditPaidThrough = new DevExpress.XtraEditors.TextEdit();
            this.textEditBuyout = new DevExpress.XtraEditors.TextEdit();
            this.textEditBalance = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.buttonChangeISFDate = new DevExpress.XtraEditors.SimpleButton();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlPaidThrough = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlLoanBalance = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlBuyout = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlPaymentDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem7 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlOverPayment = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlIncome = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlISFDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlChangeISFDateButton = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem6 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlPaymentType = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlPaymentCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem9 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem10 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlAmount = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem12 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlExtensionCount = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem8 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem11 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.paymentTableAdapter = new IAC2021SQL.IACDataSetTableAdapters.PAYMENTTableAdapter();
            this.dealerTableAdapter = new IAC2021SQL.IACDataSetTableAdapters.DEALERTableAdapter();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControlCustomerHeader = new DevExpress.XtraLayout.LayoutControl();
            this.textEditDealerName = new DevExpress.XtraEditors.TextEdit();
            this.textEditDealerID = new DevExpress.XtraEditors.TextEdit();
            this.textEditLastName = new DevExpress.XtraEditors.TextEdit();
            this.textEditFirstName = new DevExpress.XtraEditors.TextEdit();
            this.textEditCustomerID = new DevExpress.XtraEditors.GridLookUpEdit();
            this.bindingSourceCustomerLookup = new System.Windows.Forms.BindingSource(this.components);
            this.customerLookupDataSet = new IAC2021SQL.IACDataSet();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCustomerID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCUSTOMER_FIRST_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCUSTOMER_LAST_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlCustomerID = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutFirstName = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutLastName = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlDealerName = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlDealerID = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lookUpEditCustomerID = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.iacDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCUSTOMER)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDEALER)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePAYMENT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutPayment)).BeginInit();
            this.dataLayoutPayment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditExtensionCount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditISFDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditISFDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditIncome.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditOverPayment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditEFT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditPaymentDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditPaymentDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditPaymentType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePAYMENTTYPE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditPaymentCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePAYCODE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditPaidThrough.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditBuyout.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditBalance.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlPaidThrough)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlLoanBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlBuyout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlPaymentDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlOverPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlIncome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlISFDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlChangeISFDateButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlPaymentType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlPaymentCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlExtensionCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlCustomerHeader)).BeginInit();
            this.layoutControlCustomerHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditDealerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditDealerID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditLastName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditFirstName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditCustomerID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCustomerLookup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerLookupDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlCustomerID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutFirstName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutLastName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlDealerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlDealerID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditCustomerID.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // iacDataSet
            // 
            this.iacDataSet.DataSetName = "IACDataSet";
            this.iacDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingSourceCUSTOMER
            // 
            this.bindingSourceCUSTOMER.DataMember = "CUSTOMER";
            this.bindingSourceCUSTOMER.DataSource = this.iacDataSet;
            // 
            // bindingSourceDEALER
            // 
            this.bindingSourceDEALER.DataMember = "DEALER";
            this.bindingSourceDEALER.DataSource = this.iacDataSet;
            // 
            // customerTableAdapter
            // 
            this.customerTableAdapter.ClearBeforeFill = true;
            // 
            // paycodeTableAdapter
            // 
            this.paycodeTableAdapter.ClearBeforeFill = true;
            // 
            // bindingSourcePAYMENT
            // 
            this.bindingSourcePAYMENT.DataMember = "PAYMENT";
            this.bindingSourcePAYMENT.DataSource = this.iacDataSet;
            // 
            // paymenttypeTableAdapter
            // 
            this.paymenttypeTableAdapter.ClearBeforeFill = true;
            // 
            // dataLayoutPayment
            // 
            this.dataLayoutPayment.Controls.Add(this.windowsUIButtonPanel1);
            this.dataLayoutPayment.Controls.Add(this.textEditExtensionCount);
            this.dataLayoutPayment.Controls.Add(this.textEditAmount);
            this.dataLayoutPayment.Controls.Add(this.dateEditISFDate);
            this.dataLayoutPayment.Controls.Add(this.textEditIncome);
            this.dataLayoutPayment.Controls.Add(this.textEditOverPayment);
            this.dataLayoutPayment.Controls.Add(this.checkEditEFT);
            this.dataLayoutPayment.Controls.Add(this.dateEditPaymentDate);
            this.dataLayoutPayment.Controls.Add(this.lookUpEditPaymentType);
            this.dataLayoutPayment.Controls.Add(this.lookUpEditPaymentCode);
            this.dataLayoutPayment.Controls.Add(this.textEditPaidThrough);
            this.dataLayoutPayment.Controls.Add(this.textEditBuyout);
            this.dataLayoutPayment.Controls.Add(this.textEditBalance);
            this.dataLayoutPayment.Controls.Add(this.simpleButton1);
            this.dataLayoutPayment.Controls.Add(this.buttonChangeISFDate);
            this.dataLayoutPayment.DataSource = this.iacDataSet;
            this.dataLayoutPayment.Location = new System.Drawing.Point(12, 12);
            this.dataLayoutPayment.Name = "dataLayoutPayment";
            this.dataLayoutPayment.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1163, 0, 650, 400);
            this.dataLayoutPayment.Root = this.Root;
            this.dataLayoutPayment.Size = new System.Drawing.Size(763, 423);
            this.dataLayoutPayment.TabIndex = 0;
            this.dataLayoutPayment.Text = "dataLayoutControl1";
            // 
            // windowsUIButtonPanel1
            // 
            this.windowsUIButtonPanel1.AllowGlyphSkinning = false;
            this.windowsUIButtonPanel1.AppearanceButton.Hovered.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.windowsUIButtonPanel1.AppearanceButton.Hovered.Options.UseFont = true;
            this.windowsUIButtonPanel1.AppearanceButton.Normal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.windowsUIButtonPanel1.AppearanceButton.Normal.Options.UseFont = true;
            this.windowsUIButtonPanel1.AppearanceButton.Pressed.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.windowsUIButtonPanel1.AppearanceButton.Pressed.Options.UseFont = true;
            windowsUIButtonImageOptions4.Image = ((System.Drawing.Image)(resources.GetObject("windowsUIButtonImageOptions4.Image")));
            windowsUIButtonImageOptions5.Image = ((System.Drawing.Image)(resources.GetObject("windowsUIButtonImageOptions5.Image")));
            windowsUIButtonImageOptions6.Image = ((System.Drawing.Image)(resources.GetObject("windowsUIButtonImageOptions6.Image")));
            this.windowsUIButtonPanel1.Buttons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Search", true, windowsUIButtonImageOptions4, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Save", true, windowsUIButtonImageOptions5, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton("Close", true, windowsUIButtonImageOptions6, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1, false)});
            this.windowsUIButtonPanel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.windowsUIButtonPanel1.Location = new System.Drawing.Point(12, 348);
            this.windowsUIButtonPanel1.Name = "windowsUIButtonPanel1";
            this.windowsUIButtonPanel1.Size = new System.Drawing.Size(739, 63);
            this.windowsUIButtonPanel1.TabIndex = 4;
            this.windowsUIButtonPanel1.Text = "windowsUIButtonPanel1";
            this.windowsUIButtonPanel1.ButtonClick += new DevExpress.XtraBars.Docking2010.ButtonEventHandler(this.windowsUIButtonPanel1_ButtonClick);
            // 
            // textEditExtensionCount
            // 
            this.textEditExtensionCount.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSourcePAYMENT, "PAYMENT_THRU_UD", true));
            this.textEditExtensionCount.Location = new System.Drawing.Point(524, 172);
            this.textEditExtensionCount.Name = "textEditExtensionCount";
            this.textEditExtensionCount.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEditExtensionCount.Properties.Appearance.Options.UseFont = true;
            this.textEditExtensionCount.Properties.Appearance.Options.UseTextOptions = true;
            this.textEditExtensionCount.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.textEditExtensionCount.Properties.DisplayFormat.FormatString = "n0";
            this.textEditExtensionCount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.textEditExtensionCount.Size = new System.Drawing.Size(50, 28);
            this.textEditExtensionCount.StyleController = this.dataLayoutPayment;
            this.textEditExtensionCount.TabIndex = 18;
            this.textEditExtensionCount.EditValueChanged += new System.EventHandler(this.textEditExtensionCount_EditValueChanged);
            // 
            // textEditAmount
            // 
            this.textEditAmount.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSourcePAYMENT, "PAYMENT_AMOUNT_RCV", true));
            this.textEditAmount.Location = new System.Drawing.Point(141, 140);
            this.textEditAmount.Name = "textEditAmount";
            this.textEditAmount.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEditAmount.Properties.Appearance.Options.UseFont = true;
            this.textEditAmount.Properties.Appearance.Options.UseTextOptions = true;
            this.textEditAmount.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.textEditAmount.Properties.DisplayFormat.FormatString = "c2";
            this.textEditAmount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.textEditAmount.Size = new System.Drawing.Size(96, 28);
            this.textEditAmount.StyleController = this.dataLayoutPayment;
            this.textEditAmount.TabIndex = 17;
            this.textEditAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            // 
            // dateEditISFDate
            // 
            this.dateEditISFDate.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSourcePAYMENT, "PAYMENT_ISF_DATE", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "d"));
            this.dateEditISFDate.EditValue = null;
            this.dateEditISFDate.Location = new System.Drawing.Point(525, 108);
            this.dateEditISFDate.Name = "dateEditISFDate";
            this.dateEditISFDate.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateEditISFDate.Properties.Appearance.Options.UseFont = true;
            this.dateEditISFDate.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateEditISFDate.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.dateEditISFDate.Properties.AppearanceDisabled.Options.UseFont = true;
            this.dateEditISFDate.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.dateEditISFDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditISFDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditISFDate.Size = new System.Drawing.Size(115, 28);
            this.dateEditISFDate.StyleController = this.dataLayoutPayment;
            this.dateEditISFDate.TabIndex = 14;
            // 
            // textEditIncome
            // 
            this.textEditIncome.Location = new System.Drawing.Point(525, 76);
            this.textEditIncome.Name = "textEditIncome";
            this.textEditIncome.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEditIncome.Properties.Appearance.Options.UseFont = true;
            this.textEditIncome.Properties.DisplayFormat.FormatString = "c2";
            this.textEditIncome.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.textEditIncome.Size = new System.Drawing.Size(74, 28);
            this.textEditIncome.StyleController = this.dataLayoutPayment;
            this.textEditIncome.TabIndex = 13;
            this.textEditIncome.Visible = false;
            // 
            // textEditOverPayment
            // 
            this.textEditOverPayment.Location = new System.Drawing.Point(525, 44);
            this.textEditOverPayment.Name = "textEditOverPayment";
            this.textEditOverPayment.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEditOverPayment.Properties.Appearance.Options.UseFont = true;
            this.textEditOverPayment.Properties.DisplayFormat.FormatString = "c2";
            this.textEditOverPayment.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.textEditOverPayment.Size = new System.Drawing.Size(73, 28);
            this.textEditOverPayment.StyleController = this.dataLayoutPayment;
            this.textEditOverPayment.TabIndex = 12;
            this.textEditOverPayment.Visible = false;
            // 
            // checkEditEFT
            // 
            this.checkEditEFT.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSourcePAYMENT, "PAYMENT_AUTO_PAY", true));
            this.checkEditEFT.Location = new System.Drawing.Point(12, 236);
            this.checkEditEFT.Name = "checkEditEFT";
            this.checkEditEFT.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkEditEFT.Properties.Appearance.Options.UseFont = true;
            this.checkEditEFT.Properties.Appearance.Options.UseTextOptions = true;
            this.checkEditEFT.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.checkEditEFT.Properties.Caption = "EFT?";
            this.checkEditEFT.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.SvgCheckBox1;
            this.checkEditEFT.Properties.ContentAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.checkEditEFT.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.checkEditEFT.Size = new System.Drawing.Size(197, 25);
            this.checkEditEFT.StyleController = this.dataLayoutPayment;
            this.checkEditEFT.TabIndex = 11;
            this.checkEditEFT.QueryCheckStateByValue += new DevExpress.XtraEditors.Controls.QueryCheckStateByValueEventHandler(this.checkEditEFT_QueryCheckStateByValue);
            this.checkEditEFT.QueryValueByCheckState += new DevExpress.XtraEditors.Controls.QueryValueByCheckStateEventHandler(this.checkEditEFT_QueryValueByCheckState);
            // 
            // dateEditPaymentDate
            // 
            this.dateEditPaymentDate.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSourcePAYMENT, "PAYMENT_DATE", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "d"));
            this.dateEditPaymentDate.EditValue = null;
            this.dateEditPaymentDate.Location = new System.Drawing.Point(141, 108);
            this.dateEditPaymentDate.Name = "dateEditPaymentDate";
            this.dateEditPaymentDate.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateEditPaymentDate.Properties.Appearance.Options.UseFont = true;
            this.dateEditPaymentDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditPaymentDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditPaymentDate.Size = new System.Drawing.Size(116, 28);
            this.dateEditPaymentDate.StyleController = this.dataLayoutPayment;
            this.dateEditPaymentDate.TabIndex = 10;
            this.dateEditPaymentDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            // 
            // lookUpEditPaymentType
            // 
            this.lookUpEditPaymentType.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSourcePAYMENT, "PAYMENT_TYPE", true));
            this.lookUpEditPaymentType.Location = new System.Drawing.Point(141, 172);
            this.lookUpEditPaymentType.Name = "lookUpEditPaymentType";
            this.lookUpEditPaymentType.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookUpEditPaymentType.Properties.Appearance.Options.UseFont = true;
            this.lookUpEditPaymentType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditPaymentType.Properties.DataSource = this.bindingSourcePAYMENTTYPE;
            this.lookUpEditPaymentType.Properties.DisplayMember = "TYPE";
            this.lookUpEditPaymentType.Properties.NullText = "";
            this.lookUpEditPaymentType.Properties.ValueMember = "TYPE";
            this.lookUpEditPaymentType.Size = new System.Drawing.Size(68, 28);
            this.lookUpEditPaymentType.StyleController = this.dataLayoutPayment;
            this.lookUpEditPaymentType.TabIndex = 9;
            this.lookUpEditPaymentType.EditValueChanged += new System.EventHandler(this.lookUpEditPaymentType_EditValueChanged);
            // 
            // bindingSourcePAYMENTTYPE
            // 
            this.bindingSourcePAYMENTTYPE.DataMember = "PAYMENTTYPE";
            this.bindingSourcePAYMENTTYPE.DataSource = this.iacDataSet;
            // 
            // lookUpEditPaymentCode
            // 
            this.lookUpEditPaymentCode.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSourcePAYMENT, "PAYMENT_CODE_2", true));
            this.lookUpEditPaymentCode.Location = new System.Drawing.Point(141, 204);
            this.lookUpEditPaymentCode.Name = "lookUpEditPaymentCode";
            this.lookUpEditPaymentCode.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookUpEditPaymentCode.Properties.Appearance.Options.UseFont = true;
            this.lookUpEditPaymentCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditPaymentCode.Properties.DataSource = this.bindingSourcePAYCODE;
            this.lookUpEditPaymentCode.Properties.DisplayMember = "CODE";
            this.lookUpEditPaymentCode.Properties.NullText = "";
            this.lookUpEditPaymentCode.Properties.ValueMember = "CODE";
            this.lookUpEditPaymentCode.Size = new System.Drawing.Size(68, 28);
            this.lookUpEditPaymentCode.StyleController = this.dataLayoutPayment;
            this.lookUpEditPaymentCode.TabIndex = 8;
            // 
            // bindingSourcePAYCODE
            // 
            this.bindingSourcePAYCODE.DataMember = "PAYCODE";
            this.bindingSourcePAYCODE.DataSource = this.iacDataSet;
            // 
            // textEditPaidThrough
            // 
            this.textEditPaidThrough.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSourceCUSTOMER, "CUSTOMER_PAID_THRU", true));
            this.textEditPaidThrough.Location = new System.Drawing.Point(141, 76);
            this.textEditPaidThrough.Name = "textEditPaidThrough";
            this.textEditPaidThrough.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEditPaidThrough.Properties.Appearance.Options.UseFont = true;
            this.textEditPaidThrough.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEditPaidThrough.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.textEditPaidThrough.Properties.AppearanceDisabled.Options.UseFont = true;
            this.textEditPaidThrough.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.textEditPaidThrough.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.SimpleMaskManager));
            this.textEditPaidThrough.Properties.MaskSettings.Set("mask", "00/00");
            this.textEditPaidThrough.Properties.MaskSettings.Set("saveLiterals", false);
            this.textEditPaidThrough.Properties.UseMaskAsDisplayFormat = true;
            this.textEditPaidThrough.Size = new System.Drawing.Size(67, 28);
            this.textEditPaidThrough.StyleController = this.dataLayoutPayment;
            this.textEditPaidThrough.TabIndex = 6;
            // 
            // textEditBuyout
            // 
            this.textEditBuyout.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSourceCUSTOMER, "CUSTOMER_BUYOUT", true));
            this.textEditBuyout.Location = new System.Drawing.Point(141, 44);
            this.textEditBuyout.Name = "textEditBuyout";
            this.textEditBuyout.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEditBuyout.Properties.Appearance.Options.UseFont = true;
            this.textEditBuyout.Properties.Appearance.Options.UseTextOptions = true;
            this.textEditBuyout.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.textEditBuyout.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEditBuyout.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.textEditBuyout.Properties.AppearanceDisabled.Options.UseFont = true;
            this.textEditBuyout.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.textEditBuyout.Properties.DisplayFormat.FormatString = "c2";
            this.textEditBuyout.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.textEditBuyout.Size = new System.Drawing.Size(96, 28);
            this.textEditBuyout.StyleController = this.dataLayoutPayment;
            this.textEditBuyout.TabIndex = 5;
            // 
            // textEditBalance
            // 
            this.textEditBalance.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSourceCUSTOMER, "CUSTOMER_BALANCE", true));
            this.textEditBalance.Location = new System.Drawing.Point(141, 12);
            this.textEditBalance.Name = "textEditBalance";
            this.textEditBalance.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEditBalance.Properties.Appearance.Options.UseFont = true;
            this.textEditBalance.Properties.Appearance.Options.UseTextOptions = true;
            this.textEditBalance.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.textEditBalance.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEditBalance.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.textEditBalance.Properties.AppearanceDisabled.Options.UseFont = true;
            this.textEditBalance.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.textEditBalance.Properties.DisplayFormat.FormatString = "c2";
            this.textEditBalance.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.textEditBalance.Size = new System.Drawing.Size(96, 28);
            this.textEditBalance.StyleController = this.dataLayoutPayment;
            this.textEditBalance.TabIndex = 4;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(799, 259);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(83, 22);
            this.simpleButton1.StyleController = this.dataLayoutPayment;
            this.simpleButton1.TabIndex = 15;
            this.simpleButton1.Text = "simpleButton1";
            // 
            // buttonChangeISFDate
            // 
            this.buttonChangeISFDate.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonChangeISFDate.Appearance.Options.UseFont = true;
            this.buttonChangeISFDate.Location = new System.Drawing.Point(644, 111);
            this.buttonChangeISFDate.Name = "buttonChangeISFDate";
            this.buttonChangeISFDate.Size = new System.Drawing.Size(107, 22);
            this.buttonChangeISFDate.StyleController = this.dataLayoutPayment;
            this.buttonChangeISFDate.TabIndex = 16;
            this.buttonChangeISFDate.Text = "Change &ISF Date";
            this.buttonChangeISFDate.Click += new System.EventHandler(this.buttonChangeISFDate_Click);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlPaidThrough,
            this.emptySpaceItem3,
            this.layoutControlLoanBalance,
            this.layoutControlBuyout,
            this.layoutControlPaymentDate,
            this.emptySpaceItem7,
            this.layoutControlOverPayment,
            this.layoutControlIncome,
            this.emptySpaceItem2,
            this.emptySpaceItem1,
            this.layoutControlISFDate,
            this.layoutControlChangeISFDateButton,
            this.emptySpaceItem5,
            this.emptySpaceItem4,
            this.emptySpaceItem6,
            this.layoutControlPaymentType,
            this.layoutControlPaymentCode,
            this.emptySpaceItem9,
            this.emptySpaceItem10,
            this.layoutControlAmount,
            this.emptySpaceItem12,
            this.layoutControlExtensionCount,
            this.emptySpaceItem8,
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.emptySpaceItem11});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(763, 423);
            this.Root.TextVisible = false;
            // 
            // layoutControlPaidThrough
            // 
            this.layoutControlPaidThrough.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlPaidThrough.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlPaidThrough.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlPaidThrough.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlPaidThrough.AppearanceItemCaptionDisabled.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlPaidThrough.AppearanceItemCaptionDisabled.ForeColor = System.Drawing.Color.Black;
            this.layoutControlPaidThrough.AppearanceItemCaptionDisabled.Options.UseFont = true;
            this.layoutControlPaidThrough.AppearanceItemCaptionDisabled.Options.UseForeColor = true;
            this.layoutControlPaidThrough.Control = this.textEditPaidThrough;
            this.layoutControlPaidThrough.Location = new System.Drawing.Point(0, 64);
            this.layoutControlPaidThrough.Name = "layoutControlPaidThrough";
            this.layoutControlPaidThrough.Size = new System.Drawing.Size(200, 32);
            this.layoutControlPaidThrough.Text = "Paid Through";
            this.layoutControlPaidThrough.TextSize = new System.Drawing.Size(125, 21);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(229, 0);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(514, 32);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlLoanBalance
            // 
            this.layoutControlLoanBalance.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlLoanBalance.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlLoanBalance.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlLoanBalance.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlLoanBalance.AppearanceItemCaptionDisabled.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlLoanBalance.AppearanceItemCaptionDisabled.ForeColor = System.Drawing.Color.Black;
            this.layoutControlLoanBalance.AppearanceItemCaptionDisabled.Options.UseFont = true;
            this.layoutControlLoanBalance.AppearanceItemCaptionDisabled.Options.UseForeColor = true;
            this.layoutControlLoanBalance.Control = this.textEditBalance;
            this.layoutControlLoanBalance.Location = new System.Drawing.Point(0, 0);
            this.layoutControlLoanBalance.Name = "layoutControlLoanBalance";
            this.layoutControlLoanBalance.Size = new System.Drawing.Size(229, 32);
            this.layoutControlLoanBalance.Text = "Loan Balance";
            this.layoutControlLoanBalance.TextSize = new System.Drawing.Size(125, 21);
            // 
            // layoutControlBuyout
            // 
            this.layoutControlBuyout.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlBuyout.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlBuyout.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlBuyout.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlBuyout.AppearanceItemCaptionDisabled.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlBuyout.AppearanceItemCaptionDisabled.ForeColor = System.Drawing.Color.Black;
            this.layoutControlBuyout.AppearanceItemCaptionDisabled.Options.UseFont = true;
            this.layoutControlBuyout.AppearanceItemCaptionDisabled.Options.UseForeColor = true;
            this.layoutControlBuyout.Control = this.textEditBuyout;
            this.layoutControlBuyout.Location = new System.Drawing.Point(0, 32);
            this.layoutControlBuyout.Name = "layoutControlBuyout";
            this.layoutControlBuyout.Size = new System.Drawing.Size(229, 32);
            this.layoutControlBuyout.Text = "Buyout";
            this.layoutControlBuyout.TextSize = new System.Drawing.Size(125, 21);
            // 
            // layoutControlPaymentDate
            // 
            this.layoutControlPaymentDate.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlPaymentDate.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlPaymentDate.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlPaymentDate.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlPaymentDate.Control = this.dateEditPaymentDate;
            this.layoutControlPaymentDate.Location = new System.Drawing.Point(0, 96);
            this.layoutControlPaymentDate.Name = "layoutControlPaymentDate";
            this.layoutControlPaymentDate.Size = new System.Drawing.Size(249, 32);
            this.layoutControlPaymentDate.Text = "Date";
            this.layoutControlPaymentDate.TextSize = new System.Drawing.Size(125, 21);
            // 
            // emptySpaceItem7
            // 
            this.emptySpaceItem7.AllowHotTrack = false;
            this.emptySpaceItem7.Location = new System.Drawing.Point(201, 224);
            this.emptySpaceItem7.Name = "emptySpaceItem7";
            this.emptySpaceItem7.Size = new System.Drawing.Size(542, 29);
            this.emptySpaceItem7.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlOverPayment
            // 
            this.layoutControlOverPayment.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlOverPayment.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlOverPayment.Control = this.textEditOverPayment;
            this.layoutControlOverPayment.Location = new System.Drawing.Point(384, 32);
            this.layoutControlOverPayment.Name = "layoutControlOverPayment";
            this.layoutControlOverPayment.Size = new System.Drawing.Size(206, 32);
            this.layoutControlOverPayment.Text = "Over Payment";
            this.layoutControlOverPayment.TextSize = new System.Drawing.Size(125, 21);
            // 
            // layoutControlIncome
            // 
            this.layoutControlIncome.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlIncome.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlIncome.Control = this.textEditIncome;
            this.layoutControlIncome.Location = new System.Drawing.Point(384, 64);
            this.layoutControlIncome.Name = "layoutControlIncome";
            this.layoutControlIncome.Size = new System.Drawing.Size(207, 32);
            this.layoutControlIncome.Text = "Income";
            this.layoutControlIncome.TextSize = new System.Drawing.Size(125, 21);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(200, 64);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(184, 32);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(229, 32);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(155, 32);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlISFDate
            // 
            this.layoutControlISFDate.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlISFDate.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlISFDate.AppearanceItemCaptionDisabled.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlISFDate.AppearanceItemCaptionDisabled.ForeColor = System.Drawing.Color.Black;
            this.layoutControlISFDate.AppearanceItemCaptionDisabled.Options.UseFont = true;
            this.layoutControlISFDate.AppearanceItemCaptionDisabled.Options.UseForeColor = true;
            this.layoutControlISFDate.Control = this.dateEditISFDate;
            this.layoutControlISFDate.Location = new System.Drawing.Point(384, 96);
            this.layoutControlISFDate.MinSize = new System.Drawing.Size(173, 32);
            this.layoutControlISFDate.Name = "layoutControlISFDate";
            this.layoutControlISFDate.Size = new System.Drawing.Size(248, 32);
            this.layoutControlISFDate.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlISFDate.Text = "ISF Date";
            this.layoutControlISFDate.TextSize = new System.Drawing.Size(125, 21);
            // 
            // layoutControlChangeISFDateButton
            // 
            this.layoutControlChangeISFDateButton.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutControlChangeISFDateButton.Control = this.buttonChangeISFDate;
            this.layoutControlChangeISFDateButton.Location = new System.Drawing.Point(632, 96);
            this.layoutControlChangeISFDateButton.Name = "layoutControlChangeISFDateButton";
            this.layoutControlChangeISFDateButton.Size = new System.Drawing.Size(111, 32);
            this.layoutControlChangeISFDateButton.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlChangeISFDateButton.TextVisible = false;
            // 
            // emptySpaceItem5
            // 
            this.emptySpaceItem5.AllowHotTrack = false;
            this.emptySpaceItem5.Location = new System.Drawing.Point(249, 96);
            this.emptySpaceItem5.Name = "emptySpaceItem5";
            this.emptySpaceItem5.Size = new System.Drawing.Size(135, 32);
            this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.Location = new System.Drawing.Point(201, 160);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(182, 32);
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem6
            // 
            this.emptySpaceItem6.AllowHotTrack = false;
            this.emptySpaceItem6.Location = new System.Drawing.Point(201, 192);
            this.emptySpaceItem6.Name = "emptySpaceItem6";
            this.emptySpaceItem6.Size = new System.Drawing.Size(542, 32);
            this.emptySpaceItem6.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlPaymentType
            // 
            this.layoutControlPaymentType.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlPaymentType.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlPaymentType.Control = this.lookUpEditPaymentType;
            this.layoutControlPaymentType.Location = new System.Drawing.Point(0, 160);
            this.layoutControlPaymentType.Name = "layoutControlPaymentType";
            this.layoutControlPaymentType.Size = new System.Drawing.Size(201, 32);
            this.layoutControlPaymentType.Text = "Payment Type";
            this.layoutControlPaymentType.TextSize = new System.Drawing.Size(125, 21);
            // 
            // layoutControlPaymentCode
            // 
            this.layoutControlPaymentCode.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlPaymentCode.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlPaymentCode.Control = this.lookUpEditPaymentCode;
            this.layoutControlPaymentCode.Location = new System.Drawing.Point(0, 192);
            this.layoutControlPaymentCode.Name = "layoutControlPaymentCode";
            this.layoutControlPaymentCode.Size = new System.Drawing.Size(201, 32);
            this.layoutControlPaymentCode.Text = "Payment  Code";
            this.layoutControlPaymentCode.TextSize = new System.Drawing.Size(125, 21);
            // 
            // emptySpaceItem9
            // 
            this.emptySpaceItem9.AllowHotTrack = false;
            this.emptySpaceItem9.Location = new System.Drawing.Point(590, 32);
            this.emptySpaceItem9.Name = "emptySpaceItem9";
            this.emptySpaceItem9.Size = new System.Drawing.Size(153, 32);
            this.emptySpaceItem9.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem10
            // 
            this.emptySpaceItem10.AllowHotTrack = false;
            this.emptySpaceItem10.Location = new System.Drawing.Point(591, 64);
            this.emptySpaceItem10.Name = "emptySpaceItem10";
            this.emptySpaceItem10.Size = new System.Drawing.Size(152, 32);
            this.emptySpaceItem10.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlAmount
            // 
            this.layoutControlAmount.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlAmount.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlAmount.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlAmount.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlAmount.Control = this.textEditAmount;
            this.layoutControlAmount.Location = new System.Drawing.Point(0, 128);
            this.layoutControlAmount.Name = "layoutControlAmount";
            this.layoutControlAmount.Size = new System.Drawing.Size(229, 32);
            this.layoutControlAmount.Text = "Amount";
            this.layoutControlAmount.TextSize = new System.Drawing.Size(125, 21);
            // 
            // emptySpaceItem12
            // 
            this.emptySpaceItem12.AllowHotTrack = false;
            this.emptySpaceItem12.Location = new System.Drawing.Point(229, 128);
            this.emptySpaceItem12.Name = "emptySpaceItem12";
            this.emptySpaceItem12.Size = new System.Drawing.Size(514, 32);
            this.emptySpaceItem12.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlExtensionCount
            // 
            this.layoutControlExtensionCount.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlExtensionCount.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlExtensionCount.Control = this.textEditExtensionCount;
            this.layoutControlExtensionCount.Location = new System.Drawing.Point(383, 160);
            this.layoutControlExtensionCount.Name = "layoutControlExtensionCount";
            this.layoutControlExtensionCount.Size = new System.Drawing.Size(183, 32);
            this.layoutControlExtensionCount.Text = "Extension Count";
            this.layoutControlExtensionCount.TextSize = new System.Drawing.Size(125, 21);
            // 
            // emptySpaceItem8
            // 
            this.emptySpaceItem8.AllowHotTrack = false;
            this.emptySpaceItem8.Location = new System.Drawing.Point(566, 160);
            this.emptySpaceItem8.Name = "emptySpaceItem8";
            this.emptySpaceItem8.Size = new System.Drawing.Size(177, 32);
            this.emptySpaceItem8.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.checkEditEFT;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 224);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(201, 29);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.windowsUIButtonPanel1;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 336);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(743, 67);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem11
            // 
            this.emptySpaceItem11.AllowHotTrack = false;
            this.emptySpaceItem11.Location = new System.Drawing.Point(0, 253);
            this.emptySpaceItem11.Name = "emptySpaceItem11";
            this.emptySpaceItem11.Size = new System.Drawing.Size(743, 83);
            this.emptySpaceItem11.TextSize = new System.Drawing.Size(0, 0);
            // 
            // paymentTableAdapter
            // 
            this.paymentTableAdapter.ClearBeforeFill = true;
            // 
            // dealerTableAdapter
            // 
            this.dealerTableAdapter.ClearBeforeFill = true;
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl1.Controls.Add(this.layoutControlCustomerHeader);
            this.groupControl1.Controls.Add(this.layoutControl1);
            this.groupControl1.Location = new System.Drawing.Point(1, -1);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1015, 548);
            this.groupControl1.TabIndex = 166;
            // 
            // layoutControlCustomerHeader
            // 
            this.layoutControlCustomerHeader.AutoScroll = false;
            this.layoutControlCustomerHeader.Controls.Add(this.textEditDealerName);
            this.layoutControlCustomerHeader.Controls.Add(this.textEditDealerID);
            this.layoutControlCustomerHeader.Controls.Add(this.textEditLastName);
            this.layoutControlCustomerHeader.Controls.Add(this.textEditFirstName);
            this.layoutControlCustomerHeader.Controls.Add(this.textEditCustomerID);
            this.layoutControlCustomerHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutControlCustomerHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlCustomerHeader.Location = new System.Drawing.Point(0, 0);
            this.layoutControlCustomerHeader.Name = "layoutControlCustomerHeader";
            this.layoutControlCustomerHeader.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1161, 0, 650, 400);
            this.layoutControlCustomerHeader.Root = this.layoutControlGroup1;
            this.layoutControlCustomerHeader.Size = new System.Drawing.Size(1015, 81);
            this.layoutControlCustomerHeader.TabIndex = 168;
            this.layoutControlCustomerHeader.Text = "layoutControl1";
            // 
            // textEditDealerName
            // 
            this.textEditDealerName.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSourceDEALER, "DEALER_NAME", true));
            this.textEditDealerName.Location = new System.Drawing.Point(321, 44);
            this.textEditDealerName.Name = "textEditDealerName";
            this.textEditDealerName.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEditDealerName.Properties.Appearance.Options.UseFont = true;
            this.textEditDealerName.Size = new System.Drawing.Size(682, 28);
            this.textEditDealerName.StyleController = this.layoutControlCustomerHeader;
            this.textEditDealerName.TabIndex = 8;
            // 
            // textEditDealerID
            // 
            this.textEditDealerID.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSourceDEALER, "id", true));
            this.textEditDealerID.Location = new System.Drawing.Point(116, 44);
            this.textEditDealerID.Name = "textEditDealerID";
            this.textEditDealerID.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEditDealerID.Properties.Appearance.Options.UseFont = true;
            this.textEditDealerID.Size = new System.Drawing.Size(97, 28);
            this.textEditDealerID.StyleController = this.layoutControlCustomerHeader;
            this.textEditDealerID.TabIndex = 7;
            // 
            // textEditLastName
            // 
            this.textEditLastName.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSourceCUSTOMER, "CUSTOMER_LAST_NAME", true));
            this.textEditLastName.Location = new System.Drawing.Point(708, 12);
            this.textEditLastName.Name = "textEditLastName";
            this.textEditLastName.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEditLastName.Properties.Appearance.Options.UseFont = true;
            this.textEditLastName.Size = new System.Drawing.Size(295, 28);
            this.textEditLastName.StyleController = this.layoutControlCustomerHeader;
            this.textEditLastName.TabIndex = 6;
            // 
            // textEditFirstName
            // 
            this.textEditFirstName.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSourceCUSTOMER, "CUSTOMER_FIRST_NAME", true));
            this.textEditFirstName.Location = new System.Drawing.Point(321, 12);
            this.textEditFirstName.Name = "textEditFirstName";
            this.textEditFirstName.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEditFirstName.Properties.Appearance.Options.UseFont = true;
            this.textEditFirstName.Size = new System.Drawing.Size(279, 28);
            this.textEditFirstName.StyleController = this.layoutControlCustomerHeader;
            this.textEditFirstName.TabIndex = 5;
            // 
            // textEditCustomerID
            // 
            this.textEditCustomerID.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSourceCUSTOMER, "CustomerID", true));
            this.textEditCustomerID.Location = new System.Drawing.Point(116, 12);
            this.textEditCustomerID.Name = "textEditCustomerID";
            this.textEditCustomerID.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEditCustomerID.Properties.Appearance.Options.UseFont = true;
            this.textEditCustomerID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.textEditCustomerID.Properties.DataSource = this.bindingSourceCustomerLookup;
            this.textEditCustomerID.Properties.DisplayMember = "CustomerID";
            this.textEditCustomerID.Properties.NullText = "";
            this.textEditCustomerID.Properties.PopupView = this.gridLookUpEdit1View;
            this.textEditCustomerID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.textEditCustomerID.Properties.ValueMember = "CustomerID";
            this.textEditCustomerID.Size = new System.Drawing.Size(97, 28);
            this.textEditCustomerID.StyleController = this.layoutControlCustomerHeader;
            this.textEditCustomerID.TabIndex = 4;
            this.textEditCustomerID.EditValueChanged += new System.EventHandler(this.textEditCustomerID_EditValueChanged);
            this.textEditCustomerID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.General_KeyPress);
            // 
            // bindingSourceCustomerLookup
            // 
            this.bindingSourceCustomerLookup.DataMember = "CUSTOMER";
            this.bindingSourceCustomerLookup.DataSource = this.customerLookupDataSet;
            // 
            // customerLookupDataSet
            // 
            this.customerLookupDataSet.DataSetName = "IACDataSet";
            this.customerLookupDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridLookUpEdit1View.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridLookUpEdit1View.Appearance.ViewCaption.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridLookUpEdit1View.Appearance.ViewCaption.Options.UseFont = true;
            this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCustomerID,
            this.colCUSTOMER_FIRST_NAME,
            this.colCUSTOMER_LAST_NAME});
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colCustomerID
            // 
            this.colCustomerID.AppearanceCell.Options.UseTextOptions = true;
            this.colCustomerID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colCustomerID.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colCustomerID.AppearanceHeader.Options.UseFont = true;
            this.colCustomerID.AppearanceHeader.Options.UseTextOptions = true;
            this.colCustomerID.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCustomerID.Caption = "Customer ID";
            this.colCustomerID.FieldName = "CustomerID";
            this.colCustomerID.Name = "colCustomerID";
            this.colCustomerID.Visible = true;
            this.colCustomerID.VisibleIndex = 0;
            // 
            // colCUSTOMER_FIRST_NAME
            // 
            this.colCUSTOMER_FIRST_NAME.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colCUSTOMER_FIRST_NAME.AppearanceHeader.Options.UseFont = true;
            this.colCUSTOMER_FIRST_NAME.Caption = "First Name";
            this.colCUSTOMER_FIRST_NAME.FieldName = "CUSTOMER_FIRST_NAME";
            this.colCUSTOMER_FIRST_NAME.Name = "colCUSTOMER_FIRST_NAME";
            this.colCUSTOMER_FIRST_NAME.Visible = true;
            this.colCUSTOMER_FIRST_NAME.VisibleIndex = 1;
            // 
            // colCUSTOMER_LAST_NAME
            // 
            this.colCUSTOMER_LAST_NAME.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colCUSTOMER_LAST_NAME.AppearanceHeader.Options.UseFont = true;
            this.colCUSTOMER_LAST_NAME.Caption = "Last Name";
            this.colCUSTOMER_LAST_NAME.FieldName = "CUSTOMER_LAST_NAME";
            this.colCUSTOMER_LAST_NAME.Name = "colCUSTOMER_LAST_NAME";
            this.colCUSTOMER_LAST_NAME.Visible = true;
            this.colCUSTOMER_LAST_NAME.VisibleIndex = 2;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlCustomerID,
            this.layoutFirstName,
            this.layoutLastName,
            this.layoutControlDealerName,
            this.layoutControlDealerID});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1015, 84);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlCustomerID
            // 
            this.layoutControlCustomerID.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlCustomerID.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlCustomerID.Control = this.textEditCustomerID;
            this.layoutControlCustomerID.Location = new System.Drawing.Point(0, 0);
            this.layoutControlCustomerID.Name = "layoutControlCustomerID";
            this.layoutControlCustomerID.Size = new System.Drawing.Size(205, 32);
            this.layoutControlCustomerID.Text = "Customer ID";
            this.layoutControlCustomerID.TextSize = new System.Drawing.Size(100, 21);
            // 
            // layoutFirstName
            // 
            this.layoutFirstName.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutFirstName.AppearanceItemCaption.Options.UseFont = true;
            this.layoutFirstName.Control = this.textEditFirstName;
            this.layoutFirstName.Location = new System.Drawing.Point(205, 0);
            this.layoutFirstName.Name = "layoutFirstName";
            this.layoutFirstName.Size = new System.Drawing.Size(387, 32);
            this.layoutFirstName.Text = "First Name";
            this.layoutFirstName.TextSize = new System.Drawing.Size(100, 21);
            // 
            // layoutLastName
            // 
            this.layoutLastName.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutLastName.AppearanceItemCaption.Options.UseFont = true;
            this.layoutLastName.Control = this.textEditLastName;
            this.layoutLastName.Location = new System.Drawing.Point(592, 0);
            this.layoutLastName.Name = "layoutLastName";
            this.layoutLastName.Size = new System.Drawing.Size(403, 32);
            this.layoutLastName.Text = "Last Name";
            this.layoutLastName.TextSize = new System.Drawing.Size(100, 21);
            // 
            // layoutControlDealerName
            // 
            this.layoutControlDealerName.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlDealerName.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlDealerName.Control = this.textEditDealerName;
            this.layoutControlDealerName.Location = new System.Drawing.Point(205, 32);
            this.layoutControlDealerName.Name = "layoutControlDealerName";
            this.layoutControlDealerName.Size = new System.Drawing.Size(790, 32);
            this.layoutControlDealerName.Text = "Dealer Name";
            this.layoutControlDealerName.TextSize = new System.Drawing.Size(100, 21);
            // 
            // layoutControlDealerID
            // 
            this.layoutControlDealerID.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlDealerID.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlDealerID.Control = this.textEditDealerID;
            this.layoutControlDealerID.Location = new System.Drawing.Point(0, 32);
            this.layoutControlDealerID.Name = "layoutControlDealerID";
            this.layoutControlDealerID.Size = new System.Drawing.Size(205, 32);
            this.layoutControlDealerID.Text = "Dealer ID";
            this.layoutControlDealerID.TextSize = new System.Drawing.Size(100, 21);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.dataLayoutPayment);
            this.layoutControl1.Location = new System.Drawing.Point(114, 88);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1171, 269, 650, 400);
            this.layoutControl1.Root = this.layoutControlGroup2;
            this.layoutControl1.Size = new System.Drawing.Size(787, 447);
            this.layoutControl1.TabIndex = 167;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2});
            this.layoutControlGroup2.Name = "Root";
            this.layoutControlGroup2.Size = new System.Drawing.Size(787, 447);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.dataLayoutPayment;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(767, 427);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // lookUpEditCustomerID
            // 
            this.lookUpEditCustomerID.Location = new System.Drawing.Point(22, 199);
            this.lookUpEditCustomerID.Name = "lookUpEditCustomerID";
            this.lookUpEditCustomerID.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookUpEditCustomerID.Properties.Appearance.Options.UseFont = true;
            this.lookUpEditCustomerID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditCustomerID.Size = new System.Drawing.Size(887, 28);
            this.lookUpEditCustomerID.TabIndex = 168;
            // 
            // XtraFormClosedPaymentEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 545);
            this.Controls.Add(this.groupControl1);
            this.Name = "XtraFormClosedPaymentEditor";
            this.Text = "XtraFormClosedPaymentEditor";
            this.Load += new System.EventHandler(this.XtraFormClosedPaymentEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iacDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCUSTOMER)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDEALER)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePAYMENT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutPayment)).EndInit();
            this.dataLayoutPayment.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEditExtensionCount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditISFDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditISFDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditIncome.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditOverPayment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditEFT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditPaymentDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditPaymentDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditPaymentType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePAYMENTTYPE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditPaymentCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePAYCODE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditPaidThrough.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditBuyout.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditBalance.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlPaidThrough)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlLoanBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlBuyout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlPaymentDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlOverPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlIncome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlISFDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlChangeISFDateButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlPaymentType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlPaymentCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlExtensionCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlCustomerHeader)).EndInit();
            this.layoutControlCustomerHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEditDealerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditDealerID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditLastName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditFirstName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditCustomerID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCustomerLookup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerLookupDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlCustomerID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutFirstName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutLastName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlDealerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlDealerID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditCustomerID.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private IACDataSet iacDataSet;
        private System.Windows.Forms.BindingSource bindingSourceCUSTOMER;
        private System.Windows.Forms.BindingSource bindingSourceDEALER;
        private IACDataSetTableAdapters.CUSTOMERTableAdapter customerTableAdapter;
        private IACDataSetTableAdapters.PAYCODETableAdapter paycodeTableAdapter;
        private System.Windows.Forms.BindingSource bindingSourcePAYMENT;
        private IACDataSetTableAdapters.PAYMENTTYPETableAdapter paymenttypeTableAdapter;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutPayment;
        private DevExpress.XtraEditors.TextEdit textEditBalance;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlLoanBalance;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.TextEdit textEditBuyout;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlBuyout;
        private DevExpress.XtraEditors.TextEdit textEditPaidThrough;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlPaidThrough;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditPaymentCode;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlPaymentCode;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditPaymentType;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlPaymentType;
        private DevExpress.XtraEditors.DateEdit dateEditPaymentDate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlPaymentDate;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem7;
        private DevExpress.XtraEditors.CheckEdit checkEditEFT;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.TextEdit textEditOverPayment;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlOverPayment;
        private DevExpress.XtraEditors.DateEdit dateEditISFDate;
        private DevExpress.XtraEditors.TextEdit textEditIncome;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlIncome;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlISFDate;
        private System.Windows.Forms.BindingSource bindingSourcePAYCODE;
        private IACDataSetTableAdapters.PAYMENTTableAdapter paymentTableAdapter;
        private IACDataSetTableAdapters.DEALERTableAdapter dealerTableAdapter;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.BindingSource bindingSourcePAYMENTTYPE;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton buttonChangeISFDate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlChangeISFDateButton;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem9;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem10;
        private DevExpress.XtraEditors.TextEdit textEditAmount;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlAmount;
        private DevExpress.XtraEditors.TextEdit textEditExtensionCount;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlExtensionCount;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem12;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem8;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditCustomerID;
        private DevExpress.XtraLayout.LayoutControl layoutControlCustomerHeader;
        private DevExpress.XtraEditors.TextEdit textEditDealerName;
        private DevExpress.XtraEditors.TextEdit textEditDealerID;
        private DevExpress.XtraEditors.TextEdit textEditLastName;
        private DevExpress.XtraEditors.TextEdit textEditFirstName;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlCustomerID;
        private DevExpress.XtraLayout.LayoutControlItem layoutFirstName;
        private DevExpress.XtraLayout.LayoutControlItem layoutLastName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlDealerName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlDealerID;
        private System.Windows.Forms.BindingSource bindingSourceCustomerLookup;
        private IACDataSet customerLookupDataSet;
        private DevExpress.XtraEditors.GridLookUpEdit textEditCustomerID;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerID;
        private DevExpress.XtraGrid.Columns.GridColumn colCUSTOMER_FIRST_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colCUSTOMER_LAST_NAME;
        private DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel windowsUIButtonPanel1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem11;
    }
}