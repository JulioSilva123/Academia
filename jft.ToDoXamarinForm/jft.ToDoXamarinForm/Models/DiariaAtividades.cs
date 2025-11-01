using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace jft.ToDoXamarinForm.Models
{
    public class DiariaAtividades
    {


        [PrimaryKey, AutoIncrement]
        public int id_diaria_atividade { get; set; }

        public int id_atividade { get; set; }

        public int id_item_atividade { get; set; }

        public int id_tipo_atividade { get; set; }

        public int id_grupo_atividade { get; set; }




        public int nr_ordem  { get; set; }

        public string nm_diaria_atividade { get; set; }


        public string te_descricao  { get; set; }


        public DateTime dt_diaria_atividade { get; set; }


        public bool bo_concluido { get; set; }




    }



    //public class DiariaAtividadesView
    //{


        
    //    public int id_diaria_atividade { get; set; }

    //    public int id_atividade { get; set; }

    //    public int id_item_atividade { get; set; }

    //    public int id_tipo_atividade { get; set; }

    //    public int id_grupo_atividade { get; set; }




    //    public int nr_ordem { get; set; }

    //    public string nm_diaria_atividade { get; set; }


    //    public string te_descricao { get; set; }


    //    public DateTime dt_diaria_atividade { get; set; }


    //    public bool bo_concluido { get; set; }




    //}

}
