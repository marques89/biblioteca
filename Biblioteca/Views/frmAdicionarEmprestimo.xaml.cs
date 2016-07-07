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
    /// Interaction logic for frmAdicionarEmprestimo.xaml
    /// </summary>
    public partial class frmAdicionarEmprestimo : Window
    {
        Emprestimo Emp = new Emprestimo();
        Emprestimo EmpControle = new Emprestimo();
        Obra Obra = new Obra();
        Cliente Cliente = new Cliente();

        public frmAdicionarEmprestimo()
        {
            InitializeComponent();

            cbxBuscar.ItemsSource = EmprestimoDAO.RetornarListaEmprestimosEmAberto();
            cbxBuscar.DisplayMemberPath = "EmprestimoId";
            cbxCliente.ItemsSource = ClienteDAO.RetornarLista();
            cbxCliente.DisplayMemberPath = "ClienteNome";
            cbxObra.ItemsSource = ObraDAO.RetornarListaObrasDisponiveis();
            cbxObra.DisplayMemberPath = "ObraTitulo";
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

        private void btnGravar_Click(object sender, RoutedEventArgs e)
        {
            Obra = new Obra();
            Emp = new Emprestimo();

            if (cbxCliente.Text.Equals(string.Empty) || cbxObra.Text.Equals(string.Empty))
            {
                MessageBox.Show("* Campos obrigatórios!! Favor preencher.", "Cadastro de Empréstimo",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {

                Cliente = (Cliente)cbxCliente.SelectedItem;
                Emp.Cliente = Cliente;
                Obra = (Obra)cbxObra.SelectedItem;
                Emp.Obra = Obra;
                Emp.DataRetirada = Convert.ToString(DateTime.Now);
                Emp.EmprestimoStatus = "Em aberto";
                if (EmprestimoDAO.AdicionarEmprestimo(Emp))
                {
                    //Altera o status da obra para 0, indisponível
                    ControleEmprestimo();
                    MessageBox.Show("Empréstimo cadastrado com sucesso!!", "Cadastro de Empréstimo",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Não foi possível gravar!", "Cadastro de Empréstimo",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
                DesabilitarBotoes();
            }

        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            Emp = new Emprestimo();

            if (!string.IsNullOrEmpty(cbxBuscar.Text))
            {
                Emp = (Emprestimo)cbxBuscar.SelectedItem;
                //EmpControle serve para controlar a troca de status da obra quando é realizado uma alteração no empréstimo
                EmpControle = (Emprestimo)cbxBuscar.SelectedItem;
                Emp = EmprestimoDAO.BuscarEmprestimoPorId(Emp);
                EmpControle = EmprestimoDAO.BuscarEmprestimoPorId(EmpControle);
                if (Emp != null)
                {
                    cbxObra.ItemsSource = ObraDAO.RetornarLista();
                    cbxCliente.SelectedItem = Emp.Cliente;
                    cbxObra.SelectedItem = Emp.Obra;
                    HabilitarBotoes();
                }
                else
                {
                    MessageBox.Show("Obra não encontrado!", "Cadastro de Obra",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Favor preencher campo da busca!", "Cadastro de Obra",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            DesabilitarBotoes();
        }

        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show("Deseja alterar esta Obra?", "Cadastro de Obra", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (cbxCliente.Text.Equals(string.Empty) || cbxObra.Text.Equals(string.Empty))
                {
                    MessageBox.Show("* Campos obrigatórios!! Favor preencher.", "Cadastro de Empréstimo",
                            MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    //Realiza a mudança de status do filme que estava emprestado para 1 - Disponível
                    ControleDevolução();
                    //Obra auxiliar para nao deixar atribuir obra com status 0
                    Obra ObraAux = new Obra();
                    ObraAux = ObraDAO.BuscarObraPorTitulo((Obra)cbxObra.SelectedItem);
                    if (ObraAux.ObraStatus == 0 )
                    {
                        MessageBox.Show("Obra " + ObraAux.ObraTitulo + " indisponível para empréstimo!", "Cadastro de Empréstimo",
                             MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        //Atribui os valores selecionados ao empréstimo                        
                        Obra = (Obra)cbxObra.SelectedItem;
                        Emp.Obra = Obra;
                        Emp.DataRetirada = Convert.ToString(DateTime.Now);
                        Emp.EmprestimoStatus = "Em aberto";
                    }
                    //Realiza a atribuição de alteração do cliente se existir, mesmo que a obra não tenha sido alterada devido ao status;
                    Cliente = (Cliente)cbxCliente.SelectedItem;
                    Emp.Cliente = Cliente;
                    if (EmprestimoDAO.AlterarEmprestimo(Emp))
                    {
                        //Reliza a troca de status da obra, uma vez que esta foi emprestada.
                        ControleEmprestimo();
                        MessageBox.Show("Emprestimo alterado com sucesso!", "Cadastro de Empréstimo", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Erro ao alterar empréstimo!", "Cadastro de Empréstimo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                DesabilitarBotoes();
            }
            else
            {
                DesabilitarBotoes();
            }

        }

        private void btnRemover_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Deseja remover este Empréstimo?", "Remover Empréstimo",
                 MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                //Realiza a alteração do status da obra que estava emprestada para 1 - disponível, devido a remoção deste empréstimo do sistema
                ControleDevolução();
                if (EmprestimoDAO.RemoverEmprestimo(Emp))
                {
                    MessageBox.Show("Empréstimo removido com sucesso!", "Cadastro de Empréstimo",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Empréstimo não removido!", "Cadastro de Empréstimo",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
                DesabilitarBotoes();
            }
            else
            {
                DesabilitarBotoes();
            }
        }

        public void HabilitarBotoes()
        {
            btnAlterar.IsEnabled = true;
            btnRemover.IsEnabled = true;
            btnGravar.IsEnabled = false;

        }

        public void DesabilitarBotoes()
        {
            btnAlterar.IsEnabled = false;
            btnRemover.IsEnabled = false;
            btnGravar.IsEnabled = true;
            cbxBuscar.SelectedItem = null;
            cbxCliente.SelectedItem = null;
            cbxObra.SelectedItem = null;
            cbxBuscar.Focus();
            cbxBuscar.ItemsSource = EmprestimoDAO.RetornarListaEmprestimosEmAberto();
            cbxCliente.ItemsSource = ClienteDAO.RetornarLista();
            cbxObra.ItemsSource = ObraDAO.RetornarListaObrasDisponiveis();


        }

        public void ControleEmprestimo()
        {
            Obra = new Obra();
            Obra = ObraDAO.BuscarObraPorTitulo(Emp.Obra);
            Obra.ObraStatus = 0;
            ObraDAO.AlterarObra(Obra);

        }

        public void ControleDevolução()
        {
            Obra = new Obra();
            Obra = ObraDAO.BuscarObraPorTitulo(EmpControle.Obra);
            Obra.ObraStatus = 1;
            ObraDAO.AlterarObra(Obra);
        }


    }
}
