using System;
using System.Windows.Forms;
using System.Management;
//using System.Threading;
using vJoyInterfaceWrap;

#pragma warning disable IDE1006 //не выпендриваться когда я называю объекты как мне удобно

namespace SerialJoy
{
	public partial class main : Form
	{
		#region Inits and helpers
		vJoy joy = new vJoy();
		VjdStat joystat = VjdStat.VJD_STAT_UNKN;
		public main() => InitializeComponent();

		[Flags]
		enum stat {
			None = 0,
			SerialPortsExist = 1,
			SerialPortConfigured = 2,
			SerialDeviceAttached = 4,
			SerialDataFlow = 8,
			SerialOK = 0xF,
			VJDriverOK = 0x10,
			VJLibVerMatch = 0x20,
			VJDevReady = 0x40,
			VJDevAttached = 0x80,
			VJOK = 0xF0,
			BridgeOK = 0xFF,
			SerialDataFlowProblem = 0x800,
			VJLibVerProblem = 0x2000,
			BridgeWorking = 0x10000
		}

		enum maplistsub { Using, Available, Channel, Min, Max, Direction, In, Out }

		//int getMLData(int index, maplistsub param) { return 0; }
		void setMLData(int index, maplistsub param, object data) => maplist.Items[index].SubItems[(int)param].Text = data.ToString();
		void setMLData(string key, maplistsub param, object data) => setMLData(maplist.Items.IndexOfKey(key), param, data);
		//i dont know why this dont fill all fields sometimes
		//void setMLDataAsync(int index, maplistsub param, string data) => BeginInvoke((MethodInvoker)(() => maplist.Items[index].SubItems[(int)param].Text = data));

		stat status = 0;
		DateTime serialDataTime = DateTime.MinValue;

		bool checkStat(stat param) { return ((param & status) == param); }
		void setStat(stat param, bool val) { if (val) status |= param; else status &= ~param; }
		void setStat(stat param, int val) { if (val == 0) setStat(param, false); else setStat(param, true); }
		void setStat(stat param) => setStat(param, true);

		void refreshStatusIcons(stat icon) {
			if ((icon & stat.SerialPortsExist) == stat.SerialPortsExist)
				imgStatPortsFound.Image = checkStat(stat.SerialPortsExist) ? Properties.Resources.ok : Properties.Resources.err;
			if ((icon & stat.SerialPortConfigured) == stat.SerialPortConfigured)
				imgStatPortsParamOk.Image = checkStat(stat.SerialPortConfigured) ? Properties.Resources.ok : Properties.Resources.err;
			if ((icon & stat.SerialDeviceAttached) == stat.SerialDeviceAttached)
				imgStatCOMOk.Image = checkStat(stat.SerialDeviceAttached) ? Properties.Resources.ok : Properties.Resources.err;
			if ((icon & stat.SerialDataFlow) == stat.SerialDataFlow)
				imgStatSerialData.Image = checkStat(stat.SerialDataFlow) ? Properties.Resources.ok : checkStat(stat.SerialDataFlowProblem) ? Properties.Resources.warn : Properties.Resources.err;
			if ((icon & stat.VJDriverOK) == stat.VJDriverOK)
				imgStatvJoyOk.Image = checkStat(stat.VJDriverOK) ? Properties.Resources.ok : Properties.Resources.err;
			if ((icon & stat.VJLibVerMatch) == stat.VJLibVerMatch)
				imgStatvJoyLib.Image = checkStat(stat.VJLibVerMatch) ? Properties.Resources.ok : checkStat(stat.VJLibVerProblem) ? Properties.Resources.warn : Properties.Resources.err;
			if ((icon & stat.VJDevReady) == stat.VJDevReady)
				imgStatvJoyDev.Image = checkStat(stat.VJDevReady) ? Properties.Resources.ok : Properties.Resources.err;
			if ((icon & stat.VJDevAttached) == stat.VJDevAttached)
				imgStatvJoyAttached.Image = checkStat(stat.VJDevAttached) ? Properties.Resources.ok : Properties.Resources.err;

			byte minist = 0; //ministatus to ez resolve bridge state

			if (checkStat(stat.SerialOK) || checkStat(stat.SerialOK & ~stat.SerialDataFlow)) minist |= 1;
			if (checkStat(stat.VJOK)) minist |= 2;
			if (checkStat(stat.BridgeWorking)) minist |= 4;

			switch (minist) {
				case 1:  bridgeText.Text = "Joy side of bridge not ready"; break;
				case 2:  bridgeText.Text = "Serial side of bridge not ready"; break;
				case 3:  bridgeText.Text = "Bridge ready"; break;
				case 4:  bridgeText.Text = "Bridge works"; break;
				default:  bridgeText.Text = "Bridge not ready"; break;
			}
		}

