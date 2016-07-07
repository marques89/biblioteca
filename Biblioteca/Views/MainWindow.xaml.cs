using Biblioteca.DAL;
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

namespace Biblioteca.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ////Preencher GRID
            //grdObra.ItemsSource = ObraDAO.BuscarObra();

            ////Preencher COMBO BOX
            //cboObra.ItemsSource = ObraDAO.BuscarObra();
            //cboObra.DisplayMemberPath = "ObraTitulo";
            //cboObra.SelectedValuePath = "ObraId";
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Deseja sair?", "Saindo...",
                MessageBoxButton.YesNo, MessageBoxImage.Question) ==
                MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }
        
        
        private void menuObrasDisponiveis_Click(object sender, RoutedEventArgs e)
        {
            frmObrasDisponiveis frmObrasDisponiveis = new frmObrasDisponiveis();
            frmObrasDisponiveis.ShowDialog();
        }

        private void menuObrasEmprestadas_Click(object sender, RoutedEventArgs e)
        {
            frmObrasEmprestadas frmObrasEmprestadas = new frmObrasEmprestadas();
            frmObrasEmprestadas.ShowDialog();
        }

        private void menuAutor_Click(object sender, RoutedEventArgs e)
        {
            frmAdicionarAutor frmAdicionarAutor = new frmAdicionarAutor();
            frmAdicionarAutor.ShowDialog();
        }

        private void menuEditora_Click(object sender, RoutedEventArgs e)
        {
            frmAdicionarEditora frmAdicionarEditora = new frmAdicionarEditora();
            frmAdicionarEditora.ShowDialog();
        }

        private void menuObra_Click(object sender, RoutedEventArgs e)
        {
            frmAdicionarObra frmAdicionarObra = new frmAdicionarObra();
            frmAdicionarObra.ShowDialog();
        }

        private void menuCliente_Click(object sender, RoutedEventArgs e)
        {
            frmAdicionarCliente frmAdicionarCliente = new frmAdicionarCliente();
            frmAdicionarCliente.ShowDialog();
        }

        private void menuEmprestimoNovo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void menuDevolucaoNovo_Click(object sender, RoutedEventArgs e)
        {

        }


     }
}
