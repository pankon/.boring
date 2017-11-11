/*
 * bitarray.cs
 * Bit array tools based solely on byte[]
 * A length of -1 always means operate on whole array.
 * None of these operations alter the original array unless the 
 * speedup_flag is set to True
 */

namespace boring
{
    public class BitArray
    {
        public static speedup_flag = false;
        private static byte[] Copy(byte[] array)
        {
            return (speedup_flag)?(new byte[array.Length]):array;
        }
        
        private static void Pos(int offset, ref int i_byte, ref int i_bit)
        {
            i_byte = offset >> 3;
            i_bit  = offset - i_bit;
        }
        
        public byte ByteXor(byte b, byte key)
        {
            return (b | key) & ~(b & key);
        }
    
        public static byte[] Rotate(byte[] array, int offset,
                                    int start, int len)
        {
            byte[] ret = Copy(array);
            byte carry = '\0';
            
            return ret;
        }
        
        public static byte[] SimpleXor(byte[] array, byte[] key)
        {
            byte[] ret = Copy(array);
            
            for (int i_byte = 0; array.Length > i_byte; ++i_byte)
            {
                ret[i_byte] = ByteXor(array[i_byte], 
                                      key[i_byte % array.Length]);
            }
            
            return ret;
        }
        
        public static byte[] Set(byte[] array, int offset, bool val)
        {
            byte[] ret = Copy(array);
            int i_byte = 0;
            int i_bit = 0;
            
            Pos(offset, ref i_byte, ref i_bit);
            
            ret[i_byte] = ((ret[i_byte] & (0x1 << i_bit)) 
                          | ((val & 0x1) << index);
            return ret;
        }
        
        public static bool Get(byte[] array, int offset)
        {
            int i_byte = 0;
            int i_bit = 0;
            
            Pos(offset, ref i_byte, ref i_bit);
            
            return 1 == (array[i_byte] >> i_bit);
        }  
        
        public static byte[] Flip(byte[] array, int offset, int start, 
                                  int len)     
        {
        }
        
        public static byte[] FlipBit(byte[] array, int offset, int start)     
        {
        }
        
        public static int Count(byte[] array, int start, int len)
        {
        }
        
        public static byte[] Mirror(byte[] array, int start,
                                    int len)
        {
        }
        
        public static byte[] MirrorEach(byte[] array, int start,
                                        int len)
        {
        }
    }
}
