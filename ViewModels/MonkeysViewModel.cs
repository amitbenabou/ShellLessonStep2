using ShellLessonStep2.Views;
using ShellLessonStep2.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShellLessonStep2.ViewModels
{
    internal class MonkeysViewModel : ViewModelBase
    {
        private ObservableCollection<Monkeys> monkeys;
        public ObservableCollection<Monkeys> Monkeys
        {
            get
            {
                return this.monkeys;
            }
            set
            {
                this.monkeys = value;
                OnPropertyChanged();
            }
        }

        private AnimalService MonkeysService;
        public MonkeysViewModel()
        {
            this.MonkeysService =  new AnimalService();
            monkeys = new ObservableCollection<Monkeys>();
            ReadMonkeys();
        }

        private async void ReadMonkeys()
        {
            AnimalService service = this.MonkeysService;
            List<Monkeys> list = await service.GetMonkeys();
            this.Monkeys = new ObservableCollection<Monkeys>(list);
        }
    }
}
