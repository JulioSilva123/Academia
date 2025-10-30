using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace jft.ToDoXamarinForm.Models
{
    public class Atividades
    {


        [PrimaryKey, AutoIncrement]
        public int id_atividade { get; set; }

        public int id_tipo_atividade { get; set; }

        public int id_grupo_atividade { get; set; }

        public int nr_ordem_atividade { get; set; }

        public string nm_atividade { get; set; }


        public string te_descricao { get; set; }


    }


    public class AtividadesView
    {
        
        public int id_atividade { get; set; }

        public TiposAtividadesView TiposAtividades { get; set; }

        public GruposAtividadesView GruposAtividades  { get; set; }

        public int nr_ordem_atividade { get; set; }

        public string nm_atividade { get; set; }

        public string te_descricao { get; set; }


    }

}
