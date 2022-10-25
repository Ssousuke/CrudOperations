using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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

namespace CrudOperations
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadGrid();
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-MFBBRTM\\SQLEXPRESS;Initial Catalog=CrudOperations;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        public void LoadGrid()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Usuarios", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            data_grid.ItemsSource = dt.DefaultView;
        }

        public bool IsValid()
        {
            if (nome_txt.Text == String.Empty)
            {
                MessageBox.Show("Nome é obrigatorio!", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (cidade_txt.Text == String.Empty)
            {
                MessageBox.Show("Cidade é obrigatorio!", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (idade_txt.Text == String.Empty)
            {
                MessageBox.Show("Idade é obrigatorio!", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (genero_txt.Text == String.Empty)
            {
                MessageBox.Show("Genero é obrigatorio!", "Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        private void Cadastrar(object sender, RoutedEventArgs e)
        {
            if (IsValid())
            {
                string sql = ("INSERT INTO Usuarios VALUES (@Name, @City, @Age, @Gender)");
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Name", nome_txt.Text);
                cmd.Parameters.AddWithValue("@City", cidade_txt.Text);
                cmd.Parameters.AddWithValue("@Age", idade_txt.Text);
                cmd.Parameters.AddWithValue("@Gender", genero_txt.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                LoadGrid();
                MessageBox.Show("Usuário cadastrado com sucesso!", "Sucesso!", MessageBoxButton.OK, MessageBoxImage.Information);
                Limpar();
            }
        }
        private void Atualizar(object sender, RoutedEventArgs e)
        {

        }

        private void Deletar(object sender, TextChangedEventArgs e)
        {

        }

        private void Deletar(object sender, RoutedEventArgs e)
        {

        }

        private void Limpar()
        {
            nome_txt.Clear();
            idade_txt.Clear();
            cidade_txt.Clear();
            genero_txt.Clear();
        }

        private void Limpar(object sender, RoutedEventArgs e)
        {
            Limpar();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}
