﻿
using Stephanie.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Stephanie
{
    // class BloodGasMeasuredValuesResponsePacket
    //  Description:    this class is used to represent and parse a setting packet which has been received from the device
    internal class BloodGasMeasuredValuesResponsePacket : ResponsePacket
    {
        #region Constants

        protected const byte SETTING_MESSAGE_ID = 0x37;

        #endregion

        #region Constructors

        public BloodGasMeasuredValuesResponsePacket(byte[] byData)
            : base(byData)
        { }

        #endregion

        #region Functions

        public override List<Parameter> GetParsedData()
        {
            //added for testing on the machine
#if DEBUG
            Debug.WriteLine($"BloodGasMeasuredValuesResponsePacket; Data as byte array: {TestHelper.PrintByteArray(Data)}");
#endif
            //added for testing on the machine
#if DEBUG
            Console.WriteLine($"BloodGasMeasuredValuesResponsePacket; Data: {Data}");
#endif
            List<Parameter> oParamList = new List<Parameter>();

            for (int i = 0; i < Data.Length; i += 3)
            {
                oParamList.Add(new BloodGasMeasuredValuesParametar(Data, i));
            }

            return oParamList;
        }

        protected override void AssignAndValidateID(byte[] byData)
        {
            if (byData[1] != SETTING_MESSAGE_ID)
            {
                throw new InvalidMessageIDException(byData[0]);
            }

            m_MessageID = byData[1];
        }

        #endregion

    }
}


