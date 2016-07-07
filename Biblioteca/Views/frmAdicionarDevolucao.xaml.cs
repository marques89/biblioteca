using Biblioteca.DAL;
using Biblioteca.Models;
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
using System.Windows.Shapes;

namespace Biblioteca.Views
{
    /// <summary>
    /// Interaction logic for frmAdicionarDevolucao.xaml
    /// </summary>
    public partial class frmAdicionarDevolucao : Window
    {
        Emprestimo Emp = new Emprestimo();
        Obra Obra = new Obra();
        Cliente Cliente = new Cliente();

        public frmAdicionarDevolucao()
        {
            InitializeComponent();
            cbxBuscar.ItemsSource = ClienteDAO.RetornarLista();
            cbxBuscar.DisplayMemberPath = "ClienteNome";
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Deseja sair?", "Saindo...",
            MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnGravar_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Deseja realizar a devolução deste empréstimo?", "Cadastro de Devolução",
                 MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (!string.IsNullOrEmpty(cbxEmprestimoCliente.Text))
                {
                    Emp = new Emprestimo(); 
                    Emp = (Emprestimo)cbxEmprestimoCliente.SelectedItem;
                    Emp = EmprestimoDAO.BuscarEmprestimoPorId(Emp);
                    Emp.EmprestimoStatus = "Entregue";
                    Emp.DataDevolucao = Convert.ToString(DateTime.Now);
                    ControleDevolução();
                    if (EmprestimoDAO.AlterarEmprestimo(Emp))
                    {

                        MessageBox.Show("Devolução realizada com sucesso!", "Cadastro de Devolução",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Empréstimo não devolvido!", "Cadastro de Devolução",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    DesabilitarBotoes();
                }
                else
                {
                    MessageBox.Show("* Campos obrigatórios!! Favor preencher.", "Cadastro de Devolução",
                       MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                DesabilitarBotoes();
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            DesabilitarBotoes();
        }

        private void btnBuscarCliente_Click(object sender, RoutedEventArgs e)
        {
            Cliente = new Cliente();

            if (!string.IsNullOrEmpty(cbxBuscar.Text))
            {
                Cliente = (Cliente)cbxBuscar.SelectedItem;
                if (EmprestimoDAO.RetornarListaEmprestimosEmAbertoPorCliente(Cliente).Count > 0)
                {
                    cbxEmprestimoCliente.ItemsSource = EmprestimoDAO.RetornarListaEmprestimosEmAbertoPorCliente(Cliente);
                    cbxEmprestimoCliente.DisplayMemberPath = "EmprestimoId";
                    HabilitarBotoes();
                }
                else
                {
                    MessageBox.Show("Não existem empréstimos em aberto para este cliente!", "Cadastro de Devolução",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    DesabilitarBotoes();
                }

            }
            else
            {
                MessageBox.Show("Favor preencher campo da busca!", "Cadastro de Devolução",
                        MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        public void HabilitarBotoes()
        {
            cbxBuscar.IsEnabled = false;
            btnBuscarCliente.IsEnabled = false;
            btnGravar.IsEnabled = true;
            btnCancelar.IsEnabled = true;
            cbxEmprestimoCliente.IsEnabled = true;


        }

        public void DesabilitarBotoes()
        {

            btnBuscarCliente.IsEnabled = true;
            cbxBuscar.IsEnabled = true;
            cbxBuscar.SelectedItem = null;
            cbxEmprestimoCliente.SelectedItem = null;
            cbxEmprestimoCliente.IsEnabled = false;
            btnGravar.IsEnabled = false;
            cbxBuscar.Focus();
            cbxBuscar.ItemsSource = ClienteDAO.RetornarLista();

        }

        public void ControleDevolução()
        {
            Obra = new Obra();
            Obra = ObraDAO.BuscarObraPorTitulo(Emp.Obra);
            Obra.ObraStatus = 1;
            ObraDAO.AlterarObra(Obra);
        }
    }
}
