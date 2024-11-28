using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kalkulator3p
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int liczba1 = 0;
            if (int.TryParse(liczba1_textbox.Text, out liczba1))
            {
                long wynik = silnia(liczba1);
                MessageBox.Show(wynik.ToString(), "Silnia");
            }
            else
            {
                MessageBox.Show("Należy wpisać liczbę");
            }
        }

        private int nwd2(int a, int b)
        {
            while (b != 0)
            {
                int reszta = a % b;
                a = b;
                b = reszta;
            }
            return a;
        }

        private int nwd1(int a, int b)
        {
            //dopoki liczby nie sa sobie równe odejmuj od większej mniejszą
            if (a == 0)
                return b;
            if (b == 0)
                return a;
            while (a != b)
            {
                if (a > b)
                {
                    a = a - b;
                }
                else
                {
                    b = b - a;
                }

            }
            return a;
        }

        private long silnia(int n)
        {
            long wynik = 1;
            for (int i = 1; i <= n; i++)
            {
                wynik = wynik * i;
            }

            return wynik;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int liczba1 = 0;
            int liczba2 = 0;
            if (int.TryParse(liczba1_textbox.Text, out liczba1)
                && int.TryParse(liczba2_textbox.Text, out liczba2))
            {
                MessageBox.Show(nwd2(liczba1, liczba2).ToString(),
                    "Największy wspólny dzielnik");
            }
            else
            {
                MessageBox.Show("Podaj liczby");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int n = 0;
            int k = 0;
            if (int.TryParse(liczba1_textbox.Text, out n)
                && int.TryParse(liczba2_textbox.Text, out k))
            {
                MessageBox.Show(potega(n,k).ToString(),"Potęga n do k");
            }
            else
            {
                MessageBox.Show("Podaj liczby");
            }
        }
        private int potega(int n,int k)
        {
            int wynik = 1;
            //k razy mnożymy przez n
            for(int i= 0; i < k; i++)
            {
                wynik = wynik * n;
            }
            return wynik;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            int liczba1 = 0;
            int liczba2 = 0;
            if (int.TryParse(liczba1_textbox.Text, out liczba1)
                && int.TryParse(liczba2_textbox.Text, out liczba2))
            {
                if (liczba1 > liczba2)
                {
                    //zamiana miejscami;
                }
                for(int i = liczba1; i <= liczba2; i++)
                {
                    if (czyPierwsza(i) == true)
                    {
                        MessageBox.Show(i.ToString(), "liczba pierwsza");
                    }
                }

                List<int> pierwsze = sitoEratostenesa(liczba2);
                MessageBox.Show(String.Join(" ",pierwsze));
            }
        }

        private bool czyPierwsza(int liczba)
        {
            //algorytm naiwny sprawdzania czy liczba jest liczbą pierwszą
            for(int i = 2; i < liczba; i++)
            {
                if(liczba%i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        private List<int> sitoEratostenesa(int liczba)
        {
           bool[] A = new bool[liczba+1 ];
            for(int i=0; i<A.Count(); i++)
            {
                A[i] = true; 
            }
            A[0] = false;
            A[1] = false;

            int pierwiastek =(int) Math.Sqrt(liczba);
            for(int i = 0; i <= pierwiastek; i++)
            {
                if (A[i] == true)
                {
                    for(int k = 2*i; k < liczba; k = k + i)
                    {
                        A[k] = false;
                    }
                }
            }
            List<int> pierwsze =new List<int>();
            for(int j = 0;j<A.Count(); j++)
            {
                if (A[j] == true)
                {
                    pierwsze.Add(j);
                }
            }
            return pierwsze;
        }





    }
}
