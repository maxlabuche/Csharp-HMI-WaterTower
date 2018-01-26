namespace HmiWaterTower
{
    partial class CConnectionDialog
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
            this.button_Connect = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.comboBox_OpcServerName = new System.Windows.Forms.ComboBox();
            this.comboBox_PlcAlias = new System.Windows.Forms.ComboBox();
            this.label_OpcServerName_Text = new System.Windows.Forms.Label();
            this.label_PlcAlias_Text = new System.Windows.Forms.Label();
            this.comboBox_ProxyWatchTime = new System.Windows.Forms.ComboBox();
            this.label_ProxyWatchTime_Text = new System.Windows.Forms.Label();
            this.groupBox_Parameters = new System.Windows.Forms.GroupBox();
            this.comboBox_AutoRefresh = new System.Windows.Forms.ComboBox();
            this.label_AutoRefresh_Text = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_Bottom1 = new System.Windows.Forms.Label();
            this.button_SetDefault = new System.Windows.Forms.Button();
            this.label_Bottom2 = new System.Windows.Forms.Label();
            this.label_Title2 = new System.Windows.Forms.Label();
            this.label_Title1 = new System.Windows.Forms.Label();
            this.groupBox_Parameters.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_Connect
            // 
            this.button_Connect.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button_Connect.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_Connect.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_Connect.Location = new System.Drawing.Point(33, 259);
            this.button_Connect.Name = "button_Connect";
            this.button_Connect.Size = new System.Drawing.Size(92, 28);
            this.button_Connect.TabIndex = 0;
            this.button_Connect.Text = "&Connect";
            this.button_Connect.UseVisualStyleBackColor = true;
            this.button_Connect.Click += new System.EventHandler(this.button_Connect_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_Cancel.Location = new System.Drawing.Point(140, 259);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(92, 28);
            this.button_Cancel.TabIndex = 4;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            // 
            // comboBox_OpcServerName
            // 
            this.comboBox_OpcServerName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBox_OpcServerName.FormattingEnabled = true;
            this.comboBox_OpcServerName.Items.AddRange(new object[] {
            "Schneider-Aut.OFS"});
            this.comboBox_OpcServerName.Location = new System.Drawing.Point(33, 152);
            this.comboBox_OpcServerName.Name = "comboBox_OpcServerName";
            this.comboBox_OpcServerName.Size = new System.Drawing.Size(184, 21);
            this.comboBox_OpcServerName.TabIndex = 1;
            this.comboBox_OpcServerName.TextChanged += new System.EventHandler(this.comboBox_Ofs_TextChanged);
            // 
            // comboBox_PlcAlias
            // 
            this.comboBox_PlcAlias.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBox_PlcAlias.FormattingEnabled = true;
            this.comboBox_PlcAlias.Items.AddRange(new object[] {
            "Api4_1",
            "Plc4_1"});
            this.comboBox_PlcAlias.Location = new System.Drawing.Point(33, 209);
            this.comboBox_PlcAlias.Name = "comboBox_PlcAlias";
            this.comboBox_PlcAlias.Size = new System.Drawing.Size(184, 21);
            this.comboBox_PlcAlias.TabIndex = 2;
            this.comboBox_PlcAlias.TextChanged += new System.EventHandler(this.comboBox_Ofs_TextChanged);
            // 
            // label_OpcServerName_Text
            // 
            this.label_OpcServerName_Text.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_OpcServerName_Text.AutoSize = true;
            this.label_OpcServerName_Text.Location = new System.Drawing.Point(33, 135);
            this.label_OpcServerName_Text.Name = "label_OpcServerName_Text";
            this.label_OpcServerName_Text.Size = new System.Drawing.Size(90, 13);
            this.label_OpcServerName_Text.TabIndex = 4;
            this.label_OpcServerName_Text.Text = "OPC server name";
            // 
            // label_PlcAlias_Text
            // 
            this.label_PlcAlias_Text.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_PlcAlias_Text.AutoSize = true;
            this.label_PlcAlias_Text.Location = new System.Drawing.Point(33, 192);
            this.label_PlcAlias_Text.Name = "label_PlcAlias_Text";
            this.label_PlcAlias_Text.Size = new System.Drawing.Size(51, 13);
            this.label_PlcAlias_Text.TabIndex = 5;
            this.label_PlcAlias_Text.Text = "PLC alias";
            // 
            // comboBox_ProxyWatchTime
            // 
            this.comboBox_ProxyWatchTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBox_ProxyWatchTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_ProxyWatchTime.FormattingEnabled = true;
            this.comboBox_ProxyWatchTime.Items.AddRange(new object[] {
            "200 ms",
            "500 ms",
            "1 s",
            "2 s",
            "100 s",
            "250 s",
            "500 s",
            "1000 s"});
            this.comboBox_ProxyWatchTime.Location = new System.Drawing.Point(124, 26);
            this.comboBox_ProxyWatchTime.Name = "comboBox_ProxyWatchTime";
            this.comboBox_ProxyWatchTime.Size = new System.Drawing.Size(72, 21);
            this.comboBox_ProxyWatchTime.TabIndex = 5;
            // 
            // label_ProxyWatchTime_Text
            // 
            this.label_ProxyWatchTime_Text.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_ProxyWatchTime_Text.AutoSize = true;
            this.label_ProxyWatchTime_Text.Location = new System.Drawing.Point(12, 29);
            this.label_ProxyWatchTime_Text.Name = "label_ProxyWatchTime_Text";
            this.label_ProxyWatchTime_Text.Size = new System.Drawing.Size(87, 13);
            this.label_ProxyWatchTime_Text.TabIndex = 7;
            this.label_ProxyWatchTime_Text.Text = "Proxy watch time";
            // 
            // groupBox_Parameters
            // 
            this.groupBox_Parameters.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.groupBox_Parameters.Controls.Add(this.comboBox_AutoRefresh);
            this.groupBox_Parameters.Controls.Add(this.label_AutoRefresh_Text);
            this.groupBox_Parameters.Controls.Add(this.comboBox_ProxyWatchTime);
            this.groupBox_Parameters.Controls.Add(this.label_ProxyWatchTime_Text);
            this.groupBox_Parameters.Location = new System.Drawing.Point(26, 371);
            this.groupBox_Parameters.Name = "groupBox_Parameters";
            this.groupBox_Parameters.Size = new System.Drawing.Size(213, 91);
            this.groupBox_Parameters.TabIndex = 8;
            this.groupBox_Parameters.TabStop = false;
            this.groupBox_Parameters.Text = "Parameters";
            // 
            // comboBox_AutoRefresh
            // 
            this.comboBox_AutoRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBox_AutoRefresh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_AutoRefresh.Enabled = false;
            this.comboBox_AutoRefresh.FormattingEnabled = true;
            this.comboBox_AutoRefresh.Items.AddRange(new object[] {
            "500 ms",
            "1 s",
            "2 s",
            "5 s"});
            this.comboBox_AutoRefresh.Location = new System.Drawing.Point(124, 56);
            this.comboBox_AutoRefresh.Name = "comboBox_AutoRefresh";
            this.comboBox_AutoRefresh.Size = new System.Drawing.Size(72, 21);
            this.comboBox_AutoRefresh.TabIndex = 6;
            // 
            // label_AutoRefresh_Text
            // 
            this.label_AutoRefresh_Text.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_AutoRefresh_Text.AutoSize = true;
            this.label_AutoRefresh_Text.Location = new System.Drawing.Point(12, 59);
            this.label_AutoRefresh_Text.Name = "label_AutoRefresh_Text";
            this.label_AutoRefresh_Text.Size = new System.Drawing.Size(133, 13);
            this.label_AutoRefresh_Text.TabIndex = 9;
            this.label_AutoRefresh_Text.Text = "Auto refresh (not available)";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label_Bottom1);
            this.panel1.Controls.Add(this.button_SetDefault);
            this.panel1.Controls.Add(this.label_Bottom2);
            this.panel1.Controls.Add(this.label_Title2);
            this.panel1.Controls.Add(this.groupBox_Parameters);
            this.panel1.Controls.Add(this.label_Title1);
            this.panel1.Controls.Add(this.label_OpcServerName_Text);
            this.panel1.Controls.Add(this.label_PlcAlias_Text);
            this.panel1.Controls.Add(this.button_Connect);
            this.panel1.Controls.Add(this.button_Cancel);
            this.panel1.Controls.Add(this.comboBox_PlcAlias);
            this.panel1.Controls.Add(this.comboBox_OpcServerName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(673, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(264, 573);
            this.panel1.TabIndex = 9;
            // 
            // label_Bottom1
            // 
            this.label_Bottom1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_Bottom1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Bottom1.ForeColor = System.Drawing.Color.Black;
            this.label_Bottom1.Location = new System.Drawing.Point(15, 508);
            this.label_Bottom1.Name = "label_Bottom1";
            this.label_Bottom1.Size = new System.Drawing.Size(237, 21);
            this.label_Bottom1.TabIndex = 10;
            this.label_Bottom1.Text = "© 2017 Maxime MARMONT";
            this.label_Bottom1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // button_SetDefault
            // 
            this.button_SetDefault.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button_SetDefault.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_SetDefault.Location = new System.Drawing.Point(67, 316);
            this.button_SetDefault.Name = "button_SetDefault";
            this.button_SetDefault.Size = new System.Drawing.Size(130, 28);
            this.button_SetDefault.TabIndex = 3;
            this.button_SetDefault.Text = "Set &default parameters";
            this.button_SetDefault.UseVisualStyleBackColor = true;
            this.button_SetDefault.Click += new System.EventHandler(this.button_SetDefault_Click);
            // 
            // label_Bottom2
            // 
            this.label_Bottom2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_Bottom2.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Bottom2.ForeColor = System.Drawing.Color.DarkGray;
            this.label_Bottom2.Location = new System.Drawing.Point(15, 525);
            this.label_Bottom2.Name = "label_Bottom2";
            this.label_Bottom2.Size = new System.Drawing.Size(237, 39);
            this.label_Bottom2.TabIndex = 10;
            this.label_Bottom2.Text = "for IUT of Annecy\r\n(University Savoie Mont-Blanc, France)";
            this.label_Bottom2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label_Title2
            // 
            this.label_Title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Title2.Location = new System.Drawing.Point(15, 37);
            this.label_Title2.Name = "label_Title2";
            this.label_Title2.Size = new System.Drawing.Size(182, 13);
            this.label_Title2.TabIndex = 10;
            this.label_Title2.Text = "Connection manager";
            // 
            // label_Title1
            // 
            this.label_Title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Title1.Location = new System.Drawing.Point(12, 11);
            this.label_Title1.Name = "label_Title1";
            this.label_Title1.Size = new System.Drawing.Size(183, 25);
            this.label_Title1.TabIndex = 11;
            this.label_Title1.Text = "HMI Water Tower";
            // 
            // CConnectionDialog
            // 
            this.AcceptButton = this.button_Connect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Cancel;
            this.ClientSize = new System.Drawing.Size(937, 573);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(888, 535);
            this.Name = "CConnectionDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Connection";
            this.groupBox_Parameters.ResumeLayout(false);
            this.groupBox_Parameters.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Connect;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.ComboBox comboBox_OpcServerName;
        private System.Windows.Forms.ComboBox comboBox_PlcAlias;
        private System.Windows.Forms.Label label_OpcServerName_Text;
        private System.Windows.Forms.Label label_PlcAlias_Text;
        private System.Windows.Forms.ComboBox comboBox_ProxyWatchTime;
        private System.Windows.Forms.Label label_ProxyWatchTime_Text;
        private System.Windows.Forms.GroupBox groupBox_Parameters;
        private System.Windows.Forms.ComboBox comboBox_AutoRefresh;
        private System.Windows.Forms.Label label_AutoRefresh_Text;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_Title1;
        private System.Windows.Forms.Label label_Title2;
        private System.Windows.Forms.Button button_SetDefault;
        private System.Windows.Forms.Label label_Bottom2;
        private System.Windows.Forms.Label label_Bottom1;
    }
}