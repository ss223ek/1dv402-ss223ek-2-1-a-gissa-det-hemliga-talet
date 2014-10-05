using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L1A
{
    class SecretNumber
    {
        private int _count;
        private int _number;
        public const int MaxNumberOfGuesses = 7;




        public void Initialize()
        {
            Random randomTool = new Random();       //Skapar ett slumpobjekt
            _number = randomTool.Next(0, 100);       //Anropar metod som slumpat from 0 tom 100
            _count = 0;                             //nollställer räknare för fältet
        }

        public bool MakeGuess(int number)
        {
            _count++;
            if(_count>7)                            //fler än 7 gissningar inte tillåtet (sid 7)
            {
                throw new ApplicationException();
            }

            if(0>number||100<number)
            {
            throw new ArgumentOutOfRangeException();    //anropad med fel värden
            }

            // för högt, för lågt eller rätt
            if(number>_number)
            {
                Console.WriteLine("{0} är för högt. Du har {1} gissningar kvar.)",number,(MaxNumberOfGuesses-_count));
            }

            else if (number < _number)
            {
                Console.WriteLine("{0} är för lågt. Du har {1} gissningar kvar.)", number, (MaxNumberOfGuesses - _count));
            }

            else 
            {
                Console.WriteLine("RÄTT GISSAT! Du klarade det på {0} försök.)", _count);
                Initialize();
                return true;
            }

            // i detta läge vet vi att gissningen är fel, nu kollar vi om det finns gissningar kvar
            if(7<=_count)
            {
                Console.WriteLine("Det hemliga talet är {0}.",_number);
            }
        return false;
        }

        public SecretNumber()
        {
            Initialize();           //borde väl räcka? jag vet ju att värden är rätt då.
        }
    }
}
