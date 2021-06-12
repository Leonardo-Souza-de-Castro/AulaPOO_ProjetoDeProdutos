using AulaPOO_ProjetoDeProdutos.Interfaces;
using System;
using System.Collections.Generic;

namespace AulaPOO_ProjetoDeProdutos.Classes
{
    public class Produto : IProduto
    {
        public int CodigoProduto { get; set; }
        public string NomeProduto { get; set; }
        public DateTime DataCadastroP { get; set; }
        public float Preco { get; set; }
        public Marca marca { get; set; }
        public Usuario user7 { get; set; }

        public List<Produto> ListaProdutos = new List<Produto>();

        public Produto()
        {

        }
        public Produto(string _nome, float _preco, Marca mar, Usuario us)
        {
            this.NomeProduto = _nome;
            this.DataCadastroP = DateTime.Now;
            this.Preco = _preco;
            this.marca = mar;
            Random cod = new Random();
            this.CodigoProduto = cod.Next(0, 9999);
            this.user7 = us;
        }
        public string Cadastrar(Produto produto)
        {
            ListaProdutos.Add(produto);
            return "Produto cadastrado com sucesso!";
        }

        public void Listar()
        {
            foreach (Produto item in ListaProdutos)
            {
                Console.WriteLine($@" 
                ============================================
                |Nome: {item.NomeProduto}
                ============================================
                |Código: {item.CodigoProduto}
                ============================================
                |Data de cadastro: {item.DataCadastroP}
                ============================================
                |Marca: {item.marca.NomeMarca}
                ============================================
                |Preço: {item.Preco:C2}
                ============================================
                |Usuário: {item.user7}
                ============================================");

                Console.WriteLine("\n");
            }
        }

        public string Deletar(Produto produto)
        {
            ListaProdutos.Remove(produto);
            return "Produto removido com sucesso!";
        }
    }
}