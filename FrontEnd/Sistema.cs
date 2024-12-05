using Core._03_Entidades;
using FrontEnd.Models.DTO;
using FrontEnd.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal._03_Entidade;
using TrabalhoFinal._03_Entidade.DTOs;

namespace FrontEnd;

public class Sistema
{

    private readonly PessoaUC _pessoaUC;
    private readonly ProdutoUC _produtoUC;
    private readonly CarrinhoUC _carrinhoUC;
    private readonly EnderecoUC _enderecoUC;
    public Produto IdProd { get; set; }
    private static Pessoa UsuarioLogado { get; set; }

    public Sistema(HttpClient client)
    {
        _pessoaUC = new PessoaUC(client);
        _produtoUC = new ProdutoUC(client);
        _carrinhoUC = new CarrinhoUC(client);
        _enderecoUC = new EnderecoUC(client);
    }

    public void InicializarSistema()
    {

        int resposta = -1;

        while (resposta != 0)
        {
            if (UsuarioLogado == null)
            {
                resposta = ExibirLogin();
                if (resposta == 1)
                {
                    FazerLogin();
                }
                else if (resposta == 2)
                {
                    Pessoa usuario = CriarUsuario();
                    _pessoaUC.CadastrarUsuario(usuario);
                    Console.WriteLine("Usuário cadastrado com sucesso!");

                }
                else if (resposta == 3)
                {
                    List<Pessoa> ususarios = _pessoaUC.ListarUsuario();
                    foreach (Pessoa u in ususarios)
                    {
                        Console.WriteLine(u.ToString());
                    }
                }
            }
            else if (UsuarioLogado.E_funcionario == true)
            {
                ExibirMenuPrincipalFuncionário();
            }

            else if (UsuarioLogado.E_funcionario == false)
            {
                ExibirMenuPrincipalUsuario();
            }

        }
    }
    public int ExibirLogin()
    {
        Console.WriteLine("------ LOGIN ------");
        Console.WriteLine("1 - Deseja fazer login");
        Console.WriteLine("2 - Deseja se cadastrar");
        Console.WriteLine("3 - Listar usuario cadastrado");

        return int.Parse(Console.ReadLine());
    }

    public Pessoa CriarUsuario()
    {
        Pessoa usuario = new Pessoa();
        Console.WriteLine("Qual é o seu nome?");
        usuario.Nome = Console.ReadLine();
        Console.WriteLine("Qual é o seu username?");
        usuario.UserName = Console.ReadLine();
        Console.WriteLine("Qual é a sua senha?");
        usuario.Senha = Console.ReadLine();
        Console.WriteLine("Qual é o seu email?");
        usuario.Email = Console.ReadLine();
        Console.WriteLine("Você é funcionário da loja?");
        Console.WriteLine("1 - Sim, sou");
        Console.WriteLine("2 - Não, não sou");
        int resposta = int.Parse(Console.ReadLine());
        if (resposta == 1)
        {
            usuario.E_funcionario = true;
        }
        else if (resposta == 2)
        {
            usuario.E_funcionario = false;
        }
        else
        {
            Console.WriteLine("Escolha uma opção válida");
        }

        return usuario;
    }
    public void FazerLogin()
    {
        Console.WriteLine("Digite seu username?");
        string username = Console.ReadLine();
        Console.WriteLine("Digite sua senha?");
        string senha = Console.ReadLine();
        LoginDTO usuDTO = new LoginDTO
        {
            UserName = username,
            Senha = senha
        };
        Pessoa usuario = _pessoaUC.FazerLogin(usuDTO);
        if (usuario == null)
        {
            Console.WriteLine("Não foi possível fazer o login. Usuário ou senha inválidos");
        }
        UsuarioLogado = usuario;
        Console.WriteLine("Logado");

    }
    public void ExibirMenuDoCarrinho()
    {
        Console.WriteLine("---------- O que você deseja fazer? ----------");
        Console.WriteLine("1 - Comprar os Itens do carrinho");
        Console.WriteLine("2 - Excluir Produto carrinho");
        Console.WriteLine("3 - Adicionar mais Produto carrinho");
        Console.WriteLine("Qual ação você deseja realizar?");
    }

