using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myticas
{
    class MergeSortAlghoritm
    {
        public static void MergeSort(int[] numbers, int leftStart, int rightEnd)
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

        public static void MergeHalves(int[] numbers, int left, int mid, int right)
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
