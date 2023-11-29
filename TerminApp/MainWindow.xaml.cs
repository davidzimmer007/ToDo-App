using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace TerminApp
{
    
    public partial class MainWindow : Window
    {
        public TerminKalender Model { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            List<Termin> termine = new List<Termin>();
            
            Model = new TerminKalender(termine);
            DataContext = Model ;
            MeineListBox.ItemsSource = Model.Termine;
            

        }

        // Adden ueber enter
        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                CreateTermin();
       
            }
        }
        // Adden ueber check button
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CreateTermin();
        }

        // Remove wenn Termin gechecked wird
        public void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            if (checkBox.IsChecked == true)
            {
                
                Termin selectedTermin = (Termin)checkBox.DataContext;
                if (selectedTermin != null)
                {
                    Model.RemoveTermin(selectedTermin);
                    MeineListBox.Items.Refresh();
                    ThemaLabel.Content = "";
                }
            }
        }

        // Anzeigefenster links zeigt die Attribute des Termines an
        private void MeineListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MeineListBox.SelectedItem != null)
            {
                
                Termin selectedTermin = (Termin)MeineListBox.SelectedItem;
                ThemaLabel.Content = selectedTermin.ToString();
                ThemaLabel.Visibility = Visibility.Visible;

                
            }
        }

      

    
        
        // Sortieren nach Datum
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Model.SortTermineDatum();
            MeineListBox.ItemsSource = Model.Termine;
            MeineListBox.Items.Refresh();
        }
        // Sortieren nach Prioritaet
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Model.SortTerminePrioritaet();
            MeineListBox.ItemsSource = Model.Termine;
            MeineListBox.Items.Refresh();
        }



        // Hilfsmethoden
        private void NurZahlenTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

            if (!IsNumeric(e.Text))
            {
                e.Handled = true;
            }
        }
        private bool IsNumeric(string text)
        {
            return int.TryParse(text, out _);
        }

        public void CreateTermin()
        {
            if (!string.IsNullOrWhiteSpace(PostleitzahlTextBox.Text) &&
                   !string.IsNullOrWhiteSpace(StraßeTextBox.Text) &&
                   !string.IsNullOrWhiteSpace(StadtTextBox.Text) &&
                   !string.IsNullOrWhiteSpace(PrioritaetTextBox.Text) &&
                   !string.IsNullOrEmpty(MeineTextBox.Text) &&
                      MeinDatePicker.SelectedDate.HasValue)

            {
                Ort ort = new Ort(int.Parse(PostleitzahlTextBox.Text), StadtTextBox.Text, StraßeTextBox.Text);
                if (!string.IsNullOrEmpty(MeineTextBox.Text)) 
                {
                    Termin termin = new Termin(MeineTextBox.Text,ort, MeinDatePicker.SelectedDate.Value, int.Parse(PrioritaetTextBox.Text));
                   
                  

                    Model.AddTermin(termin);
                    MeineListBox.Items.Refresh();

                    MeineTextBox.Text = "";
                    PostleitzahlTextBox.Text = "";
                    StraßeTextBox.Text = "";
                    StadtTextBox.Text = "";
                    PrioritaetTextBox.Text = "";
                    MeinDatePicker.SelectedDate = null;



                }
            }
        }
    }
}
