/*
 *  icipher.cs
 *  Take byte[] data and turn it into cipher, and back
 *  (given some sort of key)
 */

using System;
using System.Reflection;

namespace boring
{
    public interface ICipher
    {
        byte[] encrypt(byte[] plaintext, byte[] key);
        byte[] decrypt(byte[] ciphertext, byte[] key);
        
        // some guessing interface?
    } 
    
    public class CipherFactory
    {
        private CipherFactory() {}
        private static Assembly asm = (new CipherFactory()).GetType().Assembly;
    
        public static ICipher Make(string classname)
        {
            
            //Type t = asm.GetType(classname);
            ICipher ret = null;
            //Activator.CreateInstance(classname);//ct) as ICipher;
            
            if (null == ret)
            {
                return new RailFence();//throw new Exception("No cipher created: " + classname);
            }

            return ret;
        }
    }   
}
