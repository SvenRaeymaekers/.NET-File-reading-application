using System.Text;
public class ReverseStringDecryptionStrategy : IDecryptionStrategy
{


    public string Decrypt(string dataContent)
    {
        //this decryption algorithm is a simple reversestring algorithm
        //for that reason the assumption is made that any file that is encrypted with such algorithm, whether it was a json, xml or txt file, results in a .txt file, since the content is reversed on character-level
        //e.g. A json file that is encrypted with this type of algorithm, does not return a 'valid' json file.
        //with this assumption, all files that are being decrypted with this algorithm can be read as .txt files.
        
        char[] charArray = dataContent.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);

    }
}