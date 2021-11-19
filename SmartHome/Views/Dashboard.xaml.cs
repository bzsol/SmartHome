using Common.Class;
using Common.Model;
using SmartHome.DataProvider;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SmartHome.Views
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        

        public Dashboard()
        {
            InitializeComponent();
            Thread.CurrentThread.CurrentCulture = new CultureInfo("hu-HU");
            if (((List<ExternalFactors>)ExtFactDataProvider.Get()).Count < 1 )
            {
                // Generate new list without null
                ExtFactDataProvider.Create(new ExternalFactors(new List<Electronics>(), new List<Electronics>(), new Climate(), new Climate(), new Climate(), new Climate(),new Climate(),new Climate(),new Climate(),new Climate(),new Climate(),new Lights(),new Lights(),new Lights(),
                    new Lights(),new Lights(),new Lights(),new Lights(),new Lights(),new Lights(), new Lights(),
                    new Lights(), new Lights(), new Lights(), new Irrigative(), new Irrigative(),new Shading(), new Shading(),new Shading(),new Shading(),new Shading(),new Shading(),new Shading(), new Shading()));
            }
        }
    }
}
