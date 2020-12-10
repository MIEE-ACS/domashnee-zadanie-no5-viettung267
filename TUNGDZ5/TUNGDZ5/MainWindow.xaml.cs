using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TUNGDZ5
{
    public partial class MainWindow : Window
    {
        // tao nhanh
        public class Kniga
        {
            // khai bao cac thuoc tinh con (chu thuong)
            public int bookcode;
            public int yearpublish;
            public int price;
            public int page;
            // nhap gia tri (viet hoa chu dau)
            public int Bookcode
            {
                set { bookcode = value; }
                get { return bookcode; }
            }
            public int Yearpublish
            {
                set { yearpublish = value; }
                get { return yearpublish; }
            }
            public int Price
            {
                set { price = value; }
                get { return price; }
            }
            public int Page
            {
                set { page = value; }
                get { return page; }
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        List<Kniga> items = new List<Kniga>();
        Kniga[] Book = new Kniga[100];//khai bao book voi kieu du lieu kniga
        int click = 0;
        public void delete()
        {
            for (int i = 0; i < click; i++)
            {
                if (Book[i].Bookcode == Book[click].Bookcode && Book[i].Yearpublish == Book[click].Yearpublish && Book[i].Price == Book[click].Price && Book[i].Page == Book[click].Page)
                {
                    items.RemoveAt(click);// xoa het du lieu cua sach tai vi tri thu click
                    click--;
                    break;
                }
            }
        }
        
        private void input_Click(object sender, RoutedEventArgs e)
        {
            int a1, b1, c1, d1;
            //kiem tra co phai kieu int k
            bool a = int.TryParse(bookcode.Text, out a1);
            bool b = int.TryParse(yearpublish.Text, out b1);
            bool c = int.TryParse(price.Text, out c1);
            bool d = int.TryParse(page.Text, out d1);
            if ((a == true && b == true && c == true && d == true) && (a1>0 && b1>0 && b1<=2020 && c1>0 && d1>0))
            {   

                Book[click] = new Kniga();
                Book[click].Bookcode = a1;
                Book[click].Yearpublish = b1;
                Book[click].Price = c1;
                Book[click].Page = d1;
                // them thong so phan tu da nhap vao list
                items.Add(new Kniga { Bookcode = Book[click].Bookcode, Yearpublish = Book[click].Yearpublish, Price = Book[click].Price, Page = Book[click].Page });
                if (click >= 1)
                {
                    delete();
                }
                click++;
                Listbook.ItemsSource = items;
                Listbook.Items.Refresh();
            }
            else
            {
                MessageBox.Show("fault, try to input again,please");
            }
        }

        private void price_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        //phan tim kiem ( thao tac voi listbox)
        private void findbook_Click(object sender, RoutedEventArgs e)
        {
            List<Kniga> Listfind = new List<Kniga>();
            int check = int.Parse(textcategory.Text);
            int choice = categorycb.SelectedIndex;
            switch (choice)
            {
                case 0:
                    {
                        for (int i = 0; i < click; i++)
                        {
                            if (check == Book[i].Bookcode)
                            {
                                Listfind.Add(new Kniga { Bookcode = Book[i].Bookcode, Yearpublish = Book[i].Yearpublish, Price = Book[i].Price, Page = Book[i].Page });
                            }
                        }
                        break;
                    }
                case 1:
                    {
                        for (int i = 0; i < click; i++)
                        {
                            if (check == Book[i].Yearpublish)
                            {
                                Listfind.Add(new Kniga { bookcode = Book[i].Bookcode, yearpublish = Book[i].Yearpublish, price = Book[i].Price, page = Book[i].Page });
                            }
                        }
                        break;
                    }
            }
            Listbook.ItemsSource = Listfind;
            Listbook.Items.Refresh();
        }

        private void bookcode_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