    public void ExibirMenuPrincipalUsuario()
    {
        Console.WriteLine("---------- Qual das opções abaixo você deseja realizar? ----------");
        Console.WriteLine("1 - Listar Produtos");
        Console.WriteLine("2 - Realizar uma compra");
        Console.WriteLine("3 - Vizualizar meu carrinho");
        int resposta = int.Parse(Console.ReadLine());

        if (resposta == 1)
        {
            Console.WriteLine("---------- Produto ----------");
            List<Produto> produtos = _produtoUC.ListarProduto();

            foreach (Produto p in produtos)
            {

                Console.WriteLine(p.ToString());
            }

        }
        else if (resposta == 2)
        {
            List<Produto> produtos = _produtoUC.ListarProduto();
            Console.WriteLine($"----------Produtos-----------");
            foreach (Produto p in produtos)
            {
                Console.WriteLine(p.ToString());
            }
            Carrinho carrinho = RealizarCompra();

            _carrinhoUC.ComprarProduto(carrinho);
            List<CarrinhoDTO> carrinhoDTOs = _carrinhoUC.ListarCarrinhoPorId(UsuarioLogado);
            foreach (CarrinhoDTO ca in carrinhoDTOs)
            {
                Console.WriteLine(ca.ToString());

            }
        }
        else if (resposta == 3)
        {
                VizualizarCarrinho();
            
        }

    }
    public void ExibirMenuPrincipalFuncionário()
    {
        Console.WriteLine("---------- Qual das opções abaixo você deseja realizar? ----------");
        Console.WriteLine("1 - Listar Produtos");
        Console.WriteLine("2 - Cadastrar Produtos");
        Console.WriteLine("3 - Realizar uma compra");
        Console.WriteLine("4 - Vizualizar meu carrinho");
        int resposta = int.Parse(Console.ReadLine());

        if (resposta == 1)
        {
            Console.WriteLine("---------- Produto ----------");
            List<Produto> produtos = _produtoUC.ListarProduto();

            foreach (Produto p in produtos)
            {

                Console.WriteLine(p.ToString());
            }

        }
        else if (resposta == 2)
        {
            Produto produto = CriarProduto();
            _produtoUC.CadastrarProduto(produto);
            Console.WriteLine("Usuário cadastrado com sucesso!");
        }
        else if (resposta == 3)
        {
            List<Produto> produtos = _produtoUC.ListarProduto();
            Console.WriteLine($"----------Produtos-----------");
            foreach (Produto p in produtos)
            {
                Console.WriteLine(p.ToString());
            }
            Carrinho carrinho = RealizarCompra();

            _carrinhoUC.ComprarProduto(carrinho);
            List<CarrinhoDTO> carrinhoDTOs = _carrinhoUC.ListarCarrinhoPorId(UsuarioLogado);
            foreach (CarrinhoDTO ca in carrinhoDTOs)
            {
                Console.WriteLine(ca.ToString());

            }
        }
        else if (resposta == 4)
        {
            VizualizarCarrinho();
        }

    }
    public Produto CriarProduto()
    {
        Produto pro = new Produto();
        Console.WriteLine("Qual é o Produto?");
        pro.Nome = Console.ReadLine();
        Console.WriteLine("Qual é o preço?");
        pro.Preco = int.Parse(Console.ReadLine());
        Console.WriteLine("Produto cadastrado com sucesso");
        return pro;
    }

