using AulaPOO_ProjetoDeProdutos.Classes;

namespace AulaPOO_ProjetoDeProdutos.Interfaces
{
    public interface ILogin
    {
        void Logar(Usuario usuario);
        void Deslogar(Usuario usuario);
    }
}