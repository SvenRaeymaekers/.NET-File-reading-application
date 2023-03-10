
public class ReverseStringStrategy : IDecryptionStrategy
{


    public string Decrypt(string encryptedData)
    {

        char[] charArray = encryptedData.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);

    }
}