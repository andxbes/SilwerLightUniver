using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Navigation;

namespace SilverlightApplicationWeapon.Views
{
    public partial class Page2 : Page
    {
        private SolidColorBrush black = new SolidColorBrush(Colors.Black);
        private Canvas canv;
        public Page2()
        {
            InitializeComponent();
        }

        // Выполняется, когда пользователь переходит на эту страницу.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void PaintField_Loaded_1(object sender, RoutedEventArgs e)
        {
            canv = (Canvas) sender;
   
          

        }

     

    }
}
