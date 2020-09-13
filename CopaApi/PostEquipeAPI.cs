using CopaApi.Domain.Entities.DTOs;
using CopaApi.Domain.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CopaApi
{
    public class PostEquipeAPI : IServicePostEquipe
    {
        public async Task<List<EquipeDTo>> PostCopaAsync(List<EquipeDTo> equipes)
        {
            try
            {
                ValidarEntrou(equipes);

                var equipesOrdenada = equipes.OrderBy(x => x.nome).ToList();
                var ListSemiFinal = new List<EquipeDTo>();
                var ListFinal = new List<EquipeDTo>();

                for (int i = 0; i < 4; i++)
                {
                    var equipe1 = equipesOrdenada.FirstOrDefault();
                    var equipe2 = equipesOrdenada.LastOrDefault();

                    if (equipe1.gols >= equipe2.gols)
                        ListSemiFinal.Add(equipe1);
                    else if (equipe1.gols < equipe2.gols)
                        ListSemiFinal.Add(equipe2);

                    equipesOrdenada.Remove(equipe1);
                    equipesOrdenada.Remove(equipe2);
                }

                for (int i = 0; i < 2; i++)
                {
                    var equipe1 = ListSemiFinal.FirstOrDefault();
                    var equipe2 = ListSemiFinal.LastOrDefault();

                    if (equipe1.gols >= equipe2.gols)
                        ListFinal.Add(equipe1);
                    else if (equipe1.gols < equipe2.gols)
                        ListFinal.Add(equipe2);

                    ListSemiFinal.Remove(equipe1);
                    ListSemiFinal.Remove(equipe2);
                }

                return ListFinal.OrderByDescending(x => x.gols).ThenByDescending(x => x.nome).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ValidarEntrou(List<EquipeDTo> equipes)
        {
            if (equipes == null)
                throw new Exception("Não há equipes cadastradas!");

        }

    }
}
