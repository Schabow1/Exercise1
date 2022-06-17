using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise1
{
    public class SC_58029_WystepujacyZnak
    {
        public int SC_58029_Ilosc { get; set; }
        public string SC_58029_Znak { get; set; }
        public string SC_58029_BinaryCode { get; set; }
    }

    public class SC_58029_DrzewoHuffmana
    {
        public int SC_58029_BinaryCode { get; set; }
        public string SC_58029_Znak { get; set; }
        public string SC_58029_Node { get; set; }
        public int SC_58029_Ilosc { get; set; }

    }
    public class SC_58029_HuffmanSourceDictionary
    {
        public string SC_58029_SingleChar { get; set; }
        public string SC_58029_BinaryCode { get; set; }
    }
    class Program
    {
        static string sc_58029_SourceMenu;
        static void Main(string[] args)
        {

            Console.WriteLine("Program kompresujący.\nAby wprowadzić własny ciąg znaków wciśnij na klawiaturze 1, natomiast aby wybrać gotowy ciąg wciśnij 2.");
            string sc_58029_Wybor;
            string sc_58029_Source;
            sc_58029_Wybor = Console.ReadLine();
            if (sc_58029_Wybor == "1")
            {
                Console.Clear();
                Console.WriteLine("Podaj ciąg znaków do kompresji:");
                sc_58029_SourceMenu = Console.ReadLine();

            }
            if (sc_58029_Wybor == "2")
            {
                Console.Clear();
                Console.WriteLine("Gotowy ciąg znaków:\nXADJSOSDAOUAZADXSXODJAOUAOADAOXAAJSAXADOAOADO");
                sc_58029_SourceMenu = "XADJSOSDAOUAZADXSXODJAOUAOADAOXAAJSAXADOAOADO";

            }
            sc_58029_Source = sc_58029_SourceMenu;
            List<string> sc_58029_Kompresja = new List<string>();
            List<SC_58029_WystepujacyZnak> sc_58029_ListaZnakow = new List<SC_58029_WystepujacyZnak>();

            SC_58029_KompresjaHuffmana(sc_58029_Source, ref sc_58029_Kompresja, ref sc_58029_ListaZnakow);

            Console.WriteLine("{0} \t {1} \t {2}\n", "ZNAK", "ILE", "POSTAĆ BINRARNA");
            sc_58029_ListaZnakow.ForEach(sc_58029_x => Console.WriteLine("{0} \t {1} \t {2}", sc_58029_x.SC_58029_Znak, sc_58029_x.SC_58029_Ilosc, sc_58029_x.SC_58029_BinaryCode));
            Console.WriteLine();
            sc_58029_Kompresja.ForEach(sc_58029_x => Console.Write("{0} ", sc_58029_x));
            Console.Write(" EOF\n");

            List<SC_58029_HuffmanSourceDictionary> sc_58029_SourceDictionary = new List<SC_58029_HuffmanSourceDictionary>();
            sc_58029_ListaZnakow.ForEach(sc_58029_x => sc_58029_SourceDictionary.Add(new SC_58029_HuffmanSourceDictionary()
            { SC_58029_BinaryCode = sc_58029_x.SC_58029_BinaryCode, SC_58029_SingleChar = sc_58029_x.SC_58029_Znak }));

            string sc_58029_CiagSkompresowany = string.Empty;
            foreach (var sc_58029_Item in sc_58029_Kompresja)
                sc_58029_CiagSkompresowany += sc_58029_Item;

            List<string> sc_58029_Dekompresja = new List<string>();
            bool sc_58029_Koniec = true;

            SC_58029_DekompresjaHuffmana(sc_58029_SourceDictionary, sc_58029_CiagSkompresowany, ref sc_58029_Dekompresja, ref sc_58029_Koniec);
            Console.WriteLine("Wynik dekompresji:");
            sc_58029_Dekompresja.ForEach(sc_58029_x => Console.Write("{0}", sc_58029_x));

            Console.ReadKey();


        }

        public static void SC_58029_KompresjaHuffmana(string sc_58029_Source, ref List<string> sc_58029_ResultCode, ref List<SC_58029_WystepujacyZnak> sc_58029_ListaZnakow)
        {
            string sc_58029_pozostaly = sc_58029_Source;
            string sc_58029_roboczy = sc_58029_pozostaly;
            string sc_58029_kolejnyZnak = "";
            int sc_58029_IndexListy = 0;

            List<SC_58029_DrzewoHuffmana> sc_58029_DrzewoHuffmana = new List<SC_58029_DrzewoHuffmana>();
            List<SC_58029_WystepujacyZnak> sc_58029_TymczasowaListaZnakow = new List<SC_58029_WystepujacyZnak>();
            List<SC_58029_DrzewoHuffmana> sc_58029_TymczasoweDrzewoHuffmana = new List<SC_58029_DrzewoHuffmana>();

            do
            {
                sc_58029_roboczy = sc_58029_pozostaly;
                sc_58029_kolejnyZnak = sc_58029_roboczy.Substring(0, 1);
                sc_58029_IndexListy = sc_58029_TymczasowaListaZnakow.FindIndex(f => f.SC_58029_Znak == sc_58029_kolejnyZnak);

                if (sc_58029_IndexListy == -1)
                {
                    SC_58029_WystepujacyZnak sc_58029_NowyZnak = new SC_58029_WystepujacyZnak();
                    sc_58029_NowyZnak.SC_58029_Ilosc = 1;
                    sc_58029_NowyZnak.SC_58029_Znak = sc_58029_kolejnyZnak;
                    sc_58029_TymczasowaListaZnakow.Add(sc_58029_NowyZnak);
                }
                else
                {
                    sc_58029_TymczasowaListaZnakow.Where(sc_58029_w => sc_58029_w.SC_58029_Znak == sc_58029_kolejnyZnak).ToList().ForEach(sc_58029_s => sc_58029_s.SC_58029_Ilosc = sc_58029_s.SC_58029_Ilosc + 1);
                }
                sc_58029_pozostaly = sc_58029_roboczy.Remove(0, 1);

            }
            while (sc_58029_pozostaly.Length != 0);
            sc_58029_ListaZnakow = sc_58029_TymczasowaListaZnakow.OrderBy(sc_58029_o => sc_58029_o.SC_58029_Ilosc).ToList();
            List<SC_58029_WystepujacyZnak> sc_58029_PosortowanaListaZnaków = new List<SC_58029_WystepujacyZnak>(sc_58029_ListaZnakow);
            int sc_58029_NrKorzenia = 0;
            int sc_58029_NowyKorzenWartosc = 0;
            string sc_58029_NowyKorzen = "node";

            do
            {
                if (sc_58029_PosortowanaListaZnaków.Count > 1)
                {
                    if (sc_58029_DrzewoHuffmana.Count > 0)
                    {
                        if (sc_58029_DrzewoHuffmana[0].SC_58029_Ilosc + sc_58029_PosortowanaListaZnaków[0].SC_58029_Ilosc > sc_58029_PosortowanaListaZnaków[0].SC_58029_Ilosc + sc_58029_PosortowanaListaZnaków[1].SC_58029_Ilosc)
                            sc_58029_NowyKorzenWartosc = sc_58029_DrzewoHuffmana[0].SC_58029_Ilosc + sc_58029_PosortowanaListaZnaków[0].SC_58029_Ilosc;
                        else
                            sc_58029_NowyKorzenWartosc = sc_58029_PosortowanaListaZnaków[0].SC_58029_Ilosc + sc_58029_PosortowanaListaZnaków[1].SC_58029_Ilosc;
                    }
                    else
                        if (sc_58029_DrzewoHuffmana.Count == 0)
                        sc_58029_NowyKorzenWartosc = sc_58029_PosortowanaListaZnaków[0].SC_58029_Ilosc + sc_58029_PosortowanaListaZnaków[0].SC_58029_Ilosc;
                    if (sc_58029_PosortowanaListaZnaków.Count > 2)
                    {
                        if (sc_58029_NowyKorzenWartosc >= sc_58029_PosortowanaListaZnaków[2].SC_58029_Ilosc && sc_58029_PosortowanaListaZnaków.Count >= 3)
                            sc_58029_NrKorzenia++;
                    }
                    else
                        sc_58029_NrKorzenia++;
                    SC_58029_WystepujacyZnak sc_58029_NowyZnak = new SC_58029_WystepujacyZnak
                    {
                        SC_58029_Ilosc = sc_58029_NowyKorzenWartosc,
                        SC_58029_Znak = sc_58029_NowyKorzen + sc_58029_NrKorzenia
                    };
                    sc_58029_PosortowanaListaZnaków.Add(sc_58029_NowyZnak);
                    for (int i = 0; i <= 1; i++)
                    {
                        SC_58029_DrzewoHuffmana sc_58029_DrzewoHuffmanaItem = new SC_58029_DrzewoHuffmana();
                        if (sc_58029_PosortowanaListaZnaków.Count > 1)
                            sc_58029_DrzewoHuffmanaItem.SC_58029_BinaryCode = i;
                        else
                            sc_58029_DrzewoHuffmanaItem.SC_58029_BinaryCode = 2;
                        sc_58029_DrzewoHuffmanaItem.SC_58029_Znak = sc_58029_PosortowanaListaZnaków[i].SC_58029_Znak;
                        sc_58029_DrzewoHuffmanaItem.SC_58029_Node = sc_58029_NowyKorzen + sc_58029_NrKorzenia.ToString();
                        sc_58029_DrzewoHuffmanaItem.SC_58029_Ilosc = sc_58029_PosortowanaListaZnaków[i].SC_58029_Ilosc;
                        sc_58029_DrzewoHuffmana.Add(sc_58029_DrzewoHuffmanaItem);
                    }
                    sc_58029_PosortowanaListaZnaków.RemoveRange(0, 2);
                    sc_58029_TymczasowaListaZnakow = sc_58029_PosortowanaListaZnaków.OrderBy(o => o.SC_58029_Ilosc).ToList();
                    sc_58029_TymczasoweDrzewoHuffmana = sc_58029_DrzewoHuffmana.OrderByDescending(o => o.SC_58029_Ilosc).ToList();
                    sc_58029_DrzewoHuffmana = sc_58029_TymczasoweDrzewoHuffmana;
                    sc_58029_PosortowanaListaZnaków = sc_58029_TymczasowaListaZnakow;
                }
                else
                {
                    SC_58029_DrzewoHuffmana sc_58029_DrzewoHuffmanaItem = new SC_58029_DrzewoHuffmana
                    {
                        SC_58029_BinaryCode = 2,
                        SC_58029_Znak = sc_58029_NowyKorzen + (sc_58029_NrKorzenia + 1).ToString(),
                        SC_58029_Node = "TOP"
                    };
                    sc_58029_DrzewoHuffmana.Add(sc_58029_DrzewoHuffmanaItem);
                    sc_58029_PosortowanaListaZnaków.Clear();
                }
            }
            while (sc_58029_PosortowanaListaZnaków.Count != 0);
            sc_58029_TymczasoweDrzewoHuffmana = sc_58029_DrzewoHuffmana.OrderBy(o => o.SC_58029_Ilosc).ToList();
            sc_58029_DrzewoHuffmana = sc_58029_TymczasoweDrzewoHuffmana;
            string sc_58029_TempBinaryCode = "";
            string sc_58029_ActualNode = "";

            for (int sc_58029_i = 0; sc_58029_i < sc_58029_DrzewoHuffmana.Count - 1; sc_58029_i++)
            {
                if (sc_58029_DrzewoHuffmana[sc_58029_i].SC_58029_Ilosc == sc_58029_DrzewoHuffmana[sc_58029_i + 1].SC_58029_Ilosc && sc_58029_DrzewoHuffmana[sc_58029_i + 1].SC_58029_Znak.Length > 1)
                {
                    SC_58029_DrzewoHuffmana sc_58029_Tymczasowy = new SC_58029_DrzewoHuffmana();
                    sc_58029_Tymczasowy = sc_58029_DrzewoHuffmana[sc_58029_i];
                    sc_58029_DrzewoHuffmana[sc_58029_i] = sc_58029_DrzewoHuffmana[sc_58029_i + 1];
                    sc_58029_DrzewoHuffmana[sc_58029_i + 1] = sc_58029_Tymczasowy;
                    sc_58029_DrzewoHuffmana[sc_58029_i].SC_58029_BinaryCode = 0;
                    sc_58029_DrzewoHuffmana[sc_58029_i + 1].SC_58029_BinaryCode = 1;
                }
            }
            for (int sc_58029_i = 0; sc_58029_i < sc_58029_ListaZnakow.Count; sc_58029_i++)
            {
                sc_58029_kolejnyZnak = sc_58029_ListaZnakow[sc_58029_i].SC_58029_Znak;
                sc_58029_IndexListy = sc_58029_DrzewoHuffmana.FindIndex(sc_58029_f => sc_58029_f.SC_58029_Znak == sc_58029_kolejnyZnak);
                sc_58029_ActualNode = sc_58029_DrzewoHuffmana[sc_58029_IndexListy].SC_58029_Node;
                sc_58029_TempBinaryCode = sc_58029_DrzewoHuffmana[sc_58029_IndexListy].SC_58029_BinaryCode.ToString();

                do
                {
                    sc_58029_IndexListy = sc_58029_DrzewoHuffmana.FindIndex(sc_58029_f => sc_58029_f.SC_58029_Znak == sc_58029_ActualNode);
                    if (sc_58029_IndexListy != -1)
                    {
                        sc_58029_ActualNode = sc_58029_DrzewoHuffmana[sc_58029_IndexListy].SC_58029_Node;
                        sc_58029_TempBinaryCode = sc_58029_TempBinaryCode + sc_58029_DrzewoHuffmana[sc_58029_IndexListy].SC_58029_BinaryCode.ToString();
                        if (sc_58029_TempBinaryCode.Length > 1 && sc_58029_TempBinaryCode.Substring(0, 1) == "0")
                            sc_58029_TempBinaryCode = sc_58029_TempBinaryCode.Remove(0, 1);
                    }
                }
                while (sc_58029_IndexListy != -1);
                sc_58029_ListaZnakow[sc_58029_i].SC_58029_BinaryCode = sc_58029_TempBinaryCode;

            }

            for (int sc_58029_i = 0; sc_58029_i < sc_58029_Source.Length; sc_58029_i++)
            {
                sc_58029_kolejnyZnak = sc_58029_Source.Substring(sc_58029_i, 1);
                for (int sc_58029_j = 0; sc_58029_j <= sc_58029_ListaZnakow.Count; sc_58029_j++)
                {
                    if (sc_58029_ListaZnakow[sc_58029_j].SC_58029_Znak == sc_58029_kolejnyZnak)
                    {
                        sc_58029_ResultCode.Add(sc_58029_ListaZnakow[sc_58029_j].SC_58029_BinaryCode + ",");
                        sc_58029_j = sc_58029_ListaZnakow.Count;
                    }
                }
            }

        }

        public static void SC_58029_DekompresjaHuffmana(List<SC_58029_HuffmanSourceDictionary> sc_58029_SourceDictionary, string sc_58029_Source, ref List<string> sc_58029_ResultCode, ref bool sc_58029_DictionaryComplete)
        {
            string sc_58029_KolejnyZnak = "";
            int sc_58029_Zawiera = 0;
            try
            {
                do
                {
                    do
                    {
                        if (sc_58029_Source.Length > 0 &&
                            sc_58029_Source.Substring(0, 1) != "0" &&
                            sc_58029_Source.Substring(0, 1) != "1")
                        {
                            sc_58029_Source = sc_58029_Source.Remove(0, 1);
                        }
                    }
                    while (sc_58029_Source.Length > 0 && sc_58029_Source.Substring(0, 1) != "1" && sc_58029_Source.Substring(0, 1) != "0");
                    if (sc_58029_Source.Length > 0)
                    {
                        do
                        {
                            sc_58029_KolejnyZnak = sc_58029_KolejnyZnak + sc_58029_Source.Substring(0, 1);
                            sc_58029_Source = sc_58029_Source.Remove(0, 1);
                        }
                        while (sc_58029_Source.Substring(0, 1) == "0" || sc_58029_Source.Substring(0, 1) == "1");
                        sc_58029_Zawiera = sc_58029_SourceDictionary.FindIndex(sc_58029_f => sc_58029_f.SC_58029_BinaryCode == sc_58029_KolejnyZnak);
                        sc_58029_ResultCode.Add(sc_58029_SourceDictionary[sc_58029_Zawiera].SC_58029_SingleChar);
                        sc_58029_KolejnyZnak = "";
                    }
                    else
                    {
                        sc_58029_DictionaryComplete = true;
                        return;
                    }
                }
                while (sc_58029_Source.Length > 0);
            }
            catch (Exception sc_58029_ex)
            {
                sc_58029_DictionaryComplete = false;
            }
        }

    }
}
