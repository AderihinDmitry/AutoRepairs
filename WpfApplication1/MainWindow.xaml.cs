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
using System.Data.Entity;
namespace WpfApplication1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AutosContext context = new AutosContext();
            context.order.Load();
            var entityPoint = from ord in context.order
                              join aut in context.auto on ord.idauto equals aut.idauto
                              select new { 
                              IdOrder = ord.idorder,
                              Mark = aut.mark,
                              Model = aut.model,
                              Year = aut.year,
                              Transmission = aut.transmission,
                              HorsePower = aut.horsePower,
                              Workname = ord.workname,
                              WorkBegin = ord.beginTime,
                              WorkEnd = ord.endTime,
                              Salary = ord.cost
                                };
            DataGridOrder.ItemsSource = entityPoint.ToList();

            
        }

        private void DataGridOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AutosContext context = new AutosContext();
            context.order.Load();
            object item = DataGridOrder.SelectedItem;
            int id = int.Parse((DataGridOrder.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
            var entityPoint = from cl in context.client
                              join ord in context.order on cl.idClient equals ord.idclient
                              where ord.idorder == id
                              select new
                              {
                                  Name = cl.SecondName,
                                  Surname = cl.FirstName,
                                  Patronymic = cl.ThirdName,
                                  Birth = cl.Birth,
                                  Phone = cl.Phone
                              };
            DataGridClient.ItemsSource = entityPoint.ToList();
        }
        
    }
}
