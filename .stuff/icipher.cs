/*
 *  icipher.cs
 *  Take byte[] data and turn it into cipher, and back
 *  (given some sort of key)
 */

using System;
using System.Collections.Generic;
using System.Reflection;

namespace boring
{
    public interface ICipher
    {
        byte[] encrypt(byte[] plaintext, byte[] key);
        byte[] decrypt(byte[] ciphertext, byte[] key);
        
        ICipher Make();
        
        // some guessing interface?
    } 
    
    public class CipherFactory
    {
        static private Dictionary<string, ICipher>dict = new Dictionary<string, ICipher>();
        
        static CipherFactory()
        {
            dict.Add("RailFence", (new RailFence()));
        }
        
        private CipherFactory() {}
    
        public static ICipher Make(string classname)
        {
            
            ICipher ret = dict[classname].Make();
            
            return ret;
        }
    }   
}