		void refreshStatusIcons() => refreshStatusIcons(stat.BridgeOK); //equal to refresh all
		#endregion

		#region Serial port processing
		void checkComPorts() {
			string varholder = null;
			if (portSelector.Text.Length != 0) varholder = portSelector.Text;
			portSelector.Items.Clear();
			portSelector.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
			if (portSelector.Items.Count > 0) setStat(stat.SerialPortsExist); else setStat(stat.SerialPortsExist, 0);//status |= stat.SerialPortsExist; else status &= ~stat.SerialPortsExist; //imgStatPortsFound.Image = Properties.Resources.err; else imgStatPortsFound.Image = Properties.Resources.ok;
			portSelector.Text = varholder;
			checkSerialParams();
		}

		void checkSerialParams()	{
			if ((portSelector.Text.Length != 0) & (portRateSelector.Text.Length != 0) & int.TryParse(portRateSelector.Text, out _)) setStat(stat.SerialPortConfigured); else setStat(stat.SerialPortConfigured, 0);//status |= stat.SerialPortConfigured; else status &= ~stat.SerialPortConfigured;
			btnSerialSwitch.Enabled = checkStat(stat.SerialPortConfigured) ? true : false;
			refreshStatusIcons(stat.SerialPortsExist | stat.SerialPortConfigured);
			//imgStatPortsParamOk.Image = (portSelector.Text.Length != 0) & (portRateSelector.Text.Length != 0) ? Properties.Resources.ok : Properties.Resources.err;
		}

		void getSerialDeviceInfo() {
			//string qry = "SELECT * FROM Win32_SerialPort WHERE DeviceID = '" + portSelector.Text + "'";
			string qry = "SELECT * FROM Win32_PnPEntity WHERE Name LIKE '%" + portSelector.Text + "%'";
			//SELECT *  WHERE Name LIKE '%COM%'
			ManagementObjectSearcher wmiglass = new ManagementObjectSearcher(qry);
			ManagementObjectCollection results = wmiglass.Get();
			if (results.Count != 0) {
				ManagementObjectCollection.ManagementObjectEnumerator enumer = results.GetEnumerator();
				enumer.MoveNext(); ManagementObject obj = (ManagementObject)enumer.Current;
				System.Diagnostics.Debug.Print(obj.ToString());
				System.Diagnostics.Debug.Print(obj["DeviceID"].ToString());
				System.Diagnostics.Debug.Print(obj["Description"].ToString());
				txtDevAtt.Text = obj["Description"] + " attached";
			}
			checkSerialParams();
		}

		void serialToggle()	{
			if (!serial.IsOpen) {
				if (checkStat(stat.SerialPortConfigured)) {
					try {
						serial.PortName = portSelector.Text;
						serial.BaudRate = int.Parse(portRateSelector.Text);
						serial.Open();
						setStat(stat.SerialDeviceAttached);
						bridgeGuard.Enabled = true;

						btnSerialSwitch.Text = "Detach";
						btnSerialPortsRescan.Enabled = false;
						portSelector.Enabled = false;
						portRateSelector.Enabled = false;
					} catch (Exception e) { MessageBox.Show(e.Message); }
			}}
			else {
				serialError("Port closed by user");
			}
			refreshStatusIcons(stat.SerialDeviceAttached);
		}

