﻿/* 
 * NodeDiscoverData.cs
 * 
 * Copyright (c) 2008, Michael Schwarz (http://www.schwarz-interactive.de)
 *
 * Permission is hereby granted, free of charge, to any person
 * obtaining a copy of this software and associated documentation
 * files (the "Software"), to deal in the Software without
 * restriction, including without limitation the rights to use,
 * copy, modify, merge, publish, distribute, sublicense, and/or
 * sell copies of the Software, and to permit persons to whom the
 * Software is furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
 * OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
 * IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR
 * ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
 * CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
 * CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 * 
 */
using System;
using System.Text;
using MSchwarz.IO;

namespace MSchwarz.Net.Zigbee
{
	public class NodeDiscoverData : IAtCommandData
	{
		private ushort _addr16;
		private ulong _addr64;
		private string _ni;
		private ushort _parent16;
		private byte _deviceType;
		private byte _sourceAction;
		private ushort _profileID;
		private ushort _manufactureID;

		#region Public Properties

		public ushort Address16
		{
			get { return _addr16; }
		}

		public ulong Address64
		{
			get { return _addr64; }
		}

		public string NodeIdentifier
		{
			get { return _ni; }
		}

		// ...

		public ZigBeeDeviceType DeviceType
		{
			get { return (ZigBeeDeviceType)_deviceType; }
		}

		// ...

		#endregion

		public void Fill(byte[] value)
		{
			ByteReader nd = new ByteReader(value, ByteOrder.BigEndian);

            _addr16 = nd.ReadUInt16();
            _addr64 = nd.ReadUInt64();

            _ni = nd.ReadString((int)nd.AvailableBytes - 8);

			_parent16 = nd.ReadUInt16();
			_deviceType = nd.ReadByte();
			_sourceAction = nd.ReadByte();
			_profileID = nd.ReadUInt16();
			_manufactureID = nd.ReadUInt16();
		}

		public override string ToString()
		{
			string s = @"                    MY " + _addr16 + @"
                 SH SL " + _addr64 + @"
                    NI " + _ni + @"
PARENT_NETWORK ADDRESS {3}
           DEVICE_TYPE {4}
                STATUS {5}
            PROFILE_ID {6}
       MANUFACTURER_ID {7}";

			return s;
		}
	}
}