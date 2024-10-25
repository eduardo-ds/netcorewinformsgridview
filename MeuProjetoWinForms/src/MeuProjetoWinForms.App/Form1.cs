using Microsoft.EntityFrameworkCore;

namespace MeuProjetoWinForms.App
{
    public partial class Form1 : Form
    {
        private AppDbContext _context;

        public Form1()
        {
            InitializeComponent();
            _context = new AppDbContext();
            _context.Database.EnsureCreated();
            LoadData();
        }

        private void LoadData()
        {
            var produtos = _context.Produtos.ToList();
            dataGridView1.DataSource = produtos;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var produto = new Produto
            {
                Nome = txtNome.Text,
                Preco = decimal.Parse(txtPreco.Text)
            };
            _context.Produtos.Add(produto);
            _context.SaveChanges();
            LoadData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var selected = dataGridView1.CurrentRow?.DataBoundItem as Produto;
            if (selected != null)
            {
                selected.Nome = txtNome.Text;
                selected.Preco = decimal.Parse(txtPreco.Text);
                _context.SaveChanges();
                LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var selected = dataGridView1.CurrentRow?.DataBoundItem as Produto;
            if (selected != null)
            {
                _context.Produtos.Remove(selected);
                _context.SaveChanges();
                LoadData();
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            var selected = dataGridView1.CurrentRow?.DataBoundItem as Produto;
            if (selected != null)
            {
                txtNome.Text = selected.Nome;
                txtPreco.Text = selected.Preco.ToString();
            }
        }
    }
}
