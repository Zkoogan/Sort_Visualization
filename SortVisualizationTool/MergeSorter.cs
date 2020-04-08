using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SortVisualizationTool.MainViewModel;

namespace SortVisualizationTool
{
    class MergeSorter : SortingMethods
    {

        ObservableCollectionPropertyNotify<Cell> listToBeSorted { get; set; }

        public async void Sort(MainViewModel.ObservableCollectionPropertyNotify<Cell> listToBeSorted)
        {
            this.listToBeSorted = listToBeSorted;
           int n = listToBeSorted.Count;
           await MergeSort(0, n-1);
        }

        private async Task MergeSort(int l, int r)
        {
            if(l < r){
                await Task.Delay(50);
                int m = (l+r) / 2;
                await Task.Run(()=>MergeSort(l, m));
                await Task.Run(()=> MergeSort(m+1, r));
                await Task.Run(()=>Merge(l, m, r));
            }
        }

        private async Task Merge(int start, int mid, int end)
        {
            int left_index = 0;
            int right_index = 0;
            int list_index = start;

            List<int> leftValues = new List<int>();
            List<int> rightValues = new List<int>();


            for(int i = start; i <= end; i++)
            {
                if(i <= mid)
                {
                    leftValues.Add(listToBeSorted[i].Value);
                }
                else
                {
                    rightValues.Add(listToBeSorted[i].Value);
                }
            }
            int n_right = rightValues.Count;
            int n_left = leftValues.Count;

            while(left_index < n_left && right_index < n_right)
            {
                if(leftValues[left_index] <= rightValues[right_index])
                {
                    listToBeSorted[list_index].Value = leftValues[left_index];
                    left_index++;
                    list_index++;
                    await Task.Delay(1);
                }
                else
                {
                    listToBeSorted[list_index].Value = rightValues[right_index];
                    right_index++;
                    list_index++;
                    await Task.Delay(1);

                }
            }
            while(left_index < n_left)
            {
                listToBeSorted[list_index].Value = leftValues[left_index];
                left_index++;
                list_index++;
                await Task.Delay(1);
            }
            while(right_index < n_right)
            {
                listToBeSorted[list_index].Value = rightValues[right_index];
                right_index++;
                list_index++;
                await Task.Delay(1);
            }
        }
    }
}
