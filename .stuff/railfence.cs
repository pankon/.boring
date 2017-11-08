/*
 *  railfence.cs
 *  Take byte[] data and turn it into cipher, and back
 *  (given some sort of key)
 */

namespace boring
{
    public class RailFence : ICipher
    {
        public byte[] encrypt(byte[] plaintext, byte[] key)
        {
            if (1 != key.Length)
            {
                return plaintext;
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
            return ciphertext; // TODO
        }
    }    
}
