using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Windows.Input;

namespace Bee.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {


        private string _title = "Bee Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ICommand ExitCmd { get; private set; }
        public ICommand DamageCmd { get; private set; }
        public MainWindowViewModel()
        {
            ExitCmd = new DelegateCommand(ExecExit);
            DamageCmd = new DelegateCommand(ExecDamage);
        }

        private void ExecExit()
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void ExecDamage()
        {
            var generator = new Random();
            int damage = generator.Next(100);
        }
    }
}
