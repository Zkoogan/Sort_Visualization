using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SortVisualizationTool
{
    class MainViewModel : INotifyPropertyChanged
    {

        public class ObservableCollectionPropertyNotify<T> : ObservableCollection<T>
        {
            //OnCollectionChange method is protected, accesible only within a child class in this case. This is why  
            //I made a new Collection class with a public method Refresh.  
            public void Refresh()
            {
                for (var i = 0; i < this.Count(); i++)
                {
                    this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
                }
            }
        }



        public Random rnd;

        public object problemLock;
        public event PropertyChangedEventHandler PropertyChanged;
        public bool CurrentlySolving { get { return _hiddenSolving; } set { _hiddenSolving = value; OnPropertyChanged("CurrentlySolving"); } }

        private bool _hiddenSolving { get; set; }
        public ObservableCollectionPropertyNotify<Cell> ListToBeSorted { get; set; }
        public Command CreateProblemCommand { get; set; }
        public Command SortCommand { get; set; }
        public int n_samples { get; set; }
        public IDictionary<string, SortingMethods> Sorting_methods { get; set; }
        public string selectedSortingMethod { get { return _hiddenSelection; }  set { _hiddenSelection = value; OnPropertyChanged("selectedSortingMethod"); } }
        private string _hiddenSelection { get; set; }
        public Task currentTask { get; set; }
     
        public MainViewModel()
        {
            rnd = new Random();
            CreateProblemCommand = new Command(CreateSortingProblem, CanCreateSortingProblem);
            SortCommand = new Command(ExecuteSort, CanCreateSortingProblem);
            ListToBeSorted = new ObservableCollectionPropertyNotify<Cell>();
            n_samples = 1200;
            CurrentlySolving = true;
            Sorting_methods = new Dictionary<string, SortingMethods>();
            selectedSortingMethod = "Selection Sort";
            populateDictionary();
            problemLock = new object();
        }

        private void populateDictionary()
        {
            Sorting_methods.Add("Selection Sort", new SelectionSorter());
            Sorting_methods.Add("Bubble Sort", new BubbleSort());
            Sorting_methods.Add("Insertion Sort", new InsertionSort());
            Sorting_methods.Add("Merge Sort", new MergeSorter());
            Sorting_methods.Add("Quick Sort", new QuickSorter());
        }

        public void CreateSortingProblem(object parameter)
        {
            ListToBeSorted.Clear();

            for (int i = 0; i < n_samples; i++)
            {
                    ListToBeSorted.Add(new Cell(rnd.Next(1, 600 + 1)));
            }
        }

        public bool CanCreateSortingProblem(object paratemer)
        {
            return CurrentlySolving;
        }

        public async void ExecuteSort(object parameter)
        {
            CurrentlySolving = false;
            currentTask = Task.Run( () => Sorting_methods[selectedSortingMethod].Sort(ListToBeSorted));
            await currentTask;
            CurrentlySolving = currentTask.IsCompleted;       
        }

        private void OnPropertyChanged(string parameter)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(parameter));
            }
        }
    }
}