		private void Serial_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e) //todo prettyfication
		{
			string sl="\0";
			try { sl = serial.ReadLine(); serialDataTime = DateTime.Now; }
			catch (Exception ex) { MessageBox.Show(ex.Message/* + ex.Source + ex.StackTrace*/); serialError(ex.Message + ex.Source + ex.StackTrace); }
			serval.BeginInvoke((MethodInvoker)(() => serval.Text = sl)); // ONLY ONE-MOMENT ACTIONS IN (this and not only) INVOKE!!!

			/* test only!!! 
			int val = Convert.ToInt32(double.Parse(sl) / 1024.0 * 32768);			
			if (joy.GetVJDStatus(1) == VjdStat.VJD_STAT_OWN) joy.SetAxis(val, 1, HID_USAGES.HID_USAGE_X);*/
		}
		private void Serial_ErrorReceived(object sender, System.IO.Ports.SerialErrorReceivedEventArgs e) => serialError(e);

		void serialError(object eventargs) {
			setStat(stat.SerialDeviceAttached | stat.SerialDataFlow | stat.SerialDataFlowProblem,0);
			
			serial.Close();
			refreshStatusIcons(stat.SerialOK); checkComPorts();

			btnSerialSwitch.Text = "Attach";
			btnSerialPortsRescan.Enabled = true;
			portSelector.Enabled = true;
			portRateSelector.Enabled = true;
			System.Diagnostics.Debug.Print(eventargs.ToString());
			bridgeGuard.Enabled = false;
		}
		#endregion

		#region vJoy device processing
		void checkvJoy() {
			uint dllv = 0, drvv = 0;

			if (joy.vJoyEnabled()) {
				setStat(stat.VJDriverOK);
				if (joy.DriverMatch(ref dllv, ref drvv)) { //todo ver to hex to pretty string
					setStat(stat.VJLibVerMatch);
					tooltiper.SetToolTip(imgStatvJoyLib, "Driver version matches library version (" + drvv.ToString("x") + ')');
				} else {
					setStat(stat.VJLibVerProblem);
					tooltiper.SetToolTip(imgStatvJoyLib, "Driver version: " + drvv.ToString("x") + "\nLibrary version: " + dllv.ToString("x"));
				}
			} else {
				tooltiper.SetToolTip(imgStatvJoyOk, "Check vJoy driver and restart this program");
				tooltiper.SetToolTip(imgStatvJoyLib, "I can't use library without driver");
			}
			refreshStatusIcons(stat.VJOK);
		}

