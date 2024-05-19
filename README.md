# TC Kimlik Doğrulama Script
C# programlama diliyle hazırlamış olduğum bu script, içindeki IsValidTCKimlikNo() metodu ile parametreye girilen tc kimlik numarasının doğrulunu kontrol eder.

Extra olarak tanımladığım Gender() fonksiyonu, parametreye girilen tc kimlik numarasının bir erkeğe mi veya bir kadın bireye mi ait olduğunu kontrol eder.

Projelerde bu gibi doğrulamaları kolaylıkla yapmanız için bu kodu kullanabilirsiniz.

Örnek Kullanım : IsValidTCKimlikNo("01234567891") => return true or false 

                 Gender("01234567891") => return Erkek or Bayan as Enum
