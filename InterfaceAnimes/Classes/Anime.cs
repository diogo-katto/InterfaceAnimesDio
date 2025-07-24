using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterfaceAnimes.Classes
{
    public class Anime : EntidadeBase
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int AnoLancamento { get; set; }
        public string Genero { get; set; }
        public bool Assistido { get; set; }
        public bool Excluido { get; set; }

        

        public Anime(int id, string titulo, string descricao, int anoLancamento, string genero, bool assistido)
        {
            this.Id = id;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.AnoLancamento = anoLancamento;
            this.Genero = genero;
            this.Assistido = assistido;
            this.Excluido = false;
        }
        public override string ToString()
        {
            return "Genêro :" + this.Genero + Environment.NewLine
            + "Título :" + this.Titulo + Environment.NewLine
            + "Descrição :" + this.Descricao + Environment.NewLine
            + "Ano de Lançamento :" + this.AnoLancamento + Environment.NewLine
            + "Assistido :" + (this.Assistido ? "Sim" : "Não") + Environment.NewLine
            + "Excluído :" + (this.Excluido ? "Sim" : "Não");
        }
        public void Excluir()
        {
            this.Excluido = true;
        }
        public bool retornaExcluido()
        {
            return this.Excluido;
        }
        public int RetornarId()
        {
            return this.Id;
        }
        public string RetornarTitulo()
        {
            return this.Titulo;
        }  
    
        
    }
}