using System;

using System.IO;

using System.Security.Cryptography;

using System.Text;

namespace HeartbeatBusiness.BusinessObjects
{

public class EncryptDecrypt
{

    public EncryptDecrypt()
    {

        //

        // TODO: Add constructor logic here

        //

    }

    public static string Encrypt(string sTextToEncrypt)
    {

        string passPhrase;

        string iVal;

        string hashAlgorithm;

        int pwdIterations;

        string initVector;

        int ikeySize;

        passPhrase = "LetUsInNow!@!@!@!"; // can be any string

        iVal = "s@1tValue"; // can be any string

        hashAlgorithm = "SHA1"; // can be "MD5"

        pwdIterations = 27; // can be any number

        initVector = "heartbeat2014hot"; // MUST BE 16 BYTES.

        ikeySize = 256;

        //CONVERT STRINGS INTO BYTE ARRAYS.

        byte[] initVectorBytes;

        initVectorBytes = System.Text.Encoding.ASCII.GetBytes(initVector);

        byte[] iValBytes;

        iValBytes = System.Text.Encoding.ASCII.GetBytes(iVal);

        //CONVERT OUR PLAINTEXT INTO A BYTE ARRAY.

        byte[] plainTextBytes;

        plainTextBytes = System.Text.Encoding.UTF8.GetBytes(sTextToEncrypt);

        //CREATE A PASSWORD, FROM WHICH THE KEY WILL BE DERIVED.

        PasswordDeriveBytes password;

        password = new PasswordDeriveBytes(passPhrase, iValBytes, hashAlgorithm, pwdIterations);

        //USE THE PASSWORD TO GENERATE PSEUDO-RANDOM BYTES FOR THE ENCRYPTION

        //KEY. SPECIFY THE SIZE OF THE KEY IN BYTES (INSTEAD OF BITS).

        byte[] keyBytes;

        keyBytes = password.GetBytes(ikeySize / 8);

        //CREATE UNINITIALIZED RIJNDAEL ENCRYPTION OBJECT.

        RijndaelManaged symmetricKey;

        symmetricKey = new RijndaelManaged();

        //IT IS REASONABLE TO SET ENCRYPTION MODE TO CIPHER BLOCK CHAINING

        //(CBC). USE DEFAULT OPTIONS FOR OTHER SYMMETRIC KEY PARAMETERS.

        symmetricKey.Mode = CipherMode.CBC;

        //GENERATE ENCRYPTOR FROM THE EXISTING KEY BYTES AND INITIALIZATION 

        //VECTOR. KEY SIZE WILL BE DEFINED BASED ON THE NUMBER OF THE KEY 

        //BYTES.

        ICryptoTransform encryptor;

        encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);

        //DEFINE MEMORY STREAM WHICH WILL BE USED TO HOLD ENCRYPTED DATA.

        MemoryStream memoryStream;

        memoryStream = new MemoryStream();

        //DEFINE CRYPTOGRAPHIC STREAM (ALWAYS USE WRITE MODE FOR ENCRYPTION).

        CryptoStream cryptoStream;

        cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);

        //BEGIN ENCRYPTING.

        cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);

        //END ENCRYPTING.

        cryptoStream.FlushFinalBlock();

        //CONVERT OUR ENCRYPTED DATA FROM A MEMORY STREAM INTO A BYTE ARRAY.

        byte[] cipherTextBytes;

        cipherTextBytes = memoryStream.ToArray();

        //CLOSE STREAMS.

        memoryStream.Close();

        cryptoStream.Close();

        //CONVERT ENCRYPTED DATA INTO A BASE64-ENCODED STRING.

        string cipherText;

        cipherText = Convert.ToBase64String(cipherTextBytes);

        //RETURN ENCRYPTED STRING.

        return (cipherText);

    }//END ENCRYPT







    public static string Decrypt(string sTextToDecrypt)
    {

        string passPhrase;

        string iVal;

        string hashAlgorithm;

        int pwdIterations;

        string initVector;

        int ikeySize;

        passPhrase = "LetUsInNow!@!@!@!"; // can be any string

        iVal = "s@1tValue"; // can be any string

        hashAlgorithm = "SHA1"; // can be "MD5"

        pwdIterations = 27; // can be any number

        initVector = "heartbeat2014hot"; // MUST BE 16 BYTES.

        ikeySize = 256;

        //CONVERT STRINGS DEFINING ENCRYPTION KEY CHARACTERISTICS INTO BYTE ARRAYS. 

        byte[] initVectorBytes;

        initVectorBytes = System.Text.Encoding.ASCII.GetBytes(initVector);

        byte[] iValBytes;

        iValBytes = System.Text.Encoding.ASCII.GetBytes(iVal);

        //CONVERT OUR CIPHERTEXT INTO A BYTE ARRAY.

        byte[] cipherTextBytes;

        cipherTextBytes = Convert.FromBase64String(sTextToDecrypt);

        //CREATE A PASSWORD, FROM WHICH THE KEY WILL BE DERIVED.

        PasswordDeriveBytes password;

        password = new PasswordDeriveBytes(passPhrase, iValBytes, hashAlgorithm, pwdIterations);

        //USE THE PASSWORD TO GENERATE PSEUDO-RANDOM BYTES FOR THE ENCRYPTION

        //KEY. SPECIFY THE SIZE OF THE KEY IN BYTES (INSTEAD OF BITS).

        byte[] keyBytes;

        keyBytes = password.GetBytes(ikeySize / 8);

        //CREATE UNINITIALIZED RIJNDAEL ENCRYPTION OBJECT.

        RijndaelManaged symmetricKey;

        symmetricKey = new RijndaelManaged();

        //IT IS REASONABLE TO SET ENCRYPTION MODE TO CIPHER BLOCK CHAINING

        //(CBC). USE DEFAULT OPTIONS FOR OTHER SYMMETRIC KEY PARAMETERS.

        symmetricKey.Mode = CipherMode.CBC;

        //GENERATE DECRYPTOR FROM THE EXISTING KEY BYTES AND INITIALIZATION 

        //VECTOR. KEY SIZE WILL BE DEFINED BASED ON THE NUMBER OF THE KEY 

        //BYTES.

        ICryptoTransform decryptor;

        decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);

        //DEFINE MEMORY STREAM WHICH WILL BE USED TO HOLD ENCRYPTED DATA.

        MemoryStream memoryStream;

        memoryStream = new MemoryStream(cipherTextBytes);

        //DEFINE MEMORY STREAM WHICH WILL BE USED TO HOLD ENCRYPTED DATA.

        CryptoStream cryptoStream;

        cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);

        //SINCE AT THIS POINT WE DON'T KNOW WHAT THE SIZE OF DECRYPTED DATA

        //WILL BE, ALLOCATE THE BUFFER LONG ENOUGH TO HOLD CIPHERTEXT;

        //PLAINTEXT IS NEVER LONGER THAN CIPHERTEXT.

        //Dim plainTextBytes As Byte()

        //ReDim plainTextBytes(cipherTextBytes.Length)

        byte[] plainTextBytes;

        plainTextBytes = cipherTextBytes;

        //BEGIN DECRYPTING.

        int decryptedByteCount;

        decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);

        //CLOSE STREAMS.

        memoryStream.Close();

        cryptoStream.Close();

        //CONVERT DECRYPTED DATA INTO A STRING. 

        string plainText;

        plainText = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);

        //RETURN DECRYPTED STRING.

        return (plainText);

    }//END DECRYPT

}

}