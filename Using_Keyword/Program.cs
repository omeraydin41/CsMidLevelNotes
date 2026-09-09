// 1. Standart Using: Belirtilen namespace içindeki tüm sınıfları doğrudan kullanılabilir yapar.
using System;

// 2. Belirli kütüphanelerin isim alanlarını dahil etme:
using System.Collections.Generic; // List, Dictionary gibi dinamik koleksiyonlar için
using System.IO;                  // Dosya okuma/yazma (File, Directory vb.) işlemleri için

// 3. Static Using: Bir sınıfın statik metodlarını sınıf adını dahi yazmadan çağırmayı sağlar.
using static System.Math; // Artık Math.Sqrt() yerine doğrudan Sqrt() yazılabilir.

// 4. Using Alias: Çakışan sınıf isimlerini ayırt etmek veya kısaltma tanımlamak için takma ad verir.
using ProjeListesi = System.Collections.Generic.List<string>;

namespace ConsoleUsingOrnegi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 'using System;' sayesinde 'System.Console.WriteLine' yerine doğrudan 'Console.WriteLine' yazıyoruz.
            Console.WriteLine("--- Using Yönergesi Kullanımı ---");

            // 'using System.Collections.Generic;' sayesinde doğrudan 'List' tipine eriştik.
            // Ayrıca yukarıda 'ProjeListesi' adıyla alias (takma ad) oluşturduğumuz için onu da kullanabiliriz:
            ProjeListesi ogrenciler = new ProjeListesi();
            ogrenciler.Add("Ahmet");
            ogrenciler.Add("Ayşe");

            foreach (var ogrenci in ogrenciler)
            {
                Console.WriteLine($"Öğrenci: {ogrenci}");
            }

            // 'using static System.Math;' sayesinde 'Math.Pow' veya 'Math.Sqrt' yazmadan doğrudan çağırdık:
            double karekok = Sqrt(64); // Normalde: Math.Sqrt(64)
            Console.WriteLine($"64'ün Karekökü: {karekok}");

            // 'using System.IO;' sayesinde 'System.IO.Path' yerine sadece 'Path' kullanabiliyoruz:
            string dosyaYolu = Path.Combine("C:", "Projeler", "test.txt");
            Console.WriteLine($"Oluşturulan Yol: {dosyaYolu}");

            Console.ReadLine();
        }
    }
}