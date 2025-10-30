using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace jft.ToDoXamarinForm.Models
{
    public class itens_atividade
    {
        [PrimaryKey, AutoIncrement]
        public int id_item_atividade { get; set; }
        public int id_atividade { get; set; }

        public int id_grupo_atividade { get; set; }

        public int nr_ordem_item_atividade { get; set; }

        public string nm_item_atividade { get; set; }

        public string te_descricao { get; set; }

        public DateTime dt_item_atividade { get; set; }

        
        public bool bo_concluido { get; set; }

    }


    public class Itens_AtividadeView
    {


        
        public int id_item_atividade { get; set; }

        public AtividadesView Atividades { get; set; }

        public int nr_ordem_item_atividade { get; set; }

        public string nm_item_atividade { get; set; }

        public string te_descricao { get; set; }

        public DateTime dt_item_atividade { get; set; }

        public bool bo_concluido { get; set; }

    }



}
