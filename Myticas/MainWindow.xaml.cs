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
            //mergesort(numbers, new int[numbers.Length], 0, numbers.Length - 1);
            String numberse = textBoxU.Text;
            //string[] strings = numberse.Split(',',StringSplitOptions.RemoveEmptyEntries);
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
            MergeSort(numbers, 0, numbers.Length - 1);
            var resultSort = string.Join(",", numbers);
            textBoxS.Text = resultSort;
            
        }

        static public void MergeSort(int[] numbers, int leftStart, int rightEnd)
        {
            int mid;

            if (rightEnd > leftStart)
            {
                mid = (rightEnd + leftStart) / 2;

                Task[] tasks = new Task[2];

                tasks[0] = Task.Factory.StartNew(() => MergeSort(numbers, leftStart, mid));
                tasks[1] = Task.Factory.StartNew(() => MergeSort(numbers, (mid + 1), rightEnd));

                tasks[0].Wait();
                tasks[1].Wait();

                MergeHalves(numbers, leftStart, (mid + 1), rightEnd);
            }
        }

        static public void MergeHalves(int[] numbers, int left, int mid, int right)
        {

            int[] temp = new int[25];
            int i, leftEnd, rightStart, index;

            leftEnd = (mid - 1);
            index = left;
            rightStart = (right - left + 1);

            while ((left <= leftEnd) && (mid <= right))
            {

                if (numbers[left] <= numbers[mid])
                    temp[index++] = numbers[left++];
                else
                    temp[index++] = numbers[mid++];
            }



            while (left <= leftEnd)
                temp[index++] = numbers[left++];


            while (mid <= right)
                temp[index++] = numbers[mid++];



            for (i = 0; i < rightStart; i++)
            {
                numbers[right] = temp[right];
                right--;
            }

        }

    }
}
