﻿/* 
 * ByteUtil.cs
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

namespace MSchwarz.IO
{
    public class ByteUtil
    {
#if(MF)
		public static string GetString(byte[] bytes)
		{
			string s = "";

			foreach(char c in Encoding.UTF8.GetChars(bytes))
				s += c;

			return s;
		}
#endif

        public static string PrintByte(byte b)
        {
            return b.ToString("X2");
        }

        public static string PrintBytes(byte[] bytes)
        {
            string s = "";

            int c = 0;

            for (int i = 0; i < bytes.Length; i++)
            {
				s += bytes[i].ToString("X2");			// +"(" + (char)bytes[i] + ")";

                if (++c == 10)
                {
                    s += "\r\n";
                    c = 0;
                }
                else
                    if (i < bytes.Length - 1) s += "-";

                
            }

            return s;
        }
    }
}