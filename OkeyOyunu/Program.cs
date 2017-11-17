using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkeyOyunu
{
    public class Program
    {
        /* Burada tas destesi olusturup karistirip okeyi buluyor ve taslari 15, 14,14,14 biciminde paylastiriyoruz*/
        public static void Main(string[] args)
        {
            string[] players = {"A","B","C","D"};
            Taslar tas1 = new Taslar();

            tas1.OkeyBul();

            tas1.Shuffle();
           
            for (int i = 0; i < 57; i++)
            {
                Console.Write("{0, -15}", (tas1).DealTas());

                if ((i + 1)% players.Length == 0)
                {

                    
                        Console.WriteLine();
                    
                       
                }
                
            }
            Console.ReadLine();
        }
    }

    /* Okey Tasi icin bir class olusturuyoruz. Icinde tas numarasi ve rengini construct ediyoruz.*/
    public class OkeyTasi
    {
       public int numara;
       public string renk;


        public OkeyTasi(int num, string rnk)
        {
            numara = num;
            renk = rnk;
        }

        /* Print ederken Tasin ismi ornegin mavi-8 seklinde olacaktir.*/
        public override string ToString()
        {
            return renk + "-" + numara;
        }
    }

    /* Tas destesi classi olusturuyoruz*/
    public class Taslar
    {
        public OkeyTasi[] taslar;
        private int currentTas;
        private int TAS_SAYISI = 106;
        private Random random;
        private OkeyTasi SAHTE_OKEY;
        private static OkeyTasi okey;

        /* Constructor da tas numaralari ve renklerini belirtiyoruz. Toplamda okey taslari 106 tanedir*/
        public Taslar()
        {
            int[] numaralar = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13};

            string[] renkler = {"sari", "mavi", "siyah", "kirmizi"};
            taslar = new OkeyTasi[TAS_SAYISI];
            SAHTE_OKEY = new OkeyTasi(0, "SAHTEOKEY");
            currentTas = 0;
            random = new Random();
            okey = new OkeyTasi(0, ""); /* Okeyi belirtiyoruz*/

            /* 106 tasin 104 unu sayilari ve renklerine gore ayirt edip sonradan 105 ve 106. taslari sahte okey olarak belirtiyoruz.*/
            for (int count = 0; count < (taslar.Length) - 2; count++)
            {

                taslar[count] = new OkeyTasi(numaralar[count%13], renkler[count/26]);

            }


            taslar[104] = SAHTE_OKEY;
            taslar[105] = SAHTE_OKEY;

        }

        /* Burada Fisherman-Yates Algoritmasi ile taslari kariyoruz.*/
        public void Shuffle()
        {
            currentTas = 0;


            for (int i = 0; i < taslar.Length; i++)
            {
                int ii = random.Next(TAS_SAYISI);
                OkeyTasi temp = taslar[i];
                taslar[i] = taslar[ii];
                taslar[ii] = temp;

            }


        }

        /* Burada gostergeyi taslar arasindan rastgele secip degerinin 1 fazlasini okey olarak seciyoruz*/
        public void OkeyBul()
        {
            OkeyTasi gosterge = new OkeyTasi(0, "");

            int i = random.Next(0, taslar.Length);
            gosterge = taslar[i - 1];
            okey = taslar[i];

            Console.Write("Gosterge: " + gosterge + " Okey: " + okey + "\n");

        }
        /* Burada Taslari siraliyoruz*/
        public OkeyTasi DealTas()
        {
            
            if (currentTas < taslar.Length)
            {

                return taslar[currentTas++];
                
            }
            else
            {
                return null;
            }

        }

       
    

        /*Taslari avantajlarina gore nasil dizmemiz gerektigi konusunda bazi sorunlar yasadim. Her deneyisimde  exception error ortaya cikti. Yapilisini ogrenmek isterim :) Saygilarimla...*/



}

    
}