		void checkvJoyDevice() {
			uint vjid = (uint)joyIDSelector.Value;
			joystat = joy.GetVJDStatus(vjid);
			switch (joystat) {
				case VjdStat.VJD_STAT_FREE: setStat(stat.VJDevReady); tooltiper.SetToolTip(imgStatvJoyDev, "Selected vJoy ready to be used"); break;
				case VjdStat.VJD_STAT_OWN: setStat(stat.VJDevReady); tooltiper.SetToolTip(imgStatvJoyDev, "Selected vJoy attached"); break;
				case VjdStat.VJD_STAT_BUSY: setStat(stat.VJDevReady, 0); tooltiper.SetToolTip(imgStatvJoyDev, "Selected vJoy attached to other feeder ("+ System.Diagnostics.Process.GetProcessById(joy.GetOwnerPid((uint)joyIDSelector.Value)).ProcessName + ", process ID: "+ joy.GetOwnerPid((uint)joyIDSelector.Value) + ")"); break;
				case VjdStat.VJD_STAT_MISS: setStat(stat.VJDevReady, 0); tooltiper.SetToolTip(imgStatvJoyDev, "Selected vJoy doesn't exist"); break;
				default: setStat(stat.VJDevReady, 0); tooltiper.SetToolTip(imgStatvJoyDev, "vJoy general error"); break;
			}			
			btnJoyAttach.Enabled = checkStat(stat.VJDevReady) ? true : false;
			//Thread thread = new Thread(new ThreadStart(checkvJoyDeviceInputs));
			//thread.Start();

			//uncomment this and delete next if vjoy change its max
			/*for (int i = 0; i < 8; i++) { //8 axis
				if (joy.GetVJDAxisExist(vjid, (HID_USAGES)((int)HID_USAGES.HID_USAGE_X + i))) { //HID_USAGE_X is 1st
					setMLData(i, maplistsub.Available, "Yes");
					setMLData(i, maplistsub.Min, 0);
					setMLData(i, maplistsub.Max, 32767); //remove const from here, use joy.GetVJDAxisMax()
				} else {
					setMLData(i, maplistsub.Available, "No");
					setMLData(i, maplistsub.Min, "Unknown");
					setMLData(i, maplistsub.Max, "Unknown");
				}
			}*/
			setMLData("mlAX", maplistsub.Available, joy.GetVJDAxisExist(vjid, HID_USAGES.HID_USAGE_X) ? "Yes" : "No");
			setMLData("mlAY", maplistsub.Available, joy.GetVJDAxisExist(vjid, HID_USAGES.HID_USAGE_Y) ? "Yes" : "No");
			setMLData("mlAZ", maplistsub.Available, joy.GetVJDAxisExist(vjid, HID_USAGES.HID_USAGE_Z) ? "Yes" : "No");
			setMLData("mlARX", maplistsub.Available, joy.GetVJDAxisExist(vjid, HID_USAGES.HID_USAGE_RX) ? "Yes" : "No");
			setMLData("mlARY", maplistsub.Available, joy.GetVJDAxisExist(vjid, HID_USAGES.HID_USAGE_RY) ? "Yes" : "No");
			setMLData("mlARZ", maplistsub.Available, joy.GetVJDAxisExist(vjid, HID_USAGES.HID_USAGE_RZ) ? "Yes" : "No");
			setMLData("mlAS0", maplistsub.Available, joy.GetVJDAxisExist(vjid, HID_USAGES.HID_USAGE_SL0) ? "Yes" : "No");
			setMLData("mlAS1", maplistsub.Available, joy.GetVJDAxisExist(vjid, HID_USAGES.HID_USAGE_SL1) ? "Yes" : "No");

			int povn = joy.GetVJDContPovNumber(vjid); bool povd = false;
			if (povn < 1) { povn = joy.GetVJDDiscPovNumber(vjid); povd = true; }
			for (int i = 0; i < 4; i++) {
				setMLData("mlP" + (i + 1), maplistsub.Available, povn >= (i + 1) ? "Yes" : "No");
				setMLData("mlP" + (i + 1), maplistsub.Direction, povn >= (i + 1) ? povd ? "4-way" : "Continuous" : "Unknown");
				setMLData("mlP" + (i + 1), maplistsub.Max, povn >= (i + 1) ? povd ? "3" : "35999" : "Unknown");
			}

			int butn = joy.GetVJDButtonNumber(vjid);
			for (int i = 1; i < 33; i++) setMLData("mlB" + i, maplistsub.Available, butn >= i ? "Yes" : "No");
			refreshStatusIcons(stat.VJDevReady);
		}

