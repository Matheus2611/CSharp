using LocadoraWpf.DAL;
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
    /// Interaction logic for usHistoricoReserva.xaml
    /// </summary>
    public partial class usHistoricoReserva : UserControl
    {
        public usHistoricoReserva()
        {
            InitializeComponent();
            ListarReserva();
        }

        public void ListarReserva()
        {
            ListarReservas.ItemsSource = ReservaDAO.ListarReservas();
            ListarReservas.CanUserAddRows = false;
            ListarReservas.IsReadOnly = true;
            ListarReservas.AutoGenerateColumns = false;
            ListarReservas.CanUserDeleteRows = false;
        }
    }
}
