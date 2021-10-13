using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

namespace SorteioVagas
{
    class Program
    {
        public static List<Vaga> Vagas;
        public static List<Apartamento> Apto;
        private static Random random = new Random();
        static void Main(string[] args)
        {
            //Adicionando dados
            AddData();
            AddApto();
            //Sorteando vagas presas para inadimplentes
            foreach (var apto in Apto.Where(x => !x.Adimplente))
            {
                var vagasPresas = Vagas.Where(x => x.VagaPresa).ToArray();
                int index = random.Next(vagasPresas.Length);
                vagasPresas[index].ApSorteado = apto.Id;
                Console.WriteLine(vagasPresas[index].ApAtual);
                Console.WriteLine(vagasPresas[index].ApSorteado);
            }
            //Sorteando restante das vagas
            //primeiro para os que estão com vaga presa hoje, vão para vaga solta
            //restante aleatoriamente
            var list = Vagas
                .OrderByDescending(x => x.VagaPresa)
                .ToList();
            foreach (var v in list)
            {
                if(Vagas.Any(x=>x.ApSorteado == v.ApAtual))
                    continue;
                var query = Vagas.Where(x => x.ApSorteado == null);
                if (v.VagaPresa && Vagas.Any(x => x.VagaSolta && x.ApSorteado == null))
                    query = query.Where(x => x.VagaSolta);
                else if (v.VagaPresa)
                    query = query.Where(x => !x.VagaPresa);
                var vagas = query.ToList();
                int index = random.Next(vagas.Count);
                vagas[index].ApSorteado = v.ApAtual;
            }
            Console.WriteLine($"{"Apto",6}{"Vaga Atual",20}{"Presa",8}{"Vaga Sorteada",20}{"Presa",8}");
            //foreach (var v in Vagas.OrderBy(x=>x.ApSorteado.PadLeft(3,'0')))
            //{
            //    Console.WriteLine($"{v.ApSorteado}\t\t{v.Id}\t\t{v.VagaPresa}\t\t{v.ApAtual}");
            //}

            foreach (var v in Vagas.OrderBy(x => x.ApAtual.PadLeft(3, '0')))
            {
                Console.WriteLine($"{v.ApAtual,6}{v.Id,20}{v.VagaPresa,8}{Vagas.FirstOrDefault(x => x.ApSorteado == v.ApAtual)?.Id,20}{Vagas.FirstOrDefault(x => x.ApSorteado == v.ApAtual)?.VagaPresa,8}");
            }

            foreach (var v in Vagas.OrderBy(x => x.ApAtual.PadLeft(3, '0')))
            {
                Console.WriteLine($"{v.ApAtual},{v.Id},{v.VagaPresa},{Vagas.FirstOrDefault(x => x.ApSorteado == v.ApAtual)?.Id},{Vagas.FirstOrDefault(x => x.ApSorteado == v.ApAtual)?.VagaPresa}");
            }
        }

