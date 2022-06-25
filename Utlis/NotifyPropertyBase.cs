using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EasyChair2.Utlis
{
    public abstract class NotifyPropertyBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public virtual bool NotifyProperty([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged is null) return false;
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            return true;
        }
    }
}
