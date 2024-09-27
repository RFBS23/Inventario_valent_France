using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace presentacion
{
    public partial class frmConfiguracion : Form
    {
        public frmConfiguracion()
        {
            InitializeComponent();
        }

        private void frmConfiguracion_Load(object sender, EventArgs e)
        {
            bool obtenido = true;
            byte[] byteimage = new NNegocio().ObtenerLogo(out obtenido);

            if (obtenido)
                piclogo.Image = ByteToImage(byteimage);

            Negocios datos = new NNegocio().ObtenerDatos();
            txtnombre.Text = datos.nombre;
            txtdireccion.Text = datos.direccion;
            txtrucempresa.Text = datos.ruc;
        }

        public Image ByteToImage(byte[] imageBytes)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    Image image = Image.FromStream(ms);
                    return new Bitmap(image); // Para asegurar que el nuevo objeto Bitmap no está ligado al MemoryStream original
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción según tus necesidades
                Console.WriteLine("Error al convertir bytes a imagen: " + ex.Message);
                return null;
            }
        }

        private async void btnbuscar_Click(object sender, EventArgs e)
        {
            if (txtruc.Text.Length == 11)
            {
                string apiUrl = $"https://api.apis.net.pe/v1/ruc?numero={txtruc.Text}";
                try
                {
                    using (HttpClient client = new HttpClient())
                    {
                        HttpResponseMessage response = await client.GetAsync(apiUrl);
                        if (response.IsSuccessStatusCode)
                        {
                            string jsonResponse = await response.Content.ReadAsStringAsync();
                            dynamic json = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonResponse);

                            if (json != null)
                            {
                                txtrucempresa.Text = $"{json.numeroDocumento}";
                                txtnombre.Text = $"{json.nombre}";
                                txtdireccion.Text = $"{json.direccion}";
                            }
                            else
                            {
                                MessageBox.Show("La respuesta de la API no tiene el formato esperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show($"No se ha podido encontrar el dni buscado..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al obtener la información del DNI: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSubirImg_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            OpenFileDialog oOpenFileDialog = new OpenFileDialog();
            oOpenFileDialog.FileName = "*.jpg;*.jpeg;*.png";

            if (oOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                byte[] byteimage = File.ReadAllBytes(oOpenFileDialog.FileName);
                bool respuesta = new NNegocio().ActualizarLogo(byteimage, out mensaje);

                if (respuesta)
                    piclogo.Image = ByteToImage(byteimage);
                else
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            String mensaje = string.Empty;
            Negocios obj = new Negocios()
            {
                nombre = txtnombre.Text,
                ruc = txtrucempresa.Text,
                direccion = txtdireccion.Text
            };
            bool respuesta = new NNegocio().GuardarDatos(obj, out mensaje);
            if (respuesta)
                MessageBox.Show("Los cambios fueron guardados correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo guardar los cambios", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

    }
}
