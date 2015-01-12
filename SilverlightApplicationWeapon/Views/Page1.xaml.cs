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

namespace SilverlightApplicationWeapon
{
    public partial class Page1 : Page
    {
        private Boolean withPatron;

        public Page1()
        {

            
            InitializeComponent();
            radioWithOutPatron.IsChecked = true;
            this.dataPicker.SelectedDate = System.DateTime.Today;
         
        }

        // Выполняется, когда пользователь переходит на эту страницу.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }


        private void PasswordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == (Key.Enter)){
                showAutorization();
            }

        }
        //Альтернатива входа в учетную запись =)
        private void showAutorization() {
            MessageBox.Show("Логин = " + this.Login.Text + "\n Пароль = "+ this.Password.Password);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            showAutorization();
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            withPatron = true;
            if(patronLpz!=null||patronNorma!=null)
            visiblePatronChecked(withPatron);
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            withPatron = false;
            visiblePatronChecked(withPatron);
        }

        private void  visiblePatronChecked(Boolean b){
            patronLpz.IsEnabled = b;
            patronNorma.IsEnabled = b;
        }


        private void Button_Click_2(object sender, RoutedEventArgs e){
            this.listBox.Items.Clear();
            this.listBox.Items.Add(this.dataPicker.SelectedDate.ToString());
            this.listBox.Items.Add(this.HeaderText.Text + "( " + this.combox.SelectionBoxItem + " )");
            this.listBox.Items.Add(((bool)this.patronNorma.IsChecked ? this.patronNorma.Content : ""));
            this.listBox.Items.Add((bool)this.patronLpz.IsChecked ? this.patronLpz.Content : "");


            String s="";

            foreach (String d in this.listBox.Items) s += d + "\n";

        

            MessageBox.Show("Добавлено в корзину :\n"+s);

            
           
        }

    }
}
