using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wk6_WPFListExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        List<Employee> list;
        public MainWindow()
        {
            InitializeComponent();

            //when new window will be loaded then these employees will be displayed in the list
            list = new List<Employee>();

            Employee e1 = new Employee(1, "Anna", 0);
            Employee e2 = new Employee(2, "Max", 240);
            Employee e3 = new Employee(3, "Mike", 250);


            list.Add(e1);
            list.Add(e2);
            list.Add(e3);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //var emp = from employee in list
            //          select employee.Name;

            //empListBox.ItemsSource=emp;

            RefreshList();
        }

        private void empListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //we added this condition so that we shouldn't get an IndexOutOfRange error bcz after deletion the selected 
            if (empListBox.SelectedItem != null)
            {
                int index = empListBox.SelectedIndex;

                //get selected employee object 
                Employee emp = list[index];

                txt_id1.Text = emp.Id.ToString();  //id originally is int but textbox is expecting string value
                txt_name.Text = emp.Name;
                txt_salary.Text = emp.Salary.ToString();
            }
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            Employee emp = new Employee(int.Parse(txt_id1.Text), txt_name.Text, double.Parse(txt_salary.Text));  
            
            list.Add(emp);

            MessageBox.Show("Employee Added Successfully!","Add Employee",MessageBoxButton.OK,MessageBoxImage.Information);

            RefreshList();
        }

        public void RefreshList()
        {
            var emp = from employee in list
                      select employee.Name;

            empListBox.ItemsSource = emp;
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            int index = empListBox.SelectedIndex;

            //removing the element at the specified index
            list.RemoveAt(index);
            RefreshList();
        }
    }
}