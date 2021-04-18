using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace scada_tcp_server
{
    public class ScadaTCPBody
    {
        private byte[] bodyBytes;

        private MemoryStream stream = new MemoryStream();

        public byte[] BodyBytes
        {
            get { return bodyBytes; }
            set { bodyBytes = value; }
        }



        public virtual void Debug()
        {

        }

        public virtual void Info()
        {
        }

        public virtual void Decode()
        {
        }

        public virtual ScadaTCPMsg GetSendMsg()
        {
            return null;
        }

        public virtual void Encode()
        {
        }

        public byte[] GetBytes() => stream.ToArray();

        #region Write
        public void WriteBytes(byte[] bts)
        {
            stream.Write(bts, 0, bts.Length);
        }

        public void WriteByte(byte b)
        {
            stream.WriteByte(b);
        }

        /// <summary>
        /// 写入固定长度的字符
        /// </summary>
        /// <param name="s"></param>
        /// <param name="len"></param>
        public void WriteString(string s, int len, string charset)
        {
            byte[] bits = new byte[len];
            if (string.IsNullOrEmpty(s))
            {
                stream.Write(bits, 0, len);
                return;
            }
            byte[] sBytes = Encoding.GetEncoding(charset).GetBytes(s);
            if (sBytes.Length > bits.Length)
            {
                Array.Copy(sBytes, bits, len);
            }
            else
            {
                Array.Copy(sBytes, bits, sBytes.Length);
            }
            stream.Write(bits, 0, len);
        }

        public void WriteString(string s, int len)
        {
            byte[] bits = new byte[len];
            if (string.IsNullOrEmpty(s))
            {
                stream.Write(bits, 0, len);
                return;
            }
            byte[] sBytes = Encoding.ASCII.GetBytes(s);
            if (sBytes.Length > bits.Length)
            {
                Array.Copy(sBytes, bits, len);
            }
            else
            {
                Array.Copy(sBytes, bits, sBytes.Length);
            }
            stream.Write(bits, 0, len);
        }

        public void WriteString(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return;
            }
            byte[] sBytes = Encoding.ASCII.GetBytes(s);

            stream.Write(sBytes, 0, sBytes.Length);
        }

        public void WriteString(string s, string charset)
        {
            byte[] sBytes = Encoding.GetEncoding(charset).GetBytes(s);
            stream.Write(sBytes, 0, sBytes.Length);
        }

        public void WriteBigInt(int i)
        {
            byte[] bit = BitConverter.GetBytes(i);
            stream.Write(bit,0, bit.Length);
        }

        public void WriteSmallInt(int i)
        {
            byte[] bit = BitConverter.GetBytes(i);
            Array.Reverse(bit);
            stream.Write(bit, 0, bit.Length);
        }

        public void WriteBigShort(short s)
        {
            byte[] bit = BitConverter.GetBytes(s);
            stream.Write(bit, 0, bit.Length);
        }

        public void WriteSmallShort(short s)
        {
            byte[] bit = BitConverter.GetBytes(s);
            Array.Reverse(bit);
            stream.Write(bit, 0, bit.Length);
        }

        public void WriteBigDouble(double d)
        {
            byte[] bit = BitConverter.GetBytes(d);
            stream.Write(bit, 0, bit.Length);
        }

        public void WriteSmallDouble(double d)
        {
            byte[] bit = BitConverter.GetBytes(d);
            Array.Reverse(bit);
            stream.Write(bit, 0, bit.Length);
        }

        public void WriteBigFloat(float d)
        {
            byte[] bit = BitConverter.GetBytes(d);
            stream.Write(bit, 0, bit.Length);
        }

        public void WriteSmallFloat(double d)
        {
            byte[] bit = BitConverter.GetBytes(d);
            Array.Reverse(bit);
            stream.Write(bit, 0, bit.Length);
        }


        #endregion



        #region Read

        private int offset = 0;

        public int ReadBigInt()
        {

            int i = BitConverter.ToInt32(BodyBytes, offset);
            offset += 4;
            return i;
        }

        public int ReadSmallInt()
        {
            byte[] arr = new byte[4];
            Array.Copy(BodyBytes, offset, arr, 0, 4);
            Array.Reverse(arr);
            int i = BitConverter.ToInt32(arr, 0);
            offset += 4;
            return i;
        }

        public short ReadSmallShort()
        {
            short i = BitConverter.ToInt16(BodyBytes, offset);
            offset += 2;
            return i;
        }

        public int ReadBigShort()
        {
            byte[] arr = new byte[4];
            Array.Copy(BodyBytes, offset, arr, 0, 2);
            Array.Reverse(arr);
            int i = BitConverter.ToInt16(arr, 0);
            offset += 2;
            return i;
        }

        public string ReadString(string charset, int len)
        {
            string s = Encoding.GetEncoding(charset).GetString(BodyBytes, offset, len);
            offset += len;
            return s;
        }

        public string ReadString(int len)
        {
            string s = Encoding.ASCII.GetString(BodyBytes, offset, len);
            offset += len;
            return s;
        }

        /// <summary>
        /// 读取从当前字符串一直到结束
        /// </summary>
        /// <returns></returns>
        public string ReadStringToEnd()
        {
            int leftLen = BodyBytes.Length - offset;
            string s = Encoding.ASCII.GetString(BodyBytes, offset, leftLen);
            offset += leftLen;
            return s;
        }

        public byte ReadByte()
        {
            byte b = BodyBytes[offset];
            offset += 1;
            return b;
        }

        public int ReadByteToInt()
        {
            return ReadByte();
        }


        public double ReadBigDouble()
        {
            byte[] arr = new byte[4];
            Array.Copy(BodyBytes, offset, arr, 0, 8);
            Array.Reverse(arr);
            double i = BitConverter.ToDouble(arr, 0);
            offset += 8;
            return i;
        }

        public double ReadSmallDouble()
        {
            double i = BitConverter.ToDouble(BodyBytes, offset);
            offset += 8;
            return i;
        }

        public bool ReadBool()
        {
            bool b = BitConverter.ToBoolean(BodyBytes, offset);
            offset += 1;
            return b;
        }

        public char ReadChar()
        {
            char c = BitConverter.ToChar(BodyBytes, offset);
            offset += 2;
            return c;
        }
        public byte[] ReadBytes(int len)
        {
            byte[] bits = new byte[len];
            Array.Copy(BodyBytes, offset, bits, 0, len);
            offset += len;
            return bits;
        }
        #endregion

    }
}