        public static void AddApto()
        {
            Apto = new List<Apartamento>();
            Apto.Add(new Apartamento { Id = "11", Adimplente = false });
            Apto.Add(new Apartamento { Id = "12", Adimplente = true });
            Apto.Add(new Apartamento { Id = "13", Adimplente = true });
            Apto.Add(new Apartamento { Id = "14", Adimplente = true });
            Apto.Add(new Apartamento { Id = "21", Adimplente = true });
            Apto.Add(new Apartamento { Id = "22", Adimplente = true });
            Apto.Add(new Apartamento { Id = "23", Adimplente = true });
            Apto.Add(new Apartamento { Id = "24", Adimplente = true });
            Apto.Add(new Apartamento { Id = "31", Adimplente = true });
            Apto.Add(new Apartamento { Id = "32", Adimplente = true });
            Apto.Add(new Apartamento { Id = "33", Adimplente = true });
            Apto.Add(new Apartamento { Id = "34", Adimplente = true });
            Apto.Add(new Apartamento { Id = "41", Adimplente = true });
            Apto.Add(new Apartamento { Id = "42", Adimplente = true });
            Apto.Add(new Apartamento { Id = "43", Adimplente = true });
            Apto.Add(new Apartamento { Id = "44", Adimplente = true });
            Apto.Add(new Apartamento { Id = "51", Adimplente = true });
            Apto.Add(new Apartamento { Id = "52", Adimplente = true });
            Apto.Add(new Apartamento { Id = "53", Adimplente = true });
            Apto.Add(new Apartamento { Id = "54", Adimplente = true });
            Apto.Add(new Apartamento { Id = "61", Adimplente = true });
            Apto.Add(new Apartamento { Id = "62", Adimplente = true });
            Apto.Add(new Apartamento { Id = "63", Adimplente = true });
            Apto.Add(new Apartamento { Id = "64", Adimplente = true });
            Apto.Add(new Apartamento { Id = "71", Adimplente = true });
            Apto.Add(new Apartamento { Id = "72", Adimplente = true });
            Apto.Add(new Apartamento { Id = "73", Adimplente = true });
            Apto.Add(new Apartamento { Id = "74", Adimplente = true });
            Apto.Add(new Apartamento { Id = "81", Adimplente = true });
            Apto.Add(new Apartamento { Id = "82", Adimplente = true });
            Apto.Add(new Apartamento { Id = "83", Adimplente = true });
            Apto.Add(new Apartamento { Id = "84", Adimplente = true });
            Apto.Add(new Apartamento { Id = "91", Adimplente = true });
            Apto.Add(new Apartamento { Id = "92", Adimplente = true });
            Apto.Add(new Apartamento { Id = "93", Adimplente = true });
            Apto.Add(new Apartamento { Id = "94", Adimplente = true });
            Apto.Add(new Apartamento { Id = "101", Adimplente = true });
            Apto.Add(new Apartamento { Id = "102", Adimplente = true });
            Apto.Add(new Apartamento { Id = "103", Adimplente = true });
            Apto.Add(new Apartamento { Id = "104", Adimplente = true });
            Apto.Add(new Apartamento { Id = "111", Adimplente = true });
            Apto.Add(new Apartamento { Id = "112", Adimplente = true });
            Apto.Add(new Apartamento { Id = "113", Adimplente = true });
            Apto.Add(new Apartamento { Id = "114", Adimplente = true });
            Apto.Add(new Apartamento { Id = "121", Adimplente = true });
            Apto.Add(new Apartamento { Id = "122", Adimplente = true });
            Apto.Add(new Apartamento { Id = "123", Adimplente = true });
            Apto.Add(new Apartamento { Id = "124", Adimplente = true });
            Apto.Add(new Apartamento { Id = "131", Adimplente = true });
            Apto.Add(new Apartamento { Id = "132", Adimplente = true });
            Apto.Add(new Apartamento { Id = "133", Adimplente = true });
            Apto.Add(new Apartamento { Id = "134", Adimplente = true });
            Apto.Add(new Apartamento { Id = "141", Adimplente = true });
            Apto.Add(new Apartamento { Id = "142", Adimplente = true });
            Apto.Add(new Apartamento { Id = "143", Adimplente = true });
            Apto.Add(new Apartamento { Id = "144", Adimplente = true });
            Apto.Add(new Apartamento { Id = "151", Adimplente = true });
            Apto.Add(new Apartamento { Id = "152", Adimplente = true });
            Apto.Add(new Apartamento { Id = "153", Adimplente = true });
            Apto.Add(new Apartamento { Id = "154", Adimplente = true });
            Apto.Add(new Apartamento { Id = "161", Adimplente = true });
            Apto.Add(new Apartamento { Id = "162", Adimplente = true });
            Apto.Add(new Apartamento { Id = "163", Adimplente = true });
            Apto.Add(new Apartamento { Id = "164", Adimplente = true });
            Apto.Add(new Apartamento { Id = "171", Adimplente = true });
            Apto.Add(new Apartamento { Id = "172", Adimplente = true });
            Apto.Add(new Apartamento { Id = "173", Adimplente = true });
            Apto.Add(new Apartamento { Id = "174", Adimplente = true });
        }
        public static void AddData()
        {
            Vagas = new List<Vaga>();
            Vagas.Add(new Vaga { Id = "01", Descricao = "", VagaPresa = false, VagaSolta = true, ApAtual = "" });
            Vagas.Add(new Vaga { Id = "02", Descricao = "", VagaPresa = false, VagaSolta = true, ApAtual = "161" });
            Vagas.Add(new Vaga { Id = "03", Descricao = "", VagaPresa = false, VagaSolta = true, ApAtual = "32" });
            Vagas.Add(new Vaga { Id = "04", Descricao = "", VagaPresa = false, ApAtual = "104" });
            Vagas.Add(new Vaga { Id = "05", Descricao = "", VagaPresa = true, ApAtual = "84" });
            Vagas.Add(new Vaga { Id = "06", Descricao = "", VagaPresa = false, ApAtual = "121" });
            Vagas.Add(new Vaga { Id = "07", Descricao = "", VagaPresa = true, ApAtual = "101" });
            Vagas.Add(new Vaga { Id = "08", Descricao = "", VagaPresa = false, ApAtual = "31" });
            Vagas.Add(new Vaga { Id = "09", Descricao = "", VagaPresa = true, ApAtual = "111" });
            Vagas.Add(new Vaga { Id = "10", Descricao = "", VagaPresa = false, VagaSolta = true, ApAtual = "43" });
            Vagas.Add(new Vaga { Id = "11", Descricao = "", VagaPresa = false, VagaSolta = true, ApAtual = "103" });
            Vagas.Add(new Vaga { Id = "12", Descricao = "", VagaPresa = false, VagaSolta = true, ApAtual = "34" });
            Vagas.Add(new Vaga { Id = "13", Descricao = "", VagaPresa = false, ApAtual = "133" });
            Vagas.Add(new Vaga { Id = "14", Descricao = "", VagaPresa = true, ApAtual = "83" });
            Vagas.Add(new Vaga { Id = "15", Descricao = "", VagaPresa = false, ApAtual = "124" });
            Vagas.Add(new Vaga { Id = "16", Descricao = "", VagaPresa = true, ApAtual = "132" });
            Vagas.Add(new Vaga { Id = "17", Descricao = "", VagaPresa = false, ApAtual = "12" });
            Vagas.Add(new Vaga { Id = "18", Descricao = "", VagaPresa = true, ApAtual = "113" });
            Vagas.Add(new Vaga { Id = "19", Descricao = "", VagaPresa = false, ApAtual = "151" });
            Vagas.Add(new Vaga { Id = "20", Descricao = "", VagaPresa = true, ApAtual = "23" });
            Vagas.Add(new Vaga { Id = "21", Descricao = "", VagaPresa = false, ApAtual = "44" });
            Vagas.Add(new Vaga { Id = "22", Descricao = "", VagaPresa = true, ApAtual = "131" });
            Vagas.Add(new Vaga { Id = "23", Descricao = "", VagaPresa = false, VagaSolta = true, ApAtual = "51" });
            Vagas.Add(new Vaga { Id = "24", Descricao = "", VagaPresa = false, VagaSolta = true, ApAtual = "143" });
            Vagas.Add(new Vaga { Id = "25", Descricao = "", VagaPresa = false, VagaSolta = true, ApAtual = "164" });
            Vagas.Add(new Vaga { Id = "26", Descricao = "", VagaPresa = false, VagaSolta = true, ApAtual = "14" });
            Vagas.Add(new Vaga { Id = "27", Descricao = "", VagaPresa = false, VagaSolta = true, ApAtual = "82" });
            Vagas.Add(new Vaga { Id = "28", Descricao = "", VagaPresa = false, VagaSolta = true, ApAtual = "144" });
            Vagas.Add(new Vaga { Id = "29", Descricao = "", VagaPresa = false, VagaSolta = true, ApAtual = "54" });
            Vagas.Add(new Vaga { Id = "30", Descricao = "", VagaPresa = false, VagaSolta = true, ApAtual = "152" });
            Vagas.Add(new Vaga { Id = "31", Descricao = "", VagaPresa = true, ApAtual = "71" });
            Vagas.Add(new Vaga { Id = "32", Descricao = "", VagaPresa = false, VagaSolta = true, ApAtual = "62" });
            Vagas.Add(new Vaga { Id = "33", Descricao = "", VagaPresa = false, VagaSolta = true, ApAtual = "122" });
            Vagas.Add(new Vaga { Id = "34", Descricao = "", VagaPresa = false, VagaSolta = true, ApAtual = "93" });
            Vagas.Add(new Vaga { Id = "35", Descricao = "", VagaPresa = false, VagaSolta = true, ApAtual = "162" });
            Vagas.Add(new Vaga { Id = "36", Descricao = "", VagaPresa = false, VagaSolta = true, ApAtual = "174" });
            Vagas.Add(new Vaga { Id = "37", Descricao = "", VagaPresa = false, VagaSolta = true, ApAtual = "91" });
            Vagas.Add(new Vaga { Id = "38", Descricao = "", VagaPresa = false, VagaSolta = true, ApAtual = "72" });
            Vagas.Add(new Vaga { Id = "39", Descricao = "", VagaPresa = false, VagaSolta = true, ApAtual = "24" });
            Vagas.Add(new Vaga { Id = "40", Descricao = "", VagaPresa = false, VagaSolta = true, ApAtual = "102" });
            Vagas.Add(new Vaga { Id = "41", Descricao = "", VagaPresa = false, ApAtual = "21" });
            Vagas.Add(new Vaga { Id = "42", Descricao = "", VagaPresa = true, ApAtual = "142" });
            Vagas.Add(new Vaga { Id = "43", Descricao = "", VagaPresa = false, ApAtual = "13" });
            Vagas.Add(new Vaga { Id = "44", Descricao = "", VagaPresa = true, ApAtual = "22" });
            Vagas.Add(new Vaga { Id = "45", Descricao = "", VagaPresa = false, ApAtual = "81" });
            Vagas.Add(new Vaga { Id = "46", Descricao = "", VagaPresa = true, ApAtual = "63" });
            Vagas.Add(new Vaga { Id = "47", Descricao = "", VagaPresa = false, ApAtual = "41" });
            Vagas.Add(new Vaga { Id = "48", Descricao = "", VagaPresa = true, ApAtual = "112" });
            Vagas.Add(new Vaga { Id = "49", Descricao = "", VagaPresa = false, ApAtual = "141" });
            Vagas.Add(new Vaga { Id = "50", Descricao = "", VagaPresa = true, ApAtual = "61" });
            Vagas.Add(new Vaga { Id = "51", Descricao = "", VagaPresa = false, ApAtual = "172" });
            Vagas.Add(new Vaga { Id = "52", Descricao = "", VagaPresa = true, ApAtual = "11" });
            Vagas.Add(new Vaga { Id = "53", Descricao = "", VagaPresa = false, ApAtual = "52" });
            Vagas.Add(new Vaga { Id = "54", Descricao = "", VagaPresa = true, ApAtual = "53" });
            Vagas.Add(new Vaga { Id = "55", Descricao = "", VagaPresa = false, ApAtual = "154" });
            Vagas.Add(new Vaga { Id = "56", Descricao = "", VagaPresa = true, ApAtual = "173" });
            Vagas.Add(new Vaga { Id = "57", Descricao = "", VagaPresa = false, ApAtual = "33" });
            Vagas.Add(new Vaga { Id = "58", Descricao = "", VagaPresa = true, ApAtual = "42" });
            Vagas.Add(new Vaga { Id = "59", Descricao = "", VagaPresa = false, VagaSolta = true, ApAtual = "153" });
            Vagas.Add(new Vaga { Id = "60", Descricao = "", VagaPresa = false, VagaSolta = true, ApAtual = "92" });
            Vagas.Add(new Vaga { Id = "61", Descricao = "", VagaPresa = false, VagaSolta = true, ApAtual = "134" });
            Vagas.Add(new Vaga { Id = "62", Descricao = "", VagaPresa = false, VagaSolta = true, ApAtual = "94" });
            Vagas.Add(new Vaga { Id = "63", Descricao = "", VagaPresa = false, VagaSolta = true, ApAtual = "114" });
            Vagas.Add(new Vaga { Id = "02-Terreo", Descricao = "", VagaPresa = false, ApAtual = "163" });
            Vagas.Add(new Vaga { Id = "03-Terreo", Descricao = "", VagaPresa = false, ApAtual = "171" });
            Vagas.Add(new Vaga { Id = "04-Terreo", Descricao = "", VagaPresa = false, ApAtual = "74" });
            Vagas.Add(new Vaga { Id = "05-Terreo", Descricao = "", VagaPresa = false, ApAtual = "123" });
        }
    }
}
