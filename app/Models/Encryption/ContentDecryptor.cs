

public class ContentDecryptor
{


    private IDecryptionStrategy decryptionStrategy;

    public ContentDecryptor(IDecryptionStrategy decryptionStrategy)
    {
        this.decryptionStrategy = decryptionStrategy;
    }

    public string DecryptContent(string encryptedContent){
        return decryptionStrategy.Decrypt(encryptedContent);
    }

}