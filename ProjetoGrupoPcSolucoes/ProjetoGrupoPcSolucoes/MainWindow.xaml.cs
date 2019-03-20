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
using ProjetoGrupoPcSolucoes.Conexao;

namespace ProjetoGrupoPcSolucoes
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        string Controle;


        public MainWindow()
        {
            InitializeComponent();
            //WindowState = WindowState.Maximized;
            this.PopularGrid();
            this.ModIcluir();
        }
        #region Tabela

        private void grdCliente_MouseDoubleClick(object sender, RoutedEventArgs e)
        {

            if (grdCliente.SelectedIndex >= 0)
            {
                ResultCliente obj = (ResultCliente)grdCliente.Items[grdCliente.SelectedIndex];
                Controle = "Editar";
                this.ExibirCliente(obj.CodCliente);
                this.ModIcEditarExcluir();
            }
        }

        private void PopularGrid()
        {
            ClienteBO clienteBO = new ClienteBO();
            grdCliente.ItemsSource = clienteBO.ListarGridCliente();
        }

        private void ExibirCliente(int CodCliente)
        {
            ClienteBO clienteBO = new ClienteBO();
            cliente obj = clienteBO.BuscarClienteId(CodCliente);


            txtNome.Text = obj.NomFantasia;
            txtCpf.Text = obj.Cpf;
            txtCnpj.Text = obj.Cnpj;
            txtRazaoSocial.Text = obj.RazaoSocial;
            txtDtIniciAtividade.Text = obj.DtAtividade.ToString();
            txtDtNacimento.Text = obj.DtNacimento.ToString();
            txtEndereco.Text = obj.Endereço;
            txtNumero.Text = obj.Numero.ToString();
            txtCep.Text = obj.Cep;
            txtTelefone.Text = obj.Fone;
            txtEmail.Text = obj.Email;
            txtCodCliente.Text = obj.CodCliente.ToString();


            if (obj.TipInscricao == "J")
            {
                rbdCnpj.IsChecked = true;
                this.ModPessoaJuridica();
            }
            else
            {
                rbdCpf.IsChecked = true;
                this.ModPessoaFisica();

            }

        }
        #endregion



        #region Dados Cliente

        private void ModPessoaJuridica()
        {
            txtDtIniciAtividade.IsEnabled = true;
            txtCnpj.IsEnabled = true;
            txtRazaoSocial.IsEnabled = true;
            txtCpf.Text = null;
            txtDtNacimento.Text = null;

            txtDtNacimento.IsEnabled = false;
            txtCpf.IsEnabled = false;
        }

        private void ModPessoaFisica()
        {
            txtDtIniciAtividade.IsEnabled = false;
            txtCnpj.IsEnabled = false;
            txtRazaoSocial.IsEnabled = false;
            txtCnpj.Text = null;
            txtRazaoSocial.Text = null;
            txtDtIniciAtividade.Text = null;

            txtDtNacimento.IsEnabled = true;
            txtCpf.IsEnabled = true;
        }

        private void txtEndereco_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void rbdCnpj_Checked(object sender, RoutedEventArgs e)
        {
            this.ModPessoaJuridica();
        }

        private void rbdCpf_Checked(object sender, RoutedEventArgs e)
        {
            this.ModPessoaFisica();
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            this.Salvar();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            this.Salvar();
        }

        private void btnLimpar_Click(object sender, RoutedEventArgs e)
        {
            this.LimparCampos();
        }

        private void btnDeletar_Click(object sender, RoutedEventArgs e)
        {
            ClienteBO clienteBO = new ClienteBO();
            MessageBoxResult result = MessageBox.Show("Deseja Deletar o Cliente? Está ação é irreversível!", "", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                string msg = clienteBO.Deletar(int.Parse(txtCodCliente.Text.ToString()));
                MessageBox.Show(msg);
                this.PopularGrid();
                this.LimparCampos();
                this.ModPessoaFisica();
            }
        }

        private void btnPesquisa_Click(object sender, RoutedEventArgs e)
        {
            cliente obj = new cliente();
            ClienteBO clienteBO = new ClienteBO();
            obj.NomFantasia = txtPesquisa.Text.ToString();
            grdCliente.ItemsSource = clienteBO.Pesquisar(obj);
        }

        private string Salvar()
        {
            cliente obj = new cliente();
            ClienteBO clinteBO = new ClienteBO();

            obj.NomFantasia = txtNome.Text.ToString();
            obj.Cpf = txtCpf.Text.ToString();
            obj.Cnpj = txtCnpj.Text.ToString();
            obj.RazaoSocial = txtRazaoSocial.Text.ToString();
            obj.DtAtividade = null;
            obj.DtNacimento = null;
            obj.Endereço = txtEndereco.Text.ToString();

            obj.Cep = txtCep.Text.ToString();
            obj.Fone = txtTelefone.Text.ToString();
            obj.Email = txtEmail.Text.ToString();

            if (txtNumero.Text != "")
            {
                if ((int.Parse(txtNumero.Text.ToString()) >= 0))
                {
                    obj.Numero = int.Parse(txtNumero.Text.ToString());
                }
                else
                {
                    MessageBox.Show("Insira um número valido!");
                }
            }
            else
            {
                MessageBox.Show("Insira um número valido!");
            }

            if (rbdCnpj.IsChecked.Value == true)
            {
                obj.TipInscricao = "J";
                string ValidaData = this.ValidarData(txtDtIniciAtividade.Text.ToString());
                if (ValidaData == "")
                {
                    obj.DtAtividade = DateTime.Parse(txtDtIniciAtividade.Text.ToString());
                }
                else
                {
                    MessageBox.Show("Data Incorreta!");
                    return "";
                }

            }
            else
            {
                obj.TipInscricao = "F";
                string ValidaData = this.ValidarData(txtDtNacimento.Text.ToString());
                if (ValidaData == "")
                {
                    obj.DtNacimento = DateTime.Parse(txtDtNacimento.Text.ToString());
                }
                else
                {
                    MessageBox.Show("Data Incorreta!");
                    return "";
                }

            }

            if (Controle == "Incluir")
            {
                string msg = clinteBO.InserirCliente(obj);
                MessageBox.Show(msg);
                this.LimparCampos();
            }
            else
            {
                obj.CodCliente = int.Parse(txtCodCliente.Text.ToString());
                string msg = clinteBO.EditarCliente(obj);
                MessageBox.Show(msg);
                if (msg == "Cliente Inserido com sucesso!")
                {
                    Controle = "Incluir";
                }
            }

            this.PopularGrid();
            return "";
        }

        private void ModIcluir()
        {
            lblTitulo.Content = "Cadastro de Clientes";
            btnEditar.IsHitTestVisible = false;
            btnSalvar.IsHitTestVisible = true;
            btnDeletar.IsHitTestVisible = false;
            btnLimpar.IsHitTestVisible = false;
            Controle = "Incluir";
            rbdCpf.IsChecked = true;
        }

        private void ModIcEditarExcluir()
        {
            lblTitulo.Content = "Editar ou Excluir Cliente";
            btnEditar.IsHitTestVisible = true;
            btnSalvar.IsHitTestVisible = false;
            btnDeletar.IsHitTestVisible = true;
            btnLimpar.IsHitTestVisible = true;
        }

        private void LimparCampos()
        {
            txtNome.Text = null;
            txtCpf.Text = null;
            txtCnpj.Text = null;
            txtRazaoSocial.Text = null;
            txtDtIniciAtividade.Text = null;
            txtDtNacimento.Text = null;
            txtEndereco.Text = null;
            txtNumero.Text = null;
            txtCep.Text = null;
            txtTelefone.Text = null;
            txtEmail.Text = null;
            txtCodCliente.Text = null;

            this.ModPessoaFisica();
            this.ModIcluir();
        }

        private string ValidarData(string Data)
        {
            if (Data != "")
            {
                var array = Data.Split(new string[] { "/" }, // lista de separadores complexos
                StringSplitOptions.RemoveEmptyEntries);
                var arrayAno = array[2].Split(new string[] { " " }, // lista de separadores complexos
                  StringSplitOptions.RemoveEmptyEntries);
                string dia = array[0];
                string mes = array[1];
                string ano = arrayAno[0];

                if ((int.Parse(dia) > 31) || (int.Parse(mes) > 12 || (int.Parse(ano) > DateTime.Now.Year)))
                {
                    return "Data de nacimento incorreta!";
                }
                return "";
            }
            else
            {
                return "Insira uma Data.";
            }

        }

        #endregion


    }
}
