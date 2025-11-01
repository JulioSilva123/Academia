using System;
using SQLite;
using System.Collections.Generic;
using System.Text;

namespace jft.ToDoXamarinForm.Models
{
    public class GruposAtividades
    {
        [PrimaryKey, AutoIncrement]
        public int id_grupo_atividade { get; set; }
        public string nm_grupo_atividade { get; set; }
    }


    //public class GruposAtividadesView
    //{
    //    public int id_grupo_atividade { get; set; }
    //    public string nm_grupo_atividade { get; set; }
    //}


}