    public Carrinho RealizarCompra()
    {
        int resposta = 1;
        Carrinho car = new Carrinho();
        while (resposta == 1)
        {
            Console.WriteLine("Qual é o id do produto?");
            car.IdProduto = int.Parse(Console.ReadLine());
            car.IdPessoa = UsuarioLogado.Id;
            _carrinhoUC.ComprarProduto(car);

            Console.WriteLine("Deseja colocar mais algum produto no carrinho?");
            Console.WriteLine("1 -Sim, desejo");
            Console.WriteLine("2 - Não, obrigado(a)");
            resposta = int.Parse(Console.ReadLine());

            if (resposta == 1)
            {
                Carrinho carrinho1 = RealizarCompra();
                _carrinhoUC.ComprarProduto(carrinho1);
                Console.WriteLine($"Produto adicionado ao carrinho com sucesso");
            }
        }

        List<CarrinhoDTO> carrinhoDTOs = _carrinhoUC.ListarCarrinhoPorId(UsuarioLogado);
        foreach (CarrinhoDTO ca in carrinhoDTOs)
        {
            Console.WriteLine(ca.ToString());

        }
        Console.WriteLine($"Produto adicionado ao carrinho com sucesso");
        Finalizar();

        return car;

    }

    public void Retirada()
    {
        int idEndereco = 0;
        Console.WriteLine("Qual das opções baixo você deseja realizar?");
        Console.WriteLine("1 -Desejo receber em casa ");
        Console.WriteLine("2 - Desejo retirar na loja");
        int resp = int.Parse(Console.ReadLine());
        if (resp == 1)
        {
            Console.WriteLine("Você já tem endereço cadastrado?");
            Console.WriteLine("1 - Sim");
            Console.WriteLine("2 - Não");
            int resposta = int.Parse(Console.ReadLine());
            if (resposta == 1)
            {
                Console.WriteLine("Qual é o id do endereço que você deseja que a entrega seja feita?");
                _enderecoUC.ListarEnderecoPorId(UsuarioLogado);
                List<Endereco> enderecos = _enderecoUC.ListarEnderecoPorId(UsuarioLogado);
                foreach (Endereco en in enderecos)
                {
                    Console.WriteLine(en.ToString());
                    Console.WriteLine($"-------------");
                }
                idEndereco = int.Parse(Console.ReadLine());
                Console.WriteLine($"Endereço {idEndereco} selecionado com sucesso");

            }
            else if (resposta == 2)
            {

                Endereco end = CriarEndereco();
                end = _enderecoUC.AdicionarEndereco(end);
                idEndereco = end.id;
            }

        }
        else if (resp == 2)
        {
            Console.WriteLine("Pode retirar dentro de 3 dias úteis");

        }
    }
    public Endereco CriarEndereco()
    {
        Endereco endereco = new Endereco();
        Console.WriteLine("Qual é a sua rua?");
        endereco.Rua = Console.ReadLine();
        Console.WriteLine("Qual é o número da sua casa?");
        endereco.Numero = int.Parse(Console.ReadLine());
        Console.WriteLine("Qual é o seu bairro?");
        endereco.Bairro = Console.ReadLine();
        Console.WriteLine("Endereço cadastrado com sucesso");
        endereco.UsuarioId = UsuarioLogado.Id;
        return endereco;
    }
    public void Finalizar()
    {
        Retirada();
        Pagamento();
        Venda venda = new Venda();

        List<CarrinhoDTO> carrinhoDTOs = _carrinhoUC.ListarCarrinhoPorId(UsuarioLogado);

        double total = 0;

        foreach (CarrinhoDTO ca in carrinhoDTOs)
        {
            total += ca.Produto.Preco;

        }
        if (total >= 100)
        {
            Console.WriteLine("Parabéns!! Comprando mais que R$100 na loja, você ganhou o desconto de 10%!");
            double desconto = total * 0.1;
            double resultado = total - desconto;
            Console.WriteLine($"Total: R$ {total:F2}");
            Console.WriteLine($"Valor final com desconto: R$ {resultado:F2}");
            Encerrar();
        }
        else
        {
            Console.WriteLine($"Total do carrinho: {total}");
        }


        // Console.WriteLine("Os produtos serão entregues no endereço abaixo");
        List<Endereco> enderecos = _enderecoUC.ListarEnderecoPorId(UsuarioLogado);
        foreach (Endereco en in enderecos)
        {
            Console.WriteLine(en.ToString());
            Console.WriteLine($"--------------------------");
        }

    }

