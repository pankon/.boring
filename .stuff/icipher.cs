/*
 *  icipher.cs
 *  Take byte[] data and turn it into cipher, and back
 *  (given some sort of key)
 */

namespace boring
{
    public interface ICipher
    {
        byte[] encrypt(byte[] plaintext, byte[] key);
        byte[] decrypt(byte[] ciphertext, byte[] key);
        
        // some guessing interface?
    }    
}
