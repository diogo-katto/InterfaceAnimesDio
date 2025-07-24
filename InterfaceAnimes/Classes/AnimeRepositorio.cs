using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterfaceAnimes.Interfaces;

namespace InterfaceAnimes.Classes
{
    public class AnimeRepositorio: IRepositorio<Anime>
    {
      private List<Anime> listaAnimes = new List<Anime>();
      
        public void Atualiza(int id, Anime objeto)
        {
            listaAnimes[id] = objeto;
        }

        public void Exclui(int id)
        {
            listaAnimes[id].Excluir();
        }

        public void Insere(Anime objeto)
        {
            listaAnimes.Add(objeto);
        }

        public List<Anime> Lista()
        {
            return listaAnimes;
        }

        public int ProximoId()
        {
            return listaAnimes.Count;
        }

        public Anime RetornaPorId(int id)
        {
            return listaAnimes[id];
        }  
    }
}