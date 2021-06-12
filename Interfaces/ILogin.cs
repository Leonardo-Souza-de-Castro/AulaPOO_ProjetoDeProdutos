using AulaPOO_ProjetoDeProdutos.Classes;

namespace AulaPOO_ProjetoDeProdutos.Interfaces
{
    public interface ILogin
    {
        void Logar();
        void Deslogar(Usuario usuario);
    }
}