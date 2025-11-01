
using System;
using SQLite;
using System.Collections.Generic;
using System.Text;

namespace jft.ToDoXamarinForm.Models
{
    public class TiposAtividades
    {
        [PrimaryKey, AutoIncrement]
        public int id_tipo_atividade { get; set; }
        public string nm_tipo_atividade { get; set; }

    }

    //public class TiposAtividadesView
    //{
    //    public int id_tipo_atividade { get; set; }
    //    public string nm_tipo_atividade { get; set; }

    //}

}
