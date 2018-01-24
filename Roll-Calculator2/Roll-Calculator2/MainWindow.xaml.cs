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

namespace Roll_Calculator2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<TextBox> TB;

        public MainWindow()
        {
            InitializeComponent();
            TB = new List<TextBox>(InputsCanvas.Children.OfType<TextBox>().ToList());
        }

        private void RollButton_Click(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            String allOut = "Output\n";
            //allOut.Clear();
            //allOut.Append(Outcomes.Name);
            foreach (TextBox t in TB)
            {
                int sides = Int32.Parse(t.Name.Substring(1));
                int content = 0;
                /*int content = */Int32.TryParse(t.Text, out content);
                for (int i = 0; i < content; i++)
                {
                    int output = r.Next(1, sides+1);
                    allOut += output.ToString() + "\n";
                    //allOut.AppendLine(output.ToString());
                }
            }
            Outcomes.Text = allOut;
        }
    }
}
