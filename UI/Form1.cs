using Service.Implementation;
using Service.Interfaces;

namespace UI
{
    public partial class Form1 : Form
    {
        private readonly IMarcaService _marcaService;
        public Form1(IMarcaService marcaService)
        {
            InitializeComponent();
            _marcaService = marcaService;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            var lista = await _marcaService.listMarcaProducts();
        }
    }
}
