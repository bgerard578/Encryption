
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption
{
    public class EncryptionAlgor
    {
        public static string GenerateKey()
        {
            Random randy = new Random();
            int keyNum0 = randy.Next(0,1);
            int keyNum1 = randy.Next(2,7);
            int keyNum2 = randy.Next(3,7);
            int keyNum3 = randy.Next(1,7);
            int keyNum4 = randy.Next(1,9);
            int keyNum5 = randy.Next(1,9);
            int keyNum6 = randy.Next(1,9);
            int keyNum7 = randy.Next(1,9);
            string key = keyNum0.ToString() + keyNum1.ToString() + keyNum2.ToString() + keyNum3.ToString() + keyNum4.ToString() + keyNum5.ToString() + keyNum6.ToString() + keyNum7.ToString();
            return key;
        }
        public static string ToBinary(string code1)
        {
            string code2 = "";
            foreach (char c in code1)
            {
                int codeUnit = (int)c;
                string binaryString = Convert.ToString(codeUnit, 2).PadLeft(8, '0');
                code2 = code2 + binaryString;
            }
            return code2;
        }
        public static string FromBinary(string code1)
        {
            string code2 = "";
            List<string> bytes = new List<string>();
            int stringLength = code1.Length / 8;
            for (int i = 0; i < stringLength; i++)
            {
                string letter = "";
                letter = letter + code1[0];
                letter = letter + code1[1];
                letter = letter + code1[2];
                letter = letter + code1[3];
                letter = letter + code1[4];
                letter = letter + code1[5];
                letter = letter + code1[6];
                letter = letter + code1[7];
                code1 = code1.Remove(0,8);
                
                bytes.Add(letter);
            }
            foreach (string s in bytes)
            {
                int decimalValue = Convert.ToInt32(s, 2);
                char letter = (char)decimalValue;
                code2 = code2 + letter;
            }
            return code2;
        }
        public static int CalculateShift(string key)
        {
            int num1 = int.Parse(key[1].ToString());
            int num2 = int.Parse(key[2].ToString());
            int num3 = int.Parse(key[3].ToString());
            int shiftnum1 = int.Parse(key[num1].ToString());
            int shiftnum2 = int.Parse(key[num2].ToString());
            int shiftnum3 = int.Parse(key[num3].ToString());
            int shift = shiftnum1 * shiftnum2 + shiftnum3;
            return shift;
        }
        public static string Encrypt(string start, string key)
        {
            string end = "";
            int shift = CalculateShift(key);
            string binary1 = ToBinary(start);
            if (int.Parse(key[0].ToString()) == 0)
            {
                char[] charArray = binary1.ToCharArray();
                for (int i = 0; i < shift; i++)
                {
                    char c = charArray[0];
                    for (int j = 0; j < charArray.Length - 1; j++)
                    {
                        charArray[j] = charArray[j + 1];
                    }
                    charArray[charArray.Length - 1] = c;
                }
                end = new string(charArray);
                end = FromBinary(end);
            }
            else if (int.Parse(key[0].ToString()) == 1)
            {
                char[] charArray = binary1.ToCharArray();
                for (int i = 0; i < shift; i++)
                {
                    char c = charArray[charArray.Length - 1];
                    for (int j = charArray.Length - 1; j > 0; j--)
                    {
                        charArray[j] = charArray[j - 1];
                    }
                    charArray[0] = c;
                }
                end = new string(charArray);
                end = FromBinary(end);
            }
            return end;
        }
        public static string DeEncrypt(string start, string key)
        {
            string end = "";
            int shift = CalculateShift(key);
            string binary1 = ToBinary(start);
            if (int.Parse(key[0].ToString()) == 1)
            {
                char[] charArray = binary1.ToCharArray();
                for (int i = 0; i < shift; i++)
                {
                    char c = charArray[0];
                    for (int j = 0; j < charArray.Length - 1; j++)
                    {
                        charArray[j] = charArray[j + 1];
                    }
                    charArray[charArray.Length - 1] = c;
                }
                end = new string(charArray);
                end = FromBinary(end);
            }
            else if (int.Parse(key[0].ToString()) == 0)
            {
                char[] charArray = binary1.ToCharArray();
                for (int i = 0; i < shift; i++)
                {
                    char c = charArray[charArray.Length - 1];
                    for (int j = charArray.Length - 1; j > 0; j--)
                    {
                        charArray[j] = charArray[j - 1];
                    }
                    charArray[0] = c;
                }
                end = new string(charArray);
                end = FromBinary(end);
            }
            return end;
        }
    }
}