    public void Encerrar()
    {
        Console.WriteLine("Obrigada por comprar na Glow!");
    }
    public void Pagamento()
    {
        Console.WriteLine("Selecione a forma de pagamento");
        Console.WriteLine("1 - Cartão de Crédito");
        Console.WriteLine("2 - Pix");
        Console.WriteLine("3 - Boleto");
        int esc = int.Parse(Console.ReadLine());
        if (esc == 1)
        {
            Console.WriteLine("Você selecionou o Cartão de Crédito como forma de pagamento.");
            if (UsuarioLogado.E_funcionario == true)
            {
                List<CarrinhoDTO> carrinhoDTOs = _carrinhoUC.ListarCarrinhoPorId(UsuarioLogado);
                double total = 0;

                foreach (CarrinhoDTO ca in carrinhoDTOs)
                {
                    total += ca.Produto.Preco;

                }
                Console.WriteLine("Bonus!! Por ser um funcionário da loja, você ganhou o desconto de 5%!");
                double desconto = total * 0.1;
                double resultado = total - desconto;
                Console.WriteLine($"Total: R$ {total:F2}");
                Console.WriteLine($"Valor final com desconto: R$ {resultado:F2}");
            }

        }
        else if (esc == 2)
        {

            Console.WriteLine("Você selecionou o Pix como forma de pagamento.");
            if (UsuarioLogado.E_funcionario == true)
            {
                List<CarrinhoDTO> carrinhoDTOs = _carrinhoUC.ListarCarrinhoPorId(UsuarioLogado);
                double total = 0;

                foreach (CarrinhoDTO ca in carrinhoDTOs)
                {
                    total += ca.Produto.Preco;

                }
                Console.WriteLine("Bonus!! Por ser um funcionário da loja, você ganhou o desconto de 5%!");
                double desconto = total * 0.1;
                double resultado = total - desconto;
                Console.WriteLine($"Total: R$ {total:F2}");
                Console.WriteLine($"Valor final com desconto: R$ {resultado:F2}");
            }
        }
        else if (esc == 3)
        {
            Console.WriteLine("Você selecionou o Boleto como forma de pagamento.");
            if (UsuarioLogado.E_funcionario == true)
            {
                List<CarrinhoDTO> carrinhoDTOs = _carrinhoUC.ListarCarrinhoPorId(UsuarioLogado);
                double total = 0;

                foreach (CarrinhoDTO ca in carrinhoDTOs)
                {
                    total += ca.Produto.Preco;

                }
                Console.WriteLine("Bonus!! Por ser um funcionário da loja, você ganhou o desconto de 5%!");
                double desconto = total * 0.1;
                double resultado = total - desconto;
                Console.WriteLine($"Total: R$ {total:F2}");
                Console.WriteLine($"Valor final com desconto: R$ {resultado:F2}");
            }
        }
    }
    public void VizualizarCarrinho()
    {
        List<CarrinhoDTO> carrinhoDTOs = _carrinhoUC.ListarCarrinhoPorId(UsuarioLogado);

        foreach (CarrinhoDTO carrinhoDTO in carrinhoDTOs)
        {
            Console.WriteLine(carrinhoDTO.ToStringProduto());
        }
        ExibirMenuDoCarrinho();
        int resposta = int.Parse(Console.ReadLine());
        if (resposta == 1)
        {
            Finalizar();
        }
        else if (resposta == 2)
        {
            Console.WriteLine("Qual é o id do produto que você deseja remover?");
            int id = int.Parse(Console.ReadLine());
            _carrinhoUC.DeletarProduto(id);
            Console.WriteLine("Produto excluído com sucesso");
            foreach (CarrinhoDTO carrinhoDTO in carrinhoDTOs)
            {

                Console.WriteLine(carrinhoDTO.ToStringProduto());
            }
        }
        else if (resposta == 3)
        {
            RealizarCompra();
        }
    }


}