		/*void checkvJoyDeviceInputs() {
			uint vjid = (uint)joyIDSelector.Value;
			
			setMLDataAsync(0, maplistsub.Available, joy.GetVJDAxisExist(vjid, HID_USAGES.HID_USAGE_X) ? "Yes" : "No");
			setMLDataAsync(1, maplistsub.Available, joy.GetVJDAxisExist(vjid, HID_USAGES.HID_USAGE_Y) ? "Yes" : "No");
			setMLDataAsync(2, maplistsub.Available, joy.GetVJDAxisExist(vjid, HID_USAGES.HID_USAGE_Z) ? "Yes" : "No");
			setMLDataAsync(3, maplistsub.Available, joy.GetVJDAxisExist(vjid, HID_USAGES.HID_USAGE_RX) ? "Yes" : "No");
			setMLDataAsync(4, maplistsub.Available, joy.GetVJDAxisExist(vjid, HID_USAGES.HID_USAGE_RY) ? "Yes" : "No");
			setMLDataAsync(5, maplistsub.Available, joy.GetVJDAxisExist(vjid, HID_USAGES.HID_USAGE_RZ) ? "Yes" : "No");
			setMLDataAsync(6, maplistsub.Available, joy.GetVJDAxisExist(vjid, HID_USAGES.HID_USAGE_SL0) ? "Yes" : "No");
			setMLDataAsync(7, maplistsub.Available, joy.GetVJDAxisExist(vjid, HID_USAGES.HID_USAGE_SL1) ? "Yes" : "No");
		}*/

		void vJoyToggle() {
			if (checkStat(stat.VJDevReady) & !checkStat(stat.VJDevAttached)) {
				if (joy.AcquireVJD((uint)joyIDSelector.Value))
				{
					setStat(stat.VJDevAttached);
					joyIDSelector.Enabled = false;
					btnJoyAttach.Text = "Detach";
				}
			} else {
				joy.RelinquishVJD((uint)joyIDSelector.Value);
				setStat(stat.VJDevAttached, 0);
				joyIDSelector.Enabled = true;
				btnJoyAttach.Text = "Attach";
			}
			refreshStatusIcons(stat.VJOK);
		}

		private void joyIDupdate(object sender, EventArgs e) => checkvJoyDevice();
		#endregion

		private void BridgeGuard_Tick(object sender, EventArgs e) {
			if (DateTime.Now.Subtract(serialDataTime).TotalSeconds > 10) {
				setStat(stat.SerialDataFlow, 0);
				if (serial.IsOpen) {
					setStat(stat.SerialDataFlowProblem);
					tooltiper.SetToolTip(imgStatSerialData, "No incoming data");
				} else serialError(e);
			} else {
				setStat(stat.SerialDataFlow);
				setStat(stat.SerialDataFlowProblem,0);
				tooltiper.SetToolTip(imgStatSerialData, null);
			}
			refreshStatusIcons(stat.SerialOK);
		}

		private void Main_Load(object sender, EventArgs e)
		{
			generateMapTemplate();
			checkComPorts();
			if (checkStat(stat.SerialPortsExist)) portSelector.SelectedIndex = 0;
			checkvJoy();
			checkvJoyDevice();
		}
		private void Main_FormClosing(object sender, FormClosingEventArgs e)
		{
			serial.Close();
			joy.RelinquishVJD((uint)joyIDSelector.Value);
		}

		#region UI
		private void Button1_Click(object sender, EventArgs e)
		{
			//System.Diagnostics.Debug.Print("breakpoint passed");
			System.Diagnostics.Debug.Print(": serial.IsOpen == " + serial.IsOpen.ToString());
			long minax=0, maxax=0;
			//joy.AcquireVJD((uint)joyIDSelector.Value);
			joy.GetVJDAxisMin((uint)joyIDSelector.Value, HID_USAGES.HID_USAGE_X, ref minax);
			joy.GetVJDAxisMax((uint)joyIDSelector.Value, HID_USAGES.HID_USAGE_X, ref maxax);
			//joy.RelinquishVJD((uint)joyIDSelector.Value);			
			System.Diagnostics.Debug.Print("x axis min == "+minax+", max == "+maxax);
		}

