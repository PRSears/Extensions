using System;
using System.Collections.Generic;

namespace Extender.ObjectUtils
{
    public class Hashing
    {
        /// <summary>
        /// Computes a hash value from a list of byte arrays (blocks) by transforming the blocks with MD5.
        /// </summary>
        public static byte[] GenerateHashCode(List<byte[]> blocks)
        {
            List<byte[]> outputBuffer = blocks;

            System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();

            for(int i = 0; i < blocks.Count - 1; i++)
                md5.TransformBlock(blocks[i], 0, blocks[i].Length, outputBuffer[i], 0);

            md5.TransformFinalBlock(blocks[blocks.Count - 1], 0, blocks[blocks.Count - 1].Length);

            return md5.Hash;
        }

        /// <summary>
        /// Computes a hash value from an array of byte arrays (blocks) by transforming the blocks with MD5.
        /// </summary>
        public static byte[] GenerateHashCode(byte[][] blocks)
        {
            byte[][] outputBuffer = blocks;

            System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();

            for (int i = 0; i < blocks.Length - 1; i++)
                md5.TransformBlock(blocks[i], 0, blocks[i].Length, outputBuffer[i], 0);

            md5.TransformFinalBlock(blocks[blocks.Length - 1], 0, blocks[blocks.Length - 1].Length);

            return md5.Hash;
        }

        /// <summary>
        /// Creates a new Guid from the result of hashing the blocks passed in with MD5.
        /// </summary>
        public static Guid GenerateHashedGuid(List<byte[]> blocks)
        {
            return new Guid(GenerateHashCode(blocks));
        }
    }
}
