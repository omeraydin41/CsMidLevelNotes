using System;

namespace IsVsAsKonsol
{
    // Temel Sınıf
    class Calisan
    {
        public string Ad { get; set; } = "Bilinmiyor";
    }

    // Türetilmiş Sınıf (Calisan sınıfından miras alır)
    class Yazilimci : Calisan
    {
        public void KodYaz()
        {
            Console.WriteLine($"{Ad} yeni bir özellik geliştirdi ve kod yazıyor.");
        }
    }

    // Tamamen bağımsız/ilişkisiz başka bir sınıf
    class Araba
    {
        public string Model { get; set; } = "Sedan";
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========================================");
            Console.WriteLine("        'is' ve 'as' KULLANIMI         ");
            Console.WriteLine("========================================\n");

            // Test için genel tipli bir nesne tanımlıyoruz
            Calisan calisan1 = new Yazilimci { Ad = "Ahmet" };
            object nesne = "Merhaba, ben bir metin verisiyim";


            // ==========================================
            // 1. 'is' OPERATÖRÜ (TÜR KONTROLÜ)
            // ==========================================
            Console.WriteLine("--- 1. 'is' Operatörü (Sadece Kontrol) ---");

            // 'is', nesnenin o kalıba uyup uymadığını kontrol eder.
            // Sonuç sadece true veya false döner.
            bool yazilimciMi = calisan1 is Yazilimci;
            Console.WriteLine($"calisan1 bir Yazilimci mı? -> {yazilimciMi}");

            // Değer tiplerinde de kontrol yapabilir
            int sayi = 100;
            if (sayi is int)
            {
                Console.WriteLine("sayi değişkeni int türündedir.");
            }

            // Modern C# 'is pattern matching' kullanımı:
            // Kontrol eder ve başarılıysa aynı anda yeni bir değişkene aktarır
            if (calisan1 is Yazilimci aktifYazilimci)
            {
                Console.WriteLine("Pattern Matching başarılı:");
                aktifYazilimci.KodYaz();
            }


            // ==========================================
            // 2. 'as' OPERATÖRÜ (GÜVENLİ TÜR DÖNÜŞÜMÜ)
            // ==========================================
            Console.WriteLine("\n--- 2. 'as' Operatörü (Dönüştürme Denemesi) ---");

            // Başarılı Dönüşüm Örneği:
            // Dönüşüm başarılı olursa hedef türdeki nesneyi döner.
            Yazilimci donusenYazilimci = calisan1 as Yazilimci;

            if (donusenYazilimci != null)
            {
                Console.WriteLine("Dönüşüm başarılı!");
                donusenYazilimci.KodYaz();
            }
            else
            {
                Console.WriteLine("Dönüşüm başarısız.");
            }

            // Başarısız Dönüşüm Örneği:
            // Bir string nesnesini 'Araba' türüne çevirmeyi deniyoruz.
            // Sistem hata (exception) vermez, sadece 'null' döner.
            Araba basarisizDonusum = nesne as Araba;

            if (basarisizDonusum == null)
            {
                Console.WriteLine("String verisi 'Araba' tipine dönüştürülemedi (Sonuç: null döndü).");
            }

            Console.WriteLine("\nProgram bitti. Çıkmak için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}
//IS OPERATORU 
/*
 is operatörü, bir nesnenin çalışma zamanında belirli bir türe (sınıfa, arayüze veya veri tipine) ait olup olmadığını ya da o türe dönüştürülüp dönüştürülemeyeceğini test eden bir soru sorma (kontrol) aracıdır.

Mantığı tamamen şudur: "Elimdeki bu veri, şu kalıba uyuyor mu?"

Bu kontrolün sonucunda sistem size sadece iki cevaptan birini verir:

Evet (true): Nesne o türdendir veya o türden türetilmiştir.

Hayır (false): Nesne o türle ilişkisizdir veya içi boştur (null).

Gerçek Hayattan Bir Benzetme

Elinizde kapalı bir koli olduğunu ve içinde ne olduğunu tam bilmediğinizi düşünün:

is operatörü koliye dışarıdan bir dedektörle bakıp "Bu kolideki şey bir kitap mı?" diye sormak gibidir.

Koli gerçekten bir kitapsa dedektör yeşil ışık yakar (true), oyuncak veya boşsa kırmızı ışık yakar (false).

Kolinin içindekini zorla çıkarıp masaya koymaz; sadece durumunu doğrular, dolayısıyla hiçbir zaman kırılma ya da patlama (hata/exception) riski oluşturmaz.

Kısacası is, program akışında bir işlem yapmadan önce "Güvende miyim, doğru veriyle mi çalışıyorum?" kontrolü yapmak için kullanılan bir güvenlik filtresidir.
 */




//AS OPERATORU
/*
 as operatörü, bir nesneyi başka bir türe dönüştürmeye çalışan kibar (güvenli) bir dönüştürme aracıdır.

Geleneksel dönüştürme (cast) işlemlerinden en büyük farkı, işlem başarısız olduğunda programı çökertecek bir hata (exception) fırlatmak yerine sessizce null (boş/geçersiz) değeri döndürmesidir.

Mantığı tamamen şudur: "Elimdeki bu nesneyi şu türe dönüştürmeyi dene; olursa nesneyi bana ver, olmazsa bana boş (null) dön."

Gerçek Hayattan Bir Benzetme

Yine kapalı bir koli örneğinden gidelim:

Geleneksel dönüştürme (Casting), koliyi açıp içindekini masaya fırlatmak gibidir. Eğer içindeki şey kırılgan ya da beklediğiniz şey değilse sistem patlar (hata verir).

as operatörü ise koliyi kibarca açmayı dener:

İçindeki şey gerçekten istediğiniz nesneyse (örneğin kitap), onu elinize verir.

Eğer içindeki şey bambaşka bir nesneyse veya koli tamamen boşsa, zorlamaz; elinize hiçbir şey vermez, avucunuz boş kalır (null).

Dikkat Edilmesi Gereken Kural

as operatörü başarısız olduğunda null dönebilmek zorundadır. Bu yüzden yalnızca referans tipleri (sınıflar, arayüzler, diziler) ve nullable (int?, double? gibi) türler ile çalışır; doğrudan int, bool, struct gibi standart değer tipleriyle kullanılamaz.*/