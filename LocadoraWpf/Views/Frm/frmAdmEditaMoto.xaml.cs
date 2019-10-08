using LocadoraWpf.DAL;
using LocadoraWpf.Models;
using LocadoraWpf.Views.Controls;
using System;
using System.Windows;


namespace LocadoraWpf.Views.Frm
{
    /// <summary>
    /// Interaction logic for frmAdmEditaMoto.xaml
    /// </summary>
    public partial class frmAdmEditaMoto : Window
    {
        public usListarMoto Usc { get; set; }
        public string Parameter { get; set; }
        public frmAdmEditaMoto(string parameter, usListarMoto usc)
        {
            this.Usc = usc;
            Parameter = parameter;
            InitializeComponent();
            #region Dados da moto
            Moto moto = new Moto();
            moto.Placa = parameter;
            moto = (Moto)VeiculoDAO.Get(null, moto);
            txtNome.Text = moto.Nome;
            txtCor.Text = moto.Cor;
            txtModelo.Text = moto.Modelo;
            txtStatus.Text = moto.Status;
            txtValorPorDia.Text = moto.ValorPorDia.ToString();
            txtValorPorHora.Text = moto.ValorPorHora.ToString(); 
            #endregion
        }

        private void BtnEditarMoto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Moto moto = new Moto();
                if (ValidaCamposEmBranco())
                {
                    moto.Placa = Parameter;
                    moto = (Moto)VeiculoDAO.Get(null, moto);
                    moto.Nome = txtNome.Text;
                    moto.Cor = txtCor.Text;
                    moto.Modelo = txtModelo.Text;                    
                    moto.Status = txtStatus.Text;
                    moto.ValorPorDia = Convert.ToDouble(txtValorPorDia.Text);
                    moto.ValorPorHora = Convert.ToDouble(txtValorPorHora.Text);
                    VeiculoDAO.AlterarDadosVeiculo(null, moto);
                    MessageBox.Show("Dados alterados com sucesso!!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimparCampos();
                    Usc.ListarMoto();
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

        public void LimparCampos()
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

