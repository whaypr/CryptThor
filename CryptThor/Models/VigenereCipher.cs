﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptThor.Models
{
    public static class VigenereCipher
    {
        /// <summary>
        /// Caesar, Vigenere and Vernam ciphers encryption function
        /// </summary>
        /// <param name="plainText">Text to encipher</param>
        /// <param name="key">Key used to perform the alphabet shift</param>
        /// <returns></returns>
        public static string Encrypt(string plainText, string key)
        {
            string cipherText = "";

            for (int i = 0; i < plainText.Length; i++)
            {
                char c = plainText[i];

                if (!((c >= 65 && c <= 90) || (c >= 97 && c <= 122))) //skips the character if non-alphabetical using ASCII table
                {
                    cipherText += c;
                    continue;
                }

                int j = key[i % key.Length] - 97; //calculates the shift
                char shift = (char)j;

                int newChar = c + shift; //shifts the character

                if (char.IsLower(c)) //case-sensitive encryption/decryption
                {
                    while (newChar > 'z')
                        newChar -= 26;
                    while (newChar < 'a')
                        newChar += 26;
                }
                else
                {
                    while (newChar > 'Z')
                        newChar -= 26;
                    while (newChar < 'A')
                        newChar += 26;
                }

                cipherText += (char)newChar; //adds encyphered char
            }

            return cipherText;
        }

        /// <summary>
        /// Caesar, Vigenere and Vernam ciphers decryption function
        /// </summary>
        /// <param name="plainText">Text to decipher</param>
        /// <param name="key">Key used to perform the alphabet shift</param>
        /// <returns></returns>
        public static string Decrypt(string cipherText, string key)
        {
            string newKey = "";
            key = key.ToLower();

            foreach (char c in key) //makes new inverse key 
            {
                int i = 'z' - (c - 'a') + 1;
                newKey += (char)i;
            }

            return Encrypt(cipherText, newKey);
        }
    }
}
