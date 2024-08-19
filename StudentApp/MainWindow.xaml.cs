using StudentsApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace StudentApp
{
    public partial class MainWindow : Window
    {
        private List<Student> myStudents = new List<Student>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddStudent_button(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(NameTextBox.Text))
                {
                    var student = new Student
                    {
                        Name = NameTextBox.Text,
                        Year = ((ComboBoxItem)YearComboBox.SelectedItem)?.Content.ToString(),
                        Semester = int.Parse(((ListBoxItem)SemesterListBox.SelectedItem)?.Content.ToString() ?? "0")
                    };
                    myStudents.Add(student);
                    AllStudentsListBox.Items.Add(student);
                }
                else
                {
                    MessageBox.Show("Please enter a name.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void FilterYoungStudents_button(object sender, RoutedEventArgs e)
        {
            YoungStudentsListBox.Items.Clear();
            foreach (var student in myStudents.Where(s => s.Semester < 7))
            {
                YoungStudentsListBox.Items.Add(student);
            }
        }

        private void DeleteYoungStudents_button(object sender, RoutedEventArgs e)
        {
            if (YoungStudentsListBox.SelectedItem is Student selectedStudent)
            {
                YoungStudentsListBox.Items.Remove(selectedStudent);
                myStudents.Remove(selectedStudent);
                AllStudentsListBox.Items.Remove(selectedStudent);
            }
            else
            {
                MessageBox.Show("Please select a student to delete.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DeleteAddStudent_button(object sender, RoutedEventArgs e)
        {
            if (AllStudentsListBox.SelectedItem is Student selectedStudent)
            {
                AllStudentsListBox.Items.Remove(selectedStudent);
                myStudents.Remove(selectedStudent);
                YoungStudentsListBox.Items.Remove(selectedStudent);
            }
            else
            {
                MessageBox.Show("Please select a student to delete.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
