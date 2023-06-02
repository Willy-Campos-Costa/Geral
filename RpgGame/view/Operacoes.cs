﻿using RpgGame.models;

namespace RpgGame.view
{
    public static class Operacoes
    {
        public static void CriarPersonagem(ref PersonagemJogador personagem)
        {
            Console.Write("Digite o nome do personagem: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Selecione uma classe para o personagem:");
            Console.WriteLine("1 = Guerreiro \n2 = Mago\n3 = Ninja");
            char op = Console.ReadKey().KeyChar;
            switch (op)
            {
                case '1':
                    personagem = new Guerreiro(nome);
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"O guerreiro {nome} despertou no mundo!\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case '2':
                    personagem = new Mago(nome);
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"O Mago {nome} despertou no mundo!\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case '3':
                    personagem = new Ninja(nome);
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"O Ninja {nome} despertou no mundo!\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                default:
                    Console.WriteLine("Invalido");
                    break;
            }
        }
        public static void SubstituirHabilidade(List<Habilidade> list, Habilidade hab)
        {
            Console.WriteLine($"\nNumero maximo de habilidades possuidos\nDeseja substituir alguma das habilidades pela {hab.Nome} ? (S/N)");
            ListarHabilidades(list); //Remover função posteriormente
            char op = Console.ReadKey().KeyChar;
            if (op == 's' || op == 'S')
            {
                Console.WriteLine("\nSelecione a habilidade para substituir: ");
                ListarHabilidades(list); //Remover função posteriormente, Mesma da de cima
                int ope = int.Parse(Console.ReadLine());
                Console.Clear();
                InserirHabilidade(ope, list, hab); //Remover função posteriormente, Função de atribuir a habilidade
            }
            else if (op == 'n' || op == 'N')
            {
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Invalido");
            }
        }
        public static void InserirHabilidade(int op, List<Habilidade> list, Habilidade hab)
        {
            if (op == 1)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Substituido {list[0].Nome} por {hab.Nome}");
                Console.ForegroundColor = ConsoleColor.White;
                list[0] = hab;
            }
            else if (op == 2)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Substituido {list[1].Nome} por {hab.Nome}");
                Console.ForegroundColor = ConsoleColor.White;
                list[1] = hab;
            }
            else if(op == 3)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Substituido {list[2].Nome} por {hab.Nome}");
                Console.ForegroundColor = ConsoleColor.White;
                list[2] = hab;
            }
            else if(op == 4)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Substituido {list[3].Nome} por {hab}");
                Console.ForegroundColor = ConsoleColor.White;
                list[3] = hab;
            }
            else
                Console.WriteLine("Opção invalida");

        }
        public static void ListarHabilidades(List<Habilidade> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{i + 1} -- {list[i].Nome}");
            }
        }
        public static void GerarMonstro()
        {

        }
        public static string GeradorDeNome()
        {
            Random ran = new Random();
            List<string> Prefix = new List<string> { "Necro ", "Sombrio ", "Tenebro ", "Cadavero ", "Profano ", "Sinistro ", "Maldito ", "Amaldiçoado " };
            List<string> tipo = new List<string>() { "desalmado ", "desossado ", "andarilho ", "renegado ", "arrepiante ", "sanguinário ", "medonho ", "macabro " };
            List<string> Sufix = new List<string>() { "das trevas", "do abismo", "destruído", "do Além", "da morte eterna", "da escuridão", "das sombras", "das almas perdidas" };
            string Pref = Prefix[ran.Next(Prefix.Count)];
            string Tip = tipo[ran.Next(tipo.Count)];
            string Suf = Sufix[ran.Next(Sufix.Count)];
            return Pref+Tip+Suf;
        }
        public static int GerarTier()
        {
            int num;
            Random r = new Random();
            num = r.Next(0, 100);
            if(num <= 20)
            {
                return 1;
            }
            else if(num > 20 && num <= 85)
            {
                return 2;
            }
            else { return 3; }
        }
        public static int GerarNivel(int tier, PersonagemJogador p) {
            Random r = new Random();
            int level;
            int minLevel = p.atributo.Nivel - (tier+1);
            int maxLevel = p.atributo.Nivel + (2*tier);

            level = r.Next(minLevel, maxLevel);
            if(level <= 1)
            {
                return 1;
            }
            else
            {
                return level;
            }

        }
        public static int GerarHp(int tier,int nivel, PersonagemJogador p) //Com 2 jogadores, adicionar um If com 1.2 de multiplicador na base final
        {
            Random r = new Random();
            double maxHp;
            int Base = r.Next(20, 40);
            int VidaPNivel = r.Next(1, 3);
            if (tier == 1)
            {
                maxHp = (Base + (nivel * VidaPNivel)*(r.NextDouble() * 0.2 + 0.7));//De 0.7 a 0.9 
            }
            else if (tier == 2)
            {
                maxHp = (Base + (nivel * VidaPNivel) * (r.NextDouble() * 0.4 + 0.8)); //de 0.8 a 1.2
            }
            else
            {
                maxHp = (Base + (nivel * VidaPNivel) * (r.NextDouble() * 0.4 + 1.2)); //de 1.2 a 1.6
            }
            int x = (int)maxHp;
            return x;
        }
        public static void GerarStats(int tier, PersonagemJogador p, List<Habilidade> hab)
        {
            Random r = new Random();
            double Atk;
            if (tier == 1)
            {
                Atk = p.atributo.Atk * (r.NextDouble() * 0.3 + 0.7); //De 0.6 a 0.9
            }
            else if (tier == 2)
            {
                Atk = p.atributo.Atk * (r.NextDouble() * 0.4 + 0.8); //de 0.8 a 1.2
            }
            else
            {
                Atk = p.atributo.Atk * (r.NextDouble() * 0.4 + 1.2); //de 1.2 a 1.6
            }
        }
    } 
}
