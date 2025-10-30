using GeometriaClientRestAPIDesktop.DTOs;
using System.Net.Http.Json;

namespace GeometriaClientRestAPIDesktop
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
        }

        private async void btnActualizarLista_Click(object sender, EventArgs e)
        {
            try
            {
                string url = "https://localhost:8080/api/Geometrias2";

                using var client = new HttpClient();

                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(url)
                };

                var response = await client.SendAsync(request);

                listBox1.Items.Clear();
                if (response.IsSuccessStatusCode)
                {
                    var lista = await response.Content.ReadFromJsonAsync<List<FiguraDTO>>();
                    listBox1.DataSource = lista;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    
}
