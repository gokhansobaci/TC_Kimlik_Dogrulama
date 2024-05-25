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
        public static TCIdentity ValidateIdentity(string TCId)
        {
            if (!ValidateString(TCId) || !IsCorrectIdentity(TCId))
            {
                throw new Exception("Incorrect Identity number.");
            }

            var obj = new TCIdentity
            {
                IsValid = true,
                Gender = GenderControl(TCId)
            };

            return obj;
        }
        private static bool IsCorrectIdentity(string tcID)
        {
            int sumOdd = 0; 
            int sumEven = 0;
            int totalSum = 0; 

            for(int i = 0; i <10; i++)
            {
                int digit = tcID[i] - '0';
                totalSum += digit;

                if (i % 2 == 0) sumOdd += digit;
                else if (i != 9) sumEven += digit;
                else
                    sumEven += 0; 
            }
            int t1 = (sumOdd * 7 - sumEven) % 10; 
            int t2 = totalSum % 10;

            if (t1 != tcID[9] - '0' || t2 != tcID[10] - '0') return false; 
            return true;
        }
        private static bool ValidateString(string tcID)
        {
            if (tcID.Length != 11) return false;

            if (!long.TryParse(tcID, out _)) return false;

            if (tcID[0] == '0') return false;

            return true;
        }

        public static EGender GenderControl(string tcKimlikNo)
        {
            int digit = tcKimlikNo[9] - '0';

            return digit >= 5 && digit <= 9 ? EGender.Erkek : EGender.Kadın;
        }
    }
}
