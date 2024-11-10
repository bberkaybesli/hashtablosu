using System;

class Program
{
    // Hash tablosunun boyutunu 100 olarak belirliyoruz
    const int TabloBoyutu = 100;

    // Linear probing için kullanılan hash tablosu
    static int[] hashTablosuLinear = new int[TabloBoyutu];

    // Quadratic probing için kullanılan hash tablosu
    static int[] hashTablosuQuadratic = new int[TabloBoyutu];

    static void Main()
    {
        // Başlangıçta her iki tablonun elemanlarını -1 ile işaretliyoruz 
        for (int i = 0; i < TabloBoyutu; i++)
        {
            hashTablosuLinear[i] = -1;
            hashTablosuQuadratic[i] = -1;
        }

        Random rastgele = new Random();

        // 100 rastgele anahtar üretip her iki tabloya ekliyoruz
        for (int i = 0; i < 100; i++)
        {
            int anahtar = rastgele.Next(1, 1000); // 1 ile 1000 arasında rastgele anahtar oluşturuyoruz

            // Linear probing ile anahtarı hash tablosuna ekliyoruz
            AnahtarEkleLinear(anahtar);

            // Quadratic probing ile anahtarı hash tablosuna ekliyoruz
            AnahtarEkleQuadratic(anahtar);
        }

        // Linear probing hash tablosunu ekrana yazdırıyoruz
        Console.WriteLine("Linear Probing Hash Tablosu:");
        TabloyuYazdir(hashTablosuLinear);

        // Quadratic probing hash tablosunu ekrana yazdırıyoruz
        Console.WriteLine("\nQuadratic Probing Hash Tablosu:");
        TabloyuYazdir(hashTablosuQuadratic);
    }

    static int HashFonksiyonu(int anahtar)
    {
        // Anahtarın tablo boyutuna göre kalanını alıyoruz
        return anahtar % TabloBoyutu;
    }

    // Linear probing yöntemiyle anahtar ekliyoruz
    static void AnahtarEkleLinear(int anahtar)
    {
        int index = HashFonksiyonu(anahtar);

        // Çakışma varsa bir sonraki indekse geçiyoruz
        while (hashTablosuLinear[index] != -1)
        {
            index = (index + 1) % TabloBoyutu; 
        }

        // Boş bir yer bulduğumuzda anahtarı yerleştiriyoruz
        hashTablosuLinear[index] = anahtar;
    }

    // Quadratic probing yöntemiyle anahtar ekliyoruz
    static void AnahtarEkleQuadratic(int anahtar)
    {
        int index = HashFonksiyonu(anahtar);
        int i = 1; // Artış faktörü

        // Çakışma varsa karesel artış ile ilerliyoruz
        while (hashTablosuQuadratic[index] != -1)
        {
            index = (index + i * i) % TabloBoyutu;
            i++; // Artış faktörünü artırıyoruz
            if (i > TabloBoyutu) break; // Çakışmalar devam ederse kontrol ediyoruz
        }

        // Boş yer bulduğumuzda anahtarı yerleştiriyoruz
        hashTablosuQuadratic[index] = anahtar;
    }

    // Hash tablosunu yazdıran metot
    static void TabloyuYazdir(int[] hashTablosu)
    {
        for (int i = 0; i < TabloBoyutu; i++)
        {
            Console.WriteLine($"Index {i}: {hashTablosu[i]}");
        }
    }
}
