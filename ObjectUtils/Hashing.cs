using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Extender.ObjectUtils;

public class Hashing
{
    /// <summary>
    /// Computes a hash value from a list of byte arrays (blocks) by transforming the blocks with MD5.
    /// </summary>
    public static byte[] GenerateHashCode(List<byte[]> blocks)
    {
        //List<byte[]> outputBuffer = blocks;

        MD5 md5 = new MD5CryptoServiceProvider();

        for (int i = 0; i < blocks.Count - 1; i++)
            md5.TransformBlock
            (
                blocks[i],
                0,
                blocks[i].Length,
                null,
                0
            );

        md5.TransformFinalBlock(blocks[blocks.Count - 1], 0, blocks[blocks.Count - 1].Length);

        return md5.Hash;
    }

    /// <summary>
    /// Computes a hash value from an array of byte arrays (blocks) by transforming the blocks with MD5.
    /// </summary>
    public static byte[] GenerateHashCode(byte[][] blocks)
    {
        //byte[][] outputBuffer = blocks;

        MD5 md5 = new MD5CryptoServiceProvider();

        for (int i = 0; i < blocks.Length - 1; i++)
            md5.TransformBlock
            (
                blocks[i],
                0,
                blocks[i].Length,
                null,
                0
            );

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

    /// <summary>
    /// Computes a hash value from an array of byte arrays (blocks) by transforming the blocks with SHA256.
    /// </summary>
    public static byte[] GenerateSHA256(byte[][] blocks)
    {
        var hashFunction = SHA256.Create
            ("System.Security.Cryptography.SHA256CryptoServiceProvider");

        for (int i = 0; i < blocks.Length - 1; i++)
            hashFunction.TransformBlock
            (
                blocks[i],
                0,
                blocks[i].Length,
                null,
                0
            );

        hashFunction.TransformFinalBlock
            (blocks[blocks.Length - 1], 0, blocks[blocks.Length - 1].Length);

        return hashFunction.Hash; //TODOh This function may not be working correctly. CHECK UP ON IT
    }

    /// <summary>
    /// Computes a hash value from an array of objects by first converting them into byte arrays, then transforming them with SHA256.
    /// Only use this if the objects array contains only primitives. Using other types might result in unexpected results. 
    /// </summary>
    /// <param name="properties">Array of objects to hash. Recommended to only use primitives.</param>
    public static byte[] GenerateSHA256(object[] properties)
    {
        byte[][] blocks = new byte[properties.Length][];

        for (int i = 0; i < properties.Length; i++)
            if (properties[i] is string)
            {
                blocks[i] = Encoding.Default.GetBytes((string) properties[i]);
            }
            else if (properties[i] is int)
            {
                blocks[i] = BitConverter.GetBytes((int) properties[i]);
            }
            else if (properties[i] is double)
            {
                blocks[i] = BitConverter.GetBytes((double) properties[i]);
            }
            else if (properties[i] is float)
            {
                blocks[i] = BitConverter.GetBytes((float) properties[i]);
            }
            else if (properties[i] is short)
            {
                blocks[i] = BitConverter.GetBytes((short) properties[i]);
            }
            else if (properties[i] is ushort)
            {
                blocks[i] = BitConverter.GetBytes((ushort) properties[i]);
            }
            else if (properties[i] is uint)
            {
                blocks[i] = BitConverter.GetBytes((uint) properties[i]);
            }
            else if (properties[i] is long)
            {
                blocks[i] = BitConverter.GetBytes((long) properties[i]);
            }
            else if (properties[i] is ulong)
            {
                blocks[i] = BitConverter.GetBytes((ulong) properties[i]);
            }
            else
            {
                blocks[i] = BitConverter.GetBytes(properties[i].GetHashCode());
                Debugging.Debug.WriteMessage
                (
                    string.Format
                    (
                        "Extender.ObjectUtils.GenerateSHA256 did not recognize type ({0}) of object '{1}'. Generic GetHashCode was called instead.",
                        properties[i].GetType().FullName,
                        properties[i]
                    )
                );
            }

        return GenerateSHA256(blocks);
    }
}