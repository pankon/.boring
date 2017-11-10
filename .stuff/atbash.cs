/*
 *  atbash.cs
 *  Take byte[] data and turn it into cipher, and back
 *  (given some sort of key)
 */

using System;

namespace boring
{
    public class AtBash : ICipher
    {
        public ICipher Make()
        {
            return new AtBash();
        }
    
        public byte[] encrypt(byte[] plaintext, byte[] key)
        {
            byte[] ciphertext = new byte[plaintext.Length];

            for (int i = 0; plaintext.Length > i; ++i)
            {
                ciphertext[i] = (byte)(~(plaintext[i] + key[0]));
            }
            
            return ciphertext;
        }
        
        public byte[] decrypt(byte[] ciphertext, byte[] key)
        {
            byte[] plaintext = new byte[ciphertext.Length];

            for (int i = 0; ciphertext.Length > i; ++i)
            {
                plaintext[i] = (byte)((~ciphertext[i]) - key[0]);
            }
            
            return plaintext;
        }
    }
}
