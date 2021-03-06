/*
 *  railfence.cs
 *  Take byte[] data and turn it into cipher, and back
 *  (given some sort of key)
 */

using System;

namespace boring
{
    public class RailFence : ICipher
    {
        public ICipher Make()
        {
            return new RailFence();
        }
    
        public byte[] encrypt(byte[] plaintext, byte[] key)
        {
            if (1 != key.Length)
            {
                throw new Exception("key not of form { len }");
            }
            
            int columns = (key[0] > 0)?key[0]:1; // Could be backwards also..
            
            int rows = plaintext.Length / columns;
            byte[] ciphertext = new byte[rows * columns];
            
            int i_byte = 0;
            for (int i_col = 0; columns > i_col; ++i_col)
            {
                for (int i_row = 0; rows > i_row; ++i_row)
                {
                    ciphertext[i_col + i_row * columns] = plaintext[i_byte];
                    ++i_byte;
                }
            } 
            
            return ciphertext;
        }
        
        public byte[] decrypt(byte[] ciphertext, byte[] key)
        {
            if (1 != key.Length)
            {
                throw new Exception("key not of form { len }");
            }
            
            int columns = (key[0] > 0)?key[0]:1; // Could be backwards also..
            
            int rows = ciphertext.Length / columns;
            byte[] plaintext = new byte[rows * columns];
            
            int i_byte = 0;
            for (int i_col = 0; columns > i_col; ++i_col)
            {
                for (int i_row = 0; rows > i_row; ++i_row)
                {
                    plaintext[i_byte] = ciphertext[i_col + i_row * columns];
                    ++i_byte;
                }
            } 
            
            return plaintext;
        }
    }    
}
