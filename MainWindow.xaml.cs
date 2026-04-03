using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GDI.constanta;
using Project_X.Model;

namespace Water_Flow_Simulation_v1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private controller myController;
        private Project_X.Model.Pipa selectedPipa;
        private vertex selectedVertex;
        public MainWindow()
        {
            InitializeComponent();
            p.PROTOKOL = "";
            iniObj();
            initTooltip();
        }
        private void iniObj()
        {
            myController = new controller();
        }
        private void initTooltip()
        {
            lurus.ToolTip = n.PIPA_LURUS;
            belok.ToolTip = n.PIPA_BELOK;
            abesar.ToolTip = n.PIPA_PEMBESARAN_PERLAHAN;
            akecil.ToolTip = n.PIPA_PENGECILAN_PERLAHAN;
            tbesar.ToolTip = n.PIPA_PEMBESARAN_TIBA_TIBA;
            tkecil.ToolTip = n.PIPA_PENGECILAN_TIBA_TIBA;
        }
        private void lurus_Click(object sender, RoutedEventArgs e)
        {
            p.PROTOKOL = p.PIPA_LURUS;
        }
        private void belok_Click(object sender, RoutedEventArgs e)
        {
            p.PROTOKOL = p.PIPA_BELOK;
        }
        private void abesar_Click(object sender, RoutedEventArgs e)
        {
            p.PROTOKOL = p.PIPA_ANGSUR_BESAR;
        }
        private void akecil_Click(object sender, RoutedEventArgs e)
        {
            p.PROTOKOL = p.PIPA_ANGSUR_KECIL;
        }
        private void tbesar_Click(object sender, RoutedEventArgs e)
        {
            p.PROTOKOL = p.PIPA_TIBA_BESAR;
        }
        private void tkecil_Click(object sender, RoutedEventArgs e)
        {
            p.PROTOKOL = p.PIPA_TIBA_KECIL;
        }

        private void canvas1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point titikIni = new Point();
            titikIni.X = e.GetPosition(canvas1).X;
            titikIni.Y = e.GetPosition(canvas1).Y;
            if (p.PROTOKOL == p.DOT_TANGKI_1)
                myController.insertNode(titikIni);
            else if (p.PROTOKOL.Contains(p.PIPA_NAME))
            {
                selectedPipa = myController.insertEdge(titikIni);
            }
            else if (p.PROTOKOL == p.DELETE)
                myController.removeNode(titikIni);
            else if (p.PROTOKOL == p.SELECT)
            {
                selectedPipa = myController.SelectEdge(titikIni);
                selectedVertex = myController.SelectNode(titikIni);
            }
            else if (p.PROTOKOL == p.START) myController.setStart(titikIni);
            else if (p.PROTOKOL == p.END) myController.setDest(titikIni);
            canvas1.Children.Clear();
            myController.drawCircle(canvas1.Children);
            myController.drawLine(canvas1.Children);
            try
            {
                isiBan();
            }
            catch { }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            p.PROTOKOL = p.DOT_TANGKI_1;
        }
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            p.PROTOKOL = p.DELETE;
        }
        private void awal_Click(object sender, RoutedEventArgs e)
        {
            p.PROTOKOL = p.START;
        }
        private void akhir_Click(object sender, RoutedEventArgs e)
        {
            p.PROTOKOL = p.END;
        }



        private void button3_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                selectedPipa.Diameter = double.Parse(diameter.Text);
                selectedPipa.Debit = double.Parse(debit.Text);
                PipaLurus b = new PipaLurus();
                PipaAngsurBesar c = new PipaAngsurBesar();
                PipaAngsurKecil d = new PipaAngsurKecil();
                PipaBelok f = new PipaBelok();
                PipaPembesaranTibaTiba g = new PipaPembesaranTibaTiba();
                PipaPengecilanTibaTiba h = new PipaPengecilanTibaTiba();
                if (selectedPipa.GetType() == b.GetType())
                {

                }
                else if (selectedPipa.GetType() == c.GetType())
                {
                    ((PipaAngsurBesar)selectedPipa).SudutPengecilan = double.Parse(sudutpembesaran.Text);
                    ((PipaAngsurBesar)selectedPipa).Diameter2 = double.Parse(diemater2.Text);
                }
                else if (selectedPipa.GetType() == d.GetType())
                {
                    ((PipaAngsurKecil)selectedPipa).SudutPengecilan = double.Parse(sudutpengecilan.Text);
                    ((PipaAngsurKecil)selectedPipa).Diameter2 = double.Parse(diemater2.Text);
                }
                else if (selectedPipa.GetType() == f.GetType())
                {
                    ((PipaBelok)selectedPipa).Radius = int.Parse(radius.Text);
                }
                else if (selectedPipa.GetType() == g.GetType())
                {
                    ((PipaPembesaranTibaTiba)selectedPipa).Diameter2 = double.Parse(diemater2.Text);
                }
                else if (selectedPipa.GetType() == h.GetType())
                {
                    ((PipaPengecilanTibaTiba)selectedPipa).Diameter2 = double.Parse(diemater2.Text);
                }
            }
            catch {
                MessageBox.Show("pastikan Input anda benar");
            }
        }
        private void isiBan()
        {
            PipaLurus b = new PipaLurus();
            PipaAngsurBesar c = new PipaAngsurBesar();
            PipaAngsurKecil d = new PipaAngsurKecil();
            PipaBelok f = new PipaBelok();
            PipaPembesaranTibaTiba g = new PipaPembesaranTibaTiba();
            PipaPengecilanTibaTiba h = new PipaPengecilanTibaTiba();
            lockTextbox();
            debit.Text = selectedPipa.Debit.ToString();
            debit.IsEnabled = true;
            diameter.Text = selectedPipa.Diameter.ToString();
            diameter.IsEnabled = true;
            namaPipa.Content = n.NAMA_PIPA;
            if (selectedPipa.GetType() == b.GetType())
            {
                namaPipa.Content = n.PIPA_LURUS;
            }
            else if (selectedPipa.GetType() == c.GetType())
            {
                namaPipa.Content = n.PIPA_PEMBESARAN_PERLAHAN;
                sudutpembesaran.Text = ((PipaAngsurBesar)selectedPipa).SudutPengecilan.ToString();
                diemater2.Text = ((PipaAngsurBesar)selectedPipa).Diameter2.ToString();
                sudutpembesaran.IsEnabled = true;
                diemater2.IsEnabled = true;
            }
            else if (selectedPipa.GetType() == d.GetType())
            {
                namaPipa.Content = n.PIPA_PENGECILAN_PERLAHAN;
                sudutpengecilan.Text = ((PipaAngsurKecil)selectedPipa).SudutPengecilan.ToString();
                diemater2.Text = ((PipaAngsurKecil)selectedPipa).Diameter2.ToString();
                sudutpengecilan.IsEnabled = true;
                diemater2.IsEnabled = true;
            }
            else if (selectedPipa.GetType() == f.GetType())
            {
                namaPipa.Content = n.PIPA_BELOK;
                radius.Text = ((PipaBelok)selectedPipa).Radius.ToString() ;
                radius.IsEnabled = true; 
            }
            else if (selectedPipa.GetType() == g.GetType())
            {
                namaPipa.Content = n.PIPA_PEMBESARAN_TIBA_TIBA;
                diemater2.Text = ((PipaPembesaranTibaTiba)selectedPipa).Diameter2.ToString();
                diemater2.IsEnabled = true;
            }
            else if (selectedPipa.GetType() == h.GetType())
            {
                namaPipa.Content = n.PIPA_PENGECILAN_TIBA_TIBA;
                diemater2.Text = ((PipaPengecilanTibaTiba)selectedPipa).Diameter2.ToString();
                diemater2.IsEnabled = true;
            }
        }
        private void lockTextbox()
        {
            diameter.Text = "";
            diameter.IsEnabled = false;
            diemater2.Text = "";
            diemater2.IsEnabled = false;
            debit.Text = "";
            debit.IsEnabled = false;
            sudutpengecilan.Text = "";
            sudutpengecilan.IsEnabled = false;
            sudutpembesaran.Text = "";
            sudutpembesaran.IsEnabled = false;
            radius.Text = "";
            radius.IsEnabled = false;
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            myController.conput();
            View tampilan = new View(myController.hasilnya);
            tampilan.ShowDialog();
        }
    }
}
