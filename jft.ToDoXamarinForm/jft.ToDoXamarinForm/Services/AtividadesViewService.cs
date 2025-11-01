using jft.ToDoXamarinForm.Models;
using jft.ToDoXamarinForm.Utils;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static SQLite.SQLite3;

namespace jft.ToDoXamarinForm.Services
{
    public class AtividadesViewService :
        BaseService<Atividades, AtividadesView, AtividadesService, AtividadesViewService>,
        IDataStoreViewAsync<AtividadesView>

    {


        public AtividadesViewService()
        {
            // Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            //_atividadesService = AtividadesViewService.Instance;
          
        }
        public async override void OnIniciar()
        {
           // _atividadesService = await AtividadesViewService.Instance;
        }

        //public async void OnIniciar()
        //{
        //    _atividadesService = await AtividadesViewService.Instance;
        //}


       // private AtividadesService _atividadesService { get; set; }

         
        public Task<AtividadesView>  GetItemViewAsync(int id)
        {
           

            var _result = DataStore.GetItemAsync(id).ContinueWith(t =>
            {
                var atividade = t.Result;
                if (atividade == null)
                {
                    return null;
                }

                var dataAtividadesbase = new GruposAtividadesService();
                var _grupoatividade = dataAtividadesbase.GetItemAsync(atividade.id_grupo_atividade);
                
                
                var dataTiposAtividades = new TiposAtividadesService();
                var _tipoatividade = dataTiposAtividades.GetItemAsync(atividade.id_tipo_atividade);




                var _view = new AtividadesView
                {
                    id_atividade = atividade.id_atividade,
                    nr_ordem_atividade = atividade.nr_ordem_atividade,
                    nm_atividade = atividade.nm_atividade,
                    te_descricao = atividade.te_descricao,
                    GruposAtividades = _grupoatividade.Result != null ? new GruposAtividadesView
                    {
                        id_grupo_atividade = _grupoatividade.Result.id_grupo_atividade,
                        nm_grupo_atividade = _grupoatividade.Result.nm_grupo_atividade
                    } : null,
                    TiposAtividades = _tipoatividade.Result != null ? new TiposAtividadesView
                    {
                        id_tipo_atividade = _tipoatividade.Result.id_tipo_atividade,
                        nm_tipo_atividade = _tipoatividade.Result.nm_tipo_atividade
                    } : null
                };
                return _view;
            });


            return _result;

        }

          
        public Task<List<AtividadesView>>  GetItemsViewAsync(bool forceRefresh = false)
        {

            var _result = DataStore.GetItemsAsync().ContinueWith(t =>
            {
                var atividades = t.Result;
                var listAtividadesView = new List<AtividadesView>();
                var dataGruposAtividades = new GruposAtividadesService();
                var dataTiposAtividades = new TiposAtividadesService();
                foreach (var atividade in atividades)
                {
                    var _grupoatividade = dataGruposAtividades.GetItemAsync(atividade.id_grupo_atividade);
                    var _tipoatividade = dataTiposAtividades.GetItemAsync(atividade.id_tipo_atividade);
                    var _view = new AtividadesView
                    {
                        id_atividade = atividade.id_atividade,
                        nr_ordem_atividade = atividade.nr_ordem_atividade,
                        nm_atividade = atividade.nm_atividade,
                        te_descricao = atividade.te_descricao,
                        GruposAtividades = _grupoatividade.Result != null ? new GruposAtividadesView
                        {
                            id_grupo_atividade = _grupoatividade.Result.id_grupo_atividade,
                            nm_grupo_atividade = _grupoatividade.Result.nm_grupo_atividade
                        } : null,
                        TiposAtividades = _tipoatividade.Result != null ? new TiposAtividadesView
                        {
                            id_tipo_atividade = _tipoatividade.Result.id_tipo_atividade,
                            nm_tipo_atividade = _tipoatividade.Result.nm_tipo_atividade
                        } : null
                    };
                    listAtividadesView.Add(_view);
                }
                return listAtividadesView;
            });


            return _result;

        }

        public Task<IEnumerable<AtividadesView>>  GetItemsAsyncViewEnumerable(bool forceRefresh)
        {
            
            
            var _result = this.GetItemsViewAsync(forceRefresh);


            //return _result;

            return Task.FromResult<IEnumerable<AtividadesView>>(_result as IEnumerable<AtividadesView>);
        }

        public Task<bool> DeleteItemViewAsync(string id)
        {
            var _atividade = DataStore.GetItemAsync(int.Parse(id)).Result;
            return DataStore.DeleteItemAsync(_atividade);
        }


        public async Task<bool> SaveItemViewAsync(AtividadesView item)
        {

             

            Atividades _atividade = new Atividades();

            if (item.id_atividade != 0)
            {
                _atividade = await DataStore.GetItemAsync(item.id_atividade);
            } 
            _atividade.id_atividade = item.id_atividade;
            _atividade.id_grupo_atividade = item.GruposAtividades != null ? item.GruposAtividades.id_grupo_atividade : 0;
            _atividade.id_tipo_atividade = item.TiposAtividades != null ? item.TiposAtividades.id_tipo_atividade : 0;
            _atividade.nm_atividade = item.nm_atividade;
            _atividade.nr_ordem_atividade = item.nr_ordem_atividade;
            _atividade.te_descricao = item.te_descricao;


            return await DataStore.SaveItemAsync(_atividade);
             

        }

        
    }
}
