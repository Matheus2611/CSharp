using LocadoraWpf.DAL;
using LocadoraWpf.Models;
using LocadoraWpf.Views.Controls;
using System;
using System.Windows;


namespace LocadoraWpf.Views.Frm
{
    /// <summary>
    /// Interaction logic for frmAdmEditaCarro.xaml
    /// </summary>
    public partial class frmAdmEditaCarro : Window
    {

        public string Parameter { get; set; }
        public usListarCarro Usc { get; set; }
        public frmAdmEditaCarro(string parameter, usListarCarro usc)
        {
            this.Usc = usc;
            Parameter = parameter;
            InitializeComponent();
            #region Dados do carro
            Carro carro = new Carro();
            carro.Placa = parameter;
            carro = (Carro)VeiculoDAO.Get(carro, null);
            txtNome.Text = carro.Nome;
            txtCor.Text = carro.Cor;
            txtModelo.Text = carro.Modelo;
            txtStatus.Text = carro.Status;
            txtValorPorDia.Text = carro.ValorPorDia.ToString();
            txtValorPorHora.Text = carro.ValorPorHora.ToString();
            #endregion

        }

        private void BtnEditarCarro_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                Carro carro = new Carro();
                if (ValidaCamposEmBranco())
                {
                    carro.Placa = Parameter;
                    carro = (Carro)VeiculoDAO.Get(carro, null);
                    carro.Nome = txtNome.Text;
                    carro.Cor = txtCor.Text;
                    carro.Modelo = txtModelo.Text;
                    carro.Status = txtStatus.Text;
                    carro.ValorPorDia = Convert.ToDouble(txtValorPorDia.Text);
                    carro.ValorPorHora = Convert.ToDouble(txtValorPorHora.Text);

                    VeiculoDAO.AlterarDadosVeiculo(carro, null);

                    MessageBox.Show("Dados alterados com sucesso!!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpaCampos();
                    Usc.ListarCarro();
                    Close();

                }
                else { MessageBox.Show("Favor preencher as informações!", "Mensagem", MessageBoxButton.OK, MessageBoxImage.Error); }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString(), "LocadoraWPF", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void BtnSair_Click(object sender, RoutedEventArgs e) { this.Close(); }

        public bool ValidaCamposEmBranco()
        {
            if (!string.IsNullOrEmpty(txtNome.Text) && !string.IsNullOrEmpty(txtModelo.Text) && !string.IsNullOrEmpty(txtCor.Text) &&
                !string.IsNullOrEmpty(txtStatus.Text) && !string.IsNullOrEmpty(txtValorPorDia.Text) &&
                !string.IsNullOrEmpty(txtValorPorHora.Text))
            { return true; }
            return false;
        }

        public void LimpaCampos()
        {
            txtNome.Clear();
            txtCor.Clear();
            txtModelo.Clear();
            txtStatus.Clear();
            txtValorPorDia.Clear();
            txtValorPorHora.Clear();
        }
    }
}
