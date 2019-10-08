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
    /// Interaction logic for usCadastrarCarro.xaml
    /// </summary>
    public partial class usCadastrarCarro : UserControl
    {        
        public usCadastrarCarro()
        {
            InitializeComponent();
        }

        private void BtnCadastrarCarro_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ValidaCamposEmBranco())
                {
                    Carro carro = new Carro();
                    carro.Nome = txtNome.Text;
                    carro.Marca = txtMarca.Text;
                    carro.Modelo = txtModelo.Text;
                    carro.Cor = txtCor.Text;
                    carro.Ano = Convert.ToInt32(txtAno.Text);
                    carro.Placa = txtPlaca.Text;
                    carro.ValorPorDia = Convert.ToDouble(txtValorPorDia.Text);
                    carro.ValorPorHora = Convert.ToDouble(txtValorPorHora.Text);
                    carro.Status = "DISPONIVEL";

                    if (VeiculoDAO.CadastrarVeiculo(carro, null))
                    {
                        MessageBox.Show("Cadastro Efetuado com secesso", "LocadoraWPF", MessageBoxButton.OK, MessageBoxImage.Information);
                        LimparCampos();
                    }
                    else { MessageBox.Show("Erro ao efetuar o cadastro ", "LocadoraWPF", MessageBoxButton.OK, MessageBoxImage.Error); } 
                }
                else
                { MessageBox.Show("Preencha todos os campos!", "LocadoraWPF", MessageBoxButton.OK, MessageBoxImage.Information); }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString(), "LocadoraWPF", MessageBoxButton.OK, MessageBoxImage.Error); }
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
