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
			VJLibVerProblem = 0x2000
		}

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
			int dummy=0;
			if ((portSelector.Text.Length != 0) & (portRateSelector.Text.Length != 0) & int.TryParse(portRateSelector.Text, out dummy)) setStat(stat.SerialPortConfigured); else setStat(stat.SerialPortConfigured, 0);//status |= stat.SerialPortConfigured; else status &= ~stat.SerialPortConfigured;
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
			joystat = joy.GetVJDStatus((uint)joyIDSelector.Value);
			switch (joystat) {
				case VjdStat.VJD_STAT_FREE: setStat(stat.VJDevReady); tooltiper.SetToolTip(imgStatvJoyDev, "Selected vJoy ready to be used"); break;
				case VjdStat.VJD_STAT_OWN: setStat(stat.VJDevReady); tooltiper.SetToolTip(imgStatvJoyDev, "Selected vJoy attached"); break;
				case VjdStat.VJD_STAT_BUSY: setStat(stat.VJDevReady, 0); tooltiper.SetToolTip(imgStatvJoyDev, "Selected vJoy attached to other feeder ("+ System.Diagnostics.Process.GetProcessById(joy.GetOwnerPid((uint)joyIDSelector.Value)).ProcessName + ", process ID: "+ joy.GetOwnerPid((uint)joyIDSelector.Value) + ")"); break;
				case VjdStat.VJD_STAT_MISS: setStat(stat.VJDevReady, 0); tooltiper.SetToolTip(imgStatvJoyDev, "Selected vJoy doesn't exist"); break;
				default: setStat(stat.VJDevReady, 0); tooltiper.SetToolTip(imgStatvJoyDev, "vJoy general error"); break;
			}
			refreshStatusIcons(stat.VJDevReady);
		}
		private void BtnJoyAttach_Click(object sender, EventArgs e)
		{
			//joy.AcquireVJD(1);
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

		private void BtnSerialPortsRescan_Click(object sender, EventArgs e) => checkComPorts();
		private void PortSelector_SelectedIndexChanged(object sender, EventArgs e) => getSerialDeviceInfo();
		private void PortRateSelector_ValueChanged(object sender, EventArgs e) => checkSerialParams();
		private void BtnSerialSwitch_Click(object sender, EventArgs e) => serialToggle();
		#endregion

	}
}

#pragma warning restore