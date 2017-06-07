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

namespace Myticas
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

        private void btnSort_Click(object sender, RoutedEventArgs e)
        {
            int[] numbers = new int[1];
            String numberse = textBoxU.Text;
            
            string[] strings = numberse.Split(new String[] {","}, StringSplitOptions.RemoveEmptyEntries);
            int i = 0;
            foreach (String item in strings)
            {
                numbers[i] = Convert.ToInt32(item);
                if (i == strings.Length - 1)
                    break;
                i++;
                Array.Resize(ref numbers, i+1);
            }
            MergeSortAlghoritm.MergeSort(numbers, 0, numbers.Length - 1);
            var resultSort = string.Join(",", numbers);
            textBoxS.Text = resultSort;
            
        }



    }
}
