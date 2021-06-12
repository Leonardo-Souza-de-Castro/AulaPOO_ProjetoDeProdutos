using AulaPOO_ProjetoDeProdutos.Classes;

namespace AulaPOO_ProjetoDeProdutos.Interfaces
{
    public interface IMarca
    {
        string Cadastrar(Marca marca);
        void Deletar();
    }
}