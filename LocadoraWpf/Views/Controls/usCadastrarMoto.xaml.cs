using LocadoraWpf.DAL;
using LocadoraWpf.Models;
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

namespace LocadoraWpf.Views.Controls
{
    /// <summary>
    /// Interaction logic for usCadastrarMoto.xaml
    /// </summary>
    public partial class usCadastrarMoto : UserControl
    {
        public usCadastrarMoto()
        {
            InitializeComponent();
        }

        private void BtnCadastrarMoto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ValidaCamposEmBranco())
                {
                    Moto moto = new Moto();
                    moto.Nome = txtNome.Text;
                    moto.Marca = txtMarca.Text;
                    moto.Modelo = txtModelo.Text;
                    moto.Cor = txtModelo.Text;
                    moto.Ano = Convert.ToInt32(txtAno.Text);
                    moto.Placa = txtPlaca.Text;
                    moto.ValorPorDia = Convert.ToDouble(txtValorPorDia.Text);
                    moto.ValorPorHora = Convert.ToDouble(txtValorPorHora.Text);
                    moto.Status = "DISPONIVEL";

                    if (VeiculoDAO.CadastrarVeiculo(null, moto))
                    {
                        MessageBox.Show("Cadastro Efetuado com secesso", "LocadoraWPF", MessageBoxButton.OK, MessageBoxImage.Information);
                        LimparCampos();
                    }
                    else
                    { MessageBox.Show("Erro ao efetuar o cadastro, tente novamente ", "LocadoraWPF", MessageBoxButton.OK, MessageBoxImage.Error); }
                }
                else { MessageBox.Show("Erro ao efetuar o cadastro, tente novamente ", "LocadoraWPF", MessageBoxButton.OK, MessageBoxImage.Error); }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString(), "LocadoraWPF", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        public void LimparCampos()
        {
            txtNome.Clear();
            txtMarca.Clear();
            txtModelo.Clear();
            txtCor.Clear();
            txtAno.Clear();
            txtPlaca.Clear();
            txtValorPorDia.Clear();
            txtValorPorHora.Clear();
        }

        public bool ValidaCamposEmBranco()
        {
            if (!string.IsNullOrEmpty(txtNome.Text) && !string.IsNullOrEmpty(txtMarca.Text) && !string.IsNullOrEmpty(txtModelo.Text) &&
                !string.IsNullOrEmpty(txtCor.Text) && !string.IsNullOrEmpty(txtAno.Text) && !string.IsNullOrEmpty(txtPlaca.Text) &&
                !string.IsNullOrEmpty(txtValorPorDia.Text) && !string.IsNullOrEmpty(txtValorPorHora.Text))
            { return true; }
            return false;
        }
    }
}
