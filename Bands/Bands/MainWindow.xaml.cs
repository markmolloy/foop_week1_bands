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

namespace Bands
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Band[] bands = new Band[6];
        Band[] filtered = new Band[6];
        public MainWindow()
        {
            InitializeComponent();

            
        }

        private void lbBandList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //get selected item
            Band selected = lbBandList.SelectedItem as Band;
            //reset info display bits
            tbDetails.Text = "";
            lbAlbums.ItemsSource = "";

            if (selected != null)
            {
                tbDetails.Text = Details(selected);
                lbAlbums.ItemsSource = selected.Albums;
            }

        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lbBandList.ItemsSource = "";
            string filter = comboBox.SelectedValue.ToString();
            Filter(filter);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //create bands
            bands = CreateBands();
            //sort bands
            Array.Sort(bands);
            //put into list box
            lbBandList.ItemsSource = bands;
            string[] genres = { "All", "Rock", "Pop", "Indie" };
            comboBox.ItemsSource = genres;
            comboBox.SelectedIndex = 0;
        }

        public void Filter(string genre)
        {
            if (genre == "All")
            {
                //if all genres selected
                lbBandList.ItemsSource = bands;
            }
            else
            {
                //if specific genre selected
                int counter = 0;
                for (int i = 0; i < bands.Length; i++)
                {
                    string type = bands[i].GetType().Name;
                    if (type.Equals(genre))
                    {
                        filtered[counter] = bands[i];
                        counter++;
                    }
                }
                lbBandList.ItemsSource = filtered;
            }
        }
            

        public Album[] Albumise(string al1, string al2, Random rnd)
        {
            //add two albums to band with sales and release year for each
            Album[] albums = new Album[2];
            for (int i = 0; i < albums.Length; i++)
            {
                //basic
                //Album a = new Album() { Name = (i == 0) ? al1 : al2, Year = 1900 + rnd.Next(50, 107), Sales = rnd.Next(1, 7) };
                
                //with datetime released date
                Album a = new Album() { Name = (i == 0) ? al1 : al2, Relased = GetRandomDate(rnd), Sales = rnd.Next(1, 7) };
                albums[i] = a;
            }

            return albums;            
        }
        public DateTime GetRandomDate(Random randomFactory)
        {
            DateTime startDate = DateTime.Now.AddYears(-70);
            DateTime endDate = DateTime.Now;
            TimeSpan timeSpan = endDate - startDate;
            TimeSpan newSpan = new TimeSpan(0, randomFactory.Next(0, (int)timeSpan.TotalMinutes), 0);
            DateTime newDate = startDate + newSpan;
            return newDate;

        }

        public Band[] CreateBands()
        {
            Band[] bands = new Band[6];
            //band members
            string[] m0 = { "Tom", "Dick", "Harry" }, m1 = { "Michelle", "Sam" }, m2 = { "Janey" }, m3 = { "Rob", "Bundee", "Fred" }, m4 = { "Rick", "Courtney" }, m5 = { "Rebecca", "Jill", "Gemma", "Ella" };
            //bands
            Random rnd = new Random();
            Rock b0 = new Rock() { Name = "REM", Year = 1990, Members = m0, Albums = Albumise("White Album", " Back in Black", rnd) };
            Rock b1 = new Rock() { Name = "ACDC", Year = 1984, Members = m1, Albums = Albumise("Born To Run", "The Man Who Sold the World", rnd) };
            Pop b2 = new Pop() { Name = "OneD", Year = 2010, Members = m2, Albums = Albumise("Saturday Night Fever", "Too Dark Park", rnd) };
            Pop b3 = new Pop() { Name = "TwoD", Year = 2013, Members = m3, Albums = Albumise("Slippery When Wet", "Parklife", rnd) };
            Indie b4 = new Indie() { Name = "Indo", Year = 2000, Members = m4, Albums = Albumise("Appetite For Destruction", "The Shape of Jazz to Come", rnd) };
            Indie b5 = new Indie() { Name = "Foop", Year = 1999, Members = m5, Albums = Albumise("Strangeways, Here We Come", "The Chronic", rnd) };
            //put into array
            bands[0] = b0;
            bands[1] = b1;
            bands[2] = b2;
            bands[3] = b3;
            bands[4] = b4;
            bands[5] = b5;

            return bands;
        }

        private string Details(Band b)
        {
            //output message for details box
            string output = string.Format("Year formed: {0}\nMembers: ", b.Year);
            for (int i = 0; i < b.Members.Length; i++)
            {
                output += string.Format("{0}, ", b.Members[i]);
            }
            output = output.Remove(output.Length - 2);//remove last comma
            return output;
        }

        private void tbDetails_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //write data about selected band to file
            Band b = lbBandList.SelectedItem as Band;
            if (b != null)
            {
                b.WriteToFile();
            }
        }
    }
}
