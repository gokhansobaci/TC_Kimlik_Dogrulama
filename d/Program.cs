using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace d
{
    public class Program
    {
        public static bool IsValidTCKimlikNo(string tcKimlikNo)
        {
            // TC Kimlik No 11 karakter uzunluğunda olmalıdır
            if (tcKimlikNo.Length != 11)
                return false;

            // TC Kimlik No yalnızca sayılardan oluşmalıdır
            if (!long.TryParse(tcKimlikNo, out _))
                return false;

            // İlk hane 0 olamaz
            if (tcKimlikNo[0] == '0')
                return false;

            // İlk 10 haneyi ve 11. haneyi kontrol et
            int sumOdd = 0; // 1, 3, 5, 7, 9. haneler
            int sumEven = 0; // 2, 4, 6, 8. haneler
            int totalSum = 0; // İlk 10 hane toplamı

            for (int i = 0; i < 10; i++)
            {
                int digit = tcKimlikNo[i] - '0';
                totalSum += digit;

                if (i % 2 == 0) // 0, 2, 4, 6, 8 indexleri (1, 3, 5, 7, 9. haneler)
                    sumOdd += digit;
                else if(i != 9)
                    sumEven += digit;
                else // 1, 3, 5, 7 indexleri (2, 4, 6, 8. haneler)
                    sumEven += 0 ;
            }

            

            int t1 = (sumOdd * 7 - (sumEven)) % 10;
            int t2 = totalSum % 10;

            if (t1 != tcKimlikNo[9] - '0' || t2 != tcKimlikNo[10] - '0')
                return false;

            return true;
        }


        public static bool IsValideTCKimlikNo(string tcKimlikNo)
        {
            if (tcKimlikNo.Length != 11) return false;

            if (!long.TryParse(tcKimlikNo, out _)) return false;

            if (tcKimlikNo[0] == '0') return false;

            int sumOdd = 0;
            int sumEven = 0;
            int totalSum = 0;

            for (int i = 0; i < 10; i++)
            {
                int digit = tcKimlikNo[i] - '0';
                totalSum += digit;

                if (i % 2 == 0) sumOdd += digit;
                else if (i != 9) sumEven += digit;
                else
                    sumEven += 0;
            }
            int t1 = (sumOdd * 7 - sumEven) % 10;
            int t2 = totalSum % 10;

            if (t1 != tcKimlikNo[9] - '0' || t2 != tcKimlikNo[10] - '0') return false;

            return true;
        }

        public enum Gender
        {
            Erkek,
            Kadın,
            Yanlıs_Durum,
        }

        public static Gender GenderControl(string tcKimlikNo)
        {
            if (tcKimlikNo.Length != 11) return Gender.Yanlıs_Durum;

            if (!long.TryParse(tcKimlikNo, out _)) return Gender.Yanlıs_Durum;

            if (tcKimlikNo[0] == '0') return Gender.Yanlıs_Durum;

            int digit = tcKimlikNo[9] - '0';

           var value =  digit >= 5 && digit <= 9 ? Gender.Erkek : Gender.Kadın;

            return value; 
        }




        public static void Main(string[] args)
        {
            var result2 = GenderControl("18608294806");
            var result = IsValideTCKimlikNo("18608294806");
            Console.WriteLine(result);
            Console.WriteLine(result2);
            Console.ReadLine();
        }
    }
}
