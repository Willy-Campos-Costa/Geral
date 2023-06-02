﻿using RpgGame.habilidades;
using RpgGame.Interface;
using RpgGame.itens;
using System;

namespace RpgGame.models
{
    public sealed class Guerreiro : PersonagemJogador, ILevelUp
    {
        public Guerreiro(string nome)
        {
            Nome = nome;
            atributo.Hp = 36;
            atributo.MaxHp = 36;
            atributo.Atk = 6;
            atributo.Xp = 0;
            atributo.Nivel = 20;
            inventario = new List<Item> { new EspadaMadeira(), new PocaoCura(), new PocaoCura() };
            habilidades = new List<Habilidade> { new AtaqueBasico(), new CorteRapido() };
        }
        public void LevelUp()
        {
            atributo.Nivel++;
          //RecoverHp();
            atributo.Hp += 4;
            atributo.MaxHp += 4;
            atributo.Atk += 2;
        }

        //Remover \/
        public override string ToString()
        {
            string inventStr = string.Join(", ", inventario.Select(item => item.nome));
            string HabStr = string.Join(", ", habilidades.Select(Hab => Hab.Nome));

            return $"Guerreiro de nome {Nome}\nHP atual: {atributo.Hp}\nATK Atual {atributo.Atk}\nXp: {atributo.Xp}\nNivel: {atributo.Nivel}\nInventario: {inventStr}\nHabilidades: {HabStr}";
        }
    }
}
