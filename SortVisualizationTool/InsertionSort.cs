using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortVisualizationTool
{
    class InsertionSort : SortingMethods
    {
        public async void Sort(MainViewModel.ObservableCollectionPropertyNotify<Cell> listToBeSorted)
        {
            int n = listToBeSorted.Count;
            for (int i = 1; i < n; ++i)
            {
                await Task.Delay(2);
                int key = listToBeSorted[i].Value;
                int j = i - 1;

                listToBeSorted[i].State = true;
                

                while (j >= 0 && listToBeSorted[j].Value > key)
                {
                    listToBeSorted[j].State = true;
                    listToBeSorted[j + 1].Value = listToBeSorted[j].Value;
                    listToBeSorted[j].State = false;
                    j = j - 1;
                }
                listToBeSorted[j + 1].Value = key;
                listToBeSorted[i].State = false;

            }
            
        }
    }
}
