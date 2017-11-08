/*
 *  ciphers.cs
 *  Take byte[] data and turn it into cipher, and back
 *  (given some sort of key)
 */

using System;
using System.IO;
using System.Diagnostics;

namespace boring
{
    public class Cipher
    {
        static byte[] MakeKey(string[] args)
        {
            byte[] key = new byte[args.Length - 2];
            
            for (int i = 2; args.Length > i; ++i)
            {
                key[i - 2] = Convert.ToByte(args[i]);
            }
            
            return key;
        }
    
        static public void Main(string[] args)
        {
            if (3 > args.Length)
            {
                Console.WriteLine(@"Usage: ./{0}.exe filename output_file [cipher params]",
                                  Process.GetCurrentProcess().ProcessName);
                return;
            }
            
            byte[] key = MakeKey(args);
            byte[] data;
            
            using (FileStream fs = File.OpenRead(args[0]))
            {
                data = new byte[fs.Length];
                fs.Read(data, 0, (int)fs.Length);
                
                /*
                foreach (byte b in (new RailFence()).encrypt(data, key))
                {
                    Console.Write((char)b);
                }
                Console.WriteLine("");
                */
            }
            
            ICipher cipher = new RailFence();
            byte[] ciphertext = cipher.encrypt(data, key);
            
            using (FileStream fs = File.Create(args[1]))
            {
                fs.Write(ciphertext, 0, ciphertext.Length);
            }
            
            Utils.Spawn("ghex " + args[0] + "&>/dev/null", true);
            Utils.Spawn("ghex " + args[1] + "&>/dev/null", true);
        }
    }
}
