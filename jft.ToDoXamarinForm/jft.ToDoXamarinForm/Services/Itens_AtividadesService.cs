using jft.ToDoXamarinForm.Models;
using jft.ToDoXamarinForm.ModelsView;
using jft.ToDoXamarinForm.Utils;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace jft.ToDoXamarinForm.Services
{
    public class Itens_AtividadesViewService :
        BaseService<itens_atividade, Itens_AtividadeView, Itens_AtividadesService, Itens_AtividadesViewService>,
        IDataStoreViewAsync<Itens_AtividadeView>
    {

         

        public Task<Itens_AtividadeView> GetItemViewAsync(int id)
        {
            var _result = DataStore.GetItemAsync(id).ContinueWith(t =>
            {
                var item_atividade = t.Result;

                var dataAtividades = new AtividadesViewService();
                var dataGruposAtividades = new GruposAtividadesService();
                var _atividade = dataAtividades.GetItemViewAsync(item_atividade.id_atividade).Result;

                var _grupoatividade = dataGruposAtividades.GetItemAsync(item_atividade.id_grupo_atividade);



                var _view = new Itens_AtividadeView
                {
                    id_item_atividade = item_atividade.id_item_atividade,
                    nr_ordem_item_atividade = item_atividade.nr_ordem_item_atividade,
                    nm_item_atividade = item_atividade.nm_item_atividade,
                    te_descricao = item_atividade.te_descricao,
                    dt_item_atividade = item_atividade.dt_item_atividade,
                    bo_concluido = item_atividade.bo_concluido,
                    Atividades = _atividade != null ? _atividade : null,
                    GruposAtividades = _grupoatividade.Result != null 
                    ? 
                    new GruposAtividadesView
                        {
                            id_grupo_atividade = _grupoatividade.Result.id_grupo_atividade,
                            nm_grupo_atividade = _grupoatividade.Result.nm_grupo_atividade
                        }
                        : _atividade.GruposAtividades != null ? 
                            new GruposAtividadesView
                            {
                                id_grupo_atividade = _atividade.GruposAtividades.id_grupo_atividade,
                                nm_grupo_atividade = _atividade.GruposAtividades.nm_grupo_atividade
                            }
                        : null
                };
                return _view;
            });
                
            

            return _result;

        }

        public Task<List<Itens_AtividadeView>> GetItemsViewAsync(bool forceRefresh = false)
        {
            var _result = DataStore.GetItemsAsync().ContinueWith(t =>
            {
            var itens_atividades = t.Result;
            var listItensAtividadesView = new List<Itens_AtividadeView>();
            var dataAtividades = new AtividadesViewService();
            var dataGruposAtividades = new GruposAtividadesService();
            foreach (var item_atividade in itens_atividades)
            {
                var _atividade = dataAtividades.GetItemViewAsync(item_atividade.id_atividade).Result;
                var _grupoatividade = dataGruposAtividades.GetItemAsync(item_atividade.id_grupo_atividade);


                var _view = new Itens_AtividadeView
                {
                    id_item_atividade = item_atividade.id_item_atividade,
                    nr_ordem_item_atividade = item_atividade.nr_ordem_item_atividade,
                    nm_item_atividade = item_atividade.nm_item_atividade,
                    te_descricao = item_atividade.te_descricao,
                    dt_item_atividade = item_atividade.dt_item_atividade,
                    bo_concluido = item_atividade.bo_concluido,
                    Atividades = _atividade != null ? _atividade : null,
                    GruposAtividades = _grupoatividade.Result != null ? new GruposAtividadesView
                        {
                            id_grupo_atividade = _grupoatividade.Result.id_grupo_atividade,
                            nm_grupo_atividade = _grupoatividade.Result.nm_grupo_atividade
                        } 
                        : _atividade.GruposAtividades != null ? new GruposAtividadesView
                            {
                                id_grupo_atividade = _atividade.GruposAtividades.id_grupo_atividade,
                                nm_grupo_atividade = _atividade.GruposAtividades.nm_grupo_atividade
                            } 
                            :  null
                    };
                    listItensAtividadesView.Add(_view);
                }
                return listItensAtividadesView;
            });


            return _result;

        }

        public Task<IEnumerable<Itens_AtividadeView>> GetItemsAsyncViewEnumerable(bool forceRefresh = false)
        {

            var _result = this.GetItemsViewAsync(forceRefresh);

            return Task.FromResult<IEnumerable<Itens_AtividadeView>>(_result as IEnumerable<Itens_AtividadeView>);


        }

        public Task<bool> DeleteItemViewAsync(string id)
        {
            var _item = DataStore.GetItemAsync(int.Parse(id)).Result;
            return DataStore.DeleteItemAsync(_item);
        }

        public async Task<bool> SaveItemViewAsync(Itens_AtividadeView item)
        {


            itens_atividade _item = new itens_atividade();

            if (item.id_item_atividade != 0)
            {
                _item = await DataStore.GetItemAsync(item.id_item_atividade);
            }
            _item.id_item_atividade = item.id_item_atividade;
            _item.nr_ordem_item_atividade = item.nr_ordem_item_atividade;
            _item.nm_item_atividade = item.nm_item_atividade;
            _item.te_descricao = item.te_descricao;
            _item.dt_item_atividade = item.dt_item_atividade;
            _item.bo_concluido = item.bo_concluido;
            _item.id_atividade = item.Atividades != null ? item.Atividades.id_atividade : 0;
            _item.id_grupo_atividade = item.GruposAtividades != null ? item.GruposAtividades.id_grupo_atividade : 0;


            return await DataStore.SaveItemAsync(_item);
        }

        public override void OnIniciar()
        {
            throw new NotImplementedException();
        }
    }







    public class Itens_AtividadesService :
        BaseService<itens_atividade, Itens_AtividadeView, Itens_AtividadesService, Itens_AtividadesViewService>, 
        IDataStoreAsync<itens_atividade>
    {


        public Itens_AtividadesService()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }

        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<Itens_AtividadesService> Instance = new AsyncLazy<Itens_AtividadesService>(async () =>
        {
            var instance = new Itens_AtividadesService();
            CreateTableResult result = await Database.CreateTableAsync<itens_atividade>();
            return instance;
        });






        public Task<bool> AddItemAsync(itens_atividade item)
        {
            Database.InsertAsync(item);

            return Task.FromResult(true);

        }

        public Task<bool> DeleteItemAsync(itens_atividade item)
        {
            Database.DeleteAsync(item);
            return Task.FromResult(true);
        }

        public Task<itens_atividade> GetItemAsync(int id)
        {
            return Database.Table<itens_atividade>().Where(i => i.id_item_atividade == id).FirstOrDefaultAsync();
        }

        public Task<List<itens_atividade>> GetItemsAsync(bool forceRefresh = false)
        {
            return Database.Table<itens_atividade>().ToListAsync();
        }

        public async Task<IEnumerable<itens_atividade>> GetItemsAsyncEnumerable(bool forceRefresh = false)
        {
            return await Database.Table<itens_atividade>().ToListAsync();
        }

        public Task<bool> SaveItemAsync(itens_atividade item)
        {
            if (item.id_item_atividade != 0)
            {
                return this.UpdateItemAsync(item);
            }
            else
            {
                return this.AddItemAsync(item);
            }
        }

        public Task<bool> UpdateItemAsync(itens_atividade item)
        {
            Database.UpdateAsync(item);
            return Task.FromResult(true);
        }

        public Task<bool> DeleteItemViewAsync(string id)
        {
            var _itens_atividade = DataStore.GetItemAsync(int.Parse(id)).Result;
            return this.DeleteItemAsync(_itens_atividade);
        }

        public async Task<bool> SaveItemViewAsync(Itens_AtividadeView item)
        {
            
            
            itens_atividade _itens_atividade = new itens_atividade();


            if (item.id_item_atividade != 0)
            {
                _itens_atividade = await DataStore.GetItemAsync(item.id_item_atividade);
            }

            _itens_atividade.id_item_atividade = item.id_item_atividade;
            _itens_atividade.nr_ordem_item_atividade = item.nr_ordem_item_atividade;
            _itens_atividade.nm_item_atividade = item.nm_item_atividade;
            _itens_atividade.te_descricao = item.te_descricao;
            _itens_atividade.dt_item_atividade = item.dt_item_atividade;
            _itens_atividade.bo_concluido = item.bo_concluido;
            _itens_atividade.id_atividade = item.Atividades != null ? item.Atividades.id_atividade : 0;
            _itens_atividade.id_grupo_atividade = item.GruposAtividades != null ? item.GruposAtividades.id_grupo_atividade : 0;


            if (item.id_item_atividade != 0)
            {
                return await this.UpdateItemAsync(_itens_atividade);
            }
            else
            {
                return await this.AddItemAsync(_itens_atividade);
            }

        }






        public override void OnIniciar()
        {
            throw new NotImplementedException();
        }
    }
}
