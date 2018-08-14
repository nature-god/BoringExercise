using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Security.Cryptography;
using Newtonsoft.Json;
using ItemClassDesign;

namespace StorageClass
{
    public static class Storage
    {
        public static bool IsFileExists(string fileName)
        {
            return File.Exists(fileName);
        }

        public static bool IsDirectoryExists(string fileName)
        {
            return Directory.Exists(fileName);
        }

        public static void CreateFile(string fileName,string content)
        {
            StreamWriter streamWriter = File.CreateText(fileName);
            streamWriter.Write(content);
            streamWriter.Close();
        }

        public static void CreateDirectory(string fileName)
        {
            if(IsDirectoryExists(fileName))
            {
                return;
            }
            Directory.CreateDirectory(fileName);
        }

        public static void SetData(string fileName,Object pObject,GameSerializationBinder binder)
        {
            string toSave = SerializeObject(pObject,binder);
            toSave = RijndaelEncrypt(toSave,"RecommendedGraduateStudentAAAAAA");
            StreamWriter streamWriter = File.CreateText(fileName);
            streamWriter.Write(toSave);
            streamWriter.Close();
        }

        public static Object GetData(string fileName,Type pType,GameSerializationBinder binder)
        {
            StreamReader streamReader = File.OpenText(fileName);
            string data = streamReader.ReadToEnd();
            data = RijndaelDecrypt(data,"RecommendedGraduateStudentAAAAAA");
            //Console.WriteLine("Decrypt Data:\n"+data);
            streamReader.Close();
            return DeserializeObject(data,pType,binder);
        }


        //Serialize Object
        private static string SerializeObject(Object pObject,GameSerializationBinder binder)
        {
            string SerializedString = string.Empty;
            SerializedString = JsonConvert.SerializeObject(pObject,Formatting.Indented,new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Binder = binder
            });
            return SerializedString;
        }

        private static object DeserializeObject(string pString,Type pType,GameSerializationBinder binder)
        {
            Object deserializeObject = null;

            deserializeObject = JsonConvert.DeserializeObject(pString,pType,new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Binder = binder
            });
            return deserializeObject;
        }
        private static string RijndaelEncrypt(string pString,string pKey)
        {
            //key
            byte[] keyArray = UTF8Encoding.UTF8.GetBytes(pKey);
            //The message need to encrypt
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(pString);
            //Rijindael encrypt
            RijndaelManaged rDel = new RijndaelManaged();
            rDel.Key = keyArray;
            rDel.Mode = CipherMode.ECB;
            rDel.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = rDel.CreateEncryptor();

            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray,0,toEncryptArray.Length);
            return Convert.ToBase64String(resultArray,0,resultArray.Length);
        }
        private static String RijndaelDecrypt(string pString,string pKey)
        {
            byte[] keyArray = UTF8Encoding.UTF8.GetBytes(pKey);
            byte[] toEncryptArray = Convert.FromBase64String(pString);
            RijndaelManaged rDel = new RijndaelManaged();
            rDel.Key = keyArray;
            rDel.Mode = CipherMode.ECB;
            rDel.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = rDel.CreateDecryptor();

            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray,0,toEncryptArray.Length);
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
    }
}