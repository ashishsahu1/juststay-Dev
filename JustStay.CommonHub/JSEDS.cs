using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services;

namespace JustStay.CommonHub
{
    public class JSEDS
    {
        private const int LENGTH = 256;

        private int _pswdLen = 0;
        private int[] _key = null;
        private int[] _box = null;

        public JSEDS()
            : this("nmsKaarInfotech_juststay@#0")
        {
        }

        public JSEDS(string password)
        {
            int i, j, tmp = 0;
            _pswdLen = password.Length;
            _key = new int[LENGTH];
            _box = new int[LENGTH];

            for (i = 0; i < LENGTH; i++)
            {
                _key[i] = Ord(password[i % _pswdLen]);
                _box[i] = i;
            }
            for (j = i = 0; i < LENGTH; i++)
            {
                j = (j + _box[i] + _key[i]) % LENGTH;
                tmp = _box[i];
                _box[i] = _box[j];
                _box[j] = tmp;
            }
        }
        /**
         * Get Integer Code
         *
         * @param char ch Character to get ASCII value for
         * @access private
         * @return int
         */
        private int Ord(char ch)
        {

            return (int)(Encoding.Default.GetBytes(ch.ToString())[0]);
        }
        /**
         * Get character representation of ASCII Code
         *
         * @param int i code
         * @access private
         * @return char
         */
        private char Chr(int i)
        {
            byte[] bytes = new byte[1];
            bytes[0] = (byte)i;
            return Encoding.Default.GetString(bytes)[0];
        }

        /**
         * Convert Binary to Hex (bin2hex)
         *
         * @param string bindata Binary data
         * @access public
         * @return string
         */
        private string Bin2Hex(byte[] bindata)
        {
            int i;
            byte[] bytes = bindata;
            StringBuilder hexString = new StringBuilder();
            for (i = 0; i < bytes.Length; i++)
            {
                hexString.Append(bytes[i].ToString("x2"));
            }
            return hexString.ToString();
        }

        private string Hex2Bin(string hexdata)
        {
            byte[] bytes = new byte[hexdata.Length / 2];
            int counter = 0;
            string hexValue = null;
            for (int i = 0; i < hexdata.Length - 1; i += 2)
            {
                hexValue = hexdata.Substring(i, 2);
                bytes[counter++] = Convert.ToByte(hexValue, 16);
            }
            return Encoding.Default.GetString(bytes);
        }

        /**
         * The symmetric encryption function
         *
         * @param string pwd Key to encrypt with (can be binary of hex)
         * @param string data Content to be encrypted
         * @param bool ispwdHex Key passed is in hexadecimal or not
         * @access public
         * @return string
         */
        public string Encrypt(string data)
        {
            if (data == null)
                return String.Empty;

            int a, i, j, k, tmp, data_length;
            byte[] cipher;
            //string cipher;

            data_length = data.Length;
            cipher = new byte[data.Length];
            int[] tmpBox = new int[_box.Length];
            for (i = 0; i < _box.Length; i++)
            {
                tmpBox[i] = _box[i];
            }

            for (a = j = i = 0; i < data_length; i++)
            {
                a = (a + 1) % LENGTH;
                j = (j + tmpBox[a]) % LENGTH;
                tmp = tmpBox[a];
                tmpBox[a] = tmpBox[j];
                tmpBox[j] = tmp;
                k = tmpBox[((tmpBox[a] + tmpBox[j]) % LENGTH)];
                cipher[i] = (byte)(Ord(data[i]) ^ k);
                //cipher += chr(ord(data[i]) ^ k);
            }
            return Bin2Hex(cipher).ToUpper();
            //return cipher;
        }
        /**
         * Decryption, recall encryption
         *
         * @param string pwd Key to decrypt with (can be binary of hex)
         * @param string data Content to be decrypted
         * @param bool ispwdHex Key passed is in hexadecimal or not
         * @access public
         * @return string
         */
        public string Decrypt(string hex)
        {
            if (hex == null)
                return String.Empty;

            string data = Hex2Bin(hex);
            int a, i, j, k, tmp, data_length;
            byte[] cipher;

            data_length = data.Length;

            int[] tmpBox = new int[_box.Length];
            for (i = 0; i < _box.Length; i++)
            {
                tmpBox[i] = _box[i];
            }

            cipher = new byte[data_length];
            int counter = 0;
            for (a = j = i = 0; i < data_length; i++)
            {
                a = (a + 1) % LENGTH;
                j = (j + tmpBox[a]) % LENGTH;
                tmp = tmpBox[a];
                tmpBox[a] = tmpBox[j];
                tmpBox[j] = tmp;
                k = tmpBox[((tmpBox[a] + tmpBox[j]) % LENGTH)];
                cipher[counter++] = (byte)(Ord(data[i]) ^ k);
            }
            return Encoding.Default.GetString(cipher);
        }
    }
}
