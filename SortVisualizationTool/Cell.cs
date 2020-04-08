using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortVisualizationTool
{
    public class Cell : INotifyPropertyChanged
    {
        public bool State { get { return _hiddenState; } set { _hiddenState = value; OnPropertyChanged("State"); } }

        private bool _hiddenState { get; set; }

        private int _hidden { get; set; }

        public int Value { get { return _hidden; } set { _hidden = value; OnPropertyChanged("Value"); } }

        public Cell(int value)
        {
            this.Value = value;
        }


        private void OnPropertyChanged(string parameter)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(parameter));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
