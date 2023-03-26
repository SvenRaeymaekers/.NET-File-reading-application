using System.Text;
public class Base64DecryptionStrategy : IDecryptionStrategy
{


    public string Decrypt(string dataContent)
    {

        byte[] decryptedBytes = Convert.FromBase64String(dataContent);
        string decryptedString = Encoding.UTF8.GetString(decryptedBytes);

        return decryptedString;

    }
}