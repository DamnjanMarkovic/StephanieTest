using System;
using System.Collections.Generic;
using System.Text;

namespace Stephanie
{
    internal class DeviceSettingsParameter : Parameter
    {

        #region Constructors

        public DeviceSettingsParameter(byte[] byData, int startIndex)
            : base(byData, startIndex)
        { }

        public DeviceSettingsParameter(byte id, Int16 value)
            : base(id, value)
        { }

        #endregion

        protected override bool AssignAndValidateValue(short value)
        {
            //added for testing on the machine
#if DEBUG
            Console.WriteLine($"DeviceSettingsParameter; Value: {value}");
#endif
            //  Set Description, using Name and PDF values:

            switch (this.Name)
            {
                case "Trigger Source":
                    this.m_Description = SetTriggerSourceDescription(value);
                    break;
                case "Respiratory Supplement":
                    this.m_Description = SetRespiratorySupplementDescription(value);
                    break;
                case "Closed Loop Ventilation":
                    this.m_Description = SetClosedLoopVentilationDescription(value);
                    break;
                case "Rebreathing Mode":
                    this.m_Description = SetRebreathingModeDescription(value);
                    break;
                default:
                    break;
            }
            // Calculating the real value for this parameter
            m_Value = ((float)value / m_Divider).ToString();
            return true;
        }


        #region Set description based on values 
        private string SetTriggerSourceDescription(short value)
        {
            switch (value)
            {
                case 0:
                    return "Inactive / No Trigger";
                case 1:
                    return "Pressure-";
                case 2:
                    return "Flow-";
                case 3:
                    return "External Trigger";
                default:
                    return string.Empty;
            }
        }
        private string SetRespiratorySupplementDescription(short value)
        {
            switch (value)
            {
                case 0:
                    return "NONE";
                case 1:
                    return "HFO";
                case 2:
                    return "PAV (NVI) ";
                case 4:
                    return "PVI";
                case 8:
                    return "APNCTRL (Apnoe control)";
                case 16:
                    return "VLIM (Volume limit)";
                case 32:
                    return "VG (PRVC)";
                case 64:
                    return "Backup (STDBU)";
                case 128:
                    return "PSV";
                case 256:
                    return "BBRK (Break)";
                case 512:
                    return "NIV (non invasive)";
                case 1024:
                    return "TC";
                case 2048:
                    return "Leakage Compensation ";
                case 4096:
                    return "Measure";
                default:
                    return string.Empty;
            }
        }
        private string SetClosedLoopVentilationDescription(short value)
        {
            switch (value)
            {
                case 0:
                    return "Deactivated";
                case 1:
                    return "Activated";
                default:
                    return string.Empty;
            }
        }
        private string SetRebreathingModeDescription(short value)
        {
            switch (value)
            {
                case 0:
                    return "Closed";
                case 1:
                    return "Open";
                case 2:
                    return "Semi Open";
                case 3:
                    return "Semi Closed";
                default:
                    return string.Empty; 
            }
        }

        #endregion
    }
}
