﻿
namespace IAC2018SQL
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
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.cUSTOMERBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productionMainTables = new IAC2018SQL.ProductionMainTables();
            this.textBoxMiddleInitial = new System.Windows.Forms.TextBox();
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxDealerNumber = new System.Windows.Forms.TextBox();
            this.bindingSourceDealer = new System.Windows.Forms.BindingSource(this.components);
            this.textBoxAccount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxDealerName = new System.Windows.Forms.TextBox();
            this.groupBoxHeader = new System.Windows.Forms.GroupBox();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonPrevious = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.dataListView1 = new BrightIdeasSoftware.DataListView();
            this.DetailID = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.TicketID = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.Account = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.Dealer = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.Debit = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.Credit = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.PaymentType = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.PaymentCode = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.bindingSourceTicketDetail = new System.Windows.Forms.BindingSource(this.components);
            this.ticketsdataset = new IAC2018SQL.Tickets();
            this.cUSTOMERTableAdapter = new IAC2018SQL.ProductionMainTablesTableAdapters.CUSTOMERTableAdapter();
            this.dEALERTableAdapter = new IAC2018SQL.ProductionMainTablesTableAdapters.DEALERTableAdapter();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.bindingSourceTicketHeader = new System.Windows.Forms.BindingSource(this.components);
            this.labelExplanation = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.labelMadeBy = new System.Windows.Forms.Label();
            this.textBoxMadeBy = new System.Windows.Forms.TextBox();
            this.textBoxApprovedBy = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonClearDetail = new System.Windows.Forms.Button();
            this.buttonSaveTicket = new System.Windows.Forms.Button();
            this.ticketHeaderTableAdapter = new IAC2018SQL.TicketsTableAdapters.TicketHeaderTableAdapter();
            this.ticketDetailTableAdapter = new IAC2018SQL.TicketsTableAdapters.TicketDetailTableAdapter();
            this.buttonReprint = new System.Windows.Forms.Button();
            this.colorTextBoxOutofBalance = new IAC2018SQL.ColorTextBox();
            this.colorTextBoxCredits = new IAC2018SQL.ColorTextBox();
            this.colorTextBoxDebits = new IAC2018SQL.ColorTextBox();
            this.txtFirstPayDate = new ProManApp.NullableDateTimePicker();
            this.checkBoxCloseOut = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.cUSTOMERBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productionMainTables)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDealer)).BeginInit();
            this.groupBoxHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceTicketDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ticketsdataset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceTicketHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFirstPayDate)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxName
            // 
            this.textBoxName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cUSTOMERBindingSource, "CUSTOMER_FIRST_NAME", true));
            this.textBoxName.Enabled = false;
            this.textBoxName.Location = new System.Drawing.Point(187, 13);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.ReadOnly = true;
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
            this.textBoxMiddleInitial.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cUSTOMERBindingSource, "MiddleName", true));
            this.textBoxMiddleInitial.Enabled = false;
            this.textBoxMiddleInitial.Location = new System.Drawing.Point(542, 13);
            this.textBoxMiddleInitial.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxMiddleInitial.Name = "textBoxMiddleInitial";
            this.textBoxMiddleInitial.ReadOnly = true;
            this.textBoxMiddleInitial.Size = new System.Drawing.Size(24, 22);
            this.textBoxMiddleInitial.TabIndex = 2;
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cUSTOMERBindingSource, "CUSTOMER_LAST_NAME", true));
            this.textBoxLastName.Enabled = false;
            this.textBoxLastName.Location = new System.Drawing.Point(576, 13);
            this.textBoxLastName.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.ReadOnly = true;
            this.textBoxLastName.Size = new System.Drawing.Size(347, 22);
            this.textBoxLastName.TabIndex = 3;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(131, 21);
            this.labelName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(48, 16);
            this.labelName.TabIndex = 4;
            this.labelName.Text = "Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(126, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Dealer:";
            // 
            // textBoxDealerNumber
            // 
            this.textBoxDealerNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceDealer, "DEALER_ACC_NO", true));
            this.textBoxDealerNumber.Enabled = false;
            this.textBoxDealerNumber.Location = new System.Drawing.Point(187, 51);
            this.textBoxDealerNumber.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDealerNumber.Name = "textBoxDealerNumber";
            this.textBoxDealerNumber.ReadOnly = true;
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
            this.textBoxAccount.BackColor = System.Drawing.Color.Gold;
            this.textBoxAccount.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cUSTOMERBindingSource, "CUSTOMER_NO", true));
            this.textBoxAccount.Location = new System.Drawing.Point(187, 85);
            this.textBoxAccount.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxAccount.Name = "textBoxAccount";
            this.textBoxAccount.Size = new System.Drawing.Size(65, 22);
            this.textBoxAccount.TabIndex = 8;
            this.textBoxAccount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GeneralKeypress);
            this.textBoxAccount.Validated += new System.EventHandler(this.textBoxAccount_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(115, 85);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Account:";
            // 
            // textBoxDealerName
            // 
            this.textBoxDealerName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceDealer, "DEALER_NAME", true));
            this.textBoxDealerName.Enabled = false;
            this.textBoxDealerName.Location = new System.Drawing.Point(240, 51);
            this.textBoxDealerName.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDealerName.Name = "textBoxDealerName";
            this.textBoxDealerName.ReadOnly = true;
            this.textBoxDealerName.Size = new System.Drawing.Size(347, 22);
            this.textBoxDealerName.TabIndex = 9;
            // 
            // groupBoxHeader
            // 
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
            this.groupBoxHeader.Location = new System.Drawing.Point(11, 2);
            this.groupBoxHeader.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxHeader.Name = "groupBoxHeader";
            this.groupBoxHeader.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxHeader.Size = new System.Drawing.Size(1038, 121);
            this.groupBoxHeader.TabIndex = 10;
            this.groupBoxHeader.TabStop = false;
            // 
            // buttonNext
            // 
            this.buttonNext.BackgroundImage = global::IAC2018SQL.Properties.Resources.Next_16x_24;
            this.buttonNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonNext.Location = new System.Drawing.Point(961, 70);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(35, 33);
            this.buttonNext.TabIndex = 11;
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonPrevious
            // 
            this.buttonPrevious.BackgroundImage = global::IAC2018SQL.Properties.Resources.Previous_16x_24;
            this.buttonPrevious.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonPrevious.Location = new System.Drawing.Point(917, 70);
            this.buttonPrevious.Name = "buttonPrevious";
            this.buttonPrevious.Size = new System.Drawing.Size(35, 33);
            this.buttonPrevious.TabIndex = 10;
            this.buttonPrevious.UseVisualStyleBackColor = true;
            this.buttonPrevious.Click += new System.EventHandler(this.buttonPrevious_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(14, 603);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(100, 28);
            this.buttonAdd.TabIndex = 11;
            this.buttonAdd.Text = "&Add Entry";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // dataListView1
            // 
            this.dataListView1.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.dataListView1.AllColumns.Add(this.DetailID);
            this.dataListView1.AllColumns.Add(this.TicketID);
            this.dataListView1.AllColumns.Add(this.Account);
            this.dataListView1.AllColumns.Add(this.Dealer);
            this.dataListView1.AllColumns.Add(this.Debit);
            this.dataListView1.AllColumns.Add(this.Credit);
            this.dataListView1.AllColumns.Add(this.PaymentType);
            this.dataListView1.AllColumns.Add(this.PaymentCode);
            this.dataListView1.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClick;
            this.dataListView1.CellEditUseWholeCell = false;
            this.dataListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.DetailID,
            this.Account,
            this.Dealer,
            this.Debit,
            this.Credit,
            this.PaymentType,
            this.PaymentCode});
            this.dataListView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.dataListView1.DataSource = this.bindingSourceTicketDetail;
            this.dataListView1.GridLines = true;
            this.dataListView1.HasCollapsibleGroups = false;
            this.dataListView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.dataListView1.HeaderWordWrap = true;
            this.dataListView1.HideSelection = false;
            this.dataListView1.Location = new System.Drawing.Point(14, 131);
            this.dataListView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataListView1.Name = "dataListView1";
            this.dataListView1.OverlayImage.Transparency = 64;
            this.dataListView1.ShowGroups = false;
            this.dataListView1.Size = new System.Drawing.Size(615, 365);
            this.dataListView1.TabIndex = 0;
            this.dataListView1.UseAlternatingBackColors = true;
            this.dataListView1.UseCompatibleStateImageBehavior = false;
            this.dataListView1.View = System.Windows.Forms.View.Details;
            this.dataListView1.CellEditFinished += new BrightIdeasSoftware.CellEditEventHandler(this.dataListView1_CellEditFinished);
            this.dataListView1.CellEditFinishing += new BrightIdeasSoftware.CellEditEventHandler(this.dataListView1_CellEditFinishing);
            this.dataListView1.CellEditStarting += new BrightIdeasSoftware.CellEditEventHandler(this.dataListView1_CellEditStarting);
            this.dataListView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GeneralKeypress);
            this.dataListView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataListView1_MouseClick);
            // 
            // DetailID
            // 
            this.DetailID.AspectName = "DetailID";
            this.DetailID.Groupable = false;
            this.DetailID.IsEditable = false;
            this.DetailID.Text = "Row#";
            this.DetailID.Width = 51;
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
            // Account
            // 
            this.Account.AspectName = "GLAccount";
            this.Account.CellEditUseWholeCell = true;
            this.Account.Text = "Account";
            this.Account.Width = 200;
            // 
            // Dealer
            // 
            this.Dealer.AspectName = "SubDealer";
            this.Dealer.Text = "Dealer";
            // 
            // Debit
            // 
            this.Debit.AspectName = "Debit";
            this.Debit.AspectToStringFormat = "{0:C}";
            this.Debit.AutoCompleteEditor = false;
            this.Debit.AutoCompleteEditorMode = System.Windows.Forms.AutoCompleteMode.None;
            this.Debit.ButtonSizing = BrightIdeasSoftware.OLVColumn.ButtonSizingMode.FixedBounds;
            this.Debit.Text = "Debit";
            this.Debit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Debit.Width = 100;
            // 
            // Credit
            // 
            this.Credit.AspectName = "Credit";
            this.Credit.AspectToStringFormat = "{0:C}";
            this.Credit.Text = "Credit";
            this.Credit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Credit.Width = 100;
            // 
            // PaymentType
            // 
            this.PaymentType.AspectName = "PaymentType";
            this.PaymentType.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.PaymentType.Text = "Pay Type";
            this.PaymentType.Width = 50;
            // 
            // PaymentCode
            // 
            this.PaymentCode.AspectName = "PaymentCode";
            this.PaymentCode.Text = "Pay Code";
            this.PaymentCode.Width = 50;
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
            // richTextBox1
            // 
            this.richTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceTicketHeader, "Explanation", true));
            this.richTextBox1.Location = new System.Drawing.Point(652, 155);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(397, 341);
            this.richTextBox1.TabIndex = 12;
            this.richTextBox1.Text = "";
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
            this.labelExplanation.Location = new System.Drawing.Point(652, 131);
            this.labelExplanation.Name = "labelExplanation";
            this.labelExplanation.Size = new System.Drawing.Size(93, 16);
            this.labelExplanation.TabIndex = 13;
            this.labelExplanation.Text = "Explanation:";
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDate.Location = new System.Drawing.Point(373, 508);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(53, 20);
            this.labelDate.TabIndex = 78;
            this.labelDate.Text = "Date:";
            // 
            // labelMadeBy
            // 
            this.labelMadeBy.AutoSize = true;
            this.labelMadeBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMadeBy.Location = new System.Drawing.Point(565, 508);
            this.labelMadeBy.Name = "labelMadeBy";
            this.labelMadeBy.Size = new System.Drawing.Size(83, 20);
            this.labelMadeBy.TabIndex = 79;
            this.labelMadeBy.Text = "Made By:";
            // 
            // textBoxMadeBy
            // 
            this.textBoxMadeBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMadeBy.Location = new System.Drawing.Point(652, 502);
            this.textBoxMadeBy.Name = "textBoxMadeBy";
            this.textBoxMadeBy.ReadOnly = true;
            this.textBoxMadeBy.Size = new System.Drawing.Size(397, 26);
            this.textBoxMadeBy.TabIndex = 80;
            // 
            // textBoxApprovedBy
            // 
            this.textBoxApprovedBy.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceTicketHeader, "ApprovedBy", true));
            this.textBoxApprovedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxApprovedBy.Location = new System.Drawing.Point(652, 535);
            this.textBoxApprovedBy.Name = "textBoxApprovedBy";
            this.textBoxApprovedBy.Size = new System.Drawing.Size(397, 26);
            this.textBoxApprovedBy.TabIndex = 82;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(533, 541);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 20);
            this.label3.TabIndex = 81;
            this.label3.Text = "Approved By:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(261, 541);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 20);
            this.label4.TabIndex = 83;
            this.label4.Text = "Totals:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(190, 565);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 20);
            this.label5.TabIndex = 84;
            this.label5.Text = "Out of Balance:";
            // 
            // buttonClearDetail
            // 
            this.buttonClearDetail.Location = new System.Drawing.Point(122, 603);
            this.buttonClearDetail.Margin = new System.Windows.Forms.Padding(4);
            this.buttonClearDetail.Name = "buttonClearDetail";
            this.buttonClearDetail.Size = new System.Drawing.Size(100, 28);
            this.buttonClearDetail.TabIndex = 88;
            this.buttonClearDetail.Text = "Clear Detail";
            this.buttonClearDetail.UseVisualStyleBackColor = true;
            this.buttonClearDetail.Click += new System.EventHandler(this.buttonClearDetail_Click);
            // 
            // buttonSaveTicket
            // 
            this.buttonSaveTicket.Location = new System.Drawing.Point(230, 603);
            this.buttonSaveTicket.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSaveTicket.Name = "buttonSaveTicket";
            this.buttonSaveTicket.Size = new System.Drawing.Size(100, 28);
            this.buttonSaveTicket.TabIndex = 89;
            this.buttonSaveTicket.Text = "&Save Ticket";
            this.buttonSaveTicket.UseVisualStyleBackColor = true;
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
            // buttonReprint
            // 
            this.buttonReprint.Enabled = false;
            this.buttonReprint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReprint.Image = ((System.Drawing.Image)(resources.GetObject("buttonReprint.Image")));
            this.buttonReprint.Location = new System.Drawing.Point(972, 567);
            this.buttonReprint.Name = "buttonReprint";
            this.buttonReprint.Size = new System.Drawing.Size(74, 65);
            this.buttonReprint.TabIndex = 90;
            this.buttonReprint.Text = "&Reprint";
            this.buttonReprint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonReprint.UseVisualStyleBackColor = true;
            this.buttonReprint.Click += new System.EventHandler(this.buttonReprint_Click);
            // 
            // colorTextBoxOutofBalance
            // 
            this.colorTextBoxOutofBalance.Location = new System.Drawing.Point(329, 563);
            this.colorTextBoxOutofBalance.Name = "colorTextBoxOutofBalance";
            this.colorTextBoxOutofBalance.ReadOnly = true;
            this.colorTextBoxOutofBalance.Size = new System.Drawing.Size(100, 22);
            this.colorTextBoxOutofBalance.TabIndex = 87;
            this.colorTextBoxOutofBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // colorTextBoxCredits
            // 
            this.colorTextBoxCredits.Location = new System.Drawing.Point(430, 538);
            this.colorTextBoxCredits.Name = "colorTextBoxCredits";
            this.colorTextBoxCredits.ReadOnly = true;
            this.colorTextBoxCredits.Size = new System.Drawing.Size(100, 22);
            this.colorTextBoxCredits.TabIndex = 86;
            this.colorTextBoxCredits.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // colorTextBoxDebits
            // 
            this.colorTextBoxDebits.Location = new System.Drawing.Point(329, 538);
            this.colorTextBoxDebits.Name = "colorTextBoxDebits";
            this.colorTextBoxDebits.ReadOnly = true;
            this.colorTextBoxDebits.Size = new System.Drawing.Size(100, 22);
            this.colorTextBoxDebits.TabIndex = 85;
            this.colorTextBoxDebits.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtFirstPayDate
            // 
            this.txtFirstPayDate.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceTicketHeader, "Date", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "1/1/1980", "d"));
            this.txtFirstPayDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstPayDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtFirstPayDate.Location = new System.Drawing.Point(432, 502);
            this.txtFirstPayDate.Name = "txtFirstPayDate";
            this.txtFirstPayDate.ReadOnly = true;
            this.txtFirstPayDate.Size = new System.Drawing.Size(97, 26);
            this.txtFirstPayDate.TabIndex = 77;
            this.txtFirstPayDate.Value = new System.DateTime(2021, 5, 26, 0, 0, 0, 0);
            // 
            // checkBoxCloseOut
            // 
            this.checkBoxCloseOut.AutoSize = true;
            this.checkBoxCloseOut.Checked = true;
            this.checkBoxCloseOut.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCloseOut.Enabled = false;
            this.checkBoxCloseOut.Location = new System.Drawing.Point(14, 507);
            this.checkBoxCloseOut.Name = "checkBoxCloseOut";
            this.checkBoxCloseOut.Size = new System.Drawing.Size(132, 20);
            this.checkBoxCloseOut.TabIndex = 91;
            this.checkBoxCloseOut.Text = "Close Out Ticket?";
            this.checkBoxCloseOut.UseVisualStyleBackColor = true;
            // 
            // FormTickets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1067, 644);
            this.Controls.Add(this.checkBoxCloseOut);
            this.Controls.Add(this.buttonReprint);
            this.Controls.Add(this.buttonSaveTicket);
            this.Controls.Add(this.buttonClearDetail);
            this.Controls.Add(this.colorTextBoxOutofBalance);
            this.Controls.Add(this.colorTextBoxCredits);
            this.Controls.Add(this.colorTextBoxDebits);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxApprovedBy);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxMadeBy);
            this.Controls.Add(this.labelMadeBy);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.txtFirstPayDate);
            this.Controls.Add(this.labelExplanation);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.groupBoxHeader);
            this.Controls.Add(this.dataListView1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormTickets";
            this.Text = "FormTickets";
            this.Load += new System.EventHandler(this.FormTickets_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cUSTOMERBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productionMainTables)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDealer)).EndInit();
            this.groupBoxHeader.ResumeLayout(false);
            this.groupBoxHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceTicketDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ticketsdataset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceTicketHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFirstPayDate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BrightIdeasSoftware.DataListView dataListView1;
        private System.Windows.Forms.BindingSource bindingSourceTicketHeader;
        private TicketsTableAdapters.TicketHeaderTableAdapter ticketHeaderTableAdapter;
        private System.Windows.Forms.BindingSource bindingSourceTicketDetail;
        private TicketsTableAdapters.TicketDetailTableAdapter ticketDetailTableAdapter;
        private ProductionMainTables productionMainTables;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxMiddleInitial;
        private System.Windows.Forms.BindingSource cUSTOMERBindingSource;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.Label labelName;
        private ProductionMainTablesTableAdapters.CUSTOMERTableAdapter cUSTOMERTableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDealerNumber;
        private System.Windows.Forms.TextBox textBoxAccount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxDealerName;
        private System.Windows.Forms.GroupBox groupBoxHeader;
        private System.Windows.Forms.BindingSource bindingSourceDealer;
        private ProductionMainTablesTableAdapters.DEALERTableAdapter dEALERTableAdapter;
        private BrightIdeasSoftware.OLVColumn TicketID;
        private BrightIdeasSoftware.OLVColumn DetailID;
        private BrightIdeasSoftware.OLVColumn Account;
        private System.Windows.Forms.Button buttonAdd;
        public Tickets ticketsdataset;
        private BrightIdeasSoftware.OLVColumn Dealer;
        private BrightIdeasSoftware.OLVColumn Debit;
        private BrightIdeasSoftware.OLVColumn Credit;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label labelExplanation;
        private ProManApp.NullableDateTimePicker txtFirstPayDate;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Label labelMadeBy;
        private System.Windows.Forms.TextBox textBoxMadeBy;
        private System.Windows.Forms.TextBox textBoxApprovedBy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private ColorTextBox colorTextBoxDebits;
        private ColorTextBox colorTextBoxCredits;
        private ColorTextBox colorTextBoxOutofBalance;
        private System.Windows.Forms.Button buttonClearDetail;
        private System.Windows.Forms.Button buttonSaveTicket;
        private BrightIdeasSoftware.OLVColumn PaymentType;
        private BrightIdeasSoftware.OLVColumn PaymentCode;
        private System.Windows.Forms.Button buttonPrevious;
        private System.Windows.Forms.Button buttonNext;
        public System.Windows.Forms.Button buttonReprint;
        private System.Windows.Forms.CheckBox checkBoxCloseOut;
    }
}