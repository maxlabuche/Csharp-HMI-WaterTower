namespace HmiWaterTower
{
    partial class COPCProxy
    {
        // Name of items on .stu //

        #region Item names

        // 20 items selected //
        private string sItem_iexPlcStatus = "#PLCStatus"; // Enabled
        private string sItem_iexAru = "M_i_aru"; // Enabled
        private string sItem_iexBouchon = "M_i_bouchon";
        private string sItem_iexStorageEmpty = "M_i_cuve_vide"; // Enabled
        private string sItem_iexDisj_q2_open = "M_i_disj_q2_ouvert";
        private string sItem_iexKm1_PumpEn = "M_i_km1"; // Enabled
        private string sItem_iexPressionHydroSup_4b1 = "M_i_pression_hydro_sup_4b1"; // Enabled
        private string sItem_iexTempPompeSup_40 = "M_i_temp_pompe_sup_40"; // Enabled
        private string sItem_iexDebitPert = "M_iw_debit_pert"; // Enabled
        private string sItem_iexDebitPompe = "M_iw_debit_pompe"; // Enabled
        private string sItem_iexLevelStorage1 = "M_iw_niv_col_1"; // Enabled
        private string sItem_iexLevelStorage2 = "M_iw_niv_col_2"; // Enabled
        private string sItem_mexMode_manu = "M_Mode_Manu"; // Enabled (write available only for manual mode)
        private string sItem_mexCmdPompePert_Km2 = "M_q_cmd_pompe_pert_km2";
        private string sItem_mexTabEv = "MTab_q_ev"; // used for EV1 to EV4
        private string sItem_mexEv1 = "M_q_ev1"; // Enabled
        private string sItem_mexEv2 = "M_q_ev2"; // Enabled
        private string sItem_mexEv3 = "M_q_ev3"; // Enabled
        private string sItem_mexEv4 = "M_q_ev4"; // Enabled
        private string sItem_mexEv5 = "M_q_ev5"; // Enabled (pump to main storage)
        private string sItem_iexLowLevel = "M_q_niveau_bas"; // Enabled
        private string sItem_mexAtv18_auto = "M_qw_atv18_auto"; // Read only
        private string sItem_mexAtv18_manu = "M_qw_atv18_manu"; // Enabled
        private string sItem_mexConsigneSp = "M_qw_cons_sp"; // Read only
        private string sItem_mexMesurePv = "M_qw_mesure_pv";
        private string sItem_mexSortiePid = "M_qw_sortie_pid";
        private string sItem_mexVm1 = "M_qw_vm1"; // Enabled
        private string sItem_mexVm2 = "M_qw_vm2"; // Enabled
        private string sItem_mexVm3_auto = "M_qw_vm3_auto"; // Read only
        private string sItem_mexVm3_manu = "M_qw_vm3_manu"; // Enabled

        #endregion


        // PLC I/O //

        # region Private members of I/O

        private short iexPlcStatus_i16;
        private bool iexAru_b;
        private bool iexBouchon_b;
        private bool iexStorageEmpty_b;
        private bool iexDisj_q2_open_b;
        private bool iexKm1_PumpEn_b;
        private bool iexPressionHydroSup_4b1_b;
        private bool iexTempPompeSup_40_b;
        private short iexDebitPert_i16;
        private short iexDebitPompe_i16;
        private short iexLevelStorage1_i16;
        private short iexLevelStorage2_i16;
        private bool mexMode_manu_b;
        private bool mexCmdPompePert_Km2_b;
        private bool[] mexTabEv_b;
        private bool mexEv1_b;
        private bool mexEv2_b;
        private bool mexEv3_b;
        private bool mexEv4_b;
        private bool mexEv5_b;
        private bool iexLowLevel_b;
        private short mexAtv18_auto_i16;
        private short mexAtv18_manu_i16;
        private short mexConsigneSp_i16;
        private short mexMesurePv_i16;
        private short mexSortiePid_i16;
        private short mexVm1_i16;
        private short mexVm2_i16;
        private short mexVm3_auto_i16;
        private short mexVm3_manu_i16;

        #endregion

        #region Properties

        public short iexPlcStatus
        {
            get
            {
                return this.iexPlcStatus_i16;
            }
            set
            {
                if ((0 <= (short)value) && ((short)value <= 10000))
                {
                    this.mWriteValue(sItem_iexPlcStatus, (short)value);
                    this.iexPlcStatus_i16 = (short)value;
                }
            }
        }
        public bool iexAru
        {
            get
            {
                return this.iexAru_b;
            }
        }
        public bool iexBouchon;
        public bool iexStorageEmpty
        {
            get
            {
                return this.iexStorageEmpty_b;
            }
        }
        public bool iexDisj_q2_open;
        public bool iexKm1_PumpEn
        {
            get
            {
                return this.iexKm1_PumpEn_b;
            }
        }
        public bool iexPressionHydroSup_4b1
        {
            get
            {
                return this.iexPressionHydroSup_4b1_b;
            }
        }
        public bool iexTempPompeSup_40
        {
            get
            {
                return this.iexTempPompeSup_40_b;
            }
        }
        public short iexDebitPert
        {
            get
            {
                return this.iexDebitPert_i16;
            }
        }
        public short iexDebitPompe
        {
            get
            {
                return this.iexDebitPompe_i16;
            }
        }
        public short iexLevelStorage1
        {
            get
            {
                return this.iexLevelStorage1_i16;
            }
        }
        public short iexLevelStorage2
        {
            get
            {
                return this.iexLevelStorage2_i16;
            }
        }
        public bool mexMode_manu
        {
            get
            {
                return this.mexMode_manu_b;
            }
            set
            {
                this.mWriteValue(sItem_mexMode_manu, (bool)value);
                this.mexMode_manu_b = (bool)value;
            }
        }
        public bool mexCmdPompePert_Km2;
        public bool[] mexTabEv
        {
            get
            {
                return mexTabEv_b;
            }
            set
            {
                this.mWriteValue(sItem_mexTabEv, (bool[])value);
                this.mexTabEv_b = (bool[])value;
            }
        }
        public bool mexEv1
        {
            get
            {
                bool bOutput = this.mexEv1_b;
                return bOutput;
            }
            set
            {
                try
                {
                    this.mWriteValue(sItem_mexEv1, (bool)value);
                    this.mexEv1_b = (bool)value;
                }
                catch { }
            }
        }
        public bool mexEv2
        {
            get
            {
                return this.mexEv2_b;
            }
            set
            {
                this.mWriteValue(sItem_mexEv2, (bool)value);
                this.mexEv2_b = (bool)value;
            }
        }
        public bool mexEv3
        {
            get
            {
                return this.mexEv3_b;
            }
            set
            {
                this.mWriteValue(sItem_mexEv3, (bool)value);
                this.mexEv3_b = (bool)value;
            }
        }
        public bool mexEv4
        {
            get
            {
                return this.mexEv4_b;
            }
            set
            {
                this.mWriteValue(sItem_mexEv4, (bool)value);
                this.mexEv4_b = (bool)value;
            }
        }
        public bool mexEv5
        {
            get
            {
                return this.mexEv5_b;
            }
            set
            {
                this.mWriteValue(sItem_mexEv5, (bool)value);
                this.mexEv5_b = (bool)value;
            }
        }
        public bool iexLowLevel
        {
            get
            {
                return this.iexLowLevel_b;
            }
        }
        public short mexAtv18_auto
        {
            get
            {
                return this.mexAtv18_auto_i16;
            }
            // write not available
        }
        public short mexAtv18_manu
        {
            get
            {
                return this.mexAtv18_manu_i16;
            }
            set
            {
                if ((0 <= (short)value) && ((short)value <= 10000))
                {
                    this.mWriteValue(sItem_mexAtv18_manu, (short)value);
                    this.mexAtv18_manu_i16 = (short)value;
                }
            }
        }
        public short mexConsigneSp
        {
            get
            {
                return this.mexConsigneSp_i16;
            }
            set
            {
                if ((0 <= (short)value) && ((short)value <= 100))
                {
                    this.mWriteValue(sItem_mexConsigneSp, (short)value);
                    this.mexConsigneSp_i16 = (short)value;
                }
            }
        }
        public short mexMesurePv;
        public short mexSortiePid;
        public short mexVm1
        {
            get
            {
                return this.mexVm1_i16;
            }
            set
            {
                if ((0 <= (short)value) && ((short)value <= 10000))
                {
                    this.mWriteValue(sItem_mexVm1, (short)value);
                    this.mexVm1_i16 = (short)value;
                }
            }
        }
        public short mexVm2
        {
            get
            {
                return this.mexVm2_i16;
            }
            set
            {
                if ((0 <= (short)value) && ((short)value <= 10000))
                {
                    this.mWriteValue(sItem_mexVm2, (short)value);
                    this.mexVm2_i16 = (short)value;
                }
            }
        }
        public short mexVm3_auto
        {
            get
            {
                return this.mexVm3_auto_i16;
            }
            // write not available
        }
        public short mexVm3_manu
        {
            get
            {
                return this.mexVm3_manu_i16;
            }
            set
            {
                if ((0 <= (short)value) && ((short)value <= 10000))
                {
                    this.mWriteValue(sItem_mexVm3_manu, (short)value);
                    this.mexVm3_manu_i16 = (short)value;
                }
            }
        }

        #endregion

        #region Methods for all values

        private void mAddAllItems()
        {
            mAddItem(sItem_iexAru);
            mAddItem(sItem_iexBouchon);
            mAddItem(sItem_iexDebitPert);
            mAddItem(sItem_iexDebitPompe);
            mAddItem(sItem_iexDisj_q2_open);
            mAddItem(sItem_iexKm1_PumpEn);
            mAddItem(sItem_iexLevelStorage1);
            mAddItem(sItem_iexLevelStorage2);
            mAddItem(sItem_iexLowLevel);
            mAddItem(sItem_iexPlcStatus);
            mAddItem(sItem_iexPressionHydroSup_4b1);
            mAddItem(sItem_iexStorageEmpty);
            mAddItem(sItem_iexTempPompeSup_40);
            mAddItem(sItem_mexAtv18_auto);
            mAddItem(sItem_mexAtv18_manu);
            mAddItem(sItem_mexCmdPompePert_Km2);
            mAddItem(sItem_mexConsigneSp);
            mAddItem(sItem_mexTabEv);
            mAddItem(sItem_mexEv1);
            mAddItem(sItem_mexEv2);
            mAddItem(sItem_mexEv3);
            mAddItem(sItem_mexEv4);
            mAddItem(sItem_mexEv5);
            mAddItem(sItem_mexMesurePv);
            mAddItem(sItem_mexMode_manu);
            mAddItem(sItem_mexSortiePid);
            mAddItem(sItem_mexVm1);
            mAddItem(sItem_mexVm2);
            mAddItem(sItem_mexVm3_auto);
            mAddItem(sItem_mexVm3_manu);
        }

        private void mGetAllValues()
        {
            this.mexAtv18_auto_i16 = (short)mGetValue(sItem_mexAtv18_auto);
            this.mexAtv18_manu_i16 = (short)mGetValue(sItem_mexAtv18_manu);
            this.mexCmdPompePert_Km2_b = (bool)mGetValue(sItem_mexCmdPompePert_Km2);
            this.mexConsigneSp_i16 = (short)mGetValue(sItem_mexConsigneSp);
            this.mexTabEv_b = (bool[])mGetValue(sItem_mexTabEv);
            this.mexEv1_b = (bool)mGetValue(sItem_mexEv1);
            this.mexEv2_b = (bool)mGetValue(sItem_mexEv2);
            this.mexEv3_b = (bool)mGetValue(sItem_mexEv3);
            this.mexEv4_b = (bool)mGetValue(sItem_mexEv4);
            this.mexEv5_b = (bool)mGetValue(sItem_mexEv5);
            this.mexMesurePv_i16 = (short)mGetValue(sItem_mexMesurePv);
            this.mexMode_manu_b = (bool)mGetValue(sItem_mexMode_manu);
            this.mexSortiePid_i16 = (short)mGetValue(sItem_mexSortiePid);
            this.mexVm1_i16 = (short)mGetValue(sItem_mexVm1);
            this.mexVm2_i16 = (short)mGetValue(sItem_mexVm2);
            this.mexVm3_auto_i16 = (short)mGetValue(sItem_mexVm3_auto);
            this.mexVm3_manu_i16 = (short)mGetValue(sItem_mexVm3_manu);
            this.iexAru_b = (bool)mGetValue(sItem_iexAru);
            this.iexBouchon_b = (bool)mGetValue(sItem_iexBouchon);
            this.iexDebitPert_i16 = (short)mGetValue(sItem_iexDebitPert);
            this.iexDebitPompe_i16 = (short)mGetValue(sItem_iexDebitPompe);
            this.iexDisj_q2_open_b = (bool)mGetValue(sItem_iexDisj_q2_open);
            this.iexKm1_PumpEn_b = (bool)mGetValue(sItem_iexKm1_PumpEn);
            this.iexLevelStorage1_i16 = (short)mGetValue(sItem_iexLevelStorage1);
            this.iexLevelStorage2_i16 = (short)mGetValue(sItem_iexLevelStorage2);
            this.iexLowLevel_b = (bool)mGetValue(sItem_iexLowLevel);
            this.iexPlcStatus_i16 = (short)mGetValue(sItem_iexPlcStatus);
            this.iexPressionHydroSup_4b1_b = (bool)mGetValue(sItem_iexPressionHydroSup_4b1);
            this.iexStorageEmpty_b = (bool)mGetValue(sItem_iexStorageEmpty);
            this.iexTempPompeSup_40_b = (bool)mGetValue(sItem_iexTempPompeSup_40);
        }

        #endregion

    }
}
