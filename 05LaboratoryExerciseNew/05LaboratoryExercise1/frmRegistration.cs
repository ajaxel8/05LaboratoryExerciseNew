using System;
using System.Data;
using System.IO;
using System.Linq.Expressions;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace _05LaboratoryExercise1
{
    public partial class frmRegistration : Form
    {

        public frmRegistration()
        {
            InitializeComponent();
            Gender.Items.Add("Male");
            Gender.Items.Add("Female");

            Program.Items.Add("BS in Information Technology");
            Program.Items.Add("BS In Computer Science");
            Program.Items.Add("BS in Computer Engineering");
            Program.Items.Add("BS in Psychology");

    }

        private void frmRegistration_Load(object sender, System.EventArgs e)
        { 
         
            
        }

        private void btnRegister_Click(object sender, System.EventArgs e)
        {
            string studentNumber = studNo.Text;
            string firstName = FirstName.Text;
            string lastName = LastName.Text;
            string middleName = MiddleInitial.Text;
            string program = Program.SelectedItem.ToString();
            string gender = Gender.SelectedItem.ToString();
            int age = Convert.ToInt32(Age.Text);
            string birthday = BirthdayPicker.Text;
            string contact = ContactNumber.Text;
            // the file name will be based on Student Number
            string fileName = $"{studentNumber}_Registration.txt";

          
            
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine($"Student Number: {studentNumber}");
                writer.WriteLine($"Full Name: {lastName}, {firstName} , {middleName}");
                writer.WriteLine($"Program:{program}");
                writer.WriteLine($"Gender:{gender}");
                writer.WriteLine($"Age: {age}");
                writer.WriteLine($"Birthday: {birthday}");
                writer.WriteLine($"Contact No.:{contact}");
               
            }
          
            string[] fileContent = File.ReadAllLines(fileName);
            foreach (string files in fileContent)
            {
                Console.WriteLine(files);
            }
           
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName);
         File.WriteAllLines(filePath, fileContent);
            MessageBox.Show("Registered Successfully");
            FrmStudentRecord back = new FrmStudentRecord();
            back.ShowDialog();

        }

      
        

        private void btnRecords_Click(object sender, EventArgs e)
        {
            FrmStudentRecord back = new FrmStudentRecord();
            back.ShowDialog();
        }
    }
}
