
public class FileDataDecryptor
{

    private IDecryptionStrategy _decryptionStrategy;

    public FileDataDecryptor(IDecryptionStrategy decryptionStrategy)
    {
        this._decryptionStrategy = decryptionStrategy;
    }

    public string DecryptContent(string encryptedContent)
    {
        return this._decryptionStrategy.Decrypt(encryptedContent);
    }

}