		void generateMapTemplate() {
			/*fill map list
			1st axis index 0 / X Y Z RX RY RZ S0 S1
			1st pov index 8 / 1 2 3 4
			1st button index 12
			wheel axis not included bcs not implemented (?) in vjoy*/

			ListView.ListViewItemCollection premaplist = new ListView.ListViewItemCollection(maplist);
			ListViewItem item = new ListViewItem();
			
			void fillsubs(int group) {
				item.Group = maplist.Groups[group];  //group 0==axis, 1==pov, 2==button
				item.SubItems.Add("Unknown"); //available
				item.SubItems.Add("None"); //channel
				switch (group) { //minimum
					case 1: item.SubItems.Add("-1"); break;
					default: item.SubItems.Add("0"); break;
				}
				switch (group) { //maximum
					case 0: item.SubItems.Add("32767"); break;
					case 1: item.SubItems.Add("Unknown"); break;
					case 2: item.SubItems.Add("1"); break;
				}
				switch (group) { //direction
					case 0: item.SubItems.Add("Forward"); break;
					case 1: item.SubItems.Add("Unknown"); break;
					case 2: item.SubItems.Add("Button"); break;
				}				
				item.SubItems.Add("None"); //in
				item.SubItems.Add("None"); //out
			}

			#region add axis
			item.Name = "mlAX";
			item.Text = "Axis X";
			fillsubs(0);
			premaplist.Add(item);

			item = new ListViewItem {
				Name = "mlAY",
				Text = "Axis Y"
			};
			fillsubs(0);
			premaplist.Add(item);

			item = new ListViewItem {
				Name = "mlAZ",
				Text = "Axis Z"
			};
			fillsubs(0);
			premaplist.Add(item);

			item = new ListViewItem {
				Name = "mlARX",
				Text = "Axis RX"
			};
			fillsubs(0);
			premaplist.Add(item);

			item = new ListViewItem {
				Name = "mlARY",
				Text = "Axis RY"
			};
			fillsubs(0);
			premaplist.Add(item);

			item = new ListViewItem {
				Name = "mlARZ",
				Text = "Axis RZ"
			};
			fillsubs(0);
			premaplist.Add(item);

			item = new ListViewItem {
				Name = "mlAS0",
				Text = "Slider 0"
			};
			fillsubs(0);
			premaplist.Add(item);

			item = new ListViewItem {
				Name = "mlAS1",
				Text = "Slider 1"
			};
			fillsubs(0);
			premaplist.Add(item);
			#endregion

			#region add pov
			item = new ListViewItem {
				Name = "mlP1",
				Text = "POV Hat 1"
			};
			fillsubs(1);
			premaplist.Add(item);

			item = new ListViewItem {
				Name = "mlP2",
				Text = "POV Hat 2"
			};
			fillsubs(1);
			premaplist.Add(item);

			item = new ListViewItem {
				Name = "mlP3",
				Text = "POV Hat 3"
			};
			fillsubs(1);
			premaplist.Add(item);

			item = new ListViewItem {
				Name = "mlP4",
				Text = "POV Hat 4"
			};
			fillsubs(1);
			premaplist.Add(item);
			#endregion

			//add buttons
			for (byte i = 1; i < 33; i++) { // wtf? GetVJDButtonNumber() returns from -? to 128 but SetBtn() accepts only from 1 to 32! 
				item = new ListViewItem {
					Name = "mlB" + i,
					Text = "Button " + i
				};
			fillsubs(2);
			premaplist.Add(item);
			}
		}

		private void BtnSerialPortsRescan_Click(object sender, EventArgs e) => checkComPorts();
		private void PortSelector_SelectedIndexChanged(object sender, EventArgs e) => getSerialDeviceInfo();
		private void PortRateSelector_ValueChanged(object sender, EventArgs e) => checkSerialParams();
		private void BtnSerialSwitch_Click(object sender, EventArgs e) => serialToggle();
		private void BtnJoyAttach_Click(object sender, EventArgs e) => vJoyToggle();//joy.AcquireVJD(1);
		#endregion

	}
}

#pragma warning restore