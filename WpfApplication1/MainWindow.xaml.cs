using System;
using System.IO;
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
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Linq;
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
            using (AutosContext context = new AutosContext())
            {
                context.order.Load();
                var entityPoint = from ord in context.order
                                  join aut in context.auto on ord.idauto equals aut.idauto
                                  join cl in context.client on ord.idclient equals cl.idClient
                                  select new
                                  {
                                      IdOrder = ord.idorder,
                                      Mark = aut.mark,
                                      Model = aut.model,
                                      Year = aut.year,
                                      Transmission = aut.transmission,
                                      HorsePower = aut.horsePower,
                                      WorkName = ord.workname,
                                      WorkBegin = ord.beginTime,
                                      WorkEnd = ord.endTime,
                                      Salary = ord.cost,
                                      FirstName = cl.FirstName,
                                      SecondName = cl.SecondName,
                                      ThirdName = cl.ThirdName,
                                      Phone = cl.Phone,
                                      Birth = cl.Birth
                                  };
                DataGridOrder.ItemsSource = entityPoint.ToList();
            }
            

            
        }

        private void DataGridOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*using (AutosContext context = new AutosContext())
            {
                context.order.Load();
                object item = DataGridOrder.SelectedItem;
                int id = int.Parse((DataGridOrder.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
                IQueryable<client> entityPoint = from cl in context.client
                                  join ord in context.order on cl.idClient equals ord.idclient
                                  where ord.idorder == id
                                  select cl;
                client s = entityPoint.ToArray()[0];
                MessageBox.Show(s.FirstName.ToString());
                DataGridClient.ItemsSource = entityPoint.ToList();
            }*/
        }

        private void Button_Load_Xml_Click(object sender, RoutedEventArgs e)
        {
            XDocument doc = XDocument.Load("AutoServiceData.xml");
            var query = from aut in doc.Descendants("auto")
                        join ord in doc.Descendants("order")
                        on aut.Element("idauto").Value equals ord.Element("idauto").Value
                        join cl in doc.Descendants("client") on aut.Element("idclient").Value equals cl.Element("idclient").Value
                        select new
                        {
                            IdOrder = ord.Element("idorder").Value,
                            Mark = aut.Element("mark").Value,
                            Model = aut.Element("model").Value,
                            Year = aut.Element("year").Value,
                            Transmission = aut.Element("transmission").Value,
                            HorsePower = aut.Element("horsepower").Value,
                            WorkName = ord.Element("workname").Value,
                            WorkBegin = ord.Element("beginTime").Value,
                            WorkEnd = ord.Element("endTime").Value,
                            Salary = ord.Element("cost").Value,
                            FirstName = cl.Element("firstName").Value,
                            SecondName = cl.Element("secondName").Value,
                            ThirdName = cl.Element("thirdName").Value,
                            Phone = cl.Element("phone").Value,
                            Birth = cl.Element("birth").Value
                        };
            DataGridOrder.ItemsSource = query.ToList();
        }

        private void Button_Load_Bin_Click(object sender, RoutedEventArgs e)
        {
            List<order> OrderList = new List<order>();
            List<client> ClientList = new List<client>();
            List<auto> AutosList = new List<auto>();
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("AutoServiceData.dat", FileMode.OpenOrCreate))
            {
                OrderList = (List<order>)formatter.Deserialize(fs);
                ClientList = (List<client>)formatter.Deserialize(fs);
                AutosList = (List<auto>)formatter.Deserialize(fs);
            }
            var entityPoint = from or in OrderList
                              join au in AutosList on or.idauto equals au.idauto
                              join cli in ClientList on or.idclient equals cli.idClient
                              select new
                              {
                                  IdOrder = or.idorder,
                                  Mark = au.mark,
                                  Model = au.model,
                                  Year = au.year,
                                  Transmission = au.transmission,
                                  HorsePower = au.horsePower,
                                  WorkName = or.workname,
                                  WorkBegin = or.beginTime,
                                  WorkEnd = or.endTime,
                                  Salary = or.cost,
                                  FirstName = cli.FirstName,
                                  SecondName = cli.SecondName,
                                  ThirdName = cli.ThirdName,
                                  Phone = cli.Phone,
                                  Birth = cli.Birth
                              };
            DataGridOrder.ItemsSource = entityPoint.ToList();
        }
        
    }
}
