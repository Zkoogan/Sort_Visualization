using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortVisualizationTool
{
    class BubbleSort : SortingMethods
    {
        public async void Sort(MainViewModel.ObservableCollectionPropertyNotify<Cell> listToBeSorted)
        {
            int i, j, temp;
            bool swapped;
            for (i = 0; i < listToBeSorted.Count - 1; i++)
            {
                swapped = false;
                for (j = 0; j < listToBeSorted.Count - i - 1; j++)
                {
                    if (listToBeSorted[j].Value > listToBeSorted[j + 1].Value)
                    {
                        listToBeSorted[j].State = true;
                        listToBeSorted[j + 1].State = true;
                        temp = listToBeSorted[j].Value;
                        listToBeSorted[j].Value = listToBeSorted[j + 1].Value;
                        listToBeSorted[j + 1].Value = temp;
                        swapped = true;

                        listToBeSorted[j].State = false;    
                        listToBeSorted[j+1].State = false;
                    }
                }
                await Task.Delay(2);
                if (swapped == false)
                    break;
            }
        }
    }
}
