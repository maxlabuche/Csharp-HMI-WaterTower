using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace HmiWaterTower
{
    public partial class CGUI : Form
    {
        COPCProxy myOpcProxy;
        CConnectionDialog myConnectionDialog;
        CAbout myAbout;

        string sDefaultValueText_Disconnected = "--,-%";
        string sDefaultVariableText_Disconnected = "(not connected)";
        string sDefaultVariableText_Waiting = "Waiting for PLC...";

        /* Values in percent for some items */
        decimal dStorage1 = 0;
        decimal dStorage2 = 0;
        decimal dInFlow = 0;
        decimal dOutFlow = 0;
        decimal dPump = 0;
        decimal dVm1 = 0;
        decimal dVm2 = 0;
        decimal dVm3 = 0;

        bool onUserScrolling = false; // set (true) this variable when a data used with trackBar AND numericUpDown is being modified. Reset (false) after updating.


        public CGUI()
        {
            InitializeComponent();
            myOpcProxy = new COPCProxy();
            myConnectionDialog = new CConnectionDialog();
            myAbout = new CAbout();
            myOpcProxy.StateChange += new EventHandler(myOpcProxy_StateChange);
            myOpcProxy.DataChange += new EventHandler(myOpcProxy_DataChange);
            this.updateUI();
            //MessageBox.Show("\tATTENTION ! \n\nCe programme de supervision est encore en cours de développement. Nous vous déconseillons fortement de l'utiliser en milieu industriel pour le moment.\n\nLe développeur ne pourra en aucun cas être tenu pour responsable des éventuels dégâts occasionnés.", "Avertissement : Programme en version beta");
        }

        void myOpcProxy_StateChange(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            this.updateUI();
        }

        void myOpcProxy_DataChange(object sender, EventArgs e)
        {
            this.updateValues();
        }

        private void ConnectProxy()
        {
            DialogResult dResult;
            dResult = myConnectionDialog.ShowDialog();
            if (dResult == System.Windows.Forms.DialogResult.OK)
            {
                // catch parameters and connect //
                myOpcProxy.Connect(myConnectionDialog.ServerName, myConnectionDialog.PlcAlias, myConnectionDialog.ProxyWatchTime);
                // iRefreshTime = myConnectionDialog.UiRefreshTime;
            }
        }

        public void updateUiComponents()
        {
            /* apply font here */
        }

        public void updateUI()
        {
            switch (myOpcProxy.ConnectionState)
            {
                case TState.DISCONNECTED:
                    /* QuickView */
                    this.button_QuickView_Connect.Enabled = true;
                    this.button_QuickView_Connect.Text = "&Connect";
                    this.button_QuickView_Refresh.Enabled = false;

                    this.label_QuickView_PlcState.Enabled = false;
                    this.label_QuickView_PlcState.Text = "Not connected";
                    this.pictureBox_QuickView_PlcState.Image = GlobalRc.picto_round_grey_0_5x;

                    this.label_QuickView_Data1.Text = this.sDefaultValueText_Disconnected;
                    this.label_QuickView_Data2.Text = this.sDefaultValueText_Disconnected;
                    this.label_QuickView_Data3.Text = this.sDefaultValueText_Disconnected;
                    this.label_QuickView_Data4.Text = this.sDefaultValueText_Disconnected;

                    /* CtrlPanel/Plc */
                    this.label_CtrlPanel_Plc_OpcName.Enabled = false;
                    this.label_CtrlPanel_Plc_OpcName.Text = myConnectionDialog.ServerName;

                    this.label_CtrlPanel_Plc_Alias.Enabled = false;
                    this.label_CtrlPanel_Plc_Alias.Text = myConnectionDialog.PlcAlias;

                    this.label_CtrlPanel_Plc_PollingInterval.Enabled = false;
                    this.label_CtrlPanel_Plc_PollingInterval.Text = Convert.ToString(myConnectionDialog.ProxyWatchTime) + " ms";

                    this.label_CtrlPanel_Plc_ConnectionState.Text = "Not connected";
                    this.label_CtrlPanel_Plc_ConnectionState.ForeColor = Color.Red;
                    this.pictureBox_CtrlPanel_Plc_ConnectionState.Image = GlobalRc.picto_round_red_0_5x;

                    this.checkBox_CtrlPanel_Plc_RunStop.Enabled = false;
                    this.checkBox_CtrlPanel_Plc_RunStop.Text = this.sDefaultVariableText_Disconnected;

                    this.checkBox_CtrlPanel_Plc_Emergency.Enabled = false;

                    this.radioButton_CtrlPanel_Plc_OpAuto.Enabled = false;
                    this.radioButton_CtrlPanel_Plc_OpManu.Enabled = false;

                    this.trackBar_CtrlPanel_Plc_Order.Enabled = false;
                    this.numericUpDown_CtrlPanel_Plc_Order.Enabled = false;
                    this.label_CtrlPanel_Plc_OrderMin.Enabled = false;
                    this.label_CtrlPanel_Plc_OrderMax.Enabled = false;

                    /* CtrlPanel/Telemetry */
                    this.label_CtrlPanel_Telemetry_Pressure.Enabled = false;
                    this.label_CtrlPanel_Telemetry_Pressure.Text = this.sDefaultVariableText_Disconnected;

                    this.label_CtrlPanel_Telemetry_Temperature.Enabled = false;
                    this.label_CtrlPanel_Telemetry_Temperature.Text = this.sDefaultVariableText_Disconnected;

                    this.label_CtrlPanel_Telemetry_InFlow.Enabled = false;
                    this.label_CtrlPanel_Telemetry_InFlow.Text = this.sDefaultVariableText_Disconnected;

                    this.label_CtrlPanel_Telemetry_OutFlow.Enabled = false;
                    this.label_CtrlPanel_Telemetry_OutFlow.Text = this.sDefaultVariableText_Disconnected;

                    this.label_CtrlPanel_Telemetry_MainStorage.Enabled = false;
                    this.label_CtrlPanel_Telemetry_MainStorage.Text = this.sDefaultVariableText_Disconnected;

                    this.label_CtrlPanel_Telemetry_Stor1.Enabled = false;
                    this.label_CtrlPanel_Telemetry_Stor1.Text = this.sDefaultVariableText_Disconnected;

                    this.label_CtrlPanel_Telemetry_Stor2.Enabled = false;
                    this.label_CtrlPanel_Telemetry_Stor2.Text = this.sDefaultVariableText_Disconnected;

                    /* CtrlPanel/Control */
                    this.panel_CtrlPanel_Control.Enabled = false;

                    /* VirtualView */
                    this.pictureBox_VirtualView_Ev1.Enabled = false;
                    this.pictureBox_VirtualView_Ev1.Image = GlobalRc.picto_round_grey_3x;

                    this.pictureBox_VirtualView_Ev2.Enabled = false;
                    this.pictureBox_VirtualView_Ev2.Image = GlobalRc.picto_round_grey_3x;

                    this.pictureBox_VirtualView_Ev3.Enabled = false;
                    this.pictureBox_VirtualView_Ev3.Image = GlobalRc.picto_round_grey_3x;

                    this.pictureBox_VirtualView_Ev4.Enabled = false;
                    this.pictureBox_VirtualView_Ev4.Image = GlobalRc.picto_round_grey_3x;

                    this.pictureBox_VirtualView_Ev5.Enabled = false;
                    this.pictureBox_VirtualView_Ev5.Image = GlobalRc.picto_round_grey_3x;

                    this.pictureBox_VirtualView_Vm1.Enabled = false;
                    this.pictureBox_VirtualView_Vm1.Image = GlobalRc.picto_round_grey_3x;
                    this.pictureBox_VirtualView_Vm1BarBg.BackColor = Color.DarkGray;
                    this.label_VirtualView_Vm1.Enabled = false;
                    this.label_VirtualView_Vm1.Text = this.sDefaultValueText_Disconnected;

                    this.pictureBox_VirtualView_Vm2.Enabled = false;
                    this.pictureBox_VirtualView_Vm2.Image = GlobalRc.picto_round_grey_3x;
                    this.pictureBox_VirtualView_Vm2BarBg.BackColor = Color.DarkGray;
                    this.label_VirtualView_Vm2.Enabled = false;
                    this.label_VirtualView_Vm2.Text = this.sDefaultValueText_Disconnected;

                    this.pictureBox_VirtualView_InFlow.Enabled = false;
                    this.pictureBox_VirtualView_InFlow.Image = GlobalRc.picto_round_grey_3x;
                    this.pictureBox_VirtualView_InFlowBarBg.BackColor = Color.DarkGray;
                    this.label_VirtualView_InFlow.Enabled = false;
                    this.label_VirtualView_InFlow.Text = this.sDefaultValueText_Disconnected;

                    this.pictureBox_VirtualView_OutFlow.Enabled = false;
                    this.pictureBox_VirtualView_OutFlow.Image = GlobalRc.picto_round_grey_3x;
                    this.pictureBox_VirtualView_OutFlowBarBg.BackColor = Color.DarkGray;
                    this.label_VirtualView_OutFlow.Enabled = false;
                    this.label_VirtualView_OutFlow.Text = this.sDefaultValueText_Disconnected;

                    this.pictureBox_VirtualView_PumpBarBg.BackColor = Color.DarkGray;
                    this.label_VirtualView_Pump.Enabled = false;
                    this.label_VirtualView_Pump.Text = this.sDefaultValueText_Disconnected;

                    this.label_VirtualView_Vm3.Enabled = false;
                    this.label_VirtualView_Vm3.Text = this.sDefaultValueText_Disconnected;

                    this.label_VirtualView_MainStorage.Enabled = false;
                    this.label_VirtualView_MainStorage.Text = "NC";

                    this.pictureBox_VirtualView_Stor1BarBg.BackColor = Color.Gainsboro;
                    this.label_VirtualView_Stor1.Enabled = false;
                    this.label_VirtualView_Stor1.Text = this.sDefaultValueText_Disconnected;

                    this.pictureBox_VirtualView_Stor2BarBg.BackColor = Color.Gainsboro;
                    this.label_VirtualView_Stor2.Enabled = false;
                    this.label_VirtualView_Stor2.Text = this.sDefaultValueText_Disconnected;

                    /* Cursor (mouse) */
                    this.Cursor = Cursors.Default;
                    break;
                case TState.CONNECTING:
                    /* QuickView */
                    this.button_QuickView_Connect.Enabled = false;
                    this.button_QuickView_Connect.Text = "Connect";

                    this.label_QuickView_PlcState.Enabled = false;
                    this.label_QuickView_PlcState.Text = "Not connected";
                    this.pictureBox_QuickView_PlcState.Image = GlobalRc.picto_round_grey_0_5x;

                    this.label_CtrlPanel_Plc_OpcName.Enabled = false;
                    this.label_CtrlPanel_Plc_OpcName.Text = myConnectionDialog.ServerName;

                    this.label_CtrlPanel_Plc_Alias.Enabled = false;
                    this.label_CtrlPanel_Plc_Alias.Text = myConnectionDialog.PlcAlias;

                    this.label_CtrlPanel_Plc_PollingInterval.Enabled = false;
                    this.label_CtrlPanel_Plc_PollingInterval.Text = Convert.ToString(myConnectionDialog.ProxyWatchTime) + " ms";

                    this.label_CtrlPanel_Plc_ConnectionState.Text = "Connecting...";
                    this.label_CtrlPanel_Plc_ConnectionState.ForeColor = Color.DarkOrange;
                    this.pictureBox_CtrlPanel_Plc_ConnectionState.Image = GlobalRc.picto_round_orange_0_5x;

                    /* Cursor (mouse) */
                    this.Cursor = Cursors.AppStarting;
                    break;
                case TState.CONNECTED:
                    /* QuickView */
                    this.button_QuickView_Connect.Enabled = true;
                    this.button_QuickView_Connect.Text = "Dis&connect";
                    this.button_QuickView_Refresh.Enabled = true;

                    this.label_QuickView_PlcState.Enabled = true;
                    this.label_QuickView_PlcState.Text = this.sDefaultVariableText_Waiting;
                    this.label_QuickView_PlcState.ForeColor = Color.DarkGray;
                    this.pictureBox_QuickView_PlcState.Image = GlobalRc.picto_round_grey_0_5x;

                    this.label_QuickView_Data1.Text = this.sDefaultValueText_Disconnected;
                    this.label_QuickView_Data2.Text = this.sDefaultValueText_Disconnected;
                    this.label_QuickView_Data3.Text = this.sDefaultValueText_Disconnected;
                    this.label_QuickView_Data4.Text = this.sDefaultValueText_Disconnected;

                    /* CtrlPanel/Plc */
                    this.label_CtrlPanel_Plc_OpcName.Enabled = true;
                    this.label_CtrlPanel_Plc_OpcName.Text = myConnectionDialog.ServerName;

                    this.label_CtrlPanel_Plc_Alias.Enabled = true;
                    this.label_CtrlPanel_Plc_Alias.Text = myConnectionDialog.PlcAlias;

                    this.label_CtrlPanel_Plc_PollingInterval.Enabled = true;
                    this.label_CtrlPanel_Plc_PollingInterval.Text = Convert.ToString(myConnectionDialog.ProxyWatchTime) + " ms";

                    this.label_CtrlPanel_Plc_ConnectionState.Text = "Connected";
                    this.label_CtrlPanel_Plc_ConnectionState.ForeColor = Color.Green;
                    this.pictureBox_CtrlPanel_Plc_ConnectionState.Image = GlobalRc.picto_round_green_0_5x;

                    this.checkBox_CtrlPanel_Plc_RunStop.Enabled = true;
                    this.checkBox_CtrlPanel_Plc_RunStop.Text = this.sDefaultVariableText_Waiting;

                    this.checkBox_CtrlPanel_Plc_Emergency.Enabled = true;

                    this.radioButton_CtrlPanel_Plc_OpAuto.Enabled = true;
                    this.radioButton_CtrlPanel_Plc_OpManu.Enabled = true;

                    this.trackBar_CtrlPanel_Plc_Order.Enabled = true;
                    this.numericUpDown_CtrlPanel_Plc_Order.Enabled = true;
                    this.label_CtrlPanel_Plc_OrderMin.Enabled = true;
                    this.label_CtrlPanel_Plc_OrderMax.Enabled = true;

                    /* CtrlPanel/Telemetry */
                    this.label_CtrlPanel_Telemetry_Pressure.Enabled = true;
                    this.label_CtrlPanel_Telemetry_Pressure.Text = this.sDefaultVariableText_Waiting;

                    this.label_CtrlPanel_Telemetry_Temperature.Enabled = true;
                    this.label_CtrlPanel_Telemetry_Temperature.Text = this.sDefaultVariableText_Waiting;

                    this.label_CtrlPanel_Telemetry_InFlow.Enabled = true;
                    this.label_CtrlPanel_Telemetry_InFlow.Text = this.sDefaultVariableText_Waiting;

                    this.label_CtrlPanel_Telemetry_OutFlow.Enabled = true;
                    this.label_CtrlPanel_Telemetry_OutFlow.Text = this.sDefaultVariableText_Waiting;

                    this.label_CtrlPanel_Telemetry_MainStorage.Enabled = true;
                    this.label_CtrlPanel_Telemetry_MainStorage.Text = this.sDefaultVariableText_Waiting;

                    this.label_CtrlPanel_Telemetry_Stor1.Enabled = true;
                    this.label_CtrlPanel_Telemetry_Stor1.Text = this.sDefaultVariableText_Waiting;

                    this.label_CtrlPanel_Telemetry_Stor2.Enabled = true;
                    this.label_CtrlPanel_Telemetry_Stor2.Text = this.sDefaultVariableText_Waiting;

                    /* CtrlPanel/Control */
                    this.panel_CtrlPanel_Control.Enabled = true;

                    /* VirtualView */
                    this.pictureBox_VirtualView_Ev1.Enabled = true;
                    this.pictureBox_VirtualView_Ev1.Image = GlobalRc.picto_round_grey_3x;

                    this.pictureBox_VirtualView_Ev2.Enabled = true;
                    this.pictureBox_VirtualView_Ev2.Image = GlobalRc.picto_round_grey_3x;

                    this.pictureBox_VirtualView_Ev3.Enabled = true;
                    this.pictureBox_VirtualView_Ev3.Image = GlobalRc.picto_round_grey_3x;

                    this.pictureBox_VirtualView_Ev4.Enabled = true;
                    this.pictureBox_VirtualView_Ev4.Image = GlobalRc.picto_round_grey_3x;

                    this.pictureBox_VirtualView_Ev5.Enabled = true;
                    this.pictureBox_VirtualView_Ev5.Image = GlobalRc.picto_round_grey_3x;

                    this.pictureBox_VirtualView_Vm1.Enabled = true;
                    this.pictureBox_VirtualView_Vm1.Image = GlobalRc.picto_round_grey_3x;
                    this.pictureBox_VirtualView_Vm1BarBg.BackColor = Color.RoyalBlue;
                    this.label_VirtualView_Vm1.Enabled = true;
                    this.label_VirtualView_Vm1.Text = this.sDefaultValueText_Disconnected;

                    this.pictureBox_VirtualView_Vm2.Enabled = true;
                    this.pictureBox_VirtualView_Vm2.Image = GlobalRc.picto_round_grey_3x;
                    this.pictureBox_VirtualView_Vm2BarBg.BackColor = Color.RoyalBlue;
                    this.label_VirtualView_Vm2.Enabled = true;
                    this.label_VirtualView_Vm2.Text = this.sDefaultValueText_Disconnected;

                    this.pictureBox_VirtualView_InFlow.Enabled = true;
                    this.pictureBox_VirtualView_InFlow.Image = GlobalRc.picto_round_grey_3x;
                    this.pictureBox_VirtualView_InFlowBarBg.BackColor = Color.RoyalBlue;
                    this.label_VirtualView_InFlow.Enabled = true;
                    this.label_VirtualView_InFlow.Text = this.sDefaultValueText_Disconnected;

                    this.pictureBox_VirtualView_OutFlow.Enabled = true;
                    this.pictureBox_VirtualView_OutFlow.Image = GlobalRc.picto_round_grey_3x;
                    this.pictureBox_VirtualView_OutFlowBarBg.BackColor = Color.RoyalBlue;
                    this.label_VirtualView_OutFlow.Enabled = true;
                    this.label_VirtualView_OutFlow.Text = this.sDefaultValueText_Disconnected;

                    this.pictureBox_VirtualView_PumpBarBg.BackColor = Color.RoyalBlue;
                    this.label_VirtualView_Pump.Enabled = true;
                    this.label_VirtualView_Pump.Text = this.sDefaultValueText_Disconnected;

                    this.label_VirtualView_Vm3.Enabled = true;
                    this.label_VirtualView_Vm3.Text = this.sDefaultValueText_Disconnected;

                    this.label_VirtualView_MainStorage.Enabled = true;
                    this.label_VirtualView_MainStorage.Text = "NC";

                    this.pictureBox_VirtualView_Stor1BarBg.BackColor = Color.LightSkyBlue;
                    this.label_VirtualView_Stor1.Enabled = true;
                    this.label_VirtualView_Stor1.Text = this.sDefaultValueText_Disconnected;

                    this.pictureBox_VirtualView_Stor2BarBg.BackColor = Color.LightSkyBlue;
                    this.label_VirtualView_Stor2.Enabled = true;
                    this.label_VirtualView_Stor2.Text = this.sDefaultValueText_Disconnected;

                    /* Cursor (mouse) */
                    this.Cursor = Cursors.Default;

                    this.updateValues();

                    break;
            }
        }

        public void updateValues()
        {
            // Process management //
            if (myOpcProxy.iexPlcStatus == 0)
            {
                this.label_QuickView_PlcState.Text = "Safe mode";
                this.label_QuickView_PlcState.ForeColor = Color.DarkOrange;
                this.pictureBox_QuickView_PlcState.Image = GlobalRc.picto_round_orange_0_5x;
                this.checkBox_CtrlPanel_Plc_RunStop.Text = "STOP";
                this.checkBox_CtrlPanel_Plc_RunStop.ForeColor = Color.Red;
                this.checkBox_CtrlPanel_Plc_RunStop.Checked = false;
            }
            else if (!myOpcProxy.iexAru)
            {
                this.label_QuickView_PlcState.Text = "Emergency stop";
                this.label_QuickView_PlcState.ForeColor = Color.Red;
                this.pictureBox_QuickView_PlcState.Image = GlobalRc.picto_round_red_0_5x;
                this.checkBox_CtrlPanel_Plc_RunStop.Text = "RUN";
                this.checkBox_CtrlPanel_Plc_RunStop.ForeColor = Color.Green;
                this.checkBox_CtrlPanel_Plc_RunStop.Checked = true;
            }
            else if (myOpcProxy.iexPlcStatus == 1)
            {
                this.label_QuickView_PlcState.Text = "Ready";
                this.label_QuickView_PlcState.ForeColor = Color.Green;
                this.pictureBox_QuickView_PlcState.Image = GlobalRc.picto_round_green_0_5x;
                this.checkBox_CtrlPanel_Plc_RunStop.Text = "RUN";
                this.checkBox_CtrlPanel_Plc_RunStop.ForeColor = Color.Green;
                this.checkBox_CtrlPanel_Plc_RunStop.Checked = true;
            }

            if (myOpcProxy.iexAru)
            {
                this.checkBox_CtrlPanel_Plc_Emergency.ForeColor = Color.Black;
                this.checkBox_CtrlPanel_Plc_Emergency.Checked = false;
            }
            else
            {
                this.checkBox_CtrlPanel_Plc_Emergency.ForeColor = Color.Red;
                this.checkBox_CtrlPanel_Plc_Emergency.Checked = true;
            }

            if (myOpcProxy.mexMode_manu)
            {
                this.radioButton_CtrlPanel_Plc_OpManu.Checked = true;
                this.radioButton_CtrlPanel_Plc_OpAuto.Checked = false;

                this.trackBar_CtrlPanel_Plc_Order.Enabled = false;
                this.numericUpDown_CtrlPanel_Plc_Order.Enabled = false;
                this.label_CtrlPanel_Plc_OrderMin.Enabled = false;
                this.label_CtrlPanel_Plc_OrderMax.Enabled = false;

                this.trackBar_CtrlPanel_Ctrl_Pump.Enabled = true;
                this.numericUpDown_CtrlPanel_Ctrl_Pump.Enabled = true;
                this.label_CtrlPanel_Ctrl_PumpMin.Enabled = true;
                this.label_CtrlPanel_Ctrl_PumpMax.Enabled = true;

                this.trackBar_CtrlPanel_Ctrl_Vm3.Enabled = true;
                this.numericUpDown_CtrlPanel_Ctrl_Vm3.Enabled = true;
                this.label_CtrlPanel_Ctrl_Vm3Min.Enabled = true;
                this.label_CtrlPanel_Ctrl_Vm3Max.Enabled = true;
            }
            else
            {
                this.radioButton_CtrlPanel_Plc_OpManu.Checked = false;
                this.radioButton_CtrlPanel_Plc_OpAuto.Checked = true;

                this.trackBar_CtrlPanel_Plc_Order.Enabled = true;
                this.numericUpDown_CtrlPanel_Plc_Order.Enabled = true;
                this.label_CtrlPanel_Plc_OrderMin.Enabled = true;
                this.label_CtrlPanel_Plc_OrderMax.Enabled = true;

                this.trackBar_CtrlPanel_Ctrl_Pump.Enabled = false;
                this.numericUpDown_CtrlPanel_Ctrl_Pump.Enabled = false;
                this.label_CtrlPanel_Ctrl_PumpMin.Enabled = false;
                this.label_CtrlPanel_Ctrl_PumpMax.Enabled = false;

                this.trackBar_CtrlPanel_Ctrl_Vm3.Enabled = false;
                this.numericUpDown_CtrlPanel_Ctrl_Vm3.Enabled = false;
                this.label_CtrlPanel_Ctrl_Vm3Min.Enabled = false;
                this.label_CtrlPanel_Ctrl_Vm3Max.Enabled = false;
            }

            // Order //
            this.onUserScrolling = true;
            this.trackBar_CtrlPanel_Plc_Order.Value = myOpcProxy.mexConsigneSp;
            this.numericUpDown_CtrlPanel_Plc_Order.Value = myOpcProxy.mexConsigneSp;
            this.onUserScrolling = false;

            // Other telemetry //
            if (myOpcProxy.iexPressionHydroSup_4b1)
            {
                this.label_CtrlPanel_Telemetry_Pressure.Text = "More than 4 bar";
                this.label_CtrlPanel_Telemetry_Pressure.ForeColor = Color.DarkOrange;
            }
            else
            {
                this.label_CtrlPanel_Telemetry_Pressure.Text = "OK";
                this.label_CtrlPanel_Telemetry_Pressure.ForeColor = Color.Green;
            }

            if (myOpcProxy.iexTempPompeSup_40)
            {
                this.label_CtrlPanel_Telemetry_Temperature.Text = "More than 40°C";
                this.label_CtrlPanel_Telemetry_Temperature.ForeColor = Color.DarkOrange;
            }
            else
            {
                this.label_CtrlPanel_Telemetry_Temperature.Text = "OK";
                this.label_CtrlPanel_Telemetry_Temperature.ForeColor = Color.Green;
            }

            // Main storage //
            if ((!myOpcProxy.iexStorageEmpty) && (!myOpcProxy.iexLowLevel))
            {
                this.label_CtrlPanel_Telemetry_MainStorage.Text = "OK";
                this.label_CtrlPanel_Telemetry_MainStorage.ForeColor = Color.Green;
                this.label_VirtualView_MainStorage.Text = "OK";
                this.label_VirtualView_MainStorage.ForeColor = Color.Green;
            }
            else if ((!myOpcProxy.iexStorageEmpty) && (myOpcProxy.iexLowLevel))
            {
                this.label_CtrlPanel_Telemetry_MainStorage.Text = "Low";
                this.label_CtrlPanel_Telemetry_MainStorage.ForeColor = Color.DarkOrange;
                this.label_VirtualView_MainStorage.Text = "Low";
                this.label_VirtualView_MainStorage.ForeColor = Color.DarkOrange;
            }
            else if (myOpcProxy.iexStorageEmpty)
            {
                this.label_CtrlPanel_Telemetry_MainStorage.Text = "Empty";
                this.label_CtrlPanel_Telemetry_MainStorage.ForeColor = Color.Red;
                this.label_VirtualView_MainStorage.Text = "Empty";
                this.label_VirtualView_MainStorage.ForeColor = Color.Red;
            }
            else
            {
                this.label_CtrlPanel_Telemetry_MainStorage.Text = "NC";
                this.label_CtrlPanel_Telemetry_MainStorage.ForeColor = Color.Black;
                this.label_VirtualView_MainStorage.Text = "NC";
                this.label_VirtualView_MainStorage.ForeColor = Color.Black;
            }

            // Storage 1 //
            dStorage1 = ProportionalCompute(myOpcProxy.iexLevelStorage1, 0, 10000, 0, 100);
            this.label_VirtualView_Stor1.Text = PercentValueToString(dStorage1);
            this.label_QuickView_Data4.Text = PercentValueToString(dStorage1);
            this.label_CtrlPanel_Telemetry_Stor1.Text = Convert.ToString(myOpcProxy.iexLevelStorage1) + " (" + Convert.ToString(this.dStorage1) + " %)";
            SizeBarFromPercent(dStorage1, this.pictureBox_VirtualView_Stor1Bar, this.pictureBox_VirtualView_Stor1BarBg);

            // Storage 2 //
            dStorage2 = ProportionalCompute(myOpcProxy.iexLevelStorage2, 0, 10000, 0, 100);
            this.label_VirtualView_Stor2.Text = PercentValueToString(dStorage2);
            this.label_QuickView_Data3.Text = PercentValueToString(dStorage2);
            this.label_CtrlPanel_Telemetry_Stor2.Text = Convert.ToString(myOpcProxy.iexLevelStorage2) + " (" + Convert.ToString(this.dStorage2) + " %)";
            SizeBarFromPercent(dStorage2, this.pictureBox_VirtualView_Stor2Bar, this.pictureBox_VirtualView_Stor2BarBg);

            // Incoming flow //
            dInFlow = ProportionalCompute(myOpcProxy.iexDebitPompe, 0, 10000, 0, 100);
            this.label_VirtualView_InFlow.Text = PercentValueToString(dInFlow);
            this.label_QuickView_Data1.Text = PercentValueToString(dInFlow);
            this.label_CtrlPanel_Telemetry_InFlow.Text = Convert.ToString(myOpcProxy.iexDebitPompe) + " (" + Convert.ToString(this.dInFlow) + " %)";
            SizeBarFromPercent(dInFlow, this.pictureBox_VirtualView_InFlowBar, this.pictureBox_VirtualView_InFlowBarBg);
            if (dInFlow > 5)
            {
                this.pictureBox_VirtualView_InFlow.Image = GlobalRc.picto_round_blue_3x;
            }
            else
            {
                this.pictureBox_VirtualView_InFlow.Image = GlobalRc.picto_round_grey_3x;
            }

            // Outgoing flow //
            dOutFlow = ProportionalCompute(myOpcProxy.iexDebitPert, 0, 10000, 0, 100);
            this.label_VirtualView_OutFlow.Text = PercentValueToString(dOutFlow);
            this.label_QuickView_Data2.Text = PercentValueToString(dOutFlow);
            this.label_CtrlPanel_Telemetry_OutFlow.Text = Convert.ToString(myOpcProxy.iexDebitPert) + " (" + Convert.ToString(this.dOutFlow) + " %)";
            SizeBarFromPercent(dOutFlow, this.pictureBox_VirtualView_OutFlowBar, this.pictureBox_VirtualView_OutFlowBarBg);
            if (dOutFlow > 5)
            {
                this.pictureBox_VirtualView_OutFlow.Image = GlobalRc.picto_round_blue_3x;
            }
            else
            {
                this.pictureBox_VirtualView_OutFlow.Image = GlobalRc.picto_round_grey_3x;
            }

            // Pump //
            if (myOpcProxy.mexMode_manu == false)
            {
                dPump = ProportionalCompute(myOpcProxy.mexAtv18_auto, 0, 10000, 0, 100);
                this.onUserScrolling = true;
                this.trackBar_CtrlPanel_Ctrl_Pump.Value = myOpcProxy.mexAtv18_auto;
                this.numericUpDown_CtrlPanel_Ctrl_Pump.Value = myOpcProxy.mexAtv18_auto;
                this.onUserScrolling = false;
            }
            else
            {
                dPump = ProportionalCompute(myOpcProxy.mexAtv18_manu, 0, 10000, 0, 100);
                this.onUserScrolling = true;
                this.trackBar_CtrlPanel_Ctrl_Pump.Value = myOpcProxy.mexAtv18_manu;
                this.numericUpDown_CtrlPanel_Ctrl_Pump.Value = myOpcProxy.mexAtv18_manu;
                this.onUserScrolling = false;
            }
            this.label_VirtualView_Pump.Text = PercentValueToString(dPump);
            SizeBarFromPercent(dPump, this.pictureBox_VirtualView_PumpBar, this.pictureBox_VirtualView_PumpBarBg);

            // VM1 //
            dVm1 = ProportionalCompute(myOpcProxy.mexVm1, 0, 10000, 0, 100);
            this.onUserScrolling = true;
            this.trackBar_CtrlPanel_Ctrl_Vm1.Value = myOpcProxy.mexVm1;
            this.numericUpDown_CtrlPanel_Ctrl_Vm1.Value = myOpcProxy.mexVm1;
            this.onUserScrolling = false;
            this.label_VirtualView_Vm1.Text = PercentValueToString(dVm1);
            SizeBarFromPercent(dVm1, this.pictureBox_VirtualView_Vm1Bar, this.pictureBox_VirtualView_Vm1BarBg);
            if (dVm1 > 0)
            {
                this.pictureBox_VirtualView_Vm1.Image = GlobalRc.picto_round_green_3x;
            }
            else
            {
                this.pictureBox_VirtualView_Vm1.Image = GlobalRc.picto_round_red_3x;
            }

            // VM2 //
            dVm2 = ProportionalCompute(myOpcProxy.mexVm2, 0, 10000, 0, 100);
            this.onUserScrolling = true;
            this.trackBar_CtrlPanel_Ctrl_Vm2.Value = myOpcProxy.mexVm2;
            this.numericUpDown_CtrlPanel_Ctrl_Vm2.Value = myOpcProxy.mexVm2;
            this.onUserScrolling = false;
            this.label_VirtualView_Vm2.Text = PercentValueToString(dVm2);
            SizeBarFromPercent(dVm2, this.pictureBox_VirtualView_Vm2Bar, this.pictureBox_VirtualView_Vm2BarBg);
            if (dVm2 > 0)
            {
                this.pictureBox_VirtualView_Vm2.Image = GlobalRc.picto_round_green_3x;
            }
            else
            {
                this.pictureBox_VirtualView_Vm2.Image = GlobalRc.picto_round_red_3x;
            }

            // VM3 //
            if (myOpcProxy.mexMode_manu == false)
            {
                dVm3 = ProportionalCompute(myOpcProxy.mexVm3_auto, 0, 10000, 0, 100);
                this.onUserScrolling = true;
                this.trackBar_CtrlPanel_Ctrl_Vm3.Value = myOpcProxy.mexVm3_auto;
                this.numericUpDown_CtrlPanel_Ctrl_Vm3.Value = myOpcProxy.mexVm3_auto;
                this.onUserScrolling = false;
            }
            else
            {
                dVm3 = ProportionalCompute(myOpcProxy.mexVm3_manu, 0, 10000, 0, 100);
                this.onUserScrolling = true;
                this.trackBar_CtrlPanel_Ctrl_Vm3.Value = myOpcProxy.mexVm3_manu;
                this.numericUpDown_CtrlPanel_Ctrl_Vm3.Value = myOpcProxy.mexVm3_manu;
                this.onUserScrolling = false;
            }
            this.label_VirtualView_Vm3.Text = PercentValueToString(dVm3);

            // EV1 //
            if (myOpcProxy.mexEv1)
            {
                this.checkBox_CtrlPanel_Ctrl_Ev1.Checked = true;
                this.pictureBox_VirtualView_Ev1.Image = GlobalRc.picto_round_green_3x;
            }
            else
            {
                this.checkBox_CtrlPanel_Ctrl_Ev1.Checked = false;
                this.pictureBox_VirtualView_Ev1.Image = GlobalRc.picto_round_red_3x;
            }

            // EV2 //
            if (myOpcProxy.mexEv2)
            {
                this.checkBox_CtrlPanel_Ctrl_Ev2.Checked = true;
                this.pictureBox_VirtualView_Ev2.Image = GlobalRc.picto_round_green_3x;
            }
            else
            {
                this.checkBox_CtrlPanel_Ctrl_Ev2.Checked = false;
                this.pictureBox_VirtualView_Ev2.Image = GlobalRc.picto_round_red_3x;
            }

            // EV3 //
            if (myOpcProxy.mexEv3)
            {
                this.checkBox_CtrlPanel_Ctrl_Ev3.Checked = true;
                this.pictureBox_VirtualView_Ev3.Image = GlobalRc.picto_round_green_3x;
            }
            else
            {
                this.checkBox_CtrlPanel_Ctrl_Ev3.Checked = false;
                this.pictureBox_VirtualView_Ev3.Image = GlobalRc.picto_round_red_3x;
            }

            // EV4 //
            if (myOpcProxy.mexEv4)
            {
                this.checkBox_CtrlPanel_Ctrl_Ev4.Checked = true;
                this.pictureBox_VirtualView_Ev4.Image = GlobalRc.picto_round_green_3x;
            }
            else
            {
                this.checkBox_CtrlPanel_Ctrl_Ev4.Checked = false;
                this.pictureBox_VirtualView_Ev4.Image = GlobalRc.picto_round_red_3x;
            }

            // EV5 //
            if (myOpcProxy.mexEv5)
            {
                this.checkBox_CtrlPanel_Ctrl_Ev5.Checked = true;
                this.pictureBox_VirtualView_Ev5.Image = GlobalRc.picto_round_green_3x;
            }
            else
            {
                this.checkBox_CtrlPanel_Ctrl_Ev5.Checked = false;
                this.pictureBox_VirtualView_Ev5.Image = GlobalRc.picto_round_red_3x;
            }

        }

        private void onFormClosing(object sender, FormClosingEventArgs e)
        {
            if (myOpcProxy.ConnectionState == TState.CONNECTED)
            {
                DialogResult res = MessageBox.Show(
                        "This client is currently connected to the OFS server.\nDo you want to disconnect and close the program?",
                        "Client connected",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Exclamation,
                        MessageBoxDefaultButton.Button2);
                if (res == DialogResult.Yes)
                {
                    myOpcProxy.Disconnect();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void CGUI_Shown(object sender, EventArgs e)
        {
            // do something when main interface appears //
        }

        private string PercentValueToString(decimal dPercentValue)
        {
            string sText = null;
            decimal dPercent = Decimal.Round(dPercentValue, 1);
            sText = Convert.ToString(dPercent) + "%";
            return sText;
        }

        private decimal ProportionalCompute(int iValue, int iPrevMin, int iPrevMax, int iNewMin, int iNewMax)
        {
            decimal dReturnValue = 0;
            int iPrevLength = iPrevMax - iPrevMin;
            int iNewLength = iNewMax - iNewMin;

            dReturnValue = (decimal)((((iValue - iPrevMin) / (decimal)(iPrevLength)) * iNewLength) + iNewMin);

            return dReturnValue;
        }

        private void SizeBarFromPercent(decimal pdValue, PictureBox pBarValue, PictureBox pBarBg)
        {
            int iHeight = (int)(pBarBg.Size.Height - (((int)pdValue / (float)100) * pBarBg.Size.Height));
            pBarValue.Size = new System.Drawing.Size(pBarBg.Size.Width, iHeight);
        }

        private void trackBar_CtrlPanel_Plc_Order_Scroll(object sender, EventArgs e)
        {
            if ((!this.onUserScrolling) && (!myOpcProxy.mexMode_manu))
            {
                this.onUserScrolling = true;
                this.numericUpDown_CtrlPanel_Plc_Order.Value = (decimal)this.trackBar_CtrlPanel_Plc_Order.Value;
                myOpcProxy.mexConsigneSp = (short)this.trackBar_CtrlPanel_Plc_Order.Value;
                this.onUserScrolling = false;
            }
        }

        private void numericUpDown_CtrlPanel_Plc_Order_ValueChanged(object sender, EventArgs e)
        {
            if ((!this.onUserScrolling) && (!myOpcProxy.mexMode_manu))
            {
                this.onUserScrolling = true;
                this.trackBar_CtrlPanel_Plc_Order.Value = (int)this.numericUpDown_CtrlPanel_Plc_Order.Value;
                myOpcProxy.mexConsigneSp = (short)this.numericUpDown_CtrlPanel_Plc_Order.Value;
                this.onUserScrolling = false;
            }
        }

        private void trackBar_CtrlPanel_Ctrl_Pump_Scroll(object sender, EventArgs e)
        {
            if ((!this.onUserScrolling) && (myOpcProxy.mexMode_manu))
            {
                this.onUserScrolling = true;
                this.numericUpDown_CtrlPanel_Ctrl_Pump.Value = (decimal)this.trackBar_CtrlPanel_Ctrl_Pump.Value;
                myOpcProxy.mexAtv18_manu = (short)this.trackBar_CtrlPanel_Ctrl_Pump.Value;
                this.onUserScrolling = false;
            }
        }

        private void numericUpDown_CtrlPanel_Ctrl_Pump_ValueChanged(object sender, EventArgs e)
        {
            if ((!this.onUserScrolling) && (myOpcProxy.mexMode_manu))
            {
                this.onUserScrolling = true;
                this.trackBar_CtrlPanel_Ctrl_Pump.Value = (int)this.numericUpDown_CtrlPanel_Ctrl_Pump.Value;
                myOpcProxy.mexAtv18_manu = (short)this.numericUpDown_CtrlPanel_Ctrl_Pump.Value;
                this.onUserScrolling = false;
            }
        }

        private void trackBar_CtrlPanel_Ctrl_Vm1_Scroll(object sender, EventArgs e)
        {
            if (!this.onUserScrolling)
            {
                this.onUserScrolling = true;
                this.numericUpDown_CtrlPanel_Ctrl_Vm1.Value = (decimal)this.trackBar_CtrlPanel_Ctrl_Vm1.Value;
                myOpcProxy.mexVm1 = (short)this.trackBar_CtrlPanel_Ctrl_Vm1.Value;
                this.onUserScrolling = false;
            }
        }

        private void numericUpDown_CtrlPanel_Ctrl_Vm1_ValueChanged(object sender, EventArgs e)
        {
            if (!this.onUserScrolling)
            {
                this.onUserScrolling = true;
                this.trackBar_CtrlPanel_Ctrl_Vm1.Value = (int)this.numericUpDown_CtrlPanel_Ctrl_Vm1.Value;
                myOpcProxy.mexVm1 = (short)this.numericUpDown_CtrlPanel_Ctrl_Vm1.Value;
                this.onUserScrolling = false;
            }
        }

        private void trackBar_CtrlPanel_Ctrl_Vm2_Scroll(object sender, EventArgs e)
        {
            if (!this.onUserScrolling)
            {
                this.onUserScrolling = true;
                this.numericUpDown_CtrlPanel_Ctrl_Vm2.Value = (decimal)this.trackBar_CtrlPanel_Ctrl_Vm2.Value;
                myOpcProxy.mexVm2 = (short)this.trackBar_CtrlPanel_Ctrl_Vm2.Value;
                this.onUserScrolling = false;
            }
        }

        private void numericUpDown_CtrlPanel_Ctrl_Vm2_ValueChanged(object sender, EventArgs e)
        {
            if (!this.onUserScrolling)
            {
                this.onUserScrolling = true;
                this.trackBar_CtrlPanel_Ctrl_Vm2.Value = (int)this.numericUpDown_CtrlPanel_Ctrl_Vm2.Value;
                myOpcProxy.mexVm2 = (short)this.numericUpDown_CtrlPanel_Ctrl_Vm2.Value;
                this.onUserScrolling = false;
            }
        }

        private void trackBar_CtrlPanel_Ctrl_Vm3_Scroll(object sender, EventArgs e)
        {
            if ((!this.onUserScrolling) && (myOpcProxy.mexMode_manu))
            {
                this.onUserScrolling = true;
                this.numericUpDown_CtrlPanel_Ctrl_Vm3.Value = (decimal)this.trackBar_CtrlPanel_Ctrl_Vm3.Value;
                myOpcProxy.mexVm3_manu = (short)this.trackBar_CtrlPanel_Ctrl_Vm3.Value;
                this.onUserScrolling = false;
            }
        }

        private void numericUpDown_CtrlPanel_Ctrl_Vm3_ValueChanged(object sender, EventArgs e)
        {
            if ((!this.onUserScrolling) && (myOpcProxy.mexMode_manu))
            {
                this.onUserScrolling = true;
                this.trackBar_CtrlPanel_Ctrl_Vm3.Value = (int)this.numericUpDown_CtrlPanel_Ctrl_Vm3.Value;
                myOpcProxy.mexVm3_manu = (short)this.numericUpDown_CtrlPanel_Ctrl_Vm3.Value;
                this.onUserScrolling = false;
            }
        }

        private void button_QuickView_Connect_Click(object sender, EventArgs e)
        {
            switch (myOpcProxy.ConnectionState)
            {
                case TState.DISCONNECTED:
                    this.ConnectProxy();
                    break;
                case TState.CONNECTING:
                    myOpcProxy.Disconnect();
                    break;
                case TState.CONNECTED:
                    myOpcProxy.Disconnect();
                    break;
            }
        }

        private void checkBox_CtrlPanel_Plc_RunStop_Click(object sender, EventArgs e)
        {
            if (myOpcProxy.iexPlcStatus == 0)
            {
                myOpcProxy.iexPlcStatus = 1;
            }
            else if (myOpcProxy.iexPlcStatus == 1)
            {
                myOpcProxy.iexPlcStatus = 0;
            }
        }

        private void checkBox_CtrlPanel_Ctrl_Ev1_Click(object sender, EventArgs e)
        {
            if (!myOpcProxy.mexEv1)
            {
                myOpcProxy.mexEv1 = true;
            }
            else if (myOpcProxy.mexEv1)
            {
                myOpcProxy.mexEv1 = false;
            }
        }

        private void checkBox_CtrlPanel_Ctrl_Ev2_Click(object sender, EventArgs e)
        {
            if (!myOpcProxy.mexEv2)
            {
                myOpcProxy.mexEv2 = true;
            }
            else if (myOpcProxy.mexEv2)
            {
                myOpcProxy.mexEv2 = false;
            }
        }

        private void checkBox_CtrlPanel_Ctrl_Ev3_Click(object sender, EventArgs e)
        {
            if (!myOpcProxy.mexEv3)
            {
                myOpcProxy.mexEv3 = true;
            }
            else if (myOpcProxy.mexEv3)
            {
                myOpcProxy.mexEv3 = false;
            }
        }

        private void checkBox_CtrlPanel_Ctrl_Ev4_Click(object sender, EventArgs e)
        {
            if (!myOpcProxy.mexEv4)
            {
                myOpcProxy.mexEv4 = true;
            }
            else if (myOpcProxy.mexEv4)
            {
                myOpcProxy.mexEv4 = false;
            }
        }

        private void checkBox_CtrlPanel_Ctrl_Ev5_Click(object sender, EventArgs e)
        {
            if (!myOpcProxy.mexEv5)
            {
                myOpcProxy.mexEv5 = true;
            }
            else if (myOpcProxy.mexEv5)
            {
                myOpcProxy.mexEv5 = false;
            }
        }

        private void radioButton_CtrlPanel_Plc_OpAuto_Click(object sender, EventArgs e)
        {
            if (myOpcProxy.mexMode_manu)
            {
                myOpcProxy.mexMode_manu = false;
            }
        }

        private void radioButton_CtrlPanel_Plc_OpManu_Click(object sender, EventArgs e)
        {
            if (!myOpcProxy.mexMode_manu)
            {
                myOpcProxy.mexMode_manu = true;
            }
        }

        private void button_QuickView_About_Click(object sender, EventArgs e)
        {
            myAbout.ShowDialog();
        }
    }
}
