using CallConseole.Service;
using System;

namespace CallConseole
{
    class Program
    {
        static void Main(string[] args)
        {
            int mNumber, station;
            Console.WriteLine("Call");

            while (true)
            {
                Console.Write("Masa Numarası: ");
                mNumber = Convert.ToInt32(Console.ReadLine());

                Console.Write("1- Boş / 2- İptal / 3- Servis / 4- Hesap" +
                    "\nDurum: ");
                station = Convert.ToInt32(Console.ReadLine());
               
                StationChange(mNumber, station);
            }
        }

        private static async void StationChange(int mNumber, int station)
        {
            var response = await ApiService.StationChanged(mNumber, station);
            Console.WriteLine("Masa: " + mNumber + " Durum No: " + station);
        }
    }
}
