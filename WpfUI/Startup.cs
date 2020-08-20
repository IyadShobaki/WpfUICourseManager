using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfUI.ViewModels;

namespace WpfUI
{
    class Startup : BootstrapperBase
    {
        public Startup()
        {
            Initialize();

        }
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<MainViewModel>();
        }
    }
}
