using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using DevExpress.Utils.MVVM;
using DevExpress.XtraRichEdit.Import.OpenXml;
using Sistema_de_Gestão_de_Lojas_e_Comércios._2___Classes;

namespace Sistema_de_Gestão_de_Lojas_e_Comércios._1___Forms
{
    public partial class frm_CapturarImagemWebcam : Form
    {
        private FilterInfoCollection _filterInfoCollection;
        private VideoCaptureDevice _videoCaptureDevice;

        public frm_CapturarImagemWebcam()
        {
            InitializeComponent();
            _filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            foreach (FilterInfo filterInfo in _filterInfoCollection)

                cmb_SelecionarCamera.Items.Add(filterInfo.Name);

            cmb_SelecionarCamera.SelectedIndex = 0;
            _videoCaptureDevice = new VideoCaptureDevice();
        }

        private void btn_ConectarWebCam_Click(object sender, EventArgs e)
        {
            AtivarDesativarBotoesWebCam();
            _videoCaptureDevice =
                new VideoCaptureDevice(_filterInfoCollection[cmb_SelecionarCamera.SelectedIndex].MonikerString);
            _videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            _videoCaptureDevice.Start();
        }

        private void AtivarDesativarBotoesWebCam()
        {
            if (btn_CapturarFotoWebCam.Enabled == false)
            {
                btn_CapturarFotoWebCam.Enabled = true;
                btn_Encerrar.Enabled = true;
                btn_SalvarImagem.Enabled = true;
            }
            else
            {
                DesativarBotoesWebCam();
            }
        }

        private void DesativarBotoesWebCam()
        {
            btn_CapturarFotoWebCam.Enabled = false;
            btn_Encerrar.Enabled = false;
            btn_SalvarImagem.Enabled = false;
        }

        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs e)
        {
            pct_ImagemWebCam.Image = (Bitmap)e.Frame.Clone();
        }

        private void btn_TirarFotoWebCam_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetImage(pct_ImagemWebCam.Image);
            pct_FotoTiradaWebcam.Image = Clipboard.GetImage();
            Clipboard.Clear();
        }

        private void btn_Encerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sair da aplicação?", "Saindo...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
            Encerrar();
        }

        private void frm_CapturarImagemWebcam_FormClosing(object sender, FormClosingEventArgs e)
        {
            Encerrar();
        }

        private void Encerrar()
        {
            if (!(_videoCaptureDevice == null))
                if (_videoCaptureDevice.IsRunning)
                {
                    _videoCaptureDevice.NewFrame -= VideoCaptureDevice_NewFrame;
                    _videoCaptureDevice.SignalToStop();
                    _videoCaptureDevice = null;
                }
            AtivarDesativarBotoesWebCam();
        }

        private void btn_SalvarImagem_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = @"Por favor salve esta Foto";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                pct_ImagemWebCam.Image.Save(saveFileDialog.FileName + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                MessageBox.Show(@"Imagem Salva com Sucesso!");
            }
        }
    }
}