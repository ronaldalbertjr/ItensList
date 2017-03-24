using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaEncadeadaDeItens
{
    class Program
    {
        static Itens item1 = new Itens(0, "Leftovers", 1);
        static Itens item2 = new Itens(1, "Potion", 20);
        static Itens item3 = new Itens(2, "Lucky Egg", 3);
        static Itens item4 = new Itens(3, "Moon Stone", 1);
        static Itens item5 = new Itens(4, "Miracle Seed", 7);
        static Itens item6 = new Itens(5, "Quick Claw", 3);
        static Itens item7 = new Itens(6, "Poke Ball", 60);
        static Itens item8 = new Itens(7, "Revive", 10);
        static Itens item9 = new Itens(8, "Amulet Coin", 5);
        static Itens item10 = new Itens(9, "TwistedSpoon", 1);
        static void Main(string[] args)
        {
            item1.next = item2;
            item2.next = item3;
            item3.next = item4;
            item4.next = item5;
            item5.next = item6;
            item6.next = item7;
            item7.next = item8;
            item8.next = item9;
            item9.next = item10;
            while (true)
            {
                Console.WriteLine("Qual item você deseja encontrar na lista?");
                string itemParaEncontrar = Console.ReadLine();
                SearchItens(itemParaEncontrar, item1);
                Console.ReadKey();
                Console.WriteLine("Você deseja continuar? (S/N)");
                string continuar = Console.ReadLine();
                while(continuar != "S" && continuar != "N")
                {
                    Console.WriteLine("Você deseja continuar? (S/N) [ENTRE UMA RESPOSTA VÁLIDA]");
                    continuar = Console.ReadLine();
                }
                if(continuar == "N")
                {
                    break;
                }
                Console.Clear();
            }
        }

        static Itens SearchItens(string nomeDoItem, Itens pointOfStart)
        {
            Itens item = pointOfStart;
            Itens itemAnterior = item;
            while (item != null && item.quantidade > 0)
            {
                if (item.nome == nomeDoItem)
                {
                    item.quantidade--;
                    Console.WriteLine("O item " + item.nome + " foi encontrado na posição " + item.pos + ", você ainda tem " + item.quantidade + " itens desse");
                    if (item.quantidade <= 0)
                    {
                        Console.WriteLine("Acabaram todos os seus " + item.nome + " no inventário");
                        itemAnterior.RemoveNextItem();
                    }
                    return item;
                }
                itemAnterior = item;
                item = item.next;
            }
            Console.WriteLine("O item não foi encontrado");
            return item;
        }
    }

    class Itens
    {
        public int pos;
        public string nome;
        public int quantidade;
        public Itens next;

        public Itens(int Pos, string Nome, int Quantidade)
        {
            pos = Pos;
            nome = Nome;
            quantidade = Quantidade;
        }

        public void RemoveNextItem()
        {
            next = next.next;
        }
    }
}
