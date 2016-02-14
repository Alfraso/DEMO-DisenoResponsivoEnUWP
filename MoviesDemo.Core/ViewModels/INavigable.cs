using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesDemo.Core.ViewModels
{
    public interface INavigable
    {
        void Activate(object parameter);
      //  void Deactivate(object parameter);
        void Start();
    }
}
