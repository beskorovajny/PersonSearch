using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Serialization;

namespace PersonalSearch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string PATH = @"D:\Staff.xml";
        private Staff persons = new Staff();
        private Staff toSearch = new Staff();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (File.Exists(PATH))
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(List<Person>));
                FileStream fs = new FileStream(PATH, FileMode.Open);
                persons.PersonList = (List<Person>)deserializer.Deserialize(fs);

                foreach (var item in persons.PersonList)
                {
                    lvProductList.Items.Add(item);
                }
                fs.Close();
            }

            if (persons.PersonList.Count >= 1)
            {
                searchButton.Visibility = Visibility.Visible;
                editButton.Visibility = Visibility.Visible;
                deleteButton.Visibility = Visibility.Visible;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            lvProductList.Items.Clear();
            fillError.Visibility = Visibility.Hidden;
            if (!(string.IsNullOrWhiteSpace(firstNameTxtBox.Text) &&
                string.IsNullOrWhiteSpace(lastNameTxtBox.Text) &&
                string.IsNullOrWhiteSpace(IDTxtBox.Text) &&
                string.IsNullOrWhiteSpace(ageTxtBox.Text)))
            {
                persons.PersonList.Add(new Person()
                {
                    FirstName = firstNameTxtBox.Text,
                    LastName = lastNameTxtBox.Text,
                    ID = IDTxtBox.Text,
                    Age = ageTxtBox.Text
                });
                firstNameTxtBox.Text = string.Empty;
                lastNameTxtBox.Text = string.Empty;
                IDTxtBox.Text = string.Empty;
                ageTxtBox.Text = string.Empty;


            }
            else
            {
                fillError.Visibility = Visibility.Visible;
            }
            foreach (var item in persons.PersonList)
            {
                lvProductList.Items.Add(item);
            }
            lvProductList.Items.Refresh();

            if(persons.PersonList.Count >= 1)
            {
                searchButton.Visibility = Visibility.Visible;
                editButton.Visibility = Visibility.Visible;
                deleteButton.Visibility = Visibility.Visible;
            } 
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
          
           if(lvProductList.SelectedItem != null)
            {
                AddButton.Visibility = Visibility.Hidden;
                searchButton.Visibility = Visibility.Hidden;
                deleteButton.Visibility = Visibility.Hidden;
                editButton.Visibility = Visibility.Hidden;
                selectError.Visibility = Visibility.Hidden;
                OkButton.Visibility = Visibility.Visible;

                firstNameTxtBox.Text = persons.PersonList.ElementAt(lvProductList.SelectedIndex).FirstName;
                lastNameTxtBox.Text = persons.PersonList.ElementAt(lvProductList.SelectedIndex).LastName;
                IDTxtBox.Text = persons.PersonList.ElementAt(lvProductList.SelectedIndex).ID;
                ageTxtBox.Text = persons.PersonList.ElementAt(lvProductList.SelectedIndex).Age;
            }
            else
            {
                selectError.Visibility = Visibility.Visible;
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
           
            selectError.Visibility = Visibility.Hidden;
            if (lvProductList.SelectedItem != null)
            {
                persons.PersonList.RemoveAt(lvProductList.SelectedIndex);
                lvProductList.Items.Clear();
                foreach (var item in persons.PersonList)
                {
                lvProductList.Items.Add(item);
                }
            }
            else
            {
                 selectError.Visibility = Visibility.Visible;
            }
            if (persons.PersonList.Count == 0)
            {
                searchButton.Visibility = Visibility.Hidden;
                editButton.Visibility = Visibility.Hidden;
                deleteButton.Visibility = Visibility.Hidden;
            }
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            optionBlock.Visibility = Visibility.Visible;
            comboBox.Visibility = Visibility.Visible;
            searchTxtBox.Visibility = Visibility.Visible;
            searchBlock.Visibility = Visibility.Visible;
            submitButton.Visibility = Visibility.Visible;
            cancelButton.Visibility = Visibility.Visible;
           // Hide
            fNameBlock.Visibility = Visibility.Hidden;
            firstNameTxtBox.Visibility = Visibility.Hidden;
            lNameBlock.Visibility = Visibility.Hidden;
            lastNameTxtBox.Visibility = Visibility.Hidden;
            idBlock.Visibility = Visibility.Hidden;
            IDTxtBox.Visibility = Visibility.Hidden;
            ageBlock.Visibility = Visibility.Hidden;
            ageTxtBox.Visibility = Visibility.Hidden;
            AddButton.Visibility = Visibility.Hidden;
            searchButton.Visibility = Visibility.Hidden;
            editButton.Visibility = Visibility.Hidden;
            deleteButton.Visibility = Visibility.Hidden;
            // search
            toSearch.PersonList = persons.PersonList;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            fillError.Visibility = Visibility.Hidden;
            if (!(string.IsNullOrWhiteSpace(firstNameTxtBox.Text) &&
               string.IsNullOrWhiteSpace(lastNameTxtBox.Text) &&
               string.IsNullOrWhiteSpace(IDTxtBox.Text) &&
               string.IsNullOrWhiteSpace(ageTxtBox.Text)))
            {
                persons.PersonList.ElementAt(lvProductList.SelectedIndex).FirstName = firstNameTxtBox.Text;
                persons.PersonList.ElementAt(lvProductList.SelectedIndex).LastName = lastNameTxtBox.Text;
                persons.PersonList.ElementAt(lvProductList.SelectedIndex).ID = IDTxtBox.Text;
                persons.PersonList.ElementAt(lvProductList.SelectedIndex).Age = ageTxtBox.Text;

                lvProductList.Items.Clear();
                foreach(var item in persons.PersonList)
                {
                    lvProductList.Items.Add(item);
                }
                OkButton.Visibility = Visibility.Hidden;
                AddButton.Visibility = Visibility.Visible;
                editButton.Visibility = Visibility.Visible;
                searchButton.Visibility = Visibility.Visible;
                deleteButton.Visibility = Visibility.Visible;

                firstNameTxtBox.Text = string.Empty;
                lastNameTxtBox.Text = string.Empty;
                IDTxtBox.Text = string.Empty;
                ageTxtBox.Text = string.Empty;
            }
            else
            {
                fillError.Visibility = Visibility.Visible;
            }
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {

            if (comboBox.SelectedValue.ToString() == "Firstname")
            {
                lvProductList.Items.Clear();
                foreach (var item in toSearch.PersonList)
                {
                    if(searchTxtBox.Text.ToLower() == item.FirstName.ToLower())
                    {
                        lvProductList.Items.Add(item);
                    }
                }
            }
            else if (comboBox.SelectedValue.ToString() == "Lastname")
            {
                lvProductList.Items.Clear();
                foreach (var item in toSearch.PersonList)
                {
                    if(searchTxtBox.Text.ToLower() == item.LastName.ToLower())
                    {
                       
                        lvProductList.Items.Add(item);
                    }
                }
            }
            else if (comboBox.SelectedValue.ToString() == "ID")
            {
                lvProductList.Items.Clear();
                foreach (var item in toSearch.PersonList)
                {
                    if(searchTxtBox.Text.ToLower() == item.ID.ToLower())
                    {
                      
                        lvProductList.Items.Add(item);
                    }
                  
                }
            }
            else if (comboBox.SelectedValue.ToString() == "Age")
            {
                lvProductList.Items.Clear();
                foreach (var item in toSearch.PersonList)
                {
                    if(searchTxtBox.Text.ToLower() == item.Age.ToLower())
                    {
                        lvProductList.Items.Add(item);
                    }
                }
            }
            else
            {
                notFoundError.Visibility = Visibility.Visible;
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            optionBlock.Visibility = Visibility.Hidden;
            comboBox.Visibility = Visibility.Hidden;
            searchTxtBox.Visibility = Visibility.Hidden;
            searchBlock.Visibility = Visibility.Hidden;
            submitButton.Visibility = Visibility.Hidden;
            cancelButton.Visibility = Visibility.Hidden;
            notFoundError.Visibility = Visibility.Hidden;
            selectError.Visibility = Visibility.Hidden;
            // Hide
            fNameBlock.Visibility = Visibility.Visible;
            firstNameTxtBox.Visibility = Visibility.Visible;
            lNameBlock.Visibility = Visibility.Visible;
            lastNameTxtBox.Visibility = Visibility.Visible;
            idBlock.Visibility = Visibility.Visible;
            IDTxtBox.Visibility = Visibility.Visible;
            ageBlock.Visibility = Visibility.Visible;
            ageTxtBox.Visibility = Visibility.Visible;
            AddButton.Visibility = Visibility.Visible;
            searchButton.Visibility = Visibility.Visible;
            editButton.Visibility = Visibility.Visible;
            deleteButton.Visibility = Visibility.Visible;

            lvProductList.Items.Clear();
            foreach (var item in persons.PersonList)
            {
                lvProductList.Items.Add(item);
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Person>));
            TextWriter writer = new StreamWriter(PATH);
            serializer.Serialize(writer, persons.PersonList);
            writer.Close();
        }
    }
}
