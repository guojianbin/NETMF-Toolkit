﻿/* 
 * DnsWriter.cs
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
using System.IO;
using MSchwarz.IO;

namespace MSchwarz.Net.Dns
{
    internal class DnsWriter : ByteWriter
    {
        public DnsWriter()
            : base()
        {
            _byteOrder = ByteOrder.Network;
        }

        public override void Write(string s)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(s);

            Write((byte)bytes.Length);      // RFC 1035 strings are prefixed with a 8-bit length indicator.
            Write(bytes);
        }

        /// <summary>
        /// Writs a domain name. (RFC 1035 - 4.1.4.)
        /// </summary>
        public void WriteDomain(string domain)
        {
            foreach (string label in domain.Split('.'))
                this.Write(label);

            Write((byte)0x00);    // last label
        }
    }
}