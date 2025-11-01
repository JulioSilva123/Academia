using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace jft.ToDoXamarinForm.ModelsView
{
 

    public class Itens_AtividadeView
    {


        
        public int id_item_atividade { get; set; }

        public AtividadesView Atividades { get; set; }

        public GruposAtividadesView GruposAtividades { get; set; }

        public int nr_ordem_item_atividade { get; set; }

        public string nm_item_atividade { get; set; }

        public string te_descricao { get; set; }

        public DateTime dt_item_atividade { get; set; }

        public bool bo_concluido { get; set; }





    }



}
