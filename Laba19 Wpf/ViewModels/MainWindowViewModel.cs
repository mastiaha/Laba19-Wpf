using Laba19_Wpf.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Laba19_Wpf
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private double radius;
        public double Radius
        {
            get => radius;
            set
            {
                radius = value;
                OnPropertyChanged();
            }
        }

        private double lenght;
        public double Length
        {
            get => lenght;
            set
            {
                lenght = value;
                OnPropertyChanged();
            }
        }
        public ICommand AddCommand { get; }
        private void OnAddCommandExecute(object p)
        {
            Length = DlinCircle.Add(Radius);
        }

        private bool CanAddCommandExecuted(object p)
        {
            if (radius != 0)
                return true;
            else
            {
                return false;
            }

        }

        public MainWindowViewModel()
        {
            AddCommand = new RCommand(OnAddCommandExecute, CanAddCommandExecuted);
        }

    }
}

