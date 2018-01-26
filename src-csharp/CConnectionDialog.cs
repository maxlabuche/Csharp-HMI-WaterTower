using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HmiWaterTower
{
    public partial class CConnectionDialog : Form
    {
        private string msServerName;
        private string msPlcAlias;
        private int miProxyWatchTime = 2000;
        private int miAutoRefresh = 5000;

        public CConnectionDialog()
        {
            InitializeComponent();
            this.comboBox_ProxyWatchTime.Text = "2 s";
            this.comboBox_AutoRefresh.Text = "5 s";
            this.button_Connect.Enabled = false;
        }

        #region Connection parameters

        public string ServerName
        {
            get
            {
                return msServerName;
            }
            set
            {
                msServerName = (string)value;
            }
        }

        public string PlcAlias
        {
            get
            {
                return msPlcAlias;
            }
            set
            {
                msPlcAlias = (string)value;
            }
        }

        public int ProxyWatchTime
        {
            get
            {
                return miProxyWatchTime;
            }
            set
            {
                miProxyWatchTime = (int)value;
            }
        }

        public int AutoRefresh
        {
            get
            {
                return miAutoRefresh;
            }
            set
            {
                miAutoRefresh = (int)value;
            }
        }

        #endregion

        private void setDefaultParameters()
        {
            this.comboBox_OpcServerName.Text = "Schneider-Aut.OFS";
            this.comboBox_PlcAlias.Text = "Plc4_1";
            this.comboBox_ProxyWatchTime.Text = "2 s";
            this.comboBox_AutoRefresh.Text = "5 s";
        }

        private void button_Connect_Click(object sender, EventArgs e)
        {
            this.applyParameters();
            //this.DialogResult = DialogResult.OK; // --> written in InitializeComponent()
        }

        private void button_SetDefault_Click(object sender, EventArgs e)
        {
            this.setDefaultParameters();
        }

        private void applyParameters()
        {
            // OFS //
            this.msServerName = this.comboBox_OpcServerName.Text;
            this.msPlcAlias = this.comboBox_PlcAlias.Text;

            // Proxy watch time //
            switch (this.comboBox_ProxyWatchTime.Text)
            {
                case "200 ms": this.miProxyWatchTime = 200; break;
                case "500 ms": this.miProxyWatchTime = 500; break;
                case "1 s": this.miProxyWatchTime = 1000; break;
                case "2 s": this.miProxyWatchTime = 2000; break;
                case "100 s": this.miProxyWatchTime = 100000; break;
                case "250 s": this.miProxyWatchTime = 250000; break;
                case "500 s": this.miProxyWatchTime = 500000; break;
                case "1000 s": this.miProxyWatchTime = 1000000; break;
            }

            // Auto refresh //
            switch (this.comboBox_AutoRefresh.Text)
            {
                case "500 ms": this.miAutoRefresh = 500; break;
                case "1 s": this.miAutoRefresh = 1000; break;
                case "2 s": this.miAutoRefresh = 2000; break;
                case "5 s": this.miAutoRefresh = 5000; break;
            }
        }

        private void comboBox_Ofs_TextChanged(object sender, EventArgs e)
        {
            if (
                (this.comboBox_OpcServerName.Text != "")
                && (this.comboBox_PlcAlias.Text != "")
                && (this.comboBox_ProxyWatchTime.Text != "")
                && (this.comboBox_AutoRefresh.Text != "")
                )
            {
                this.button_Connect.Enabled = true;
            }
            else
            {
                this.button_Connect.Enabled = false;
            }
        }
    }
}
