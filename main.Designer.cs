namespace SerialJoy
{
    partial class main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			this.portSelector = new System.Windows.Forms.ComboBox();
			this.gridRoot = new System.Windows.Forms.TableLayoutPanel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.serval = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.gbDevBridge = new System.Windows.Forms.GroupBox();
			this.gridDevBridge = new System.Windows.Forms.TableLayoutPanel();
			this.gridSerialConf = new System.Windows.Forms.TableLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.portRateSelector = new System.Windows.Forms.ComboBox();
			this.gridSerialButtonsHolder = new System.Windows.Forms.TableLayoutPanel();
			this.btnSerialSwitch = new System.Windows.Forms.Button();
			this.btnSerialPortsRescan = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtDevAtt = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.imgStatPortsFound = new System.Windows.Forms.PictureBox();
			this.imgStatPortsParamOk = new System.Windows.Forms.PictureBox();
			this.imgStatCOMOk = new System.Windows.Forms.PictureBox();
			this.imgStatSerialData = new System.Windows.Forms.PictureBox();
			this.gridJoyConf = new System.Windows.Forms.TableLayoutPanel();
			this.label5 = new System.Windows.Forms.Label();
			this.joyIDSelector = new System.Windows.Forms.NumericUpDown();
			this.gridJoyButtonsHolder = new System.Windows.Forms.TableLayoutPanel();
			this.btnJoyAttach = new System.Windows.Forms.Button();
			this.btnJoyFeed = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.imgStatvJoyOk = new System.Windows.Forms.PictureBox();
			this.imgStatvJoyLib = new System.Windows.Forms.PictureBox();
			this.imgStatvJoyDev = new System.Windows.Forms.PictureBox();
			this.imgStatvJoyAttached = new System.Windows.Forms.PictureBox();
			this.tooltiper = new System.Windows.Forms.ToolTip(this.components);
			this.serial = new System.IO.Ports.SerialPort(this.components);
			this.bridgeGuard = new System.Windows.Forms.Timer(this.components);
			this.gridRoot.SuspendLayout();
			this.panel2.SuspendLayout();
			this.gbDevBridge.SuspendLayout();
			this.gridDevBridge.SuspendLayout();
			this.gridSerialConf.SuspendLayout();
			this.gridSerialButtonsHolder.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.imgStatPortsFound)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.imgStatPortsParamOk)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.imgStatCOMOk)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.imgStatSerialData)).BeginInit();
			this.gridJoyConf.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.joyIDSelector)).BeginInit();
			this.gridJoyButtonsHolder.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.imgStatvJoyOk)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.imgStatvJoyLib)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.imgStatvJoyDev)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.imgStatvJoyAttached)).BeginInit();
			this.SuspendLayout();
			// 
			// portSelector
			// 
			this.gridSerialConf.SetColumnSpan(this.portSelector, 2);
			this.portSelector.Dock = System.Windows.Forms.DockStyle.Fill;
			this.portSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.portSelector.FormattingEnabled = true;
			this.portSelector.Location = new System.Drawing.Point(231, 3);
			this.portSelector.Name = "portSelector";
			this.portSelector.Size = new System.Drawing.Size(64, 21);
			this.portSelector.Sorted = true;
			this.portSelector.TabIndex = 0;
			this.portSelector.SelectedIndexChanged += new System.EventHandler(this.PortSelector_SelectedIndexChanged);
			// 
			// gridRoot
			// 
			this.gridRoot.ColumnCount = 1;
			this.gridRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.gridRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.gridRoot.Controls.Add(this.panel2, 0, 1);
			this.gridRoot.Controls.Add(this.gbDevBridge, 0, 0);
			this.gridRoot.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gridRoot.Location = new System.Drawing.Point(0, 0);
			this.gridRoot.Name = "gridRoot";
			this.gridRoot.RowCount = 2;
			this.gridRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.gridRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.gridRoot.Size = new System.Drawing.Size(772, 412);
			this.gridRoot.TabIndex = 1;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.serval);
			this.panel2.Controls.Add(this.button1);
			this.panel2.Location = new System.Drawing.Point(3, 209);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(450, 161);
			this.panel2.TabIndex = 1;
			// 
			// serval
			// 
			this.serval.AutoSize = true;
			this.serval.Location = new System.Drawing.Point(107, 29);
			this.serval.Name = "serval";
			this.serval.Size = new System.Drawing.Size(41, 13);
			this.serval.TabIndex = 3;
			this.serval.Text = "label11";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(44, 84);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(77, 59);
			this.button1.TabIndex = 2;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1_Click);
			// 
			// gbDevBridge
			// 
			this.gbDevBridge.Controls.Add(this.gridDevBridge);
			this.gbDevBridge.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gbDevBridge.Location = new System.Drawing.Point(3, 3);
			this.gbDevBridge.Name = "gbDevBridge";
			this.gbDevBridge.Size = new System.Drawing.Size(766, 200);
			this.gbDevBridge.TabIndex = 2;
			this.gbDevBridge.TabStop = false;
			this.gbDevBridge.Text = "Device Bridge";
			// 
			// gridDevBridge
			// 
			this.gridDevBridge.ColumnCount = 3;
			this.gridDevBridge.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
			this.gridDevBridge.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.gridDevBridge.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
			this.gridDevBridge.Controls.Add(this.gridSerialConf, 0, 0);
			this.gridDevBridge.Controls.Add(this.gridJoyConf, 2, 0);
			this.gridDevBridge.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gridDevBridge.Location = new System.Drawing.Point(3, 16);
			this.gridDevBridge.Name = "gridDevBridge";
			this.gridDevBridge.RowCount = 1;
			this.gridDevBridge.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.gridDevBridge.Size = new System.Drawing.Size(760, 181);
			this.gridDevBridge.TabIndex = 0;
			// 
			// gridSerialConf
			// 
			this.gridSerialConf.AutoSize = true;
			this.gridSerialConf.ColumnCount = 3;
			this.gridSerialConf.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.gridSerialConf.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
			this.gridSerialConf.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 22F));
			this.gridSerialConf.Controls.Add(this.label1, 0, 0);
			this.gridSerialConf.Controls.Add(this.portRateSelector, 1, 1);
			this.gridSerialConf.Controls.Add(this.portSelector, 1, 0);
			this.gridSerialConf.Controls.Add(this.gridSerialButtonsHolder, 0, 2);
			this.gridSerialConf.Controls.Add(this.label3, 0, 3);
			this.gridSerialConf.Controls.Add(this.label4, 0, 4);
			this.gridSerialConf.Controls.Add(this.txtDevAtt, 0, 5);
			this.gridSerialConf.Controls.Add(this.label6, 0, 6);
			this.gridSerialConf.Controls.Add(this.label2, 0, 1);
			this.gridSerialConf.Controls.Add(this.imgStatPortsFound, 2, 3);
			this.gridSerialConf.Controls.Add(this.imgStatPortsParamOk, 2, 4);
			this.gridSerialConf.Controls.Add(this.imgStatCOMOk, 2, 5);
			this.gridSerialConf.Controls.Add(this.imgStatSerialData, 2, 6);
			this.gridSerialConf.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gridSerialConf.Location = new System.Drawing.Point(3, 3);
			this.gridSerialConf.Name = "gridSerialConf";
			this.gridSerialConf.RowCount = 7;
			this.gridSerialConf.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
			this.gridSerialConf.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
			this.gridSerialConf.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.gridSerialConf.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
			this.gridSerialConf.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
			this.gridSerialConf.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
			this.gridSerialConf.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
			this.gridSerialConf.Size = new System.Drawing.Size(298, 175);
			this.gridSerialConf.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(54, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Serial port";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// portRateSelector
			// 
			this.gridSerialConf.SetColumnSpan(this.portRateSelector, 2);
			this.portRateSelector.Dock = System.Windows.Forms.DockStyle.Fill;
			this.portRateSelector.FormattingEnabled = true;
			this.portRateSelector.Items.AddRange(new object[] {
            "1200",
            "4800",
            "7200",
            "9600",
            "14400",
            "19200",
            "38400",
            "56000",
            "57600",
            "115200",
            "128000"});
			this.portRateSelector.Location = new System.Drawing.Point(231, 29);
			this.portRateSelector.Name = "portRateSelector";
			this.portRateSelector.Size = new System.Drawing.Size(64, 21);
			this.portRateSelector.TabIndex = 1;
			this.portRateSelector.Text = "115200";
			this.portRateSelector.TextChanged += new System.EventHandler(this.PortRateSelector_ValueChanged);
			// 
			// gridSerialButtonsHolder
			// 
			this.gridSerialButtonsHolder.ColumnCount = 2;
			this.gridSerialConf.SetColumnSpan(this.gridSerialButtonsHolder, 3);
			this.gridSerialButtonsHolder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.gridSerialButtonsHolder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.gridSerialButtonsHolder.Controls.Add(this.btnSerialSwitch, 0, 0);
			this.gridSerialButtonsHolder.Controls.Add(this.btnSerialPortsRescan, 1, 0);
			this.gridSerialButtonsHolder.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gridSerialButtonsHolder.Location = new System.Drawing.Point(3, 55);
			this.gridSerialButtonsHolder.Name = "gridSerialButtonsHolder";
			this.gridSerialButtonsHolder.RowCount = 1;
			this.gridSerialButtonsHolder.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.gridSerialButtonsHolder.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
			this.gridSerialButtonsHolder.Size = new System.Drawing.Size(292, 29);
			this.gridSerialButtonsHolder.TabIndex = 3;
			// 
			// btnSerialSwitch
			// 
			this.btnSerialSwitch.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnSerialSwitch.Location = new System.Drawing.Point(3, 3);
			this.btnSerialSwitch.Name = "btnSerialSwitch";
			this.btnSerialSwitch.Size = new System.Drawing.Size(140, 23);
			this.btnSerialSwitch.TabIndex = 0;
			this.btnSerialSwitch.Text = "Attach";
			this.btnSerialSwitch.UseVisualStyleBackColor = true;
			this.btnSerialSwitch.Click += new System.EventHandler(this.BtnSerialSwitch_Click);
			// 
			// btnSerialPortsRescan
			// 
			this.btnSerialPortsRescan.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnSerialPortsRescan.Location = new System.Drawing.Point(149, 3);
			this.btnSerialPortsRescan.Name = "btnSerialPortsRescan";
			this.btnSerialPortsRescan.Size = new System.Drawing.Size(140, 23);
			this.btnSerialPortsRescan.TabIndex = 1;
			this.btnSerialPortsRescan.Text = "Rescan";
			this.btnSerialPortsRescan.UseVisualStyleBackColor = true;
			this.btnSerialPortsRescan.Click += new System.EventHandler(this.BtnSerialPortsRescan_Click);
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label3.AutoSize = true;
			this.gridSerialConf.SetColumnSpan(this.label3, 2);
			this.label3.Location = new System.Drawing.Point(3, 91);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(89, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Serial ports found";
			// 
			// label4
			// 
			this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label4.AutoSize = true;
			this.gridSerialConf.SetColumnSpan(this.label4, 2);
			this.label4.Location = new System.Drawing.Point(3, 113);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(107, 13);
			this.label4.TabIndex = 4;
			this.label4.Text = "Serial port configured";
			// 
			// txtDevAtt
			// 
			this.txtDevAtt.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.txtDevAtt.AutoSize = true;
			this.gridSerialConf.SetColumnSpan(this.txtDevAtt, 2);
			this.txtDevAtt.Location = new System.Drawing.Point(3, 135);
			this.txtDevAtt.Name = "txtDevAtt";
			this.txtDevAtt.Size = new System.Drawing.Size(86, 13);
			this.txtDevAtt.TabIndex = 4;
			this.txtDevAtt.Text = "Device attached";
			// 
			// label6
			// 
			this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label6.AutoSize = true;
			this.gridSerialConf.SetColumnSpan(this.label6, 2);
			this.label6.Location = new System.Drawing.Point(3, 157);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(52, 13);
			this.label6.TabIndex = 4;
			this.label6.Text = "Data flow";
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(78, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Serial data rate";
			// 
			// imgStatPortsFound
			// 
			this.imgStatPortsFound.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.imgStatPortsFound.Image = global::SerialJoy.Properties.Resources.unkn;
			this.imgStatPortsFound.Location = new System.Drawing.Point(279, 90);
			this.imgStatPortsFound.Name = "imgStatPortsFound";
			this.imgStatPortsFound.Size = new System.Drawing.Size(16, 16);
			this.imgStatPortsFound.TabIndex = 5;
			this.imgStatPortsFound.TabStop = false;
			// 
			// imgStatPortsParamOk
			// 
			this.imgStatPortsParamOk.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.imgStatPortsParamOk.Image = global::SerialJoy.Properties.Resources.unkn;
			this.imgStatPortsParamOk.Location = new System.Drawing.Point(279, 112);
			this.imgStatPortsParamOk.Name = "imgStatPortsParamOk";
			this.imgStatPortsParamOk.Size = new System.Drawing.Size(16, 16);
			this.imgStatPortsParamOk.TabIndex = 5;
			this.imgStatPortsParamOk.TabStop = false;
			// 
			// imgStatCOMOk
			// 
			this.imgStatCOMOk.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.imgStatCOMOk.Image = global::SerialJoy.Properties.Resources.unkn;
			this.imgStatCOMOk.Location = new System.Drawing.Point(279, 134);
			this.imgStatCOMOk.Name = "imgStatCOMOk";
			this.imgStatCOMOk.Size = new System.Drawing.Size(16, 16);
			this.imgStatCOMOk.TabIndex = 5;
			this.imgStatCOMOk.TabStop = false;
			// 
			// imgStatSerialData
			// 
			this.imgStatSerialData.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.imgStatSerialData.Image = global::SerialJoy.Properties.Resources.unkn;
			this.imgStatSerialData.Location = new System.Drawing.Point(279, 156);
			this.imgStatSerialData.Name = "imgStatSerialData";
			this.imgStatSerialData.Size = new System.Drawing.Size(16, 16);
			this.imgStatSerialData.TabIndex = 5;
			this.imgStatSerialData.TabStop = false;
			// 
			// gridJoyConf
			// 
			this.gridJoyConf.ColumnCount = 3;
			this.gridJoyConf.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.gridJoyConf.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
			this.gridJoyConf.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 22F));
			this.gridJoyConf.Controls.Add(this.label5, 0, 0);
			this.gridJoyConf.Controls.Add(this.joyIDSelector, 1, 0);
			this.gridJoyConf.Controls.Add(this.gridJoyButtonsHolder, 0, 1);
			this.gridJoyConf.Controls.Add(this.label7, 0, 2);
			this.gridJoyConf.Controls.Add(this.label8, 0, 3);
			this.gridJoyConf.Controls.Add(this.label9, 0, 4);
			this.gridJoyConf.Controls.Add(this.label10, 0, 5);
			this.gridJoyConf.Controls.Add(this.imgStatvJoyOk, 2, 2);
			this.gridJoyConf.Controls.Add(this.imgStatvJoyLib, 2, 3);
			this.gridJoyConf.Controls.Add(this.imgStatvJoyDev, 2, 4);
			this.gridJoyConf.Controls.Add(this.imgStatvJoyAttached, 2, 5);
			this.gridJoyConf.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gridJoyConf.Location = new System.Drawing.Point(459, 3);
			this.gridJoyConf.Name = "gridJoyConf";
			this.gridJoyConf.RowCount = 6;
			this.gridJoyConf.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
			this.gridJoyConf.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.gridJoyConf.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
			this.gridJoyConf.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
			this.gridJoyConf.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
			this.gridJoyConf.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
			this.gridJoyConf.Size = new System.Drawing.Size(298, 175);
			this.gridJoyConf.TabIndex = 1;
			// 
			// label5
			// 
			this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(3, 6);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(94, 13);
			this.label5.TabIndex = 0;
			this.label5.Text = "Joystick device ID";
			// 
			// joyIDSelector
			// 
			this.gridJoyConf.SetColumnSpan(this.joyIDSelector, 2);
			this.joyIDSelector.Dock = System.Windows.Forms.DockStyle.Fill;
			this.joyIDSelector.Location = new System.Drawing.Point(231, 3);
			this.joyIDSelector.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
			this.joyIDSelector.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.joyIDSelector.Name = "joyIDSelector";
			this.joyIDSelector.Size = new System.Drawing.Size(64, 20);
			this.joyIDSelector.TabIndex = 1;
			this.joyIDSelector.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.joyIDSelector.ValueChanged += new System.EventHandler(this.joyIDupdate);
			// 
			// gridJoyButtonsHolder
			// 
			this.gridJoyButtonsHolder.ColumnCount = 2;
			this.gridJoyConf.SetColumnSpan(this.gridJoyButtonsHolder, 3);
			this.gridJoyButtonsHolder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.gridJoyButtonsHolder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.gridJoyButtonsHolder.Controls.Add(this.btnJoyAttach, 0, 0);
			this.gridJoyButtonsHolder.Controls.Add(this.btnJoyFeed, 1, 0);
			this.gridJoyButtonsHolder.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gridJoyButtonsHolder.Location = new System.Drawing.Point(3, 29);
			this.gridJoyButtonsHolder.Name = "gridJoyButtonsHolder";
			this.gridJoyButtonsHolder.RowCount = 1;
			this.gridJoyButtonsHolder.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.gridJoyButtonsHolder.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.gridJoyButtonsHolder.Size = new System.Drawing.Size(292, 55);
			this.gridJoyButtonsHolder.TabIndex = 2;
			// 
			// btnJoyAttach
			// 
			this.btnJoyAttach.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnJoyAttach.Location = new System.Drawing.Point(3, 3);
			this.btnJoyAttach.Name = "btnJoyAttach";
			this.btnJoyAttach.Size = new System.Drawing.Size(140, 49);
			this.btnJoyAttach.TabIndex = 0;
			this.btnJoyAttach.Text = "Attach";
			this.btnJoyAttach.UseVisualStyleBackColor = true;
			this.btnJoyAttach.Click += new System.EventHandler(this.BtnJoyAttach_Click);
			// 
			// btnJoyFeed
			// 
			this.btnJoyFeed.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnJoyFeed.Location = new System.Drawing.Point(149, 3);
			this.btnJoyFeed.Name = "btnJoyFeed";
			this.btnJoyFeed.Size = new System.Drawing.Size(140, 49);
			this.btnJoyFeed.TabIndex = 1;
			this.btnJoyFeed.Text = "Follow serial";
			this.btnJoyFeed.UseVisualStyleBackColor = true;
			// 
			// label7
			// 
			this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label7.AutoSize = true;
			this.gridJoyConf.SetColumnSpan(this.label7, 2);
			this.label7.Location = new System.Drawing.Point(3, 91);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(103, 13);
			this.label7.TabIndex = 4;
			this.label7.Text = "Virtual joystick driver";
			// 
			// label8
			// 
			this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label8.AutoSize = true;
			this.gridJoyConf.SetColumnSpan(this.label8, 2);
			this.label8.Location = new System.Drawing.Point(3, 113);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(104, 13);
			this.label8.TabIndex = 4;
			this.label8.Text = "Virtual joystick library";
			// 
			// label9
			// 
			this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label9.AutoSize = true;
			this.gridJoyConf.SetColumnSpan(this.label9, 2);
			this.label9.Location = new System.Drawing.Point(3, 135);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(100, 13);
			this.label9.TabIndex = 4;
			this.label9.Text = "Virtual device ready";
			// 
			// label10
			// 
			this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label10.AutoSize = true;
			this.gridJoyConf.SetColumnSpan(this.label10, 2);
			this.label10.Location = new System.Drawing.Point(3, 157);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(86, 13);
			this.label10.TabIndex = 4;
			this.label10.Text = "Device attached";
			// 
			// imgStatvJoyOk
			// 
			this.imgStatvJoyOk.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.imgStatvJoyOk.Image = global::SerialJoy.Properties.Resources.unkn;
			this.imgStatvJoyOk.Location = new System.Drawing.Point(279, 90);
			this.imgStatvJoyOk.Name = "imgStatvJoyOk";
			this.imgStatvJoyOk.Size = new System.Drawing.Size(16, 16);
			this.imgStatvJoyOk.TabIndex = 5;
			this.imgStatvJoyOk.TabStop = false;
			// 
			// imgStatvJoyLib
			// 
			this.imgStatvJoyLib.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.imgStatvJoyLib.Image = global::SerialJoy.Properties.Resources.unkn;
			this.imgStatvJoyLib.Location = new System.Drawing.Point(279, 112);
			this.imgStatvJoyLib.Name = "imgStatvJoyLib";
			this.imgStatvJoyLib.Size = new System.Drawing.Size(16, 16);
			this.imgStatvJoyLib.TabIndex = 5;
			this.imgStatvJoyLib.TabStop = false;
			// 
			// imgStatvJoyDev
			// 
			this.imgStatvJoyDev.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.imgStatvJoyDev.Image = global::SerialJoy.Properties.Resources.unkn;
			this.imgStatvJoyDev.Location = new System.Drawing.Point(279, 134);
			this.imgStatvJoyDev.Name = "imgStatvJoyDev";
			this.imgStatvJoyDev.Size = new System.Drawing.Size(16, 16);
			this.imgStatvJoyDev.TabIndex = 5;
			this.imgStatvJoyDev.TabStop = false;
			// 
			// imgStatvJoyAttached
			// 
			this.imgStatvJoyAttached.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.imgStatvJoyAttached.Image = global::SerialJoy.Properties.Resources.unkn;
			this.imgStatvJoyAttached.Location = new System.Drawing.Point(279, 156);
			this.imgStatvJoyAttached.Name = "imgStatvJoyAttached";
			this.imgStatvJoyAttached.Size = new System.Drawing.Size(16, 16);
			this.imgStatvJoyAttached.TabIndex = 5;
			this.imgStatvJoyAttached.TabStop = false;
			// 
			// serial
			// 
			this.serial.BaudRate = 115200;
			this.serial.ErrorReceived += new System.IO.Ports.SerialErrorReceivedEventHandler(this.Serial_ErrorReceived);
			this.serial.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.Serial_DataReceived);
			// 
			// bridgeGuard
			// 
			this.bridgeGuard.Interval = 500;
			this.bridgeGuard.Tick += new System.EventHandler(this.BridgeGuard_Tick);
			// 
			// main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(772, 412);
			this.Controls.Add(this.gridRoot);
			this.Name = "main";
			this.Text = "SerialJoy";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
			this.Load += new System.EventHandler(this.Main_Load);
			this.gridRoot.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.gbDevBridge.ResumeLayout(false);
			this.gridDevBridge.ResumeLayout(false);
			this.gridDevBridge.PerformLayout();
			this.gridSerialConf.ResumeLayout(false);
			this.gridSerialConf.PerformLayout();
			this.gridSerialButtonsHolder.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.imgStatPortsFound)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.imgStatPortsParamOk)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.imgStatCOMOk)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.imgStatSerialData)).EndInit();
			this.gridJoyConf.ResumeLayout(false);
			this.gridJoyConf.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.joyIDSelector)).EndInit();
			this.gridJoyButtonsHolder.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.imgStatvJoyOk)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.imgStatvJoyLib)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.imgStatvJoyDev)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.imgStatvJoyAttached)).EndInit();
			this.ResumeLayout(false);

        }

		#endregion

		private System.Windows.Forms.ComboBox portSelector;
		private System.Windows.Forms.TableLayoutPanel gridRoot;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.GroupBox gbDevBridge;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ComboBox portRateSelector;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TableLayoutPanel gridDevBridge;
		private System.Windows.Forms.TableLayoutPanel gridSerialConf;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TableLayoutPanel gridSerialButtonsHolder;
		private System.Windows.Forms.Button btnSerialSwitch;
		private System.Windows.Forms.Button btnSerialPortsRescan;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.PictureBox imgStatPortsFound;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.PictureBox imgStatPortsParamOk;
		private System.Windows.Forms.Label txtDevAtt;
		private System.Windows.Forms.PictureBox imgStatCOMOk;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.PictureBox imgStatSerialData;
		private System.Windows.Forms.TableLayoutPanel gridJoyConf;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown joyIDSelector;
		private System.Windows.Forms.TableLayoutPanel gridJoyButtonsHolder;
		private System.Windows.Forms.Button btnJoyAttach;
		private System.Windows.Forms.Button btnJoyFeed;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.PictureBox imgStatvJoyOk;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.PictureBox imgStatvJoyLib;
		private System.Windows.Forms.ToolTip tooltiper;
		private System.Windows.Forms.PictureBox imgStatvJoyDev;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.PictureBox imgStatvJoyAttached;
		private System.Windows.Forms.Label serval;
		private System.IO.Ports.SerialPort serial;
		private System.Windows.Forms.Timer bridgeGuard;
	}
}

