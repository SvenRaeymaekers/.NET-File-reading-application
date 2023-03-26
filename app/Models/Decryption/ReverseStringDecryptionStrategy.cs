using System.Text;
public class ReverseStringDecryptionStrategy : IDecryptionStrategy
{


    public string Decrypt(string dataContent)
    {
       
        char[] charArray = dataContent.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);

    }
}