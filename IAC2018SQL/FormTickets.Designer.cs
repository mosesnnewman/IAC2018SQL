
namespace IAC2021SQL
{
    partial class FormTickets
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTickets));
            this.textBoxName = new DevExpress.XtraEditors.TextEdit();
            this.cUSTOMERBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productionMainTables = new IAC2021SQL.ProductionMainTables();
            this.textBoxMiddleInitial = new DevExpress.XtraEditors.TextEdit();
            this.textBoxLastName = new DevExpress.XtraEditors.TextEdit();
            this.labelName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxDealerNumber = new DevExpress.XtraEditors.TextEdit();
            this.bindingSourceDealer = new System.Windows.Forms.BindingSource(this.components);
            this.textBoxAccount = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxDealerName = new DevExpress.XtraEditors.TextEdit();
            this.groupBoxHeader = new System.Windows.Forms.GroupBox();
            this.buttonLast = new DevExpress.XtraEditors.SimpleButton();
            this.buttonFirst = new DevExpress.XtraEditors.SimpleButton();
            this.buttonDeleteTicket = new DevExpress.XtraEditors.SimpleButton();
            this.buttonEdit = new DevExpress.XtraEditors.SimpleButton();
            this.labelTicketID = new System.Windows.Forms.Label();
            this.textBoxTicketID = new DevExpress.XtraEditors.TextEdit();
            this.buttonNext = new DevExpress.XtraEditors.SimpleButton();
            this.buttonPrevious = new DevExpress.XtraEditors.SimpleButton();
            this.buttonAdd = new DevExpress.XtraEditors.SimpleButton();
            this.TicketID = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.bindingSourceTicketDetail = new System.Windows.Forms.BindingSource(this.components);
            this.ticketsdataset = new IAC2021SQL.Tickets();
            this.cUSTOMERTableAdapter = new IAC2021SQL.ProductionMainTablesTableAdapters.CUSTOMERTableAdapter();
            this.dEALERTableAdapter = new IAC2021SQL.ProductionMainTablesTableAdapters.DEALERTableAdapter();
            this.bindingSourceTicketHeader = new System.Windows.Forms.BindingSource(this.components);
            this.labelExplanation = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.labelMadeBy = new System.Windows.Forms.Label();
            this.textBoxMadeBy = new DevExpress.XtraEditors.TextEdit();
            this.textBoxApprovedBy = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonClearDetail = new DevExpress.XtraEditors.SimpleButton();
            this.buttonSaveTicket = new DevExpress.XtraEditors.SimpleButton();
            this.ticketHeaderTableAdapter = new IAC2021SQL.TicketsTableAdapters.TicketHeaderTableAdapter();
            this.ticketDetailTableAdapter = new IAC2021SQL.TicketsTableAdapters.TicketDetailTableAdapter();
            this.checkBoxCloseOut = new DevExpress.XtraEditors.CheckEdit();
            this.buttonCancelTicket = new DevExpress.XtraEditors.SimpleButton();
            this.colorTextBoxOutofBalance = new DevExpress.XtraEditors.TextEdit();
            this.colorTextBoxCredits = new DevExpress.XtraEditors.TextEdit();
            this.colorTextBoxDebits = new DevExpress.XtraEditors.TextEdit();
            this.NullableDateTimePickerDate = new DevExpress.XtraEditors.DateEdit();
            this.buttonDeleteEntry = new DevExpress.XtraEditors.SimpleButton();
            this.buttonReprint = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSubDealer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.lookupDEALERBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lookupDataSet = new IAC2021SQL.ProductionMainTables();
            this.colDebit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCredit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPaymentType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.pAYMENTTYPEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.listData = new IAC2021SQL.ListData();
            this.colPaymentCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.pAYCODEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colGLAccount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ticketAccountsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dEALERBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productionMainTablesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            this.ticketAccountsTableAdapter = new IAC2021SQL.TicketsTableAdapters.TicketAccountsTableAdapter();
            this.pAYMENTTYPETableAdapter1 = new IAC2021SQL.ListDataTableAdapters.PAYMENTTYPETableAdapter();
            this.pAYCODETableAdapter1 = new IAC2021SQL.ListDataTableAdapters.PAYCODETableAdapter();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.richTextBox1 = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cUSTOMERBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productionMainTables)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxMiddleInitial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxLastName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxDealerNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDealer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxDealerName.Properties)).BeginInit();
            this.groupBoxHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxTicketID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceTicketDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ticketsdataset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceTicketHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxMadeBy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxApprovedBy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkBoxCloseOut.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorTextBoxOutofBalance.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorTextBoxCredits.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorTextBoxDebits.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NullableDateTimePickerDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NullableDateTimePickerDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupDEALERBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pAYMENTTYPEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pAYCODEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ticketAccountsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEALERBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productionMainTablesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.richTextBox1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxName
            // 
            this.textBoxName.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.cUSTOMERBindingSource, "CUSTOMER_FIRST_NAME", true));
            this.textBoxName.Enabled = false;
            this.textBoxName.Location = new System.Drawing.Point(187, 15);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxName.Properties.Appearance.Options.UseFont = true;
            this.textBoxName.Properties.ReadOnly = true;
            this.textBoxName.Size = new System.Drawing.Size(347, 22);
            this.textBoxName.TabIndex = 1;
            // 
            // cUSTOMERBindingSource
            // 
            this.cUSTOMERBindingSource.DataMember = "CUSTOMER";
            this.cUSTOMERBindingSource.DataSource = this.productionMainTables;
            // 
            // productionMainTables
            // 
            this.productionMainTables.DataSetName = "ProductionMainTables";
            this.productionMainTables.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // textBoxMiddleInitial
            // 
            this.textBoxMiddleInitial.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.cUSTOMERBindingSource, "MiddleName", true));
            this.textBoxMiddleInitial.Enabled = false;
            this.textBoxMiddleInitial.Location = new System.Drawing.Point(542, 15);
            this.textBoxMiddleInitial.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxMiddleInitial.Name = "textBoxMiddleInitial";
            this.textBoxMiddleInitial.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMiddleInitial.Properties.Appearance.Options.UseFont = true;
            this.textBoxMiddleInitial.Properties.ReadOnly = true;
            this.textBoxMiddleInitial.Size = new System.Drawing.Size(24, 22);
            this.textBoxMiddleInitial.TabIndex = 2;
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.cUSTOMERBindingSource, "CUSTOMER_LAST_NAME", true));
            this.textBoxLastName.Enabled = false;
            this.textBoxLastName.Location = new System.Drawing.Point(576, 15);
            this.textBoxLastName.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxLastName.Properties.Appearance.Options.UseFont = true;
            this.textBoxLastName.Properties.ReadOnly = true;
            this.textBoxLastName.Size = new System.Drawing.Size(347, 22);
            this.textBoxLastName.TabIndex = 3;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.Location = new System.Drawing.Point(129, 21);
            this.labelName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(52, 16);
            this.labelName.TabIndex = 4;
            this.labelName.Text = "Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(123, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Dealer:";
            // 
            // textBoxDealerNumber
            // 
            this.textBoxDealerNumber.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSourceDealer, "DEALER_ACC_NO", true));
            this.textBoxDealerNumber.Enabled = false;
            this.textBoxDealerNumber.Location = new System.Drawing.Point(187, 45);
            this.textBoxDealerNumber.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDealerNumber.Name = "textBoxDealerNumber";
            this.textBoxDealerNumber.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDealerNumber.Properties.Appearance.Options.UseFont = true;
            this.textBoxDealerNumber.Properties.ReadOnly = true;
            this.textBoxDealerNumber.Size = new System.Drawing.Size(44, 22);
            this.textBoxDealerNumber.TabIndex = 6;
            // 
            // bindingSourceDealer
            // 
            this.bindingSourceDealer.DataMember = "DEALER";
            this.bindingSourceDealer.DataSource = this.productionMainTables;
            // 
            // textBoxAccount
            // 
            this.textBoxAccount.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.cUSTOMERBindingSource, "CUSTOMER_NO", true));
            this.textBoxAccount.Location = new System.Drawing.Point(187, 79);
            this.textBoxAccount.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxAccount.Name = "textBoxAccount";
            this.textBoxAccount.Properties.Appearance.BackColor = System.Drawing.Color.Gold;
            this.textBoxAccount.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAccount.Properties.Appearance.Options.UseBackColor = true;
            this.textBoxAccount.Properties.Appearance.Options.UseFont = true;
            this.textBoxAccount.Size = new System.Drawing.Size(65, 22);
            this.textBoxAccount.TabIndex = 8;
            this.textBoxAccount.EditValueChanged += new System.EventHandler(this.textBoxAccount_EditValueChanged);
            this.textBoxAccount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GeneralKeypress);
            this.textBoxAccount.Validated += new System.EventHandler(this.textBoxAccount_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(115, 85);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Account:";
            // 
            // textBoxDealerName
            // 
            this.textBoxDealerName.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSourceDealer, "DEALER_NAME", true));
            this.textBoxDealerName.Enabled = false;
            this.textBoxDealerName.Location = new System.Drawing.Point(240, 45);
            this.textBoxDealerName.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDealerName.Name = "textBoxDealerName";
            this.textBoxDealerName.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDealerName.Properties.Appearance.Options.UseFont = true;
            this.textBoxDealerName.Properties.ReadOnly = true;
            this.textBoxDealerName.Size = new System.Drawing.Size(347, 22);
            this.textBoxDealerName.TabIndex = 9;
            // 
            // groupBoxHeader
            // 
            this.groupBoxHeader.Controls.Add(this.buttonLast);
            this.groupBoxHeader.Controls.Add(this.buttonFirst);
            this.groupBoxHeader.Controls.Add(this.buttonDeleteTicket);
            this.groupBoxHeader.Controls.Add(this.buttonEdit);
            this.groupBoxHeader.Controls.Add(this.labelTicketID);
            this.groupBoxHeader.Controls.Add(this.textBoxTicketID);
            this.groupBoxHeader.Controls.Add(this.buttonNext);
            this.groupBoxHeader.Controls.Add(this.buttonPrevious);
            this.groupBoxHeader.Controls.Add(this.textBoxAccount);
            this.groupBoxHeader.Controls.Add(this.textBoxDealerName);
            this.groupBoxHeader.Controls.Add(this.label2);
            this.groupBoxHeader.Controls.Add(this.textBoxDealerNumber);
            this.groupBoxHeader.Controls.Add(this.label1);
            this.groupBoxHeader.Controls.Add(this.labelName);
            this.groupBoxHeader.Controls.Add(this.textBoxLastName);
            this.groupBoxHeader.Controls.Add(this.textBoxMiddleInitial);
            this.groupBoxHeader.Controls.Add(this.textBoxName);
            this.groupBoxHeader.Location = new System.Drawing.Point(10, 1);
            this.groupBoxHeader.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxHeader.Name = "groupBoxHeader";
            this.groupBoxHeader.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxHeader.Size = new System.Drawing.Size(1038, 121);
            this.groupBoxHeader.TabIndex = 10;
            this.groupBoxHeader.TabStop = false;
            // 
            // buttonLast
            // 
            this.buttonLast.BackgroundImage = global::IAC2021SQL.Properties.Resources.fastforward_22x;
            this.buttonLast.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonLast.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.buttonLast.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("buttonLast.ImageOptions.SvgImage")));
            this.buttonLast.Location = new System.Drawing.Point(985, 70);
            this.buttonLast.Name = "buttonLast";
            this.buttonLast.Size = new System.Drawing.Size(47, 45);
            this.buttonLast.TabIndex = 17;
            this.buttonLast.Click += new System.EventHandler(this.buttonLast_Click);
            // 
            // buttonFirst
            // 
            this.buttonFirst.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonFirst.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.buttonFirst.ImageOptions.Image = global::IAC2021SQL.Properties.Resources.rewind_22x;
            this.buttonFirst.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.buttonFirst.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("buttonFirst.ImageOptions.SvgImage")));
            this.buttonFirst.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.Full;
            this.buttonFirst.Location = new System.Drawing.Point(820, 70);
            this.buttonFirst.Name = "buttonFirst";
            this.buttonFirst.Size = new System.Drawing.Size(47, 45);
            this.buttonFirst.TabIndex = 16;
            this.buttonFirst.Click += new System.EventHandler(this.buttonFirst_Click);
            // 
            // buttonDeleteTicket
            // 
            this.buttonDeleteTicket.ImageOptions.Image = global::IAC2021SQL.Properties.Resources.Cancel_64x;
            this.buttonDeleteTicket.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.buttonDeleteTicket.Location = new System.Drawing.Point(721, 45);
            this.buttonDeleteTicket.Name = "buttonDeleteTicket";
            this.buttonDeleteTicket.Size = new System.Drawing.Size(86, 70);
            this.buttonDeleteTicket.TabIndex = 15;
            this.buttonDeleteTicket.Click += new System.EventHandler(this.buttonDeleteTicket_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.ImageOptions.Image = global::IAC2021SQL.Properties.Resources.Edit_32xMD;
            this.buttonEdit.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.buttonEdit.Location = new System.Drawing.Point(617, 45);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(86, 70);
            this.buttonEdit.TabIndex = 14;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // labelTicketID
            // 
            this.labelTicketID.AutoSize = true;
            this.labelTicketID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTicketID.Location = new System.Drawing.Point(266, 85);
            this.labelTicketID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTicketID.Name = "labelTicketID";
            this.labelTicketID.Size = new System.Drawing.Size(69, 16);
            this.labelTicketID.TabIndex = 13;
            this.labelTicketID.Text = "TicketID:";
            // 
            // textBoxTicketID
            // 
            this.textBoxTicketID.Enabled = false;
            this.textBoxTicketID.Location = new System.Drawing.Point(339, 79);
            this.textBoxTicketID.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxTicketID.Name = "textBoxTicketID";
            this.textBoxTicketID.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxTicketID.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTicketID.Properties.Appearance.Options.UseBackColor = true;
            this.textBoxTicketID.Properties.Appearance.Options.UseFont = true;
            this.textBoxTicketID.Size = new System.Drawing.Size(88, 22);
            this.textBoxTicketID.TabIndex = 12;
            // 
            // buttonNext
            // 
            this.buttonNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonNext.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.buttonNext.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.buttonNext.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("buttonNext.ImageOptions.SvgImage")));
            this.buttonNext.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.Full;
            this.buttonNext.Location = new System.Drawing.Point(930, 70);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(47, 45);
            this.buttonNext.TabIndex = 11;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonPrevious
            // 
            this.buttonPrevious.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonPrevious.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.buttonPrevious.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.buttonPrevious.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("buttonPrevious.ImageOptions.SvgImage")));
            this.buttonPrevious.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.Full;
            this.buttonPrevious.Location = new System.Drawing.Point(875, 70);
            this.buttonPrevious.LookAndFeel.SkinName = "McSkin";
            this.buttonPrevious.LookAndFeel.UseDefaultLookAndFeel = false;
            this.buttonPrevious.Name = "buttonPrevious";
            this.buttonPrevious.Size = new System.Drawing.Size(47, 45);
            this.buttonPrevious.TabIndex = 10;
            this.buttonPrevious.Click += new System.EventHandler(this.buttonPrevious_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdd.Appearance.Options.UseFont = true;
            this.buttonAdd.Location = new System.Drawing.Point(13, 602);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(100, 28);
            this.buttonAdd.TabIndex = 11;
            this.buttonAdd.Text = "&Add Entry";
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // TicketID
            // 
            this.TicketID.AspectName = "TicketID";
            this.TicketID.DisplayIndex = 0;
            this.TicketID.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TicketID.HeaderTriStateCheckBox = true;
            this.TicketID.IsEditable = false;
            this.TicketID.IsVisible = false;
            this.TicketID.Text = "";
            // 
            // bindingSourceTicketDetail
            // 
            this.bindingSourceTicketDetail.DataMember = "TicketDetail";
            this.bindingSourceTicketDetail.DataSource = this.ticketsdataset;
            this.bindingSourceTicketDetail.Sort = "";
            // 
            // ticketsdataset
            // 
            this.ticketsdataset.DataSetName = "Tickets";
            this.ticketsdataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cUSTOMERTableAdapter
            // 
            this.cUSTOMERTableAdapter.ClearBeforeFill = true;
            // 
            // dEALERTableAdapter
            // 
            this.dEALERTableAdapter.ClearBeforeFill = true;
            // 
            // bindingSourceTicketHeader
            // 
            this.bindingSourceTicketHeader.DataMember = "TicketHeader";
            this.bindingSourceTicketHeader.DataSource = this.ticketsdataset;
            // 
            // labelExplanation
            // 
            this.labelExplanation.AutoSize = true;
            this.labelExplanation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelExplanation.Location = new System.Drawing.Point(650, 130);
            this.labelExplanation.Name = "labelExplanation";
            this.labelExplanation.Size = new System.Drawing.Size(92, 16);
            this.labelExplanation.TabIndex = 13;
            this.labelExplanation.Text = "Explanation:";
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDate.Location = new System.Drawing.Point(270, 507);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(53, 20);
            this.labelDate.TabIndex = 78;
            this.labelDate.Text = "Date:";
            // 
            // labelMadeBy
            // 
            this.labelMadeBy.AutoSize = true;
            this.labelMadeBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMadeBy.Location = new System.Drawing.Point(564, 507);
            this.labelMadeBy.Name = "labelMadeBy";
            this.labelMadeBy.Size = new System.Drawing.Size(83, 20);
            this.labelMadeBy.TabIndex = 79;
            this.labelMadeBy.Text = "Made By:";
            // 
            // textBoxMadeBy
            // 
            this.textBoxMadeBy.Location = new System.Drawing.Point(651, 501);
            this.textBoxMadeBy.Name = "textBoxMadeBy";
            this.textBoxMadeBy.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMadeBy.Properties.Appearance.Options.UseFont = true;
            this.textBoxMadeBy.Properties.ReadOnly = true;
            this.textBoxMadeBy.Size = new System.Drawing.Size(397, 26);
            this.textBoxMadeBy.TabIndex = 80;
            // 
            // textBoxApprovedBy
            // 
            this.textBoxApprovedBy.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceTicketHeader, "ApprovedBy", true));
            this.textBoxApprovedBy.Location = new System.Drawing.Point(651, 534);
            this.textBoxApprovedBy.Name = "textBoxApprovedBy";
            this.textBoxApprovedBy.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxApprovedBy.Properties.Appearance.Options.UseFont = true;
            this.textBoxApprovedBy.Size = new System.Drawing.Size(397, 26);
            this.textBoxApprovedBy.TabIndex = 82;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(532, 540);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 20);
            this.label3.TabIndex = 81;
            this.label3.Text = "Approved By:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(260, 540);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 20);
            this.label4.TabIndex = 83;
            this.label4.Text = "Totals:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(189, 568);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 20);
            this.label5.TabIndex = 84;
            this.label5.Text = "Out of Balance:";
            // 
            // buttonClearDetail
            // 
            this.buttonClearDetail.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClearDetail.Appearance.Options.UseFont = true;
            this.buttonClearDetail.Location = new System.Drawing.Point(229, 602);
            this.buttonClearDetail.Margin = new System.Windows.Forms.Padding(4);
            this.buttonClearDetail.Name = "buttonClearDetail";
            this.buttonClearDetail.Size = new System.Drawing.Size(100, 28);
            this.buttonClearDetail.TabIndex = 88;
            this.buttonClearDetail.Text = "Clear &Detail";
            this.buttonClearDetail.Click += new System.EventHandler(this.buttonClearDetail_Click);
            // 
            // buttonSaveTicket
            // 
            this.buttonSaveTicket.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSaveTicket.Appearance.Options.UseFont = true;
            this.buttonSaveTicket.Location = new System.Drawing.Point(445, 602);
            this.buttonSaveTicket.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSaveTicket.Name = "buttonSaveTicket";
            this.buttonSaveTicket.Size = new System.Drawing.Size(100, 28);
            this.buttonSaveTicket.TabIndex = 89;
            this.buttonSaveTicket.Text = "&Save Ticket";
            this.buttonSaveTicket.Click += new System.EventHandler(this.buttonSaveTicket_Click);
            // 
            // ticketHeaderTableAdapter
            // 
            this.ticketHeaderTableAdapter.ClearBeforeFill = true;
            // 
            // ticketDetailTableAdapter
            // 
            this.ticketDetailTableAdapter.ClearBeforeFill = true;
            // 
            // checkBoxCloseOut
            // 
            this.checkBoxCloseOut.EditValue = true;
            this.checkBoxCloseOut.Enabled = false;
            this.checkBoxCloseOut.Location = new System.Drawing.Point(13, 506);
            this.checkBoxCloseOut.Name = "checkBoxCloseOut";
            this.checkBoxCloseOut.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxCloseOut.Properties.Appearance.Options.UseFont = true;
            this.checkBoxCloseOut.Properties.Caption = "Close Out Ticket?";
            this.checkBoxCloseOut.Size = new System.Drawing.Size(114, 21);
            this.checkBoxCloseOut.TabIndex = 91;
            // 
            // buttonCancelTicket
            // 
            this.buttonCancelTicket.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancelTicket.Appearance.Options.UseFont = true;
            this.buttonCancelTicket.Location = new System.Drawing.Point(337, 602);
            this.buttonCancelTicket.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCancelTicket.Name = "buttonCancelTicket";
            this.buttonCancelTicket.Size = new System.Drawing.Size(100, 28);
            this.buttonCancelTicket.TabIndex = 92;
            this.buttonCancelTicket.Text = "&Cancel Ticket";
            this.buttonCancelTicket.Click += new System.EventHandler(this.buttonCancelTicket_Click);
            // 
            // colorTextBoxOutofBalance
            // 
            this.colorTextBoxOutofBalance.Location = new System.Drawing.Point(328, 562);
            this.colorTextBoxOutofBalance.Name = "colorTextBoxOutofBalance";
            this.colorTextBoxOutofBalance.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colorTextBoxOutofBalance.Properties.Appearance.Options.UseFont = true;
            this.colorTextBoxOutofBalance.Properties.ReadOnly = true;
            this.colorTextBoxOutofBalance.Size = new System.Drawing.Size(100, 26);
            this.colorTextBoxOutofBalance.TabIndex = 87;
            // 
            // colorTextBoxCredits
            // 
            this.colorTextBoxCredits.Enabled = false;
            this.colorTextBoxCredits.Location = new System.Drawing.Point(429, 534);
            this.colorTextBoxCredits.Name = "colorTextBoxCredits";
            this.colorTextBoxCredits.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colorTextBoxCredits.Properties.Appearance.Options.UseFont = true;
            this.colorTextBoxCredits.Properties.ReadOnly = true;
            this.colorTextBoxCredits.Size = new System.Drawing.Size(100, 26);
            this.colorTextBoxCredits.TabIndex = 86;
            // 
            // colorTextBoxDebits
            // 
            this.colorTextBoxDebits.Enabled = false;
            this.colorTextBoxDebits.Location = new System.Drawing.Point(328, 534);
            this.colorTextBoxDebits.Name = "colorTextBoxDebits";
            this.colorTextBoxDebits.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colorTextBoxDebits.Properties.Appearance.Options.UseFont = true;
            this.colorTextBoxDebits.Properties.ReadOnly = true;
            this.colorTextBoxDebits.Size = new System.Drawing.Size(100, 26);
            this.colorTextBoxDebits.TabIndex = 85;
            // 
            // NullableDateTimePickerDate
            // 
            this.NullableDateTimePickerDate.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSourceTicketHeader, "Date", true));
            this.NullableDateTimePickerDate.EditValue = new System.DateTime(2022, 3, 25, 0, 0, 0, 0);
            this.NullableDateTimePickerDate.Location = new System.Drawing.Point(328, 501);
            this.NullableDateTimePickerDate.Name = "NullableDateTimePickerDate";
            this.NullableDateTimePickerDate.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NullableDateTimePickerDate.Properties.Appearance.Options.UseFont = true;
            this.NullableDateTimePickerDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.NullableDateTimePickerDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.NullableDateTimePickerDate.Properties.LookAndFeel.SkinName = "McSkin";
            this.NullableDateTimePickerDate.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.NullableDateTimePickerDate.Size = new System.Drawing.Size(109, 26);
            this.NullableDateTimePickerDate.TabIndex = 77;
            // 
            // buttonDeleteEntry
            // 
            this.buttonDeleteEntry.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDeleteEntry.Appearance.Options.UseFont = true;
            this.buttonDeleteEntry.Location = new System.Drawing.Point(121, 602);
            this.buttonDeleteEntry.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDeleteEntry.Name = "buttonDeleteEntry";
            this.buttonDeleteEntry.Size = new System.Drawing.Size(100, 28);
            this.buttonDeleteEntry.TabIndex = 93;
            this.buttonDeleteEntry.Text = "D&elete Entry";
            this.buttonDeleteEntry.Click += new System.EventHandler(this.buttonDeleteEntry_Click);
            // 
            // buttonReprint
            // 
            this.buttonReprint.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReprint.Appearance.Options.UseFont = true;
            this.buttonReprint.Enabled = false;
            this.buttonReprint.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("buttonReprint.ImageOptions.Image")));
            this.buttonReprint.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.buttonReprint.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.buttonReprint.Location = new System.Drawing.Point(964, 564);
            this.buttonReprint.Name = "buttonReprint";
            this.buttonReprint.Size = new System.Drawing.Size(81, 75);
            this.buttonReprint.TabIndex = 90;
            this.buttonReprint.Text = "&Reprint";
            this.buttonReprint.Click += new System.EventHandler(this.buttonReprint_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.bindingSourceTicketDetail;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.gridControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridControl1.Location = new System.Drawing.Point(3, 130);
            this.gridControl1.LookAndFeel.SkinName = "McSkin";
            this.gridControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1,
            this.repositoryItemLookUpEdit2,
            this.repositoryItemLookUpEdit3,
            this.repositoryItemLookUpEdit4});
            this.gridControl1.Size = new System.Drawing.Size(635, 365);
            this.gridControl1.TabIndex = 94;
            this.gridControl1.UseDisabledStatePainter = false;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSubDealer,
            this.colDebit,
            this.colCredit,
            this.colDetailID,
            this.colPaymentType,
            this.colPaymentCode,
            this.colGLAccount});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.AllowHtmlDrawHeaders = true;
            this.gridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.ShownEditor += new System.EventHandler(this.gridView1_ShownEditor);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridView1_CustomColumnDisplayText);
            // 
            // colSubDealer
            // 
            this.colSubDealer.AppearanceCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colSubDealer.AppearanceCell.Options.UseFont = true;
            this.colSubDealer.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colSubDealer.AppearanceHeader.Options.UseFont = true;
            this.colSubDealer.AppearanceHeader.Options.UseTextOptions = true;
            this.colSubDealer.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.Word;
            this.colSubDealer.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom;
            this.colSubDealer.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colSubDealer.Caption = "Dealer";
            this.colSubDealer.ColumnEdit = this.repositoryItemLookUpEdit2;
            this.colSubDealer.FieldName = "SubDealer";
            this.colSubDealer.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.MiddleLeft;
            this.colSubDealer.Name = "colSubDealer";
            this.colSubDealer.Visible = true;
            this.colSubDealer.VisibleIndex = 2;
            this.colSubDealer.Width = 60;
            // 
            // repositoryItemLookUpEdit2
            // 
            this.repositoryItemLookUpEdit2.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repositoryItemLookUpEdit2.Appearance.Options.UseFont = true;
            this.repositoryItemLookUpEdit2.AutoHeight = false;
            this.repositoryItemLookUpEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit2.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", "id", 19, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DEALER_NAME", "DEALER_NAME", 84, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DEALER_ST", "DEALER_ST", 65, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.repositoryItemLookUpEdit2.DataSource = this.lookupDEALERBindingSource;
            this.repositoryItemLookUpEdit2.DisplayMember = "id";
            this.repositoryItemLookUpEdit2.LookAndFeel.SkinName = "McSkin";
            this.repositoryItemLookUpEdit2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.repositoryItemLookUpEdit2.Name = "repositoryItemLookUpEdit2";
            this.repositoryItemLookUpEdit2.NullText = "";
            this.repositoryItemLookUpEdit2.ValueMember = "id";
            // 
            // lookupDEALERBindingSource
            // 
            this.lookupDEALERBindingSource.DataMember = "DEALER";
            this.lookupDEALERBindingSource.DataSource = this.lookupDataSet;
            // 
            // lookupDataSet
            // 
            this.lookupDataSet.DataSetName = "ProductionMainTables";
            this.lookupDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // colDebit
            // 
            this.colDebit.AppearanceCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDebit.AppearanceCell.ForeColor = System.Drawing.Color.Red;
            this.colDebit.AppearanceCell.Options.UseFont = true;
            this.colDebit.AppearanceCell.Options.UseForeColor = true;
            this.colDebit.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDebit.AppearanceHeader.Options.UseFont = true;
            this.colDebit.AppearanceHeader.Options.UseTextOptions = true;
            this.colDebit.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colDebit.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom;
            this.colDebit.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colDebit.DisplayFormat.FormatString = "c2";
            this.colDebit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDebit.FieldName = "Debit";
            this.colDebit.Name = "colDebit";
            this.colDebit.Visible = true;
            this.colDebit.VisibleIndex = 3;
            this.colDebit.Width = 100;
            // 
            // colCredit
            // 
            this.colCredit.AppearanceCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colCredit.AppearanceCell.ForeColor = System.Drawing.Color.Green;
            this.colCredit.AppearanceCell.Options.UseFont = true;
            this.colCredit.AppearanceCell.Options.UseForeColor = true;
            this.colCredit.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colCredit.AppearanceHeader.Options.UseFont = true;
            this.colCredit.AppearanceHeader.Options.UseTextOptions = true;
            this.colCredit.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colCredit.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom;
            this.colCredit.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCredit.DisplayFormat.FormatString = "c2";
            this.colCredit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCredit.FieldName = "Credit";
            this.colCredit.Name = "colCredit";
            this.colCredit.Visible = true;
            this.colCredit.VisibleIndex = 4;
            this.colCredit.Width = 100;
            // 
            // colDetailID
            // 
            this.colDetailID.AppearanceCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDetailID.AppearanceCell.Options.UseFont = true;
            this.colDetailID.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDetailID.AppearanceHeader.Options.UseFont = true;
            this.colDetailID.AppearanceHeader.Options.UseTextOptions = true;
            this.colDetailID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colDetailID.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom;
            this.colDetailID.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colDetailID.Caption = "Row#";
            this.colDetailID.FieldName = "DetailID";
            this.colDetailID.Name = "colDetailID";
            this.colDetailID.Visible = true;
            this.colDetailID.VisibleIndex = 0;
            this.colDetailID.Width = 52;
            // 
            // colPaymentType
            // 
            this.colPaymentType.AppearanceCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colPaymentType.AppearanceCell.Options.UseFont = true;
            this.colPaymentType.AppearanceCell.Options.UseTextOptions = true;
            this.colPaymentType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPaymentType.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colPaymentType.AppearanceHeader.Options.UseFont = true;
            this.colPaymentType.Caption = "Pay Type";
            this.colPaymentType.ColumnEdit = this.repositoryItemLookUpEdit3;
            this.colPaymentType.FieldName = "PaymentType";
            this.colPaymentType.Name = "colPaymentType";
            this.colPaymentType.Visible = true;
            this.colPaymentType.VisibleIndex = 5;
            this.colPaymentType.Width = 51;
            // 
            // repositoryItemLookUpEdit3
            // 
            this.repositoryItemLookUpEdit3.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repositoryItemLookUpEdit3.Appearance.Options.UseFont = true;
            this.repositoryItemLookUpEdit3.AutoHeight = false;
            this.repositoryItemLookUpEdit3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit3.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TYPE", "TYPE", 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DESCRIPTION", "DESCRIPTION", 800, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.repositoryItemLookUpEdit3.DataSource = this.pAYMENTTYPEBindingSource;
            this.repositoryItemLookUpEdit3.DisplayMember = "TYPE";
            this.repositoryItemLookUpEdit3.LookAndFeel.SkinName = "McSkin";
            this.repositoryItemLookUpEdit3.LookAndFeel.UseDefaultLookAndFeel = false;
            this.repositoryItemLookUpEdit3.MaxLength = 1;
            this.repositoryItemLookUpEdit3.Name = "repositoryItemLookUpEdit3";
            this.repositoryItemLookUpEdit3.NullText = "";
            this.repositoryItemLookUpEdit3.ValueMember = "TYPE";
            // 
            // pAYMENTTYPEBindingSource
            // 
            this.pAYMENTTYPEBindingSource.DataMember = "PAYMENTTYPE";
            this.pAYMENTTYPEBindingSource.DataSource = this.listData;
            // 
            // listData
            // 
            this.listData.DataSetName = "ListData";
            this.listData.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // colPaymentCode
            // 
            this.colPaymentCode.AppearanceCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colPaymentCode.AppearanceCell.Options.UseFont = true;
            this.colPaymentCode.AppearanceCell.Options.UseTextOptions = true;
            this.colPaymentCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPaymentCode.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colPaymentCode.AppearanceHeader.Options.UseFont = true;
            this.colPaymentCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colPaymentCode.AppearanceHeader.TextOptions.Trimming = DevExpress.Utils.Trimming.Word;
            this.colPaymentCode.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colPaymentCode.Caption = "Pay Code";
            this.colPaymentCode.ColumnEdit = this.repositoryItemLookUpEdit4;
            this.colPaymentCode.FieldName = "PaymentCode";
            this.colPaymentCode.Name = "colPaymentCode";
            this.colPaymentCode.Visible = true;
            this.colPaymentCode.VisibleIndex = 6;
            this.colPaymentCode.Width = 51;
            // 
            // repositoryItemLookUpEdit4
            // 
            this.repositoryItemLookUpEdit4.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repositoryItemLookUpEdit4.Appearance.Options.UseFont = true;
            this.repositoryItemLookUpEdit4.AutoHeight = false;
            this.repositoryItemLookUpEdit4.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit4.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CODE", "CODE", 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DESCRIPTION", "DESCRIPTION", 500, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.repositoryItemLookUpEdit4.DataSource = this.pAYCODEBindingSource;
            this.repositoryItemLookUpEdit4.DisplayMember = "CODE";
            this.repositoryItemLookUpEdit4.LookAndFeel.SkinName = "McSkin";
            this.repositoryItemLookUpEdit4.LookAndFeel.UseDefaultLookAndFeel = false;
            this.repositoryItemLookUpEdit4.MaxLength = 1;
            this.repositoryItemLookUpEdit4.Name = "repositoryItemLookUpEdit4";
            this.repositoryItemLookUpEdit4.NullText = "";
            this.repositoryItemLookUpEdit4.ValueMember = "CODE";
            // 
            // pAYCODEBindingSource
            // 
            this.pAYCODEBindingSource.DataMember = "PAYCODE";
            this.pAYCODEBindingSource.DataSource = this.listData;
            // 
            // colGLAccount
            // 
            this.colGLAccount.AppearanceCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colGLAccount.AppearanceCell.Options.UseFont = true;
            this.colGLAccount.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colGLAccount.AppearanceHeader.Options.UseFont = true;
            this.colGLAccount.AppearanceHeader.Options.UseTextOptions = true;
            this.colGLAccount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colGLAccount.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom;
            this.colGLAccount.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colGLAccount.Caption = "Account";
            this.colGLAccount.ColumnEdit = this.repositoryItemLookUpEdit1;
            this.colGLAccount.FieldName = "GLAccount";
            this.colGLAccount.Name = "colGLAccount";
            this.colGLAccount.Visible = true;
            this.colGLAccount.VisibleIndex = 1;
            this.colGLAccount.Width = 200;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repositoryItemLookUpEdit1.Appearance.Options.UseFont = true;
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AcctID", "Acct ID", 55, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Account", "Account", 200, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.repositoryItemLookUpEdit1.DataSource = this.ticketAccountsBindingSource;
            this.repositoryItemLookUpEdit1.DisplayMember = "Account";
            this.repositoryItemLookUpEdit1.LookAndFeel.SkinName = "McSkin";
            this.repositoryItemLookUpEdit1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.NullText = "";
            this.repositoryItemLookUpEdit1.ValueMember = "AcctID";
            // 
            // ticketAccountsBindingSource
            // 
            this.ticketAccountsBindingSource.DataMember = "TicketAccounts";
            this.ticketAccountsBindingSource.DataSource = this.ticketsdataset;
            // 
            // dEALERBindingSource
            // 
            this.dEALERBindingSource.DataMember = "DEALER";
            this.dEALERBindingSource.DataSource = this.productionMainTablesBindingSource;
            // 
            // productionMainTablesBindingSource
            // 
            this.productionMainTablesBindingSource.DataSource = this.productionMainTables;
            this.productionMainTablesBindingSource.Position = 0;
            // 
            // ticketAccountsTableAdapter
            // 
            this.ticketAccountsTableAdapter.ClearBeforeFill = true;
            // 
            // pAYMENTTYPETableAdapter1
            // 
            this.pAYMENTTYPETableAdapter1.ClearBeforeFill = true;
            // 
            // pAYCODETableAdapter1
            // 
            this.pAYCODETableAdapter1.ClearBeforeFill = true;
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControl1.Controls.Add(this.richTextBox1);
            this.groupControl1.Controls.Add(this.gridControl1);
            this.groupControl1.Controls.Add(this.buttonDeleteEntry);
            this.groupControl1.Controls.Add(this.buttonCancelTicket);
            this.groupControl1.Controls.Add(this.checkBoxCloseOut);
            this.groupControl1.Controls.Add(this.buttonReprint);
            this.groupControl1.Controls.Add(this.buttonSaveTicket);
            this.groupControl1.Controls.Add(this.buttonClearDetail);
            this.groupControl1.Controls.Add(this.colorTextBoxOutofBalance);
            this.groupControl1.Controls.Add(this.colorTextBoxCredits);
            this.groupControl1.Controls.Add(this.colorTextBoxDebits);
            this.groupControl1.Controls.Add(this.label5);
            this.groupControl1.Controls.Add(this.label4);
            this.groupControl1.Controls.Add(this.textBoxApprovedBy);
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Controls.Add(this.textBoxMadeBy);
            this.groupControl1.Controls.Add(this.labelMadeBy);
            this.groupControl1.Controls.Add(this.labelDate);
            this.groupControl1.Controls.Add(this.NullableDateTimePickerDate);
            this.groupControl1.Controls.Add(this.labelExplanation);
            this.groupControl1.Controls.Add(this.buttonAdd);
            this.groupControl1.Controls.Add(this.groupBoxHeader);
            this.groupControl1.Location = new System.Drawing.Point(1, 1);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1067, 644);
            this.groupControl1.TabIndex = 95;
            this.groupControl1.Text = "groupControl1";
            // 
            // richTextBox1
            // 
            this.richTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSourceTicketHeader, "Explanation", true));
            this.richTextBox1.Location = new System.Drawing.Point(650, 154);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Properties.Appearance.Options.UseFont = true;
            this.richTextBox1.Properties.LookAndFeel.SkinName = "McSkin";
            this.richTextBox1.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.richTextBox1.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.richTextBox1.Size = new System.Drawing.Size(397, 341);
            this.richTextBox1.TabIndex = 18;
            this.richTextBox1.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(this.richTextBox1_CustomDisplayText);
            // 
            // FormTickets
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 644);
            this.Controls.Add(this.groupControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormTickets";
            this.Text = "FormTickets";
            this.Load += new System.EventHandler(this.FormTickets_Load);
            ((System.ComponentModel.ISupportInitialize)(this.textBoxName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cUSTOMERBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productionMainTables)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxMiddleInitial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxLastName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxDealerNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDealer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxDealerName.Properties)).EndInit();
            this.groupBoxHeader.ResumeLayout(false);
            this.groupBoxHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxTicketID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceTicketDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ticketsdataset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceTicketHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxMadeBy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxApprovedBy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkBoxCloseOut.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorTextBoxOutofBalance.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorTextBoxCredits.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorTextBoxDebits.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NullableDateTimePickerDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NullableDateTimePickerDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupDEALERBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pAYMENTTYPEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pAYCODEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ticketAccountsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEALERBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productionMainTablesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.richTextBox1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource bindingSourceTicketHeader;
        private TicketsTableAdapters.TicketHeaderTableAdapter ticketHeaderTableAdapter;
        private System.Windows.Forms.BindingSource bindingSourceTicketDetail;
        private TicketsTableAdapters.TicketDetailTableAdapter ticketDetailTableAdapter;
        private ProductionMainTables productionMainTables;
        private DevExpress.XtraEditors.TextEdit textBoxName;
        private DevExpress.XtraEditors.TextEdit textBoxMiddleInitial;
        private System.Windows.Forms.BindingSource cUSTOMERBindingSource;
        private DevExpress.XtraEditors.TextEdit textBoxLastName;
        private System.Windows.Forms.Label labelName;
        private ProductionMainTablesTableAdapters.CUSTOMERTableAdapter cUSTOMERTableAdapter;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit textBoxDealerNumber;
        private DevExpress.XtraEditors.TextEdit textBoxAccount;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit textBoxDealerName;
        private System.Windows.Forms.GroupBox groupBoxHeader;
        private System.Windows.Forms.BindingSource bindingSourceDealer;
        private ProductionMainTablesTableAdapters.DEALERTableAdapter dEALERTableAdapter;
        private BrightIdeasSoftware.OLVColumn TicketID;
        private DevExpress.XtraEditors.SimpleButton buttonAdd;
        public Tickets ticketsdataset;
        private System.Windows.Forms.Label labelExplanation;
        private DevExpress.XtraEditors.DateEdit NullableDateTimePickerDate;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Label labelMadeBy;
        private DevExpress.XtraEditors.TextEdit textBoxMadeBy;
        private DevExpress.XtraEditors.TextEdit textBoxApprovedBy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.TextEdit colorTextBoxDebits;
        private DevExpress.XtraEditors.TextEdit colorTextBoxCredits;
        private DevExpress.XtraEditors.TextEdit colorTextBoxOutofBalance;
        private DevExpress.XtraEditors.SimpleButton buttonClearDetail;
        private DevExpress.XtraEditors.SimpleButton buttonSaveTicket;
        private DevExpress.XtraEditors.SimpleButton buttonPrevious;
        private DevExpress.XtraEditors.SimpleButton buttonNext;
        public DevExpress.XtraEditors.SimpleButton buttonReprint;
        private DevExpress.XtraEditors.CheckEdit checkBoxCloseOut;
        private DevExpress.XtraEditors.SimpleButton buttonCancelTicket;
        private System.Windows.Forms.Label labelTicketID;
        private DevExpress.XtraEditors.TextEdit textBoxTicketID;
        private DevExpress.XtraEditors.SimpleButton buttonDeleteEntry;
        private DevExpress.XtraEditors.SimpleButton buttonEdit;
        private DevExpress.XtraEditors.SimpleButton buttonDeleteTicket;
        private DevExpress.XtraEditors.SimpleButton buttonLast;
        private DevExpress.XtraEditors.SimpleButton buttonFirst;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colSubDealer;
        private DevExpress.XtraGrid.Columns.GridColumn colDebit;
        private DevExpress.XtraGrid.Columns.GridColumn colCredit;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailID;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentType;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentCode;
        private DevExpress.XtraGrid.Columns.GridColumn colGLAccount;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private System.Windows.Forms.BindingSource ticketAccountsBindingSource;
        private TicketsTableAdapters.TicketAccountsTableAdapter ticketAccountsTableAdapter;
        private System.Windows.Forms.BindingSource dEALERBindingSource;
        private System.Windows.Forms.BindingSource productionMainTablesBindingSource;
        private System.Windows.Forms.BindingSource lookupDEALERBindingSource;
        private ProductionMainTables lookupDataSet;
        private ListData listData;
        private System.Windows.Forms.BindingSource pAYMENTTYPEBindingSource;
        private ListDataTableAdapters.PAYMENTTYPETableAdapter pAYMENTTYPETableAdapter1;
        private System.Windows.Forms.BindingSource pAYCODEBindingSource;
        private ListDataTableAdapters.PAYCODETableAdapter pAYCODETableAdapter1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit4;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.MemoEdit richTextBox1;
    }
}