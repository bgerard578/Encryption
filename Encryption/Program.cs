namespace Encryption
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string key = EncryptionAlgor.GenerateKey();
            string original = "Brady";
            string encrypted;
            Console.WriteLine("original:");
            Console.WriteLine(original);
            Console.WriteLine("key:");
            Console.WriteLine(key);
            Console.WriteLine("ToBinary:");
            Console.WriteLine(EncryptionAlgor.ToBinary(original));
            Console.WriteLine("FromBinary:");
            Console.WriteLine(EncryptionAlgor.FromBinary(EncryptionAlgor.ToBinary(original)));
            Console.WriteLine("shift:");
            Console.WriteLine(EncryptionAlgor.CalculateShift(key));
            Console.WriteLine("Encrypted:");
            encrypted = EncryptionAlgor.Encrypt(original, key);
            Console.WriteLine(encrypted);
            Console.WriteLine("DeEncrypted:");
            Console.WriteLine(EncryptionAlgor.DeEncrypt(encrypted, key));
        }
    }
}