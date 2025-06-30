public class RSA
{
    public BigInteger p, q, n, phi, e, d;

    public RSA()
    {
        GenerateKeys();
    }

    private void GenerateKeys()
    {
        // Генерация простых чисел
        p = GeneratePrime();
        q = GeneratePrime();
        
        n = p * q;
        phi = (p - 1) * (q - 1);
        
        // Выбор открытой экспоненты
        e = 65537;
        
        // Вычисление закрытой экспоненты
        d = BigInteger.ModPow(e, -1, phi);
    }

    private BigInteger GeneratePrime()
    {
        BigInteger prime;
        do
        {
            prime = BigInteger.Parse(GenerateRandomString(1024));
        } while (!IsPrime(prime));
        return prime;
    }

    private bool IsPrime(BigInteger number)
    {
        // Простая проверка на простоту
        if (number < 2) return false;
        for (BigInteger i = 2; i * i <= number; i++)
        {
            if (number % i == 0) return false;
        }
        return true;
    }

    public BigInteger Encrypt(BigInteger message)
    {
        return BigInteger.ModPow(message, e, n);
    }

    public BigInteger Decrypt(BigInteger cipher)
    {
        return BigInteger.ModPow(cipher, d, n);
    }
}
