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
using Model;
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
            using (autos_dbEntities1 context = new autos_dbEntities1())
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            client cl = new client();
            cl.idClient = 1; cl.FirstName = "Ivanov"; cl.SecondName = "Ivan"; cl.ThirdName = "Ivanovich";
            System.DateTime dt = new DateTime(1983, 4, 14);
            cl.Phone = "89108776584"; cl.Birth = dt;
            auto aut = new auto();
            aut.idauto = 1; aut.mark = "Chevrolet"; aut.model = "Aveo"; aut.year = 2009; aut.transmission = "Manual";
            aut.horsePower = 86;
            order ord = new order();
            dt = new DateTime(2015, 11, 15, 13, 0, 0);
            ord.idorder = 1; ord.idclient = 1; ord.idauto = 1; ord.auto = aut; ord.client = cl; ord.cost = 5000;
            ord.beginTime = dt;
            dt = new DateTime(2015, 11, 15, 15, 30, 0);
            ord.endTime = dt; ord.workname = "Oil changing";
            aut.order.Add(ord); cl.order.Add(ord);

            client cl2 = new client();
            cl2.idClient = 2; cl2.FirstName = "Aderihin"; cl2.SecondName = "Dmitry"; cl2.ThirdName = "Gennadievich";
            dt = new DateTime(1993, 11, 14);
            cl2.Phone = "89107668755"; cl2.Birth = dt;
            client cl3 = new client();
            cl3.idClient = 3; cl3.FirstName = "Polupanov"; cl3.SecondName = "Alexandr"; cl3.ThirdName = "Nikolaevich";
            dt = new DateTime(1989, 3, 3);
            cl3.Phone = "89503448574"; cl3.Birth = dt;
            client cl4 = new client();
            cl4.idClient = 4; cl4.FirstName = "Nesterov"; cl4.SecondName = "Anton"; cl4.ThirdName = "Vladimirovich";
            dt = new DateTime(1973, 2, 18);
            cl4.Phone = "89107778564"; cl4.Birth = dt;

            auto aut2 = new auto();
            aut2.idauto = 2; aut2.mark = "Ford"; aut2.model = "Mondeo"; aut2.year = 2003; aut2.transmission = "Manual";
            aut2.horsePower = 124;

            auto aut3 = new auto();
            aut3.idauto = 3; aut3.mark = "Kia"; aut3.model = "Ceed"; aut3.year = 2011; aut3.transmission = "Automatic";
            aut3.horsePower = 109;

            auto aut4 = new auto();
            aut4.idauto = 4; aut4.mark = "Mitsubishi"; aut4.model = "Outlander"; aut4.year = 2012; aut4.transmission = "Automatic";
            aut4.horsePower = 140;

            auto aut5 = new auto();
            aut5.idauto = 5; aut5.mark = "Suzuki"; aut5.model = "Liana"; aut5.year = 2006; aut5.transmission = "Manual";
            aut5.horsePower = 87;

            order ord2 = new order();
            dt = new DateTime(2015, 12, 13, 10, 0, 0);
            ord2.idorder = 2; ord2.idclient = 2; ord2.idauto = 3; ord2.auto = aut3; ord2.client = cl2; ord2.cost = 12000;
            ord2.beginTime = dt;
            dt = new DateTime(2015, 12, 15, 10, 30, 0);
            ord2.endTime = dt; ord2.workname = "Timing belt replacing";
            aut3.order.Add(ord2); cl2.order.Add(ord2);

            order ord3 = new order();
            dt = new DateTime(2016, 1, 13, 16, 0, 0);
            ord3.idorder = 3; ord3.idclient = 2; ord3.idauto = 4; ord3.auto = aut4; ord3.client = cl2; ord3.cost = 3000;
            ord3.beginTime = dt;
            dt = new DateTime(2016, 1, 14, 11, 00, 0);
            ord3.endTime = dt; ord3.workname = "Shock absorbes replacing";
            aut4.order.Add(ord3); cl2.order.Add(ord3);

            order ord4 = new order();
            dt = new DateTime(2015, 12, 10, 10, 0, 0);
            ord4.idorder = 4; ord4.idclient = 3; ord4.idauto = 5; ord4.auto = aut5; ord4.client = cl3; ord4.cost = 32000;
            ord4.beginTime = dt;
            dt = new DateTime(2015, 12, 16, 14, 30, 0);
            ord4.endTime = dt; ord4.workname = "Engine repair";
            aut5.order.Add(ord4); cl3.order.Add(ord4);

            order ord5 = new order();
            dt = new DateTime(2016, 2, 11, 10, 0, 0);
            ord5.idorder = 5; ord5.idclient = 4; ord5.idauto = 2; ord5.auto = aut2; ord5.client = cl4; ord5.cost = 500;
            ord5.beginTime = dt;
            dt = new DateTime(2016, 2, 11, 10, 30, 0);
            ord5.endTime = dt; ord5.workname = "Spark plugs changing";
            aut2.order.Add(ord5); cl4.order.Add(ord5);

            List<order> OrderList = new List<order>();
            List<client> ClientList = new List<client>();
            List<auto> AutosList = new List<auto>();
            OrderList.Add(ord); OrderList.Add(ord2); OrderList.Add(ord3); OrderList.Add(ord4); OrderList.Add(ord5);
            ClientList.Add(cl); ClientList.Add(cl2); ClientList.Add(cl3); ClientList.Add(cl4);
            AutosList.Add(aut); AutosList.Add(aut2); AutosList.Add(aut3); AutosList.Add(aut4); AutosList.Add(aut5);

            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("autos.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, OrderList);
                formatter.Serialize(fs, ClientList);
                formatter.Serialize(fs, AutosList);
            }
        }
        
    }
}
