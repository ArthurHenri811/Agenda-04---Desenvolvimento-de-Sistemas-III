using System.Collections.ObjectModel;

namespace BuscaProdutos;

public partial class MainPage : ContentPage
{
    public ObservableCollection<Produto> Produtos { get; set; }
    public ObservableCollection<Produto> ProdutosFiltrados { get; set; }

    public MainPage()
    {
        InitializeComponent();

        Produtos = new ObservableCollection<Produto>
        {
            new Produto { Nome = "Arroz" },
            new Produto { Nome = "Feijão" },
            new Produto { Nome = "Macarrão" },
            new Produto { Nome = "Café" },
            new Produto { Nome = "Açúcar" },
            new Produto { Nome = "Leite" },
            new Produto { Nome = "Farinha" },
            new Produto { Nome = "Óleo" }
        };

        ProdutosFiltrados = new ObservableCollection<Produto>(Produtos);

        BindingContext = this;
    }

    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        var filtro = e.NewTextValue?.ToLower() ?? "";

        ProdutosFiltrados.Clear();

        foreach (var item in Produtos)
        {
            if (item.Nome.ToLower().Contains(filtro))
            {
                ProdutosFiltrados.Add(item);
            }
        }
    }
}

public class Produto
{
    public string Nome { get; set; }
}
