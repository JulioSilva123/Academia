using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace jft.ToDoXamarinForm.Models
{
    public class PlanosAtividades
    {


        [PrimaryKey, AutoIncrement]
        public int id_plano_atividade { get; set; }

        public int id_atividade { get; set; }

        public int id_item_atividade { get; set; }

        public int id_tipo_atividade { get; set; }

        public int id_grupo_atividade { get; set; }




        public int nr_ordem  { get; set; }

        public string nm_plano_atividade { get; set; }

        public string te_descricao  { get; set; }


    }


    //public class PlanosAtividadesView
    //{


        
    //    public int id_plano_atividade { get; set; }

    //    public int id_atividade { get; set; }

    //    public int id_item_atividade { get; set; }

    //    public int id_tipo_atividade { get; set; }

    //    public int id_grupo_atividade { get; set; }




    //    public int nr_ordem { get; set; }

    //    public string nm_plano_atividade { get; set; }

    //    public string te_descricao { get; set; }


    //}

}
