using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TC_Kimlik_Dogrulama
{
    public class TcValidator
    {
        public static bool IsValidTCKimlikNo(string tcKimlikNo)
        {
            
            if (tcKimlikNo.Length != 11) return false;

            if (!long.TryParse(tcKimlikNo,out _)) return false;

            if (tcKimlikNo[0] == '0') return false;

            int sumOdd = 0; 
            int sumEven = 0;
            int totalSum = 0; 

            for(int i = 0; i <10; i++)
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


        public static Gender GenderControl(string tcKimlikNo)
        {
            if (tcKimlikNo.Length != 11) return Gender.Bad_Code;

            if (!long.TryParse(tcKimlikNo, out _)) return Gender.Bad_Code;

            if (tcKimlikNo[0] == '0') return Gender.Bad_Code;

            int digit = tcKimlikNo[9] - '0';

            var value = digit >= 5 && digit <= 9 ? Gender.Erkek : Gender.Kadın;

            return value;
        }



    }
}